using System.Collections.Generic;
using UnityEngine;

namespace OPG.Progression
{
    using Entities;

    public class ProgressionProfile : ScriptableObject
    {
        #region Constants
        /// <summary>
        /// Prefix that preceeds the index in a progression profile's name.
        /// </summary>
        public const string ProgressionFilePrefix = "ProgressionProfile";
        #endregion

        /// <summary>
        /// Path inside Resources to the progression profile folder.
        /// </summary>
        public static readonly string progressionProfilesFolderPath = "ProgressionProfiles";

        private List<int> cardUnlocks = new List<int>();
        private Dictionary<string, Entity> entitiesByID = new Dictionary<string, Entity>();
    }
}