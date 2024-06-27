using UnityEngine;

namespace OPG.UI
{
    using Gameplay;

    public class MainSidebar : Sidebar
    {
        [Space]

        [SerializeField] private GameplayManager gameplayManager;

        [Header("Submenues")]
        [SerializeField] private WikiMenu wikiMenu;

        public void Initialize(Player player) => wikiMenu.Initialize(player.ProgressionProfile);
    }
}