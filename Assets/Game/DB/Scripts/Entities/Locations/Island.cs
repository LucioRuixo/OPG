using UnityEngine;

namespace OPG.Entities
{
    using Utils;

    [CreateAssetMenu(fileName = "NewIsland", menuName = "OPG Entities/Location/Island")]
    public class Island : Location, ILocatable
    {
        [SerializeField] private Location location;
        public Location Location => location;
    }
}