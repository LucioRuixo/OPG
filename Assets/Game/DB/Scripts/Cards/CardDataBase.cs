using UnityEngine;

namespace OPG.Cards
{
    public abstract class CardDataBase : ScriptableObject
    {
        [SerializeField, HideInInspector] private int id = -1;
        public int ID { get => id; set => id = value; }

        [SerializeField, HideInInspector] private Collection collection;
        public Collection Collection { get => collection; set => collection = value; }

        public abstract GameObject LoadFormat(Transform target);

        public abstract void DisplayFrontInfo(FrontFace frontFace);
        public abstract void DisplayBackInfo(BackFace backFace);
    }
}