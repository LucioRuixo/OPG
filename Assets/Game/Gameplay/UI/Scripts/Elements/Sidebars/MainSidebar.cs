using UnityEngine;

namespace OPG.UI
{
    using ProgressionProfiles;

    public class MainSidebar : Sidebar
    {
        [Space]

        [Header("Submenues")]
        [SerializeField] private WikiMenu wikiMenu;

        public void Initialize(ProgressionProfileHandler ppHandler) => wikiMenu.Initialize(ppHandler);
    }
}