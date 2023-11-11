using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    [CreateAssetMenu(fileName = "NewArc", menuName = "OPG Cards/Arc")]
    public class Arc : ScriptableObject, INameable
    {
        [SerializeField] new private string name;
        public string Name => name;

        [SerializeField] private Saga saga;
        public Saga Saga => saga;
    }
}