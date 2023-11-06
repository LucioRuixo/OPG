using UnityEngine;
using TMPro;

namespace OPG.Cards
{
    [ExecuteAlways]
    public class CardTextField : MonoBehaviour
    {
        [SerializeField] private TMP_Text textField;

        public string Text { get; set; }

        private void Update() => textField.text = Text;
    }
}