using UnityEngine;

namespace OPG.Gameplay
{
    using Cards;
    using Gacha;
    using Input;
    using ProgressionProfiles;
    using UI;

    public class Player : MonoBehaviour
    {
        [SerializeField] private MainInputContext inputContext;
        [SerializeField] private EpisodeLogger episodeLogger;
        [SerializeField] private ProgressionProfile progressionProfile;

        public ProgressionProfile ProgressionProfile => progressionProfile;
        public Inventory Inventory { get; private set; } = new Inventory();

        #region Initialization
        public void Initialize(MainInputContext inputContext, EpisodeLogger episodeLogger, ProgressionProfile progressionProfile)
        {
            this.inputContext = inputContext;
            this.episodeLogger = episodeLogger;
            this.progressionProfile = progressionProfile;

            progressionProfile.ResetRolledCards(); // Debug

            SubscribeToInputActions();
        }

        private void SubscribeToInputActions()
        {
            inputContext.SubscribeToAction(MainInputContext.Actions.Roll, Roll);
            inputContext.SubscribeToAction(MainInputContext.Actions.LogEpisodes, LogEpisodes);
        }
        #endregion

        private void AddToInventory(CardDataBase[] cards) => Inventory.Add(cards);

        public void Roll() => AddToInventory(Gacha.Roll(GameplayManager.BaseRoll, ref progressionProfile));

        public void LogEpisodes() => progressionProfile.LogEpisodes(episodeLogger.Input);
    }
}