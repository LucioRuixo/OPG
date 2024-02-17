using UnityEngine;

namespace OPG.Cards
{
    public class FrontFace : CardFace
    {
        /// <summary>
        /// This card's name field.
        /// </summary>
        [SerializeField] private CardName nameField;
        /// <summary>
        /// This card's name field.
        /// </summary>
        public CardName NameField => nameField;

        /// <summary>
        /// This card's title field.
        /// </summary>
        [SerializeField] private CardTitle titleField;
        /// <summary>
        /// This card's title field.
        /// </summary>
        public CardTitle TitleField => titleField;

        /// <summary>
        /// This card's description field.
        /// </summary>
        [SerializeField] private CardDescription descriptionField;
        /// <summary>
        /// This card's description field.
        /// </summary>
        public CardDescription DescriptionField => descriptionField;

        [Space]

        /// <summary>
        /// Viewport containing this card's image.
        /// </summary>
        [SerializeField] private CardImageViewport imageViewport;
        /// <summary>
        /// Viewport containing this card's image.
        /// </summary>
        public CardImageViewport ImageViewport => imageViewport;

        public override void Clear()
        {
            nameField.Text =
            nameField.CollectionText =
            titleField.Text =
            descriptionField.Text = "";

            imageViewport.Image.sprite = null;
        }
    }
}