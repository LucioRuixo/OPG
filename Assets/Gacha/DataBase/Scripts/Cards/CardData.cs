using UnityEngine;

namespace OPG.Cards
{
    public abstract class CardData<Entity, CardFormat> : CardDataBase where Entity : Entities.Entity where CardFormat : CardFormatData, new()
    {
        [SerializeField] protected Entity entity;

        public override GameObject LoadFormat(Transform target)
        {
            string formatPrefabPath = new CardFormat().PrefabPath;
            GameObject formatdPrefab = Resources.Load<GameObject>(formatPrefabPath);

            if (!formatdPrefab)
            {
                LRCore.Logger.LogError(this, $"Could not load card: card format prefab failed to load from path \"{formatPrefabPath}\"");
                return null;
            }

            return Instantiate(formatdPrefab, target);
        }
    }
}