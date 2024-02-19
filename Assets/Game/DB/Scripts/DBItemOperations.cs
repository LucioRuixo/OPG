using UnityEngine;

namespace OPG.DB
{
    public static class DBItemOperations<Item, ItemBase> where Item : ItemBase, IDBItem<Item, ItemBase>, new() where ItemBase : ScriptableObject
    {
        private static readonly Item _Item = new Item();

        public static string FolderPath => _Item.FolderPath;

        public static ItemBase Get(string id) => _Item.Get(id);
    }
}