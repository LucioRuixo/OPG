using UnityEngine;

namespace OPG.Entities
{
    public abstract class Entity : ScriptableObject
    {
        [SerializeField] new protected string name;
        public virtual string Name => name;
    }
}