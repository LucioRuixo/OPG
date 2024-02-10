using UnityEngine;
using TMPro;

namespace OPG.Cards
{
    /// <summary>
    /// Field displaying the card's name.
    /// </summary>
    public class CardName : CardTextField
    {
        /// <summary>
        /// This card's collection field.
        /// </summary>
        [SerializeField] private TMP_Text collectionTextField;

        /// <summary>
        /// This card's collection content.
        /// </summary>
        public string CollectionText { get; set; }

        protected override void Update()
        {
            base.Update();

            collectionTextField.text = CollectionText;
        }
    }
}