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
    using ArcRanges = SortedDictionary<uint, string>;
    using CardDB = SortedDictionary<int, string>;

    [CreateAssetMenu(fileName = "CardDB", menuName = "OPG/Card DB")]
    public class CardDataDB : ScriptableObject
    {
        #region Constants
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
        }
        #endregion

        private static readonly string dbFolderPath = $"{LRPaths.projectFolder}/CardDB";
        private static readonly string cardAssetsPath = $"{OPGPaths.resourcesFolder}/DB/Cards";

        private static readonly string arcRangesFile = $"ranges{Extension.ValidExts[ExtTypes.JSON].Ext}";
        private static readonly string arcRangesPath = $"{dbFolderPath}/{arcRangesFile}";

        private static readonly string cardDBFile = $"cardDB{Extension.ValidExts[ExtTypes.JSON].Ext}";
        private static readonly string cardDBPath = $"{dbFolderPath}/{cardDBFile}";

        [SerializeField] private string[] cardTypeProcessingOrder;

        [SerializeField] private List<SagaData> sagas;

        private CardDB cardDB;
        private CardDB CardDB
        {
            get
            {
                cardDB ??= Serializer.Deserialize<CardDB>(cardDBPath);
                return cardDB;
            }
        }

        #region Serialization
        public void Serialize()
        {
            ArcRanges arcRanges = new ArcRanges();
            cardDB = new CardDB();

            foreach (SagaData saga in sagas) ProcessSaga(saga, ref arcRanges, ref cardDB);

            Serializer.Serialize(arcRangesPath, arcRanges);
            Serializer.Serialize(cardDBPath, cardDB);

            AssetDatabase.SaveAssets();
        }

        private void ProcessSaga(SagaData saga, ref ArcRanges arcRanges, ref CardDB cardDB)
        {
            foreach (ArcData arc in saga.Arcs) ProcessArc(arc, saga, ref arcRanges, ref cardDB);
        }

        private void ProcessArc(ArcData arc, SagaData saga, ref ArcRanges arcRanges, ref CardDB cardDB)
        {
            string arcPath = $"{cardAssetsPath}/{saga.ID}/{arc.ID}/";

            if (!Directory.Exists(arcPath)) return;

            string[] arcFolders = Directory.GetDirectories(arcPath, "*", SearchOption.TopDirectoryOnly);

            List<string> arcCards = new List<string>();
            foreach (string cardType in cardTypeProcessingOrder) ProcessCardType(cardType, arcFolders, ref arcCards, ref cardDB);

            if (arcCards.Count == 0) return;

            string arcCardsFile = $"{saga.ID}_{arc.ID}{Extension.ValidExts[ExtTypes.JSON].Ext}";
            string arcCardsPath = $"{dbFolderPath}/{arcCardsFile}";
            Serializer.Serialize(arcCardsPath, arcCards);

            arcRanges.Add((uint)arcCards.Count - 1, arcCardsPath);
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

        public CardDataBase Get(int id) => Resources.Load<CardDataBase>(CardDB.ElementAt(id).Value);
    }
}