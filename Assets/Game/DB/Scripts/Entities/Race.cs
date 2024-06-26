using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewRace", menuName = "OPG Entities/Race")]
    public class Race : Entity
    {
        public override string FolderPath => "Races";

        protected override string ListedPrefix => "Race";

        public override EntityTypes EntityType => EntityTypes.Race;
    }
}