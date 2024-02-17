using System.Collections.Generic;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    using Entities;

    public class ProgressionProfile : ScriptableObject
    {
        private List<int> cardUnlocks = new List<int>();
        private Dictionary<string, Entity> entitiesByID = new Dictionary<string, Entity>();
    }
}