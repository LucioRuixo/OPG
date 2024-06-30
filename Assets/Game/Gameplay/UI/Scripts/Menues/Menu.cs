using UnityEngine;

namespace OPG.UI
{
    public class Menu : Screen
    {
        [SerializeField] protected GameObject viewport;
        [SerializeField] protected Submenu[] submenues;

        private Submenu openSubmenu;

        private void Awake()
        {
            foreach (Submenu submenu in submenues) submenu.OnOpenEvent += () => CloseOtherSubmenues(submenu);
        }

        public virtual void Open()
        {
            if (openSubmenu) openSubmenu.UpdateContent();
            else submenues[0]?.Open();

            gameObject.SetActive(true);
        }

        public virtual void Close() => gameObject.SetActive(false);

        private void CloseOtherSubmenues(Submenu openSubmenu)
        {
            this.openSubmenu = openSubmenu;

            foreach (Submenu submenu in submenues)
            {
                if (submenu == openSubmenu) continue;

                submenu.Close();
            }
        }
    }
}