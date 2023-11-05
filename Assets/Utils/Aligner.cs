using UnityEngine;

namespace OPG.Utils
{
    [ExecuteAlways]
    public class Aligner : MonoBehaviour
    {
        [SerializeField, Range(2, 20)] private int widthSubdivisions = 2;
        [SerializeField, Range(-20, 20)] private int xOffset = 0;

        [Space]

        [SerializeField, Range(2, 20)] private int heightSubdivisions = 2;
        [SerializeField, Range(-20, 20)] private int yOffset = 0;

        private RectTransform rect;

        private Transform parent;
        private RectTransform parentRect;

        private void Update()
        {
            rect ??= GetComponent<RectTransform>();

            if (!parent || parent != transform.parent)
            {
                parent = transform.parent;
                parentRect = transform.parent.GetComponent<RectTransform>();
            }

            //ExpandAnchor();
            SetPosition();
        }

        private void ExpandAnchor()
        {
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
        }

        private void SetPosition()
        {
            float x = 0.0f, y = 0.0f;

            bool subdivisionsOdd;
            float step;
            float min;
            int adjustment;

            subdivisionsOdd = widthSubdivisions % 2 != 0;
            if (!(xOffset == 0 && subdivisionsOdd))
            {
                step = parentRect.rect.width / widthSubdivisions;
                min = parentRect.rect.xMin;
                adjustment = subdivisionsOdd && xOffset < 0 ? 1 : 0;

                x = min + (step * (widthSubdivisions / 2 + xOffset + adjustment));
            }

            subdivisionsOdd = heightSubdivisions % 2 != 0;
            if (!(yOffset == 0 && heightSubdivisions % 2 != 0))
            {
                min = parentRect.rect.yMin;
                step = parentRect.rect.height / heightSubdivisions;
                adjustment = subdivisionsOdd && yOffset < 0 ? 1 : 0;

                y = min + (step * (heightSubdivisions / 2 + yOffset + adjustment));
            }

            rect.anchoredPosition = new(x, y);
        }
    }
}