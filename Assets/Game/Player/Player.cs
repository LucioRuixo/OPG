using UnityEngine;

namespace OPG.Player
{
    using Gacha;
    using Input;

    public class Player : MonoBehaviour
    {
        [SerializeField] private MainInputContext inputContext;

        public Inventory Inventory { get; private set; } = new Inventory();

        #region Initialization
        public void Initialize(MainInputContext inputContext)
        {
            this.inputContext = inputContext;

            SubscribeToInputActions();
        }

        private void SubscribeToInputActions() => inputContext.SubscribeToAction(MainInputContext.Actions.Roll, Roll);
        #endregion

        private void AddToInventory(int cardID) => Inventory.Add(cardID);

        public void Roll()
        {
            uint roll = GameManager.BaseRoll;
            int[] rolledIDs = new int[roll];

            for (int i = 0; i < roll; i++)
            {
                int rolledID = Gacha.Roll().ID;
                rolledIDs[i] = rolledID;

                AddToInventory(rolledID);

                LRCore.Logger.Log(this, rolledID.ToString());
            }
        }
    }
}