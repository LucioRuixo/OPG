namespace OPG.Entities
{
    public class Land : Location
    {
        public override string FolderPath => $"{base.FolderPath}/Lands";
    }
}