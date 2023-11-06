using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewIsland", menuName = "OPG/Location/Island")]
    public class Island : Location, ILocatable
    {
        [SerializeField] private Location location;
        public Location Location => location;
    }
}