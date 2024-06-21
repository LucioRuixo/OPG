using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    using Entities;

    public class ProgressionProfile : ScriptableObject
    {
        private List<int> cardUnlocks = new List<int>();
        public List<int> CardUnlocks => cardUnlocks.ToList();

        public Dictionary<string, Entity> EntitiesByID { get; private set; } = new Dictionary<string, Entity>();

        #region Entities
        public bool IsEntityUnlocked(string entityID) => EntitiesByID.ContainsKey(entityID);

        public void UnlockEntity(string entityID, Entity entity) => EntitiesByID.Add(entityID, entity);
        #endregion

        // Debug
        private void Awake() => cardUnlocks = new List<int>() { 0, 1, 2, 3, 4 };
    }
}