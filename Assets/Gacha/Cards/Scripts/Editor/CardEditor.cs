using UnityEditor;
using UnityEngine;

namespace OPG.Editor
{
    using Cards;

    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(Card))]
    public class CardEditor : Editor
    {
        private const string CardDataPath = "EastBlue/RomanceDawn/RomanceDawn/Skins";
                                             
        // Debug                             
        // ----------                        
        private string[] characters =        
        {
            "RomanceDawnLuffy",
            "RomanceDawnZoro",
            "RomanceDawnNami",
            "RomanceDawnUsopp",
            "RomanceDawnSanji"
        };
        // ----------

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();

            if (GUILayout.Button("Load entity")) LoadEntity();

            EditorGUILayout.Space();

            if (GUILayout.Button("Luffy")) LoadEntity($"{CardDataPath}/{characters[0]}");
            if (GUILayout.Button("Zoro")) LoadEntity($"{CardDataPath}/{characters[1]}");
            if (GUILayout.Button("Nami")) LoadEntity($"{CardDataPath}/{characters[2]}");
            if (GUILayout.Button("Usopp")) LoadEntity($"{CardDataPath}/{characters[3]}");
            if (GUILayout.Button("Sanji")) LoadEntity($"{CardDataPath}/{characters[4]}");

            EditorGUILayout.Space();

            if (GUILayout.Button("Random")) LoadEntity($"Characters/{characters[Random.Range(0, characters.Length)]}");
        }

        private void LoadEntity() => ((Card)target).LoadCardData();

        // Debug
        // ----------
        private void LoadEntity(string cardDataPath) => ((Card)target).LoadCardData(cardDataPath);
        // ----------
    }
}