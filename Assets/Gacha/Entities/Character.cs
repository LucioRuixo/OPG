using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewCharacter", menuName = "OPG/Character")]
    public class Character : Entity, ITitles, IDescriptions
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

        public override string Name => ProcessName();

        [Header("Info")]

        [SerializeField] private Race race;
        public Race Race => race;

        [SerializeField] private Location origin;
        public Location Origin => origin;

        [SerializeField] private DevilFruit devilFruit;
        public DevilFruit DevilFruit => devilFruit;

        [Space]

        [SerializeField] private string[] titles;
        public string[] Titles => titles;
        public string SelectedTitle => Titles.Length == 0 ? "" : Titles[0];

        [SerializeField] private string[] descriptions;
        public string[] Descriptions => descriptions;
        public string SelectedDescription => Descriptions.Length == 0 ? "" : $"\"{Descriptions[0]}\"";

        private string ProcessName()
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
    }
}