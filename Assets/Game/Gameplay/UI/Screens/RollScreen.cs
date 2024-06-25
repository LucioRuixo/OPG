using System.Collections.Generic;
using UnityEngine;

namespace OPG.UI
{
    using Cards;
    using Gacha;

    public class RollScreen : Screen
    {
        #region Constants
        private const float CardDisplayScale = 0.4f;
        #endregion

        [SerializeField] private Transform cardContainer;

        /// <summary>
        /// List of the currently displayed cards.
        /// </summary>
        private List<GameObject> displayedCards = new List<GameObject>();

        private void OnEnable() => Gacha.OnRollEvent += OnRoll;

        private void OnDisable() => Gacha.OnRollEvent -= OnRoll;

        /// <summary>
        /// Instantiate the rolled cards into the screen to be displayed.
        /// </summary>
        private void InstantiateRolledCards(CardDataBase[] rolledCards)
        {
            foreach (GameObject displayedCard in displayedCards) Destroy(displayedCard);
            displayedCards.Clear();

            foreach (CardDataBase rolledCard in rolledCards)
            {
                Card card = Card.InstantiateCard(cardContainer, rolledCard);
                card.transform.localScale = Vector3.one * CardDisplayScale;

                displayedCards.Add(card.gameObject);
            }
        }

        #region Handlers
        private void OnRoll(CardDataBase[] rolledCards) => InstantiateRolledCards(rolledCards);
        #endregion
    }
}