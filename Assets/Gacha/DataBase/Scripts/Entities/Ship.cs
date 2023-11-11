using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewShip", menuName = "OPG Entities/Ship")]
    public class Ship : Entity, ITitles
    {
        [SerializeField] private string[] titles;
        public string[] Titles => titles;
        public string SelectedTitle => Titles.Length == 0 ? "" : Titles[0];

        protected override string ListedPrefix => "Ship";
    }
}