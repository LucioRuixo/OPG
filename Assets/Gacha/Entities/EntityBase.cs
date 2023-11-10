using UnityEngine;

namespace OPG.Entities
{
    using Cards;

    public abstract class EntityBase : ScriptableObject
    {
        protected abstract string ListedPrefix { get; }

        [SerializeField] new protected string name;
        public virtual string Name => name;

        public virtual string DisplayName => Name;

        public string DefaultListedName => $"{ListedPrefix}: {DisplayName}";

        public abstract GameObject LoadCard(Transform target);

        public abstract void DisplayFrontInfo(FrontFace frontFace);
        public abstract void DisplayBackInfo(BackFace backFace);
    }
}