using UnityEngine;

namespace OPG.DB
{
    /// <summary>
    /// This object is an item inside a data base.
    /// </summary>
    public interface IDBItem<Item, ItemBase> where Item : ItemBase where ItemBase : ScriptableObject
    {
        /// <summary>
        /// Path to this object asset folder inside its data base's Resources folder.
        /// </summary>
		public string FolderPath { get; }

        /// <summary>
        /// Returns the asset of this type with the passed ID if it exists.
        /// </summary>
        public ItemBase Get(string id);
    }
}