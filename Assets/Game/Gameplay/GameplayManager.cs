using UnityEngine;

namespace OPG.Gameplay
{
    using Input;
    using UI;

    public class GameplayManager : MonoBehaviour
    {
        #region Constants
        private const string PlayerName = "Player";

        public const uint BaseRoll = 5;
        #endregion

        [Header("UI")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private EpisodeLogger episodeLogger;

        [Header("Input")]
        [SerializeField] private MainInputContext mainInputContext;

        private Player player;

        private void Start() => Initialize();

        private void Initialize()
        {
            InstantiatePlayer();

            uiManager.Initialize(player);
        }

        private void InstantiatePlayer()
        {
            player = new GameObject(PlayerName).AddComponent<Player>();
            player.transform.parent = transform;

            player.Initialize(mainInputContext, episodeLogger, ProgressionProfiles.ProgressionProfiles.LoadProgressionProfile());
        }
    }
}