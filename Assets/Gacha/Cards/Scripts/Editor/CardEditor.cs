using UnityEditor;
using UnityEngine;

namespace OPG.Editor
{
    using Cards;

    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(Card))]
    public class CardEditor : Editor
    {
        // Debug
        // ----------
        private string[] characters =
        {
            "Luffy",
            "Zoro",
            "Nami",
            "Usopp",
            "Sanji",
        };
        // ----------

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();

            if (GUILayout.Button("Load entity")) LoadEntity();

            EditorGUILayout.Space();

            if (GUILayout.Button("Luffy")) LoadEntity($"Characters/{characters[0]}");
            if (GUILayout.Button("Zoro")) LoadEntity($"Characters/{characters[1]}");
            if (GUILayout.Button("Nami")) LoadEntity($"Characters/{characters[2]}");
            if (GUILayout.Button("Usopp")) LoadEntity($"Characters/{characters[3]}");
            if (GUILayout.Button("Sanji")) LoadEntity($"Characters/{characters[4]}");

            EditorGUILayout.Space();

            if (GUILayout.Button("Random")) LoadEntity($"Characters/{characters[Random.Range(0, characters.Length)]}");
        }

        private void LoadEntity() => ((Card)target).LoadEntity();

        // Debug
        // ----------
        private void LoadEntity(string entityPath) => ((Card)target).LoadEntity(entityPath);
        // ----------
    }
}