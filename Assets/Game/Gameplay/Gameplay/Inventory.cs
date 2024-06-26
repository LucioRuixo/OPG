using System;
using System.Collections.Generic;

namespace OPG.Gameplay
{
    using Cards;

    using Cards = Dictionary<Cards.CardDataBase, Inventory.CardState>;

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

        public void Add(CardDataBase[] newCards)
        {
            foreach (CardDataBase card in newCards)
            {
                if (cards.ContainsKey(card)) cards[card].AddCopy();
                else cards.Add(card, new CardState());
            }
        }
    }
}