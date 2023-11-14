using UnityEngine;

namespace OPG.Cards
{
    public abstract class CardDataBase : ScriptableObject
    {
        public Collection Collection { get; set; }

        public abstract GameObject LoadFormat(Transform target);

        public abstract void DisplayFrontInfo(FrontFace frontFace);
        public abstract void DisplayBackInfo(BackFace backFace);
    }
}