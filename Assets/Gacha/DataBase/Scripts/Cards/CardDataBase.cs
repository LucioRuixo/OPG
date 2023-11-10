using UnityEngine;

namespace OPG.Cards
{
    [ExecuteAlways]
    public abstract class CardDataBase : ScriptableObject
    {
        public abstract GameObject LoadFormat(Transform target);

        public abstract void DisplayFrontInfo(FrontFace frontFace);
        public abstract void DisplayBackInfo(BackFace backFace);
    }
}