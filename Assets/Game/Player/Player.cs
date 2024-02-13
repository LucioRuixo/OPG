using UnityEngine;

namespace OPG.Player
{
    using Gacha;

    [RequireComponent(typeof(PlayerController))]
    public class Player : MonoBehaviour
    {
        private PlayerController playerController;

        public Inventory Inventory { get; private set; } = new Inventory();

        private void Awake() => playerController = GetComponent<PlayerController>();

        private void Start()
        {
            Roll();

            foreach (int cardID in Inventory.Cards.Keys) Debug.Log($"ID {cardID} - {Inventory.Cards[cardID].Copies + 1}");
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