using UnityEngine;

namespace OPG.UI
{
    public class Menu : Screen
    {
        [SerializeField] protected GameObject viewport;
        [SerializeField] protected Submenu[] submenues;

        private void Awake()
        {
            foreach (Submenu submenu in submenues) submenu.OnOpenEvent += () => CloseOtherSubmenues(submenu);
        }

        public virtual void Open() => viewport.SetActive(true);

        public virtual void Close() => viewport.SetActive(false);

        private void CloseOtherSubmenues(Submenu openSubmenu)
        {
            foreach (Submenu submenu in submenues)
            {
                if (submenu == openSubmenu) continue;

                submenu.Close();
            }
        }
    }
}