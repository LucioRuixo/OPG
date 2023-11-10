using UnityEngine;

namespace OPG.Entities
{
    using Cards;

    [CreateAssetMenu(fileName = "NewCharacter", menuName = "OPG Entities/Character")]
    public class Character : Entity<VerticalCardData>, ITitles, IDescriptions
    {
        private enum NameTypes
        {
            Name,
            Surname,
            Alias
        }

        [SerializeField] private string surname;
        [SerializeField] private string alias;

        [SerializeField]
        private NameTypes[] nameOrder = new NameTypes[]
        {
            NameTypes.Alias,
            NameTypes.Surname,
            NameTypes.Name
        };

        [Space]

        [SerializeField] private Sprite image;

        [Header("Info")]

        [SerializeField] private Race race;
        public Race Race => race;

        [SerializeField] private Location origin;
        public Location Origin => origin;

        [SerializeField] private DevilFruit devilFruit;
        public DevilFruit DevilFruit => devilFruit;

        [Space]

        [SerializeField] private string[] titles;
        [SerializeField] private string[] descriptions;

        public override string Name => ProcessFullName();

        public string[] Titles => titles;
        public string SelectedTitle => Titles.Length == 0 ? "" : Titles[0];

        public string[] Descriptions => descriptions;
        public string SelectedDescription => Descriptions.Length == 0 ? "" : $"\"{Descriptions[0]}\"";

        protected override string ListedPrefix => "Character";

        private string ProcessFullName()
        {
            string fullName = "";

            for (int i = 0; i < nameOrder.Length; i++)
            {
                switch (nameOrder[i])
                {
                    case NameTypes.Name:
                        fullName += name;
                        break;

                    case NameTypes.Surname:
                        fullName += surname;
                        break;

                    case NameTypes.Alias:
                        fullName += $"\"{alias}\"";
                        break;

                    default: break;
                }

                if (i < nameOrder.Length - 1) fullName += " ";
            }

            return fullName;
        }

        public override void DisplayFrontInfo(FrontFace frontFace)
        {
            frontFace.NameField.Text = ProcessFullName();
            frontFace.TitleField.Text = SelectedTitle;
            frontFace.DescriptionField.Text = SelectedDescription;
            frontFace.ImageViewport.Image.sprite = image;
        }

        public override void DisplayBackInfo(BackFace backFace)
        {
            backFace.InfoFields[0].Text = Race.DefaultListedName;
            backFace.InfoFields[1].Text = $"Origin: {Origin.Name}";
            backFace.InfoFields[2].Text = DevilFruit.DefaultListedName;
        }
    }
}