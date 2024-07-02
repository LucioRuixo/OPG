using System;
using UnityEngine;

namespace OPG.Gacha
{
    using Cards;
    using DB;
    using Progression;
    using ProgressionProfiles;

    public static class Gacha
    {
        public static event Action<CardDataBase[]> OnRollEvent;

        public static CardDataBase[] Roll(uint count, ref ProgressionProfile progressionProfile)
        {
            int unlockedCardsCount = progressionProfile.UnlockedCardIDs.Count;
            
            if (unlockedCardsCount == 0) return null;

            CardDataBase[] rolledCards = new CardDataBase[count];
            for (int i = 0; i < count; i++)
            {
                int cardIndex = progressionProfile.UnlockedCardIDs[UnityEngine.Random.Range(0, unlockedCardsCount)];
                rolledCards[i] = CardDataDB.Get(cardIndex);
            }

            Progression.ProcessRoll(rolledCards, ref progressionProfile);

            OnRollEvent?.Invoke(rolledCards);

            return rolledCards;
        }
    }
}