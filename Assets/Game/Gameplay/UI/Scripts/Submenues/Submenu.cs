using System;
using UnityEngine;
using UnityEngine.UI;

namespace OPG.UI
{
    public class Submenu : MonoBehaviour
    {
        [SerializeField] private Button backButton;

        [SerializeField] private RectTransform buttonContainer;
        public RectTransform ButtonContainer => buttonContainer;

        private Submenu source;

        public event Action OnOpenEvent;
        public event Action OnClosedEvent;

        public void Open(Submenu newSource = null)
        {
            if (backButton)
            {
                if (newSource) source = newSource;

                if (source)
                {
                    backButton.gameObject.SetActive(true);
                    backButton.onClick.AddListener(Return);
                }
                else backButton.gameObject.SetActive(false);
            }

            UpdateContent();
            gameObject.SetActive(true);

            OnOpenEvent?.Invoke();
        }

        public void Close()
        {
            gameObject.SetActive(false);
            OnClosedEvent?.Invoke();
        }

        public void Return()
        {
            backButton.onClick.RemoveListener(Return);
            source.Open();
        }

        public virtual void UpdateContent() { }
    }
}