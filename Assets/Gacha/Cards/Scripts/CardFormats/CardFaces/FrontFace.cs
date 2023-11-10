using UnityEngine;

namespace OPG.Cards
{
    public class FrontFace : CardFace
    {
        [SerializeField] private CardName nameField;
        public CardName NameField => nameField;

        [SerializeField] private CardTitle titleField;
        public CardTitle TitleField => titleField;

        [SerializeField] private CardDescription descriptionField;
        public CardDescription DescriptionField => descriptionField;

        [Space]

        [SerializeField] private CardImageViewport imageViewport;
        public CardImageViewport ImageViewport => imageViewport;

        public override void Clear()
        {
            nameField.Text = "";
            titleField.Text = "";
            descriptionField.Text = "";
            imageViewport.Image.sprite = null;
        }
    }
}