using UnityEngine;

namespace OPG.UI
{
    using Gameplay;

    public class UIManager : MonoBehaviour
    {
        [Header("Menues")]
        [SerializeField] private EpisodeLogger episodeLogger;
        [SerializeField] private MainSidebar sidebar;

        public void Initialize(Player player)
        {
            episodeLogger.Initialize(player.ProgressionProfile);
            sidebar.Initialize(player);
        }
    }
}