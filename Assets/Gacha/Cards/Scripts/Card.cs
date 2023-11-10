using UnityEngine;

namespace OPG.Cards
{
    using Entities;

    public class Card : MonoBehaviour
    {
        private const string DataBasePath = "DataBase";

        [SerializeField] private string cardDataPath;

        private CardDataBase cardData;
        private GameObject formatObject;

        private void Awake()
        {
            CardFormat format = GetComponentInChildren<CardFormat>();
            if (format) formatObject ??= format.gameObject;
        }

        public void LoadCardData()
        {
            cardData = Resources.Load<CardDataBase>($"{DataBasePath}/{cardDataPath}");

            if (!cardData)
            {
                LRCore.Logger.LogError(this, $"Entity could not be loaded: entity failed to load from path \"{cardDataPath}\"");
                return;
            }

            if (formatObject)
            {
                if (Application.isEditor) DestroyImmediate(formatObject);
                else Destroy(formatObject);

                formatObject = null;
            }

            formatObject = cardData.LoadFormat(transform);

            if (!formatObject)
            {
                LRCore.Logger.LogError(this, "Entity could not be loaded: card format failed to load");
                return;
            }
        }

        // Debug
        // ----------
        public void LoadCardData(string cardDataPath)
        {
            string path = $"{DataBasePath}/{cardDataPath}";
            cardData = Resources.Load<CardDataBase>(path);

            if (!cardData)
            {
                LRCore.Logger.LogError(this, $"Entity could not be loaded: entity failed to load from path \"{path}\"");
                return;
            }

            if (formatObject)
            {
                if (Application.isEditor) DestroyImmediate(formatObject);
                else Destroy(formatObject);

                formatObject = null;
            }

            formatObject = cardData.LoadFormat(transform);

            if (!formatObject)
            {
                LRCore.Logger.LogError(this, "Entity could not be loaded: card format failed to load");
                return;
            }

            CardFormat format = formatObject.GetComponent<CardFormat>();
        }
        // ----------
    }
}