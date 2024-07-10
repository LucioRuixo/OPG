using System.Collections.Generic;
using UnityEngine;

namespace OPG.ProgressionProfiles.Profile
{
    public class ProgressionProfile : ScriptableObject
    {
        #region Episodes
        [SerializeField, HideInInspector] private int loggedEpisodes = 1;
        public int LoggedEpisodes { get => loggedEpisodes; set => loggedEpisodes = value; }
        #endregion

        #region Cards
        [SerializeField, HideInInspector] private List<int> unlockedCardIDs = new List<int>();
        public List<int> UnlockedCardIDs { get => unlockedCardIDs; set => unlockedCardIDs = value; }

        [SerializeField, HideInInspector] private List<int> rolledCards = new List<int>();
        public List<int> RolledCards { get => rolledCards; set => rolledCards = value; }
        #endregion

        #region Entities
        [SerializeField, HideInInspector] private Dictionary<string, EntityProgression> entityProgressionsByID = new Dictionary<string, EntityProgression>();
        public Dictionary<string, EntityProgression> EntityProgressionsByID { get => entityProgressionsByID; set => entityProgressionsByID = value; }
        #endregion
    }
}