using System;
using UnityEngine;

namespace OPG.Entities
{
    using Utils;

    #region Enumerators
    [Serializable]
    public enum EntityTypes
    {
        Character,
        Location,
        Race,
        Ship,
        DevilFruit
    }
    #endregion

    /// <summary>
    /// Generic type for all entities.
    /// </summary>
    [Serializable]
    public abstract class Entity : ScriptableObject, INameable, IComparable<Entity>
    {
        public abstract string FolderPath { get; }

        public string ID => base.name;

        /// <summary>
        /// Default text preceding this entity's listed display.
        /// </summary>
        protected abstract string ListedPrefix { get; }

        /// <summary>
        /// This entity's name.
        /// </summary>
        [SerializeField] new protected string name;
        /// <summary>
        /// This entity's name.
        /// </summary>
        public virtual string Name => name;

        /// <summary>
        /// The version of this entity's name to be displayed.
        /// </summary>
        public virtual string DisplayName => Name;

        /// <summary>
        /// The default listed display of this entity's name.
        /// </summary>
        public string DefaultListedName => $"{ListedPrefix}: {DisplayName}";

        public abstract EntityTypes EntityType { get; }

        public Entity() { }

        /// <summary>
        /// Returns an array of formatted texts containing this entity's info.
        /// </summary>
        public abstract string[] GetInfoTexts();

        #region IComparable
        public int CompareTo(Entity other) => string.Compare(DisplayName, other.DisplayName);
        #endregion
    }
}