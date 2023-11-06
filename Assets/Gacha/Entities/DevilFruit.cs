using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewDevilFruit", menuName = "OPG/Devil Fruit")]
    public class DevilFruit : Entity
    {
        [SerializeField] private string englishName;
        public string EnglishName => englishName;

        [SerializeField] private string model;
        public string Model => model;
    }
}