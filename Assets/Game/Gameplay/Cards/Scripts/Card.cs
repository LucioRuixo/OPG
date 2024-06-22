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

        #region Constants
        /// <summary>
        /// Path inside Resources to the card's prefab.
        /// </summary>
        public const string PrefabPath = "Cards/Card";
        #endregion

        /// <summary>
        /// The asset containing the data to be displayed on the card.
        /// </summary>
        private CardDataBase cardData;
        /// <summary>
        /// This card's body.
        /// </summary>
        private CardFormat format;
        /// <summary>
        /// The object containing this card's body.
        /// </summary>
        private GameObject formatGO;

        /// <summary>
        /// Size of the card on the screen.
        /// </summary>
        public float Size { get => format.ReferenceSize; set => format.ReferenceSize = value; }

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
            if (formatGO)
            {
                if (Application.isEditor) DestroyImmediate(formatGO);
                else Destroy(formatGO);

                formatGO = null;
                format = null;
            }

            formatGO = cardData.LoadFormat(transform);

            if (!formatGO)
            {
                LRCore.Logger.LogError(this, "Entity could not be loaded: card format failed to load");
                return;
            }

            (format = formatGO.GetComponent<CardFormat>()).CardData = cardData;

            GetComponent<RectTransform>().sizeDelta = formatGO.GetComponent<RectTransform>().sizeDelta;
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

            if (formatGO)
            {
                if (Application.isEditor) DestroyImmediate(formatGO);
                else Destroy(formatGO);

                formatGO = null;
            }

            formatGO = cardData.LoadFormat(transform);

            if (!formatGO)
            {
                LRCore.Logger.LogError(this, "Entity could not be loaded: card format failed to load");
                return;
            }

            format.CardData = cardData;
        }
        // ----------
    }
}