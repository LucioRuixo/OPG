using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewSea", menuName = "OPG Entities/Location/Sea")]
    public class Sea : Location
    {
        public override string FolderPath => $"{base.FolderPath}/Seas";
    }
}