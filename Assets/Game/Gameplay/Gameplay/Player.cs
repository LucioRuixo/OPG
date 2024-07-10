using UnityEngine;

namespace OPG.Gameplay
{
    using Cards;
    using Gacha;
    using Input;
    using Progression;
    using ProgressionProfiles;
    using UI;

    public class Player : MonoBehaviour
    {
        private MainInputContext inputContext;
        private EpisodeLogger episodeLogger;
        private ProgressionProfileHandler ppHandler;

        public Inventory Inventory { get; private set; } = new Inventory();

        #region Initialization
        public void Initialize(MainInputContext inputContext, EpisodeLogger episodeLogger, ProgressionProfileHandler ppHandler)
        {
            this.inputContext = inputContext;
            this.episodeLogger = episodeLogger;
            this.ppHandler = ppHandler;

            SubscribeToInputActions();
        }

        private void SubscribeToInputActions()
        {
            inputContext.SubscribeToAction(MainInputContext.Actions.Roll, Roll);
            inputContext.SubscribeToAction(MainInputContext.Actions.LogEpisodes, LogEpisodes);
        }
        #endregion

        private void AddToInventory(CardDataBase[] cards) => Inventory.Add(cards);

        public void Roll() => AddToInventory(Gacha.Roll(GameplayManager.BaseRoll, ppHandler));

        public void LogEpisodes() => Progression.ProcessEpisodeLog(episodeLogger.Input, ppHandler);
    }
}