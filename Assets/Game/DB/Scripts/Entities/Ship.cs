using UnityEngine;

namespace OPG.Entities
{
    using Utils;

    [CreateAssetMenu(fileName = "NewShip", menuName = "OPG Entities/Ship")]
    public class Ship : Entity, ITitles
    {
        public override string FolderPath => "Ships";

        [SerializeField] private string[] titles;
        public string[] Titles => titles;
        public string SelectedTitle => Titles.Length == 0 ? "" : Titles[0];

        protected override string ListedPrefix => "Ship";
    }
}