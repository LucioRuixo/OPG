using UnityEngine;

namespace OPG.Utils.UI
{
    public class UIUtils
    {
        #region Contants
        private const string ResourcesUIFolderPath = "UI";
        #endregion

        private static readonly string menuTextFieldPrefabPath = $"{ResourcesUIFolderPath}/MenuTextField";
        private static readonly string menuButtonPrefabPath = $"{ResourcesUIFolderPath}/MenuButton";

        private static GameObject menuTextFieldPrefab;
        private static GameObject MenuTextFieldPrefab => menuTextFieldPrefab ??= Resources.Load<GameObject>(menuTextFieldPrefabPath);

        private static GameObject menuButtonPrefab;
        private static GameObject MenuButtonPrefab => menuButtonPrefab ??= Resources.Load<GameObject>(menuButtonPrefabPath);

        public static GameObject GetMenuTextFieldPrefab() => MenuTextFieldPrefab;

        public static GameObject GetMenuButtonPrefab() => MenuButtonPrefab;
    }
}