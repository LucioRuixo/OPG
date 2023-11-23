using UnityEngine;

namespace OPG.Player
{
    using Gacha;

    public class Player : MonoBehaviour
    {
        public Inventory Inventory { get; private set; } = new Inventory();

        private void AddToInventory(int cardID) => Inventory.Add(cardID);

        public int[] Roll()
        {
            uint roll = GameManager.BaseRoll;
            int[] rolledIDs = new int[roll];

            for (int i = 0; i < roll; i++)
            {
                int rolledID = Gacha.Roll().ID;
                rolledIDs[i] = rolledID;

                AddToInventory(rolledID);
            }

            return rolledIDs;
        }
    }
}