using UnityEngine;
using TMPro;

namespace OPG.Cards
{
    [ExecuteAlways]
    public class CardTextField : MonoBehaviour
    {
        [SerializeField] private TMP_Text textField;

        public string Text { get; set; }

        protected virtual void Update() => textField.text = Text;
    }
}