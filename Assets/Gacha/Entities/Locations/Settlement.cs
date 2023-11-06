using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewSettlement", menuName = "OPG/Location/Settlement")]
    public class Settlement : Location, ILocatable
    {
        [SerializeField] private Location location;
        public Location Location => location;
    }
}