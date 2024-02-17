using System.Collections.Generic;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    using Entities;

    public class ProgressionProfile : ScriptableObject
    {
        public List<int> CardUnlocks { get; private set; } = new List<int>();
        public Dictionary<string, Entity> EntitiesByID { get; private set; } = new Dictionary<string, Entity>();
    }
}