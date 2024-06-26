using UnityEngine;

namespace OPG.UI
{
    using Entities;
    using ProgressionProfiles;

    public class WikiMenu : Menu
    {
        [Space]

        [SerializeField] private GameObject buttonPrefab;

        [Header("Submenues")]
        [SerializeField] private Submenu entityTypeMenu;
        [SerializeField] private EntityMenu entityMenu;

        private ProgressionProfile progressionProfile;

        public void Initialize(ProgressionProfile progressionProfile) => entityMenu.Initialize(progressionProfile);

        public void OpenEntityMenu(int entityTypeIndex)
        {
            entityTypeMenu.Close();

            EntityTypes entityType = (EntityTypes)entityTypeIndex;
            entityMenu.Open(entityType);
        }

        public void OpenEntity(Entity entity)
        {
            
        }
    }
}