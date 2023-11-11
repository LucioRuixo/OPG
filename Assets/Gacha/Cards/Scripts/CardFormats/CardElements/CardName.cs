using UnityEngine;
using TMPro;

namespace OPG.Cards
{
    public class CardName : CardTextField
    {
        [SerializeField] private TMP_Text collectionTextField;

        public string CollectionText { get; set; }

        protected override void Update()
        {
            base.Update();

            collectionTextField.text = CollectionText;
        }
    }
}