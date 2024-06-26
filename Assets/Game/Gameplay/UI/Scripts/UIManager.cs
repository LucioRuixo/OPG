using UnityEngine;

namespace OPG.UI
{
    using Gameplay;

    public class UIManager : MonoBehaviour
    {
        [Header("Menues")]
        [SerializeField] private MainSidebar sidebar;

        public void Initialize(Player player) => sidebar.Initialize(player);
    }
}