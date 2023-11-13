using UnityEditor;
using UnityEngine;

namespace OPG.Editor
{
    using Cards;

    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(CardDataDataBase))]
    public class CardDataDataBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();

            if (GUILayout.Button("Serialize"))
            {
                CardDataDataBase dataBase = (CardDataDataBase)target;

                dataBase.Serialize();
            }
        }
    }
}