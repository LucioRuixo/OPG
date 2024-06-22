using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    /// <summary>
    /// Base class for cards' bodies.
    /// </summary>
    [ExecuteAlways, RequireComponent(typeof(AspectRatio))]
    public abstract class CardFormat : MonoBehaviour
    {
        /// <summary>
        /// Horizontal to vertical ratio values of this card's sides.
        /// </summary>
        protected abstract Vector2Int cardAspectRatio { get; }

        /// <summary>
        /// The face containing the front contents of this card.
        /// </summary>
        [SerializeField] private FrontFace frontFace;
        /// <summary>
        /// The face containing the front contents of this card.
        /// </summary>
        public FrontFace FrontFace => frontFace;

        /// <summary>
        /// The face containing the back contents of this card.
        /// </summary>
        [SerializeField] private BackFace backFace;
        /// <summary>
        /// The face containing the back contents of this card.
        /// </summary>
        public BackFace BackFace => backFace;

        /// <summary>
        /// Asset containing this card's contents.
        /// </summary>
        public CardDataBase CardData { get; set; }

        /// <summary>
        /// Base length of the largest side of the card, from which the remaining side will derive based on the card's aspect ratio.
        /// </summary>
        public float ReferenceSize { get => AspectRatio.ReferenceSize; set => AspectRatio.ReferenceSize = value; }

        /// <summary>
        /// Aspect ratio component for this card's sides.
        /// </summary>
        private AspectRatio aspectRatio;
        /// <summary>
        /// Aspect ratio component for this card's sides.
        /// </summary>
        protected AspectRatio AspectRatio
        {
            get
            {
                aspectRatio ??= GetComponent<AspectRatio>();
                return aspectRatio;
            }
        }

        private void Update()
        {
            AspectRatio.ReferenceSize = ReferenceSize;
            AspectRatio._AspectRatio = cardAspectRatio;

            if (CardData)
            {
                CardData.DisplayFrontInfo(frontFace);
                CardData.DisplayBackInfo(backFace);
            }
        }
    }
}