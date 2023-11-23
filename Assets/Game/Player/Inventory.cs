using System;
using System.Collections.Generic;

namespace OPG.Player
{
    using UnlockedCards = SortedDictionary<int, Inventory.CardState>;

    [Serializable]
    public class Inventory
    {
        #region Classes
        [Serializable]
        public class CardState
        {
            public uint Copies { get; private set; } = 0;

            public void AddCopy() => Copies++;

            public void AddCopies(int copies) => Copies = (uint)Math.Max(0, Copies + copies);

            public void ClearCopies() => Copies = 0;
        }
        #endregion

        private UnlockedCards unlockedCards = new UnlockedCards();

        public UnlockedCards UnlockedCards => unlockedCards;

        public void Add(int cardCode)
        {
            if (unlockedCards.ContainsKey(cardCode)) unlockedCards[cardCode].AddCopy();
            else unlockedCards.Add(cardCode, new CardState());
        }
    }
}