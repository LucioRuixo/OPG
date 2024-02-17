using UnityEngine;

namespace OPG.Cards
{
    public class BackFace : CardFace
    {
		[SerializeField] private CardTextField[] infoFields;
        public CardTextField[] InfoFields => infoFields;

        public override void Clear()
        {
            foreach (CardTextField infoField in infoFields)
            {
                infoField.Text = "";
                infoField.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            foreach (CardTextField infoText in InfoFields) infoText.gameObject.SetActive(!string.IsNullOrEmpty(infoText.Text));
        }
    }
}