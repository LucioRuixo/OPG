using System.Collections.Generic;
using UnityEngine;

namespace OPG.UI
{
    using Entities;
    using ProgressionProfiles;
    using Utils.UI;

    public class EntityMenu : Submenu
    {
        [Space]

        [SerializeField] private EntityViewer entityViewer;

        private ProgressionProfileHandler ppHandler;

        private EntityTypes lastEntityType;

        private List<EntityMenuButton> buttons = new List<EntityMenuButton>();

        public void Initialize(ProgressionProfileHandler ppHandler) => this.ppHandler = ppHandler;

		public void Open(EntityTypes entityType, Submenu source)
        {
            lastEntityType = entityType;

            Open(source);
        }

        public override void UpdateContent() => InstantiateButtons();

        private void InstantiateButtons()
        {
            foreach (EntityMenuButton button in buttons) Destroy(button.gameObject);
            buttons.Clear();

            List<Entity> entitiesOfType = ppHandler.UnlockedEntitiesOfType(lastEntityType);
            entitiesOfType.Sort();
            for (int i = 0; i < entitiesOfType.Count; i++)
            {
                Entity entity = entitiesOfType[i];

                EntityMenuButton button = Instantiate(UIUtils.GetMenuButtonPrefab(), ButtonContainer).AddComponent<EntityMenuButton>();
                button.Initialize(entity.DisplayName, entity, entityViewer, this);

                buttons.Add(button);
            }
        }
    }
}