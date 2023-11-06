using UnityEditor;
using UnityEngine;

namespace OPG.Editor
{
    using Cards;
    using Entities;

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

        private void LoadEntity()
        {
            CardInfo cardInfo = (CardInfo)target;
            Card card = cardInfo.Card;

            if (string.IsNullOrEmpty(card.EntityPath))
            {
                LRCore.Logger.LogError(this, "Could not load entity: entity path is null or empty");
                return;
            }

            Entity entity = Resources.Load<Entity>(card.EntityPath);

            if (!entity)
            {
                LRCore.Logger.LogError(this, "Could not load entity: loaded entity is null");
                return;
            }

            serializedObject.Update();
            serializedObject.FindProperty("entity").objectReferenceValue = entity;
            serializedObject.ApplyModifiedProperties();
        }
    }
}