using UnityEngine;

namespace OPG
{
    public class GameManager : MonoBehaviour
    {
        #region Constants
        private const string PlayerName = "Player";

        public const uint BaseRoll = 10;
        #endregion

        private Player.Player player;

        private void Awake() => InstantiatePlayer();

        private void InstantiatePlayer()
        {
            player = new GameObject(PlayerName).AddComponent<Player.Player>();
            player.transform.parent = transform;
        }
    }
}