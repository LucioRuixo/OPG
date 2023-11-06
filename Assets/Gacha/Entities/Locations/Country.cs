using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewCountry", menuName = "OPG/Location/Country")]
    public class Country : Location, ILocatable
    {
        [SerializeField] private Location location;
        public Location Location => location;
    }
}