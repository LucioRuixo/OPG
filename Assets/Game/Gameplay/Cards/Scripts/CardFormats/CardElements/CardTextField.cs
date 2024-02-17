using UnityEngine;
using TMPro;

namespace OPG.Cards
{
    /// <summary>
    /// Displays text on a card's face.
    /// </summary>
    [ExecuteAlways]
    public class CardTextField : MonoBehaviour
    {
        /// <summary>
        /// The text to be displayed.
        /// </summary>
        [SerializeField] private TMP_Text textField;

        /// <summary>
        /// The text to be displayed.
        /// </summary>
        public string Text { get; set; }

        protected virtual void Update() => textField.text = Text;
    }
}