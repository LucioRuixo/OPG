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

        public void Initialize(ProgressionProfileHandler ppHandler)
        {
            entityMenu.Initialize(ppHandler);
            entityViewer.Initialize(ppHandler);
        }

        public void OpenEntityMenu(int entityTypeIndex)
        {
            EntityTypes entityType = (EntityTypes)entityTypeIndex;
            entityMenu.Open(entityType, entityTypeMenu);
        }
    }
}