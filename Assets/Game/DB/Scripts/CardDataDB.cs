using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

using LRCore.Utils.Extensions;
using LRCore.Utils.IO;

namespace OPG.DB
{
    using Cards;

    using OPGPaths = Utils.Paths;
    using LRPaths = LRCore.Utils.Paths;
    using ArcRanges = SortedDictionary<int, string>;
    using CardDB = SortedDictionary<int, string>;

    [CreateAssetMenu(fileName = "CardDB", menuName = "OPG/Card DB")]
    public class CardDataDB : ScriptableObject
    {
        #region Constants
        private const string CardDBPath = "DB/CardDB";

        private const string SkinsAssetFolderName = "Skins";
        #endregion

        #region Classes
        [Serializable]
        public class SagaData
        {
            [SerializeField] private string id;
            public string ID => id;

            [SerializeField] private List<ArcData> arcs;
            public List<ArcData> Arcs => arcs;
        }

        [Serializable]
        public class ArcData
        {
            [SerializeField] private string id;
            public string ID => id;

            [SerializeField] private int lastEpisode;
            public int LastEpisode => lastEpisode;

            [SerializeField, HideInInspector] private int firstCardID = -1;
            public int FirstCardID { get => firstCardID; private set => firstCardID = value; }

            [SerializeField, HideInInspector] private int lastCardID = -1;
            public int LastCardID { get => lastCardID; private set => lastCardID = value; }

            public void SetCardIDRange(int first, int last)
            {
                FirstCardID = first;
                LastCardID = last;
            }
        }
        #endregion

        static private readonly string dbFolderPath = $"{LRPaths.projectFolder}/CardDB";
        static private readonly string cardAssetsPath = $"{OPGPaths.resourcesFolder}/DB/Cards";

        static private readonly string arcRangesFile = $"ranges{Extension.ValidExts[ExtTypes.JSON].Ext}";
        static private readonly string arcRangesPath = $"{dbFolderPath}/{arcRangesFile}";

        static private readonly string cardDBFile = $"cardDB{Extension.ValidExts[ExtTypes.JSON].Ext}";
        static private readonly string cardDBPath = $"{dbFolderPath}/{cardDBFile}";

        [SerializeField] private string[] cardTypeProcessingOrder;

        [SerializeField] private List<SagaData> sagas;
        public List<SagaData> Sagas { get => sagas; private set => sagas = value; }

        private int arcsRange;

        static private ArcRanges arcRanges;
        static private ArcRanges ArcRanges
        {
            get
            {
                arcRanges ??= Serializer.Deserialize<CardDB>(arcRangesPath);
                return arcRanges;
            }
        }

        static private CardDB cardDB;
        static private CardDB CardDB
        {
            get
            {
                cardDB ??= Serializer.Deserialize<CardDB>(cardDBPath);
                return cardDB;
            }
        }

        static private CardDataDB dbAsset;
        static private CardDataDB DBAsset => dbAsset ??= Resources.Load<CardDataDB>(CardDBPath);

        #region Serialization
        public void Serialize()
        {
            arcsRange = -1;
            ArcRanges arcRanges = new ArcRanges();

            cardDB = new CardDB();

            for (int i = 0; i < Sagas.Count; i++)
            {
                SagaData saga = Sagas[i];
                ProcessSaga(ref saga, ref arcRanges, ref cardDB);
            }

            Serializer.Serialize(arcRangesPath, arcRanges);
            Serializer.Serialize(cardDBPath, cardDB);

            AssetDatabase.SaveAssets();
        }

        private void ProcessSaga(ref SagaData saga, ref ArcRanges arcRanges, ref CardDB cardDB)
        {
            for (int i = 0; i < saga.Arcs.Count; i++)
            {
                ArcData arc = saga.Arcs[i];
                ProcessArc(ref arc, saga, ref arcRanges, ref cardDB);
            }
        }

        private void ProcessArc(ref ArcData arc, SagaData saga, ref ArcRanges arcRanges, ref CardDB cardDB)
        {
            string arcPath = $"{cardAssetsPath}/{saga.ID}/{arc.ID}/";

            if (!Directory.Exists(arcPath))
            {
                arc.SetCardIDRange(-1, -1);
                return;
            }

            string[] arcFolders = Directory.GetDirectories(arcPath, "*", SearchOption.TopDirectoryOnly);

            List<string> arcCards = new List<string>();
            foreach (string cardType in cardTypeProcessingOrder) ProcessCardType(cardType, arcFolders, ref arcCards, ref cardDB);

            if (arcCards.Count == 0)
            {
                arc.SetCardIDRange(-1, -1);
                return;
            }

            string arcCardsFile = $"{saga.ID}_{arc.ID}{Extension.ValidExts[ExtTypes.JSON].Ext}";
            string arcCardsPath = $"{dbFolderPath}/{arcCardsFile}";
            Serializer.Serialize(arcCardsPath, arcCards);

            arcRanges.Add(arcsRange + arcCards.Count, arcCardsPath);
            arc.SetCardIDRange(arcsRange + 1, arcsRange + arcCards.Count);

            arcsRange += arcCards.Count;
        }

        private void ProcessCardType(string cardType, string[] arcFolders, ref List<string> arcCards, ref CardDB cardDB)
        {
            string folderPath = arcFolders.FirstOrDefault((folder) => folder.EndsWith($"/{cardType}"));
            if (string.IsNullOrEmpty(folderPath)) return;

            string[] assetPaths = Directory.GetFiles(folderPath, "*", SearchOption.TopDirectoryOnly).
                Where((path) => Path.GetExtension(path) == ".asset").ToArray();

            if (folderPath.EndsWith($"/{SkinsAssetFolderName}")) foreach (string assetPath in assetPaths) ProcessCollection(assetPath, ref arcCards, ref cardDB);
            else foreach (string assetPath in assetPaths) ProcessCard(assetPath, ref arcCards, ref cardDB);
        }

        private void ProcessCollection(string collectionAssetPath, ref List<string> arcCards, ref CardDB cardDB)
        {
            string assetResourcesPath = collectionAssetPath.Replace($"{OPGPaths.resourcesFolder}/", "");
            assetResourcesPath = assetResourcesPath.Replace(".asset", "");

            Collection collection = Resources.Load<Collection>(assetResourcesPath);
            if (!collection) return;

            string collectionFolderPath = collectionAssetPath.Replace(".asset", "");
            if (!Directory.Exists(collectionFolderPath)) return;

            string[] cardAssetPaths = Directory.GetFiles(collectionFolderPath, "*", SearchOption.TopDirectoryOnly).
                Where((path) => Path.GetExtension(path) == ".asset").ToArray();

            foreach (string cardAssetPath in cardAssetPaths) ProcessCard(cardAssetPath, ref arcCards, ref cardDB, collection);
        }

        private void ProcessCard(string assetPath, ref List<string> arcCards, ref CardDB cardDB, Collection collection = null)
        {
            string assetResourcesPath = assetPath.Replace($"{OPGPaths.resourcesFolder}/", "");
            assetResourcesPath = assetResourcesPath.Replace(".asset", "");

            CardDataBase cardData = Resources.Load<CardDataBase>(assetResourcesPath);
            if (cardData)
            {
                if (collection) cardData.Collection = collection;
                arcCards.Add(assetPath);

                if (!cardDB.ContainsValue(assetResourcesPath))
                {
                    int cardID = cardDB.Count;

                    cardData.ID = cardID;
                    EditorUtility.SetDirty(cardData);

                    cardDB.Add(cardID, assetResourcesPath);
                }
            }
        }
        #endregion

        static public CardDataBase Get(int id) => Resources.Load<CardDataBase>(CardDB.ElementAt(id).Value);

        static public CardDataBase[] GetRange(int firstID, int lastID)
        {
            int[] rangeIDs = CardDB.Keys.Where(id => id >= firstID && id <= lastID).ToArray();

            List<CardDataBase> cards = new List<CardDataBase>();
            foreach (int id in rangeIDs)
            {
                CardDataBase card = Get(id);

                if (!card) continue;

                cards.Add(card);
            }

            return cards.ToArray();
        }

        static public int[] GetIDsByEpisodeRange(int first, int count)
        {
            int last = first + count - 1;

            List<int> ids = new List<int>();

            int baseFirstIndex = -1, baseLastIndex = -1;
            bool firstFound = false, lastFound = false;

            foreach (SagaData saga in DBAsset.Sagas)
            {
                foreach (ArcData arc in saga.Arcs)
                {
                    if (arc.LastEpisode <= 0 || arc.FirstCardID <= -1 || arc.LastCardID <= -1) continue;

                    // Is the first episode in the target range within this arc's episodes?
                    if (!firstFound && first <= arc.LastEpisode)
                    {
                        // Then start the preliminary card indeces with this arc's IDs
                        baseFirstIndex = arc.FirstCardID;
                        firstFound = true;
                    }

                    // Is the last episode in the target range within this arc's episodes?
                    if (firstFound)
                    {
                        // Then end the preliminary card indeces on this arc's IDs
                        baseLastIndex = arc.LastCardID;

                        if (last <= arc.LastEpisode) lastFound = true;
                    }

                    if (firstFound && lastFound) break;
                }

                if (firstFound && lastFound) break;
            }

            CardDataBase[] baseCards = GetRange(baseFirstIndex, baseLastIndex);
            int[] rangeIDs = baseCards.Where(card => card.UnlockEpisode >= first && card.UnlockEpisode <= last).Select(card => card.ID).ToArray();

            return rangeIDs;
        }
    }
}