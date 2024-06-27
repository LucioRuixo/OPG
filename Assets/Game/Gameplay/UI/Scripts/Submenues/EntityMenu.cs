using System.Collections.Generic;
using UnityEngine;

namespace OPG.UI
{
    using Entities;
    using ProgressionProfiles;
    using Utils.UI;

    public class EntityMenu : Submenu
    {
        [SerializeField] private EntityViewer entityViewer;

        private ProgressionProfile progressionProfile;

        public void Initialize(ProgressionProfile progressionProfile) => this.progressionProfile = progressionProfile;

		public void Open(EntityTypes entityType)
        {
            List<Entity> entitiesOfType = progressionProfile.UnlockedEntitiesOfType(entityType);
            entitiesOfType.Sort();
            for (int i = 0; i < entitiesOfType.Count; i++)
            {
                Entity entity = entitiesOfType[i];

                EntityMenuButton button = Instantiate(UIUtils.GetMenuButtonPrefab(), ButtonContainer).AddComponent<EntityMenuButton>();
                button.Initialize(entity.DisplayName, entity, entityViewer);
            }

            Open();
        }
    }
}