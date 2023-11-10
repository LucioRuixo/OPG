using UnityEditor;
using UnityEngine;

namespace OPG.Editor
{
    using Cards;

    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(SkinCard))]
    public class CardDataBaseEditor : Editor
    {
        private const string CharacterPath = "Entities/Characters";

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

            if (GUILayout.Button("Luffy")) LoadEntity($"{CharacterPath}/{characters[0]}");
            if (GUILayout.Button("Zoro")) LoadEntity($"{CharacterPath}/{characters[1]}");
            if (GUILayout.Button("Nami")) LoadEntity($"{CharacterPath}/{characters[2]}");
            if (GUILayout.Button("Usopp")) LoadEntity($"{CharacterPath}/{characters[3]}");
            if (GUILayout.Button("Sanji")) LoadEntity($"{CharacterPath}/{characters[4]}");

            EditorGUILayout.Space();

            if (GUILayout.Button("Random")) LoadEntity($"Characters/{characters[Random.Range(0, characters.Length)]}");
        }

        private void LoadEntity() => ((CardDataBase)target).LoadEntity();

        // Debug
        // ----------
        private void LoadEntity(string entityPath) => ((CardDataBase)target).LoadEntity(entityPath);
        // ----------
    }
}