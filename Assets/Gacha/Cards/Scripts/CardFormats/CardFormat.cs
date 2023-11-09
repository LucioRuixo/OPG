using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    [ExecuteAlways, RequireComponent(typeof(AspectRatio))]
    public abstract class CardFormat : MonoBehaviour
    {
        protected abstract Vector2Int cardAspectRatio { get; }

        private AspectRatio aspectRatio;
        protected AspectRatio AspectRatio
        {
            get
            {
                aspectRatio ??= GetComponent<AspectRatio>();
                return aspectRatio;
            }
        }

        private void Update() => AspectRatio._AspectRatio = cardAspectRatio;
    }
}