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
        /// Path to the card's prefab inside the Resources folder.
        /// </summary>
        private const string PrefabPath = "Cards/Card";
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
        /// Prefab of a card's body.
        /// </summary>
        static private GameObject cardPrefab;
        static private GameObject CardPrefab => cardPrefab ??= Resources.Load<GameObject>(PrefabPath);

        /// <summary>
        /// Size of the card on the screen.
        /// </summary>
        public float Size { get => format.ReferenceSize; set => format.ReferenceSize = value; }

        static public Card InstantiateCard(Transform parent, CardDataBase cardData = null)
        {
            Card card = Instantiate(CardPrefab, parent).GetComponent<Card>();
            if (cardData)
            {
                card.SetCard(cardData);
                card.name = cardData.name;
            }

            return card;
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