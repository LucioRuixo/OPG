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
        public sealed override CardTypes CardType => CardTypes.Skin;

        public override Entity GetEntity() => DBItemOperations<Character, Entity>.Get(EntityID);

        public override void DisplayFrontInfo(FrontFace frontFace)
        {
            frontFace.NameField.Text = _Entity.GetFullName();
            frontFace.NameField.CollectionText = Collection.Name;
            frontFace.TitleField.Text = _Entity.SelectedTitle;
            frontFace.DescriptionField.Text = _Entity.SelectedDescription;

            frontFace.ImageViewport.Image.sprite = Image;
        }

        public override void DisplayBackInfo(BackFace backFace)
        {
            string[] infoTexts = GenericEntity.GetInfoTexts();
            for (int i = 0; i < infoTexts.Length; i++) backFace.InfoFields[i].Text = infoTexts[i];
        }
    }
}