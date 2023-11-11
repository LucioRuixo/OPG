using UnityEngine;

namespace OPG.Entities
{
    using Utils;

    public abstract class Entity : ScriptableObject, INameable
    {
        protected abstract string ListedPrefix { get; }

        [SerializeField] new protected string name;
        public virtual string Name => name;

        public virtual string DisplayName => Name;

        public string DefaultListedName => $"{ListedPrefix}: {DisplayName}";
    }
}