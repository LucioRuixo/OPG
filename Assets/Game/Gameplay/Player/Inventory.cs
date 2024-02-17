using System;
using System.Collections.Generic;

namespace OPG.Player
{
    using Cards = SortedDictionary<int, Inventory.CardState>;

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

        private Cards cards = new Cards();

        public Cards Cards => cards;

        public void Add(int cardCode)
        {
            if (cards.ContainsKey(cardCode)) cards[cardCode].AddCopy();
            else cards.Add(cardCode, new CardState());
        }
    }
}