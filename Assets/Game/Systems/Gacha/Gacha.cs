using System;

namespace OPG.Gacha
{
    using Cards;
    using DB;
    using Progression;
    using ProgressionProfiles;

    static public class Gacha
    {
        static public event Action<CardDataBase[]> OnRollEvent;

        static public CardDataBase[] Roll(uint count, ProgressionProfileHandler ppHandler)
        {
            int unlockedCardsCount = ppHandler.UnlockedCardIDs.Count;
            
            if (unlockedCardsCount == 0) return null;

            CardDataBase[] rolledCards = new CardDataBase[count];
            for (int i = 0; i < count; i++)
            {
                int cardIndex = ppHandler.UnlockedCardIDs[UnityEngine.Random.Range(0, unlockedCardsCount)];
                rolledCards[i] = CardDataDB.Get(cardIndex);
            }

            Progression.ProcessRoll(rolledCards, ppHandler);

            OnRollEvent?.Invoke(rolledCards);

            return rolledCards;
        }
    }
}