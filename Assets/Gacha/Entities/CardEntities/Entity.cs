using UnityEngine;

namespace OPG.Entities
{
    public abstract class Entity<CardFormat> : EntityBase where CardFormat : Cards.CardFormatData, new()
    {
        public override GameObject LoadCard(Transform target)
        {
            string prefabPath = new CardFormat().PrefabPath;
            GameObject cardPrefab = Resources.Load<GameObject>(prefabPath);

            if (!cardPrefab)
            {
                LRCore.Logger.LogError(this, $"Could not load card: card prefab failed to load from path \"{prefabPath}\"");
                return null;
            }

            return Instantiate(cardPrefab, target);
        }
    }
}