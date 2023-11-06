using UnityEngine;

namespace OPG.Cards
{
    using Entities;

    [ExecuteAlways, RequireComponent(typeof(Card))]
    public class CardInfo : MonoBehaviour
    {
        [Header("Front")]
        [SerializeField] new private CardName name;
        [SerializeField] private CardTitle title;
        [SerializeField] private CardDescription description;

        [Header("Back")]
        [SerializeField] private CardTextField race;
        [SerializeField] private CardTextField origin;
        [SerializeField] private CardTextField devilFruit;

        [SerializeField, HideInInspector] private Entity entity;

        private ITitles titles;
        private IDescriptions descriptions;

        private Card card;

        public Card Card
        {
            get
            {
                card ??= GetComponent<Card>();
                return card;
            }
        }

        private void Update()
        {
            if (!entity) return;

            SetFrontInfo();
            SetBackInfo();
        }

        private void SetFrontInfo()
        {
            if (name) name.Text = entity.Name;

            if (title)
            {
                ITitles entityTitles = (ITitles)entity;
                if (entityTitles != null) title.Text = entityTitles.SelectedTitle;
            }

            if (description)
            {
                IDescriptions entityDescriptions = (IDescriptions)entity;
                if (entityDescriptions != null) description.Text = entityDescriptions.SelectedDescription;
            }
        }

        private void SetBackInfo()
        {
            Character character = (Character)entity;
            if (character)
            {
                if (race) race.Text = $"Race: {character.Race.Name}";
                if (origin) origin.Text = $"Origin: {character.Origin.Name}";
                if (devilFruit) devilFruit.Text = $"Devil fruit: {(character.DevilFruit ? character.DevilFruit.Name : "-")}";
            }
        }
    }
}