using UnityEngine;

namespace OPG.DB
{
    using Entities;

    static public class EntityDB
    {
        static private readonly string entitiesResourcesFolder = "DB/Entities";

        static public Entity Get<Item>(string id) where Item : Entity, IDBItem<Item, Entity>, new()
        {
            string entityFolderPath = DBItemOperations<Item, Entity>.FolderPath;
            string path = $"{entitiesResourcesFolder}/{entityFolderPath}/{id}";

            return Resources.Load<Item>(path);
        }
    }
}