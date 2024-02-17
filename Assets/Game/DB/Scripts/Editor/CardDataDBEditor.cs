using UnityEditor;
using UnityEngine;

namespace OPG.Editor
{
    using DB;

    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(CardDataDB))]
    public class CardDataDBEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();

            if (GUILayout.Button("Serialize"))
            {
                CardDataDB dataBase = (CardDataDB)target;

                dataBase.Serialize();
            }
        }
    }
}