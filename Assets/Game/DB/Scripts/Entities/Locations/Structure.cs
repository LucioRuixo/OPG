using UnityEngine;

namespace OPG.Entities
{
    using Utils;

    [CreateAssetMenu(fileName = "NewStructure", menuName = "OPG Entities/Location/Structure")]
    public class Structure : Location, ILocatable
    {
        public override string FolderPath => $"{base.FolderPath}/Structures";

        [SerializeField] private Location location;
        public Location Location => location;
    }
}