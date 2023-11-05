using UnityEngine;

namespace OPG.Utils
{
    [ExecuteAlways]
    public class AspectRatio : MonoBehaviour
    {
        [SerializeField] private float referenceSize = 1000.0f;
        [SerializeField] private Vector2Int aspectRatio;

        private RectTransform rect;

        public float ReferenceSize { get => referenceSize; set => referenceSize = value; }

        private void Awake() => rect = GetComponent<RectTransform>();

        private void Update() => SetDimesions();

        private void SetDimesions()
        {
            if (aspectRatio.x == aspectRatio.y)
            {
                float size = aspectRatio.x == 0 ? 0 : ReferenceSize;
                rect.sizeDelta = new(size, size);

                return;
            }

            bool widthIsHigher = aspectRatio.x > aspectRatio.y;
            float maxAR = widthIsHigher ? aspectRatio.x : aspectRatio.y;
            float minAR = widthIsHigher ? aspectRatio.y : aspectRatio.x;

            float minSize = (ReferenceSize / maxAR) * minAR;
            rect.sizeDelta = new(widthIsHigher ? ReferenceSize : minSize, widthIsHigher ? minSize : ReferenceSize);
        }
    }
}