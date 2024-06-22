using UnityEngine;

namespace OPG.Cards
{
    using DB;
    using Entities;

    /// <summary>
    /// Skin card asset.
    /// </summary>
    [CreateAssetMenu(fileName = "NewSkinCard", menuName = "OPG Cards/Cards/Skin")]
    public class SkinCard : CardData<Character, VerticalCardData>
    {
        /// <summary>
        /// Image of this card's character portraying the corresponding skin.
        /// </summary>
        [SerializeField] private Sprite image;

        public override Entity GetEntity() => DBItemOperations<Character, Entity>.Get(EntityID);

        public override void DisplayFrontInfo(FrontFace frontFace)
        {
            frontFace.NameField.Text = _Entity.GetFullName();
            frontFace.NameField.CollectionText = Collection.Name;
            frontFace.TitleField.Text = _Entity.SelectedTitle;
            frontFace.DescriptionField.Text = _Entity.SelectedDescription;

            frontFace.ImageViewport.Image.sprite = image;
        }

        public override void DisplayBackInfo(BackFace backFace)
        {
            backFace.InfoFields[0].Text = _Entity.Race.DefaultListedName;
            backFace.InfoFields[1].Text = $"Origin: {_Entity.Origin.Name}";
            backFace.InfoFields[2].Text = _Entity.DevilFruit.DefaultListedName;
        }
    }
}