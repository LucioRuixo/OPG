using UnityEngine;

namespace OPG
{
    using Input;

    public class GameplayManager : MonoBehaviour
    {
        #region Constants
        private const string PlayerName = "Player";

        public const uint BaseRoll = 10;
        #endregion

        [SerializeField] private MainInputContext mainInputContext;

        private Player.Player player;

        private void Awake() => InstantiatePlayer();

        private void InstantiatePlayer()
        {
            player = new GameObject(PlayerName).AddComponent<Player.Player>();
            player.transform.parent = transform;

            player.Initialize(mainInputContext, ProgressionProfiles.ProgressionProfiles.LoadProgressionProfile());
        }
    }
}