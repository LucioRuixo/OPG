using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewStructure", menuName = "OPG Entities/Location/Structure")]
    public class Structure : Location, ILocatable
    {
        [SerializeField] private Location location;
        public Location Location => location;
    }
}