using System;
using UnityEngine;

namespace OPG.UI
{
    public class Submenu : MonoBehaviour
    {
        [SerializeField] private RectTransform buttonContainer;
        public RectTransform ButtonContainer => buttonContainer;

        public event Action OnOpenEvent;
        public event Action OnClosedEvent;

        public void Open()
        {
            gameObject.SetActive(true);
            OnOpenEvent?.Invoke();
        }

        public void Close()
        {
            gameObject.SetActive(false);
            OnClosedEvent?.Invoke();
        }
    }
}