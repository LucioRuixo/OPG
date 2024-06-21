using UnityEngine;

namespace OPG.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] protected GameObject display;

        public virtual void Open() => display.SetActive(true);

        public virtual void Close() => display.SetActive(false);
    }
}