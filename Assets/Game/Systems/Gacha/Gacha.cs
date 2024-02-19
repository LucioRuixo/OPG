using UnityEngine;

namespace OPG.Gacha
{
    using Cards;
    using DB;
    using Progression;
    using ProgressionProfiles;

    public static class Gacha
    {
        #region Constants
        private const string CardDBPath = "DB/CardDB";
        #endregion

        private static CardDataDB cardDataDB;
        private static CardDataDB CardDataDB => cardDataDB ??= Resources.Load<CardDataDB>(CardDBPath);

        public static CardDataBase[] Roll(uint count, ref ProgressionProfile progressionProfile)
        {
            int unlockedCardsCount = progressionProfile.CardUnlocks.Count;
            
            if (unlockedCardsCount == 0) return null;

            CardDataBase[] rolledCards = new CardDataBase[count];
            for (int i = 0; i < count; i++)
            {
                int cardIndex = progressionProfile.CardUnlocks[Random.Range(0, unlockedCardsCount)];
                rolledCards[i] = CardDataDB.Get(cardIndex);
            }

            Progression.ProcessRoll(rolledCards, ref progressionProfile);

            return rolledCards;
        }
    }
}