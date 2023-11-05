using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    [ExecuteAlways, RequireComponent(typeof(AspectRatio))]
    public class Card : MonoBehaviour
    {
        private const float ReferenceSize = 1000.0f;
        private AspectRatio aspectRatio;

        private void Update()
        {
            aspectRatio ??= GetComponent<AspectRatio>();
            aspectRatio.ReferenceSize = ReferenceSize;
        }
    }
}