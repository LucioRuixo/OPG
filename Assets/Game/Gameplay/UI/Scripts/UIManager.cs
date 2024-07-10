using UnityEngine;

namespace OPG.UI
{
    using ProgressionProfiles;

    public class UIManager : MonoBehaviour
    {
        [Header("Menues")]
        [SerializeField] private EpisodeLogger episodeLogger;
        [SerializeField] private MainSidebar sidebar;

        public void Initialize(ProgressionProfileHandler ppHandler)
        {
            episodeLogger.Initialize(ppHandler);
            sidebar.Initialize(ppHandler);
        }
    }
}