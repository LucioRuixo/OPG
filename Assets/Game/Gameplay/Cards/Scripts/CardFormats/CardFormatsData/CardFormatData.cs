namespace OPG.Cards
{
    public abstract class CardFormatData
    {
        #region Constants
        /// <summary>
        /// Path inside Resources to the card format folder.
        /// </summary>
        public const string FolderPath = "CardFormats";
        #endregion

        /// <summary>
        /// Path inside Resources to this format's prefab.
        /// </summary>
        public abstract string PrefabPath { get; }
    }
}