using UnityEngine;

namespace OPG.Utils.UI
{
    public class UIUtils
    {
        #region Contants
        private const string ResourcesUIFolderPath = "UI";
        #endregion

        private static readonly string menuButtonPrefabPath = $"{ResourcesUIFolderPath}/MenuButton";

        private static GameObject menuButtonPrefab;
        private static GameObject MenuButtonPrefab => menuButtonPrefab ??= Resources.Load<GameObject>(menuButtonPrefabPath);

        public static GameObject GetMenuButtonPrefab() => MenuButtonPrefab;
    }
}