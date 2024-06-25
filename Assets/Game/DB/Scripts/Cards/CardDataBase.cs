using UnityEngine;

namespace OPG.Cards
{
    using Entities;

    #region Enumerators
    public enum CardTypes
    {
        Skin
    }
    #endregion

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

        private Entity genericEntity;
        /// <summary>
        /// The entity this card portrays as a generic Entity type.
        /// </summary>
        protected Entity GenericEntity => genericEntity ??= GetEntity();

        /// <summary>
        /// The ID of the entity this card portrays.
        /// </summary>
        [SerializeField] protected string entityID;
        /// <summary>
        /// The ID of the entity this card portrays.
        /// </summary>
        public string EntityID => entityID;

        [SerializeField, HideInInspector] private Collection collection;
        /// <summary>
        /// The card collection containing this card.
        /// </summary>
        public Collection Collection { get => collection; set => collection = value; }

        /// <summary>
        /// The type of this card.
        /// </summary>
        public abstract CardTypes CardType { get; }

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