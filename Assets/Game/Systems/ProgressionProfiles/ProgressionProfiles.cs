using UnityEditor;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    public class ProgressionProfiles
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

        public static ProgressionProfile LoadProgressionProfile()
        {
            string profilePath = $"{ProgressionProfileFolder}/{ProgressionProfileFile}";
            return Resources.Load<ProgressionProfile>(profilePath) ?? CreateProgressionProfile($"Assets/Resources/{profilePath}");
        }

        public static ProgressionProfile CreateProgressionProfile(string path)
        {
            ProgressionProfile profile = ScriptableObject.CreateInstance<ProgressionProfile>();
            AssetDatabase.CreateAsset(profile, $"{path}.asset");

            return profile;
        }
    }
}