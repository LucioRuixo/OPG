using System;

namespace OPG.Entities
{
    [Serializable]
    public class Location : Entity
    {
        public override string FolderPath => "Locations";

        protected override string ListedPrefix => "Location";

        public override EntityTypes EntityType => EntityTypes.Location;

        public override string[] GetInfoTexts()
        {
            throw new System.NotImplementedException();
        }
    }
}