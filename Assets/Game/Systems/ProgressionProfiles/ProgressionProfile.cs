using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    using Cards;
    using Entities;

    public class ProgressionProfile : ScriptableObject
    {
        private List<int> unlockedCards = new List<int>();
        public List<int> UnlockedCards => unlockedCards.ToList();

        private List<int> rolledCards = new List<int>();

        public Dictionary<string, EntityProgression> EntityProgressionsByID { get; private set; } = new Dictionary<string, EntityProgression>();

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
        #endregion

        #region Entities
        public bool IsEntityUnlocked(string entityID) => EntityProgressionsByID.ContainsKey(entityID);

        public void UnlockEntity(string entityID, Entity entity) => EntityProgressionsByID.Add(entityID, new EntityProgression(entity));

        public List<Entity> UnlockedEntitiesOfType(EntityTypes entityType) => EntityProgressionsByID.Values.Select(entityProgression => entityProgression.Entity).Where(entity => entity.EntityType == entityType).ToList();
        #endregion

        // Debug
        private void Awake() => unlockedCards = new List<int>() { 0, 1, 2, 3, 4 };

        public void ResetRolledCards() => rolledCards = new List<int>();
    }
}