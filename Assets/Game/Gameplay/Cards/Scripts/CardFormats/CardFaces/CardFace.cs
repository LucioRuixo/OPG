using UnityEngine;

namespace OPG.Cards
{
    /// <summary>
    /// Base class for a card face's contents.
    /// </summary>
    public abstract class CardFace : MonoBehaviour
    {
        /// <summary>
        /// Clear the contents of the card.
        /// </summary>
        public abstract void Clear();
    }
}