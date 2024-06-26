using UnityEngine;

namespace OPG.UI
{
    public class Menu : Screen
    {
        [SerializeField] protected GameObject viewport;

        public virtual void Open() => viewport.SetActive(true);

        public virtual void Close() => viewport.SetActive(false);
    }
}