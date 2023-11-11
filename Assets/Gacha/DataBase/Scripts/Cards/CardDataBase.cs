using UnityEngine;

namespace OPG.Cards
{
    public abstract class CardDataBase : ScriptableObject
    {
        [SerializeField] private Collection collection;
        public Collection Collection => collection;

        public abstract GameObject LoadFormat(Transform target);

        public abstract void DisplayFrontInfo(FrontFace frontFace);
        public abstract void DisplayBackInfo(BackFace backFace);
    }
}