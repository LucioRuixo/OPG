using System;
using System.Collections.Generic;
using UnityEngine;

namespace OPG.Cards
{
    [CreateAssetMenu(fileName = "CardDataBase", menuName = "OPG/Card Data Base")]
    public class CardDataDataBase : ScriptableObject
    {
        #region Classes
        [Serializable]
        public class SagaData
        {
            [SerializeField] private string id;
            [SerializeField] private List<ArcData> arcs;
        }

        [Serializable]
        public class ArcData
        {
            [SerializeField] private string id;
            [SerializeField] private List<CollectionData> collections;
        }

        [Serializable]
        public class CollectionData
        {
            [SerializeField] private string path;
            [SerializeField] private List<CardData> cards;
        }

        [Serializable]
        public class CardData
        {
            [SerializeField] private string path;
        }
        #endregion

        [SerializeField] private List<SagaData> sagas;
    }
}