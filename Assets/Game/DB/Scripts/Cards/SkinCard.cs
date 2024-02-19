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
            frontFace.NameField.Text = entity.GetFullName();
            frontFace.NameField.CollectionText = Collection.Name;
            frontFace.TitleField.Text = entity.SelectedTitle;
            frontFace.DescriptionField.Text = entity.SelectedDescription;

            frontFace.ImageViewport.Image.sprite = image;
        }

        public override void DisplayBackInfo(BackFace backFace)
        {
            backFace.InfoFields[0].Text = entity.Race.DefaultListedName;
            backFace.InfoFields[1].Text = $"Origin: {entity.Origin.Name}";
            backFace.InfoFields[2].Text = entity.DevilFruit.DefaultListedName;
        }
    }
}