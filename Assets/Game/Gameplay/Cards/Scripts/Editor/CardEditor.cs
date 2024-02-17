using UnityEditor;
using UnityEngine;

namespace OPG.Editor
{
    using Cards;
    using Gacha;

    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(Card))]
    public class CardEditor : Editor
    {
        private const string CardDataPath = "eb/rd/Skins/RomanceDawn";
                                             
        // Debug                             
        // ----------                        
        private string[] characters =        
        {
            "Luffy",
            "Zoro",
            "Nami",
            "Usopp",
            "Sanji"
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

            if (GUILayout.Button("Roll"))
            {
                ProgressionProfiles.ProgressionProfile profile = ProgressionProfiles.ProgressionProfiles.LoadProgressionProfile();
                LoadEntity(Gacha.Roll(1, ref profile)[0]);
            }
        }

        private void LoadEntity() => ((Card)target).LoadCardData();

        // Debug
        // ----------
        private void LoadEntity(string cardDataPath) => ((Card)target).LoadCardData(cardDataPath);

        private void LoadEntity(CardDataBase cardData) => ((Card)target).SetCard(cardData);
        // ----------
    }
}