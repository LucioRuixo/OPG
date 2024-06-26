using UnityEngine;

namespace OPG.UI
{
    public class Submenu : MonoBehaviour
    {
        [SerializeField] private RectTransform buttonContainer;
        public RectTransform ButtonContainer => buttonContainer;

        public void Open() => gameObject.SetActive(true);

        public void Close() => gameObject.SetActive(false);
    }
}