using System;
using UnityEngine;

namespace OPG.Entities
{
    using Utils;

    using OPGPaths = Utils.Paths;

    /// <summary>
    /// Generic type of all card contents.
    /// </summary>
    [Serializable]
    public abstract class Entity : ScriptableObject, INameable
    {
        public abstract string FolderPath { get; }

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

        public Entity() {}
    }
}