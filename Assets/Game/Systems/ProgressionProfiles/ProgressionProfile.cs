using System.Collections.Generic;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    using Entities;

    public class ProgressionProfile : ScriptableObject
    {
        public List<int> CardUnlocks { get; private set; } = new List<int>();
        public Dictionary<string, Entity> EntitiesByID { get; private set; } = new Dictionary<string, Entity>();

        // Debug
        private void Awake() => CardUnlocks = new List<int>() { 0, 1, 2, 3, 4 };
    }
}