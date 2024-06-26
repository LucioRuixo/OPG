using UnityEngine;
using UnityEngine.UI;

namespace OPG.Cards
{
    using Utils.UI;

    [RequireComponent(typeof(AspectRatio))]
    public class CardImageViewport : MonoBehaviour
    {
        [SerializeField] private Image image;
        public Image Image => image;
    }
}