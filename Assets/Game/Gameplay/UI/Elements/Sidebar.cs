using System;
using UnityEngine;
using UnityEngine.UI;

namespace OPG.UI
{
    public class Sidebar : MonoBehaviour
    {
        #region Structures
        [Serializable]
        public struct ButtonMenu
        {
            [SerializeField] private Button button;
            [SerializeField] private Menu menu;

            public Button Button => button;
            public Menu Menu => menu;
        }
        #endregion

        [SerializeField] private ButtonMenu[] menues;

        private Menu openMenu;

        private void Awake()
        {
            foreach (ButtonMenu menu in menues) menu.Button.onClick.AddListener(() => ToggleMenu(menu.Menu));
        }

        private void ToggleMenu(Menu menu)
        {
            // If the menu was open, close it
            if (menu == openMenu)
            {
                menu.Close();
                openMenu = null;

                return;
            }

            // The menu wasn't open, close the one that was, if any
            if (openMenu) openMenu.Close();

            // Finally open the menu
            menu.Open();
            openMenu = menu;
        }
    }
}