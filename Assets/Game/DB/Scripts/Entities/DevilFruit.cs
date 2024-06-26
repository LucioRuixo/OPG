using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewDevilFruit", menuName = "OPG Entities/Devil Fruit")]
    public class DevilFruit : Entity
    {
        public override string FolderPath => "DevilFruits";

        [SerializeField] private string englishName;
        public string EnglishName => englishName;

        [SerializeField] private string model;
        public string Model => model;

        public override string DisplayName =>
            $"{Name}" +
            $"{(string.IsNullOrEmpty(EnglishName) ? "" : $" ({EnglishName})")}" +
            $"{(string.IsNullOrEmpty(Model) ? "" : $", Model: {Model}")}";

        protected override string ListedPrefix => "Devil fruit";

        public override EntityTypes EntityType => EntityTypes.DevilFruit;

        public override string[] GetInfoTexts()
        {
            throw new System.NotImplementedException();
        }
    }
}