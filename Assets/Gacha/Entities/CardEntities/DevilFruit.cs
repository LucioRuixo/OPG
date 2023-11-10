using UnityEngine;

namespace OPG.Entities
{
    using Cards;

    [CreateAssetMenu(fileName = "NewDevilFruit", menuName = "OPG Entities/Devil Fruit")]
    public class DevilFruit : Entity<VerticalCardData>
    {
        [SerializeField] private string englishName;
        public string EnglishName => englishName;

        [SerializeField] private string model;
        public string Model => model;

        public override string DisplayName => $"{Name} ({EnglishName}){(string.IsNullOrEmpty(Model) ? "" : $", Model: {Model}")}";
        protected override string ListedPrefix => "Devil fruit";

        public override void DisplayFrontInfo(FrontFace frontFace)
        {
            throw new System.NotImplementedException();
        }

        public override void DisplayBackInfo(BackFace backFace)
        {
            throw new System.NotImplementedException();
        }
    }
}