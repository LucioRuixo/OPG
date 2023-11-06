using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    [ExecuteAlways, RequireComponent(typeof(AspectRatio)), RequireComponent(typeof(CardInfo))]
    public class Card : MonoBehaviour
    {
        private const float ReferenceSize = 1000.0f;

        [SerializeField] private string entityPath;

        private AspectRatio aspectRatio;

        public string EntityPath => entityPath;

        private void Update()
        {
            aspectRatio ??= GetComponent<AspectRatio>();
            aspectRatio.ReferenceSize = ReferenceSize;
        }
    }
}