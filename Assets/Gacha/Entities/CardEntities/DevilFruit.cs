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

        public override void DisplayInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}