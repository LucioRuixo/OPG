using UnityEngine;

namespace OPG.Entities
{
    public abstract class Entity<CardFormat> : EntityBase where CardFormat : Cards.CardFormatData, new()
    {
        public override GameObject LoadCard(Transform target)
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