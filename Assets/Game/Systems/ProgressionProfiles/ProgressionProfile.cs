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

        private Dictionary<string, Entity> entitiesByID = new Dictionary<string, Entity>();

        #region Entities
        public bool EntityInitialized(string entityID) => entitiesByID.ContainsKey(entityID);

        public void InitializeEntity(string entityID, Entity entity) => entitiesByID.Add(entityID, entity);
        #endregion

        // Debug
        private void Awake() => cardUnlocks = new List<int>() { 0, 1, 2, 3, 4 };
    }
}