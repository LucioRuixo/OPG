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
        [SerializeField] private EntityViewer entityViewer;

        public void Initialize(ProgressionProfile progressionProfile)
        {
            entityMenu.Initialize(progressionProfile);
            entityViewer.Initialize(progressionProfile);
        }

        public void OpenEntityMenu(int entityTypeIndex)
        {
            EntityTypes entityType = (EntityTypes)entityTypeIndex;
            entityMenu.Open(entityType, entityTypeMenu);
        }
    }
}