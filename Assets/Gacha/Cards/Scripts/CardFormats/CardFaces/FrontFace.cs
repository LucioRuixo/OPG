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

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}