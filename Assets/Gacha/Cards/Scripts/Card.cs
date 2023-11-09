using UnityEngine;

namespace OPG.Cards
{
    using Entities;

    [ExecuteAlways, RequireComponent(typeof(Card))]
    public class Card : MonoBehaviour
    {
        [SerializeField] private string entityPath;

        private EntityBase entity;
        private GameObject formatObject;
        private FrontFace frontFace;
        private BackFace backFace;

        private void Awake()
        {
            CardFormat format = GetComponentInChildren<CardFormat>();
            if (format) formatObject ??= format.gameObject;
        }

        private void Update()
        {
            if (!entity) return;

            if (frontFace) entity.DisplayFrontInfo(frontFace);
            if (backFace) entity.DisplayBackInfo(backFace);
        }

        public void LoadEntity()
        {
            entity = Resources.Load<EntityBase>(entityPath);

            if (!entity)
            {
                LRCore.Logger.LogError(this, $"Entity could not be loaded: entity failed to load from path \"{entityPath}\"");
                return;
            }

            if (formatObject)
            {
                if (Application.isEditor) DestroyImmediate(formatObject);
                else Destroy(formatObject);

                formatObject = null;
            }

            formatObject = entity.LoadCard(transform);

            if (!formatObject)
            {
                LRCore.Logger.LogError(this, "Entity could not be loaded: card format failed to load");
                return;
            }

            CardFormat format = formatObject.GetComponent<CardFormat>();
            frontFace = format.FrontFace;
            backFace = format.BackFace;
        }
    }
}