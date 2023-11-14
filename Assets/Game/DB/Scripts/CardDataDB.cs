using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

using LRCore.Utils;
using LRCore.Utils.Extensions;
using LRCore.Utils.IO;

namespace OPG.Cards
{
    using ArcRanges = SortedDictionary<uint, string>;

    [CreateAssetMenu(fileName = "CardDB", menuName = "OPG/Card DB")]
    public class CardDataDB : ScriptableObject
    {
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

        private readonly string dataBasePath = $"{Paths.projectFolder}/CardDB";

        [SerializeField] private List<SagaData> sagas;

        private string[] cardTypeOrder = new string[]
        {
            "Skins",
            "Ships",
            "Locations",
            "DevilFruits"
        };

        #region Serialization
        public void Serialize()
        {
            ArcRanges arcRanges = new ArcRanges();

            foreach (SagaData saga in sagas) ProcessSaga(saga, ref arcRanges);

            string arcRangesFile = $"ranges{Extension.ValidExts[ExtTypes.JSON].Ext}";
            string arcRangesPath = $"{dataBasePath}/{arcRangesFile}";
            Serializer.Serialize(arcRangesPath, arcRanges);
        }

        private void ProcessSaga(SagaData saga, ref ArcRanges arcRanges)
        {
            foreach (ArcData arc in saga.Arcs) ProcessArc(arc, saga, ref arcRanges);
        }

        private void ProcessArc(ArcData arc, SagaData saga, ref ArcRanges arcRanges)
        {
            string arcPath = $"{Paths.assetsFolder}/Resources/DB/Cards/{saga.ID}/{arc.ID}/";

            if (!Directory.Exists(arcPath)) return;

            string[] arcFolders = Directory.GetDirectories(arcPath, "*", SearchOption.TopDirectoryOnly);

            List<string> arcCards = new List<string>();
            foreach (string cardType in cardTypeOrder) ProcessCardType(cardType, arcFolders, ref arcCards);

            if (arcCards.Count == 0) return;

            string arcCardsFile = $"{saga.ID}_{arc.ID}{Extension.ValidExts[ExtTypes.JSON].Ext}";
            string arcCardsPath = $"{dataBasePath}/{arcCardsFile}";
            Serializer.Serialize(arcCardsPath, arcCards);

            arcRanges.Add((uint)arcCards.Count - 1, arcCardsPath);
        }

        private void ProcessCardType(string cardType, string[] arcFolders, ref List<string> arcCards)
        {
            string folderPath = arcFolders.FirstOrDefault((folder) => folder.EndsWith($"/{cardType}"));
            if (string.IsNullOrEmpty(folderPath)) return;

            string[] assetPaths = Directory.GetFiles(folderPath, "*", SearchOption.TopDirectoryOnly).
                Where((path) => Path.GetExtension(path) == ".asset").ToArray();

            if (folderPath.EndsWith("/Skins")) foreach (string assetPath in assetPaths) ProcessCollection(assetPath, ref arcCards);
            else foreach (string assetPath in assetPaths) ProcessCard(assetPath, ref arcCards);
        }

        private void ProcessCollection(string collectionAssetPath, ref List<string> arcCards)
        {
            string assetResourcesPath = collectionAssetPath.Replace($"{Paths.assetsFolder}/Resources/", "");
            assetResourcesPath = assetResourcesPath.Replace(".asset", "");

            Collection collection = Resources.Load<Collection>(assetResourcesPath);
            if (!collection) return;

            string collectionFolderPath = collectionAssetPath.Replace(".asset", "");
            if (!Directory.Exists(collectionFolderPath)) return;

            string[] cardAssetPaths = Directory.GetFiles(collectionFolderPath, "*", SearchOption.TopDirectoryOnly).
                Where((path) => Path.GetExtension(path) == ".asset").ToArray();

            foreach (string cardAssetPath in cardAssetPaths) ProcessCard(cardAssetPath, ref arcCards, collection);
        }

        private void ProcessCard(string assetPath, ref List<string> arcCards, Collection collection = null)
        {
            string assetResourcesPath = assetPath.Replace($"{Paths.assetsFolder}/Resources/", "");
            assetResourcesPath = assetResourcesPath.Replace(".asset", "");

            CardDataBase cardData = Resources.Load<CardDataBase>(assetResourcesPath);
            if (cardData)
            {
                if (collection) cardData.Collection = collection;
                arcCards.Add(assetPath);
            }
        }
        #endregion
    }
}