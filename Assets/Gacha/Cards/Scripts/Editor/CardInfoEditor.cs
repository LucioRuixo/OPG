using UnityEditor;
using UnityEngine;

namespace OPG.Editor
{
    using Cards;

    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(CardInfo))]
    public class CardInfoEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();

            if (GUILayout.Button("Load entity")) LoadEntity();
        }

        private void LoadEntity() => ((CardInfo)target).LoadEntity();
    }
}