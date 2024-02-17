using UnityEngine;

namespace OPG.Cards
{
    /// <summary>
    /// Card visual display.
    /// </summary>
    public class Card : MonoBehaviour
    {
        // Debug
        // ----------
        [SerializeField] private string cardDataPath;
        // ----------

        /// <summary>
        /// The asset containing the data to be displayed on the card.
        /// </summary>
        private CardDataBase cardData;
        /// <summary>
        /// The object containing this card's body.
        /// </summary>
        private GameObject formatObject;

        private void Awake()
        {
            CardFormat format = GetComponentInChildren<CardFormat>();
            if (format) formatObject ??= format.gameObject;
        }

        /// <summary>
        /// Loads the card's data asset.
        /// </summary>
        /// <param name="cardDataPath">Path where the asset will be loaded from.</param>
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

        /// <summary>
        /// Set a card data asset's contents as the data to be displayed on the card.
        /// </summary>
        /// <param name="cardData">The card data asset.</param>
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