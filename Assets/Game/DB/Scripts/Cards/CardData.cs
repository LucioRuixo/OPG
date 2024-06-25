using UnityEngine;

namespace OPG.Cards
{
    /// <summary>
    /// Entity and format specifying base class for card assets.
    /// </summary>
    /// <typeparam name="Entity">The type of entity this card portrays.</typeparam>
    /// <typeparam name="CardFormat">The type of format of this card (vectical, horizontal).</typeparam>
    public abstract class CardData<Entity, CardFormat> : CardDataBase where Entity : Entities.Entity where CardFormat : CardFormatData, new()
    {
        /// <summary>
        /// The entity this card portrays.
        /// </summary>
        protected Entity _Entity => (Entity)GenericEntity;

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