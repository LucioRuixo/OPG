using System.Collections.Generic;
using TMPro;

namespace OPG.UI
{
    using Entities;
    using ProgressionProfiles;
    using Utils.UI;

    public class EntityMenu : Submenu
    {
        private ProgressionProfile progressionProfile;

        public void Initialize(ProgressionProfile progressionProfile) => this.progressionProfile = progressionProfile;

		public void Open(EntityTypes entityType)
        {
            List<Entity> entitiesOfType = progressionProfile.UnlockedEntitiesOfType_List(entityType);
            entitiesOfType.Sort();
            for (int i = 0; i < entitiesOfType.Count; i++)
            {
                TextMeshProUGUI newEntity = Instantiate(UIUtils.GetMenuButtonPrefab(), ButtonContainer).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                newEntity.text = entitiesOfType[i].DisplayName;
            }

            Open();
        }
    }
}