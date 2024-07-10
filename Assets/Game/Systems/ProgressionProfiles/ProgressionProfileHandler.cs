using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    using Cards;
    using DB;
    using Entities;
    using Gameplay;
    using Profile;

    public class ProgressionProfileHandler
    {
        #region Constants
        /// <summary>
        /// Name of the progression profile file.
        /// </summary>
        public const string ProgressionProfileFile = "ProgressionProfile";

        /// <summary>
        /// Name the progression profile folder inside Resources.
        /// </summary>
        public const string ProgressionProfileFolder = "ProgressionProfiles";
        #endregion

        private ProgressionProfile progressionProfile;

        public int LoggedEpisodes { get => progressionProfile.LoggedEpisodes; private set => progressionProfile.LoggedEpisodes = value; }

        public List<int> UnlockedCardIDs { get => progressionProfile.UnlockedCardIDs; private set => progressionProfile.UnlockedCardIDs = value; }

        public Dictionary<string, EntityProgression> EntityProgressionsByID { get => progressionProfile.EntityProgressionsByID; private set => progressionProfile.EntityProgressionsByID = value; }

        public event Action<int> OnEpisodesLoggedEvent;

        public ProgressionProfileHandler()
        {
            progressionProfile = LoadProgressionProfile();

            // Debug
            ResetLoggedEpisodes();
            ResetRolledCards();
        }

        private ProgressionProfile LoadProgressionProfile()
        {
            string profilePath = $"{ProgressionProfileFolder}/{ProgressionProfileFile}";
            return Resources.Load<ProgressionProfile>(profilePath) ?? CreateProgressionProfile($"Assets/Resources/{profilePath}");
        }

        private ProgressionProfile CreateProgressionProfile(string path)
        {
            ProgressionProfile profile = ScriptableObject.CreateInstance<ProgressionProfile>();
            AssetDatabase.CreateAsset(profile, $"{path}.asset");

            return profile;
        }

        #region Episodes
        public void LogEpisodes(int logCount)
        {
            int oldLoggedEpisodes = LoggedEpisodes;

            LoggedEpisodes += logCount;
            if (LoggedEpisodes < 1)
            {
                LoggedEpisodes = 1;

                oldLoggedEpisodes = 0;
                logCount = 1;

                UnlockedCardIDs = new List<int>(); // Debug
            }

            UpdateCardUnlocks(oldLoggedEpisodes + 1, logCount);

            OnEpisodesLoggedEvent?.Invoke(LoggedEpisodes);
        }

        private void UpdateCardUnlocks(int first, int count)
        {
            int[] newUnlockedCardIDs = CardDataDB.GetIDsByEpisodeRange(first, count);
            UnlockedCardIDs.AddRange(newUnlockedCardIDs);
        }
        #endregion

        #region Cards
        public bool WasCardRolled(int cardID) => progressionProfile.RolledCards.Contains(cardID);

        public void RegisterRolledCard(CardDataBase card)
        {
            string entityID = card.GetEntity().ID;

            if (!EntityProgressionsByID.ContainsKey(entityID))
            {
                LRCore.Logger.LogError(this, "Could not register rolled card: this card's entity has not been unlocked. Rolled cards' entities must be processed BEFORE the card.");
                return;
            }

            EntityProgressionsByID[entityID].AddImage(card.Image);

            progressionProfile.RolledCards.Add(card.ID);
        }
        #endregion

        #region Entities
        public bool IsEntityUnlocked(string entityID) => EntityProgressionsByID.ContainsKey(entityID);

        public void UnlockEntity(string entityID, Entity entity) => EntityProgressionsByID.Add(entityID, new EntityProgression(entity));

        public List<Entity> UnlockedEntitiesOfType(EntityTypes entityType) => EntityProgressionsByID.Values.Select(entityProgression => entityProgression.Entity).Where(entity => entity.EntityType == entityType).ToList();
        #endregion

        #region Debug
        private void ResetLoggedEpisodes() => LogEpisodes(-9999);

        private void ResetRolledCards() => progressionProfile.RolledCards = new List<int>();
        #endregion
    }
}