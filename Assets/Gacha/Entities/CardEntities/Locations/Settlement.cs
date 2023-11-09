using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewSettlement", menuName = "OPG Entities/Location/Settlement")]
    public class Settlement : Location, ILocatable
    {
        [SerializeField] private Location location;
        public Location Location => location;
    }
}