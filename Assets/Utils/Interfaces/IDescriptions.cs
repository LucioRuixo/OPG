namespace OPG.Utils
{
    /// <summary>
    /// This object has selectable descriptions.
    /// </summary>
    public interface IDescriptions
    {
        public string[] Descriptions { get; }
        public string SelectedDescription { get; }
    }
}