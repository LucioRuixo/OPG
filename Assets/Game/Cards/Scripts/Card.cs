using UnityEngine;

namespace OPG.Cards
{
    public class Card : MonoBehaviour
    {
        // Debug
        // ----------
        [SerializeField] private string cardDataPath;
        // ----------

        private CardDataBase cardData;
        private GameObject formatObject;

        private void Awake()
        {
            CardFormat format = GetComponentInChildren<CardFormat>();
            if (format) formatObject ??= format.gameObject;
        }

        public void LoadCardData(string cardDataPath)
        {
            cardData = Resources.Load<CardDataBase>(cardDataPath);

            if (!cardData)
            {
                LRCore.Logger.LogError(this, $"Entity could not be loaded: entity failed to load from path \"{cardDataPath}\"");
                return;
            }

            SetCard(cardData);
        }

        public void SetCard(CardDataBase cardData)
        {
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

            formatObject.GetComponent<CardFormat>().CardData = cardData;
        }

        // Debug
        // ----------
        public void LoadCardData()
        {
            cardData = Resources.Load<CardDataBase>(cardDataPath);

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

            formatObject.GetComponent<CardFormat>().CardData = cardData;
        }
        // ----------
    }
}