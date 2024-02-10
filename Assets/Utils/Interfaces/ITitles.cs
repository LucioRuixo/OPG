namespace OPG.Utils
{
    /// <summary>
    /// This object possesses selectable titles.
    /// </summary>
    public interface ITitles
    {
		public string[] Titles { get; }
		public string SelectedTitle { get; }
    }
}