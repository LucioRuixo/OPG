using UnityEngine;

namespace OPG.Entities
{
    using Utils;

    [CreateAssetMenu(fileName = "NewIsland", menuName = "OPG Entities/Location/Island")]
    public class Island : Location, ILocatable
    {
        public override string FolderPath => $"{base.FolderPath}/Islands";

        [SerializeField] private Location location;
        public Location Location => location;
    }
}