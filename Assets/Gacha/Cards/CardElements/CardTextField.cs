using UnityEngine;
using TMPro;

namespace OPG.Cards
{
    [ExecuteAlways]
    public class CardTextField : MonoBehaviour
    {
        [SerializeField] protected string text;

        [Space]

        [SerializeField] private TMP_Text textField;

        private void Update() => textField.text = text;
    }
}