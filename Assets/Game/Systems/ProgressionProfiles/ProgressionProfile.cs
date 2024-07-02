using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    using Cards;
    using DB;
    using Entities;

    public class ProgressionProfile : ScriptableObject
    {
        public int LoggedEpisodes { get; private set; } = 1;

        private List<int> unlockedCardIDs = new List<int>();
        public List<int> UnlockedCardIDs => unlockedCardIDs.ToList();

        private List<int> rolledCards = new List<int>();

        public Dictionary<string, EntityProgression> EntityProgressionsByID { get; private set; } = new Dictionary<string, EntityProgression>();

        public event Action<int> OnEpisodesLoggedEvent;

        #region Episodes
        public void LogEpisodes(int count)
        {
            int oldLoggedEpisodes = LoggedEpisodes;

            LoggedEpisodes += count;
            if (LoggedEpisodes < 1)
            {
                LoggedEpisodes = 1;

                oldLoggedEpisodes = 0;
                count = 1;

                unlockedCardIDs = new List<int>(); // Debug
            }

            UpdateCardUnlocks(oldLoggedEpisodes + 1, count);

            OnEpisodesLoggedEvent?.Invoke(LoggedEpisodes);
        }

        private void UpdateCardUnlocks(int first, int count)
        {
            int[] newUnlockedCardIDs = CardDataDB.GetIDsByEpisodeRange(first, count);
            unlockedCardIDs.AddRange(newUnlockedCardIDs);
        }
        #endregion

        #region Cards
        public bool WasCardRolled(int cardID) => rolledCards.Contains(cardID);

        public void RegisterRolledCard(CardDataBase card)
        {
            string entityID = card.GetEntity().ID;

            if (!EntityProgressionsByID.ContainsKey(entityID))
            {
                LRCore.Logger.LogError(this, "Could not register rolled card: this card's entity has not been unlocked. Rolled cards' entities must be processed BEFORE the card.");
                return;
            }

            EntityProgressionsByID[entityID].AddImage(card.Image);

            rolledCards.Add(card.ID);
        }

        public void ResetRolledCards() => rolledCards = new List<int>();
        #endregion

        #region Entities
        public bool IsEntityUnlocked(string entityID) => EntityProgressionsByID.ContainsKey(entityID);

        public void UnlockEntity(string entityID, Entity entity) => EntityProgressionsByID.Add(entityID, new EntityProgression(entity));

        public List<Entity> UnlockedEntitiesOfType(EntityTypes entityType) => EntityProgressionsByID.Values.Select(entityProgression => entityProgression.Entity).Where(entity => entity.EntityType == entityType).ToList();
        #endregion
    }
}