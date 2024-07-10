using UnityEngine;

namespace OPG.DB
{
    static public class DBItemOperations<Item, ItemBase> where Item : ItemBase, IDBItem<Item, ItemBase>, new() where ItemBase : ScriptableObject
    {
        static private readonly Item _Item = new Item();

        static public string FolderPath => _Item.FolderPath;

        static public ItemBase Get(string id) => _Item.Get(id);
    }
}