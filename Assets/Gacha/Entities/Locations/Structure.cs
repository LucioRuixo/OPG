using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewStructure", menuName = "OPG/Location/Structure")]
    public class Structure : Location, ILocatable
    {
        [SerializeField] private Location location;
        public Location Location => location;
    }
}