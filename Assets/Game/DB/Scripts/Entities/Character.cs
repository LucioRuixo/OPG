using UnityEngine;

namespace OPG.Entities
{
    using DB;
    using Utils;

    /// <summary>
    /// Character in One Piece's story.
    /// </summary>
    [CreateAssetMenu(fileName = "NewCharacter", menuName = "OPG Entities/Character")]
    public class Character : Entity, ITitles, IDescriptions, IDBItem<Character, Entity>
    {
        #region Enumerators
        /// <summary>
        /// Elements possibly constituting an character's full name.
        /// </summary>
        private enum NameElements
        {
            Name,
            Surname,
            Alias
        }
        #endregion

        public override string FolderPath => "Characters";

        /// <summary>
        /// This character's surname (optional).
        /// </summary>
        [SerializeField] private string surname;
        /// <summary>
        /// This character's alias (optional).
        /// </summary>
        [SerializeField] private string alias;

        /// <summary>
        /// Sorted elements of this character's full name.
        /// </summary>
        [SerializeField]
        private NameElements[] nameOrder = new NameElements[]
        {
            NameElements.Alias,
            NameElements.Surname,
            NameElements.Name
        };

        [Header("Info")]

        /// <summary>
        /// This character's race.
        /// </summary>
        [SerializeField] private Race race;
        /// <summary>
        /// This character's race.
        /// </summary>
        public Race Race => race;

        /// <summary>
        /// This character's place of origin.
        /// </summary>
        [SerializeField] private Location origin;
        /// <summary>
        /// This character's place of origin.
        /// </summary>
        public Location Origin => origin;

        /// <summary>
        /// The devil fruit eaten by this character (if any).
        /// </summary>
        [SerializeField] private DevilFruit devilFruit;
        /// <summary>
        /// The devil fruit eaten by this character (if any).
        /// </summary>
        public DevilFruit DevilFruit => devilFruit;

        [Space]

        /// <summary>
        /// This character's possessed titles.
        /// </summary>
        [SerializeField] private string[] titles;
        /// <summary>
        /// Quotes by this characters.
        /// </summary>
        [SerializeField] private string[] descriptions;

        public override string Name => GetFullName();

        /// <summary>
        /// This character's possessed titles.
        /// </summary>
        public string[] Titles => titles;
        /// <summary>
        /// This character's currently displayed title.
        /// </summary>
        public string SelectedTitle => Titles.Length == 0 ? "" : Titles[0];

        /// <summary>
        /// Quotes by this characters.
        /// </summary>
        public string[] Descriptions => descriptions;
        /// <summary>
        /// This character's currently displayed quote.
        /// </summary>
        public string SelectedDescription => Descriptions.Length == 0 ? "" : $"\"{Descriptions[0]}\"";

        protected override string ListedPrefix => "Character";

        public override EntityTypes EntityType => EntityTypes.Character;

        /// <summary>
        /// Processes this character's full name.
        /// </summary>
        /// <returns>This character's full name.</returns>
        public string GetFullName()
        {
            string fullName = "";

            for (int i = 0; i < nameOrder.Length; i++)
            {
                switch (nameOrder[i])
                {
                    case NameElements.Name:
                        fullName += name;
                        break;

                    case NameElements.Surname:
                        fullName += surname;
                        break;

                    case NameElements.Alias:
                        fullName += $"\"{alias}\"";
                        break;

                    default: break;
                }

                if (i < nameOrder.Length - 1) fullName += " ";
            }

            return fullName;
        }

        public Entity Get(string id) => EntityDB.Get<Character>(id);
    }
}