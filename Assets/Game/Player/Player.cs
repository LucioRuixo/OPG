using UnityEngine;

namespace OPG.Player
{
    using Gacha;

    public class Player : MonoBehaviour
    {
        public Inventory Inventory { get; private set; } = new Inventory();

        private void Start()
        {
            Roll();

            foreach (int cardID in Inventory.UnlockedCards.Keys) Debug.Log($"ID {cardID} - {Inventory.UnlockedCards[cardID].Copies + 1}");
        }

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