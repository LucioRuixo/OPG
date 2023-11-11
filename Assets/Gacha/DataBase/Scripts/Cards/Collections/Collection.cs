using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    [CreateAssetMenu(fileName = "NewCollection", menuName = "OPG Cards/Collection")]
    public class Collection : ScriptableObject, INameable
    {
        [SerializeField] new private string name;
        public string Name => name;

        [SerializeField] private Arc arc;
        public Arc Arc => arc;
    }
}