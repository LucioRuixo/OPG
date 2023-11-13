using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    [ExecuteAlways, RequireComponent(typeof(AspectRatio))]
    public abstract class CardFormat : MonoBehaviour
    {
        protected const float ReferenceSize = 1000.0f;

        protected abstract Vector2Int cardAspectRatio { get; }

        [SerializeField] private FrontFace frontFace;
        [SerializeField] private BackFace backFace;

        public FrontFace FrontFace => frontFace;
        public BackFace BackFace => backFace;

        public CardDataBase CardData { get; set; }

        private AspectRatio aspectRatio;
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