using UnityEngine;

namespace OPG.DB
{
    using Entities;

    public static class EntityDB
    {
        private static readonly string entitiesResourcesFolder = "DB/Entities";

        public static Entity Get<Item>(string id) where Item : Entity, IDBItem<Item, Entity>, new()
        {
            string entityFolderPath = DBItemOperations<Item, Entity>.FolderPath;
            string path = $"{entitiesResourcesFolder}/{entityFolderPath}/{id}";

            return Resources.Load<Item>(path);
        }
    }
}