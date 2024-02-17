using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using LRCore.Utils.IO;

namespace OPG.Gacha
{
    using Cards;

    using CardDB = SortedDictionary<int, string>;

    public static class Gacha
    {
        private static CardDB cardDB;
        private static CardDB CardDB
        {
            get
            {
                cardDB ??= Serializer.Deserialize<CardDB>(CardDataDB.cardDBPath);
                return cardDB;
            }
        }

		public static CardDataBase Roll()
        {
            int cardIndex = Random.Range(0, CardDB.Keys.Count);
            string cardAssetPath = CardDB.ElementAt(cardIndex).Value;

            return Resources.Load<CardDataBase>(cardAssetPath);
        }
    }
}