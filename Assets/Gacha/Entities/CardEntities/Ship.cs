using UnityEngine;

namespace OPG.Entities
{
    using Cards;

    [CreateAssetMenu(fileName = "NewShip", menuName = "OPG Entities/Ship")]
    public class Ship : Entity<HorizontalCardData>, ITitles
    {
        [SerializeField] private string[] titles;
        public string[] Titles => titles;
        public string SelectedTitle => Titles.Length == 0 ? "" : Titles[0];

        public override void DisplayInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}