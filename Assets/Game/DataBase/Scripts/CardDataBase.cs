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
    using ArcRanges = Dictionary<uint, string>;

    [CreateAssetMenu(fileName = "CardDataBase", menuName = "OPG/Card Data Base")]
    public class CardDataDataBase : ScriptableObject
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

            [SerializeField] private List<CollectionData> collections;
            public List<CollectionData> Collections => collections;
        }

        [Serializable]
        public class CollectionData
        {
            [SerializeField] private string path;
            public string Path => path;

            [SerializeField] private List<CardData> cards;
            public List<CardData> Cards => cards;
        }

        [Serializable]
        public class CardData
        {
            [SerializeField] private string path;
            public string Path => path;
        }
        #endregion

        private readonly string dataBasePath = $"{Paths.projectFolder}/CardDataBase";

        [SerializeField] private List<SagaData> sagas;

        public void Serialize()
        {
            ArcRanges arcRanges = new ArcRanges();

            foreach (SagaData saga in sagas)
            {
                foreach (ArcData arc in saga.Arcs)
                {
                    string arcResourcesPath = $"{Paths.assetsFolder}/Resources/DataBase/Cards/{saga.ID}/{arc.ID}/";

                    if (!Directory.Exists(arcResourcesPath)) continue;

                    string[] assetPaths = Directory.GetFiles(arcResourcesPath, "*", SearchOption.AllDirectories).
                        Where((path) => Path.GetExtension(path) == ".asset").ToArray();

                    List<string> arcCards = new List<string>();
                    foreach (string assetPath in assetPaths)
                    {
                        string assetResourcesPath = assetPath.Replace($"{Paths.assetsFolder}/Resources/", "");
                        assetResourcesPath = assetResourcesPath.Replace(".asset", "");

                        CardDataBase cardData = Resources.Load<CardDataBase>(assetResourcesPath);
                        if (cardData) arcCards.Add(assetPath);
                    }

                    if (arcCards.Count == 0) continue;

                    string arcCardsFile = $"{saga.ID}_{arc.ID}{Extension.ValidExts[ExtTypes.JSON].Ext}";
                    string arcCardsPath = $"{dataBasePath}/{arcCardsFile}";
                    Serializer.Serialize(arcCardsPath, arcCards);

                    arcRanges.Add((uint)arcCards.Count - 1, arcCardsPath);
                }
            }

            string arcRangesFile = $"ranges{Extension.ValidExts[ExtTypes.JSON].Ext}";
            string arcRangesPath = $"{dataBasePath}/{arcRangesFile}";
            Serializer.Serialize(arcRangesPath, arcRanges);
        }
    }
}