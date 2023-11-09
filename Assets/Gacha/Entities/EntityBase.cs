using UnityEngine;

namespace OPG.Entities
{
    public abstract class EntityBase : ScriptableObject
    {
        [SerializeField] new protected string name;
        public virtual string Name => name;

        public abstract GameObject LoadCard(Transform target);

        public abstract void DisplayInfo();
    }
}