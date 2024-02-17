using UnityEngine;

namespace OPG.Gacha
{
    using Cards;
    using DB;
    using ProgressionProfiles;

    public static class Gacha
    {
		public static CardDataBase[] Roll(uint count, ref ProgressionProfile progressionProfile)
        {
            CardDataBase[] rolledCards = new CardDataBase[count];

            for (int i = 0; i < count; i++)
            {
                int unlockedCardsCount = progressionProfile.CardUnlocks.Count;
                int cardIndex = progressionProfile.CardUnlocks[Random.Range(0, unlockedCardsCount)];
                rolledCards[i] = CardDataDB.Get(cardIndex);
            }

            return rolledCards;
        }
    }
}