using System;
using UnityEngine;

namespace OPG.Cards
{
    using Entities;

    /// <summary>
    /// Generic base class for card assets.
    /// </summary>
    public abstract class CardDataBase : ScriptableObject
    {
        [SerializeField, HideInInspector] private int id = -1;
        /// <summary>
        /// Application-wide ID for this card data (not card instance-specific).
        /// </summary>
        public int ID { get => id; set => id = value; }

        /// <summary>
        /// The ID of the entity this card portrays.
        /// </summary>
        public abstract string EntityID { get; }

        [SerializeField, HideInInspector] private Collection collection;
        /// <summary>
        /// The card collection containing this card.
        /// </summary>
        public Collection Collection { get => collection; set => collection = value; }

        /// <summary>
        /// Gets the portrayed entity from the Entity Data Base.
        /// </summary>
        /// <returns>The portrayed entity as an Entity.</returns>
        public abstract Entity GetEntity();

        /// <summary>
        /// Loads the card's body into the scene.
        /// </summary>
        /// <param name="target">Format's target parent transform.</param>
        /// <returns></returns>
        public abstract GameObject LoadFormat(Transform target);

        /// <summary>
        /// Visually displays the front face of the card.
        /// </summary>
        /// <param name="frontFace">Face's data to be displayed.</param>
        public abstract void DisplayFrontInfo(FrontFace frontFace);

        /// <summary>
        /// Visually displays the back face of the card.
        /// </summary>
        /// <param name="backFace">Face's data to be displayed.</param>
        public abstract void DisplayBackInfo(BackFace backFace);
    }
}