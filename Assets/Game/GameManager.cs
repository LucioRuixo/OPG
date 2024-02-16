using UnityEditor;
using UnityEngine;

namespace OPG
{
    using Input;
    using Progression;

    public class GameManager : MonoBehaviour
    {
        #region Constants
        private const uint ProgressionProfileIndex = 0;
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

            player.Initialize(mainInputContext, LoadProgressionProfile());
        }

        private ProgressionProfile LoadProgressionProfile()
        {
            string profilePath = $"{ProgressionProfile.progressionProfilesFolderPath}/{ProgressionProfile.ProgressionFilePrefix}{ProgressionProfileIndex}";
            return Resources.Load<ProgressionProfile>(profilePath) ?? CreateProgressionProfile($"Assets/Resources/{profilePath}");
        }

        private ProgressionProfile CreateProgressionProfile(string path)
        {
            ProgressionProfile profile = ScriptableObject.CreateInstance<ProgressionProfile>();
            AssetDatabase.CreateAsset(profile, $"{path}.asset");

            return profile;
        }
    }
}