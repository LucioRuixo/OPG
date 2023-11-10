using UnityEngine;

namespace OPG.Entities
{
    using Cards;

    [CreateAssetMenu(fileName = "NewShip", menuName = "OPG Entities/Ship")]
    public class Ship : BORRAR<HorizontalCardData>, ITitles
    {
        [SerializeField] private string[] titles;
        public string[] Titles => titles;
        public string SelectedTitle => Titles.Length == 0 ? "" : Titles[0];

        protected override string ListedPrefix => "Ship";

        //public override void DisplayBackInfo(BackFace backFace)
        //{
        //    // ...
        //}
        //
        //public override void DisplayFrontInfo(FrontFace frontFace)
        //{
        //    frontFace.NameField.Text = Name;
        //    frontFace.TitleField.Text = SelectedTitle;
        //}
    }
}