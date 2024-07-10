using UnityEngine;

namespace OPG.Utils.UI
{
    public class UIUtils
    {
        #region Contants
        private const string ResourcesUIFolderPath = "UI";
        #endregion

        static private readonly string menuTextFieldPrefabPath = $"{ResourcesUIFolderPath}/MenuTextField";
        static private readonly string menuButtonPrefabPath = $"{ResourcesUIFolderPath}/MenuButton";

        static private GameObject menuTextFieldPrefab;
        static private GameObject MenuTextFieldPrefab => menuTextFieldPrefab ??= Resources.Load<GameObject>(menuTextFieldPrefabPath);

        static private GameObject menuButtonPrefab;
        static private GameObject MenuButtonPrefab => menuButtonPrefab ??= Resources.Load<GameObject>(menuButtonPrefabPath);

        static public GameObject GetMenuTextFieldPrefab() => MenuTextFieldPrefab;

        static public GameObject GetMenuButtonPrefab() => MenuButtonPrefab;
    }
}