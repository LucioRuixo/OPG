using System;
using System.Collections.Generic;
using UnityEngine;

namespace OPG.ProgressionProfiles
{
    using Entities;

    [Serializable]
    public class EntityProgression
    {
        [SerializeField] private Entity entity;
        public Entity Entity { get => entity; private set => entity = value; }

        [SerializeField] private Sprite mainImage;
        public Sprite MainImage { get => mainImage; private set => mainImage = value; }

        [SerializeField] private List<Sprite> images = new List<Sprite>();
        public List<Sprite> Images { get => images; private set => images = value; }

        public EntityProgression(Entity entity) => Entity = entity;

        public void AddImage(Sprite image)
        {
            Images.Add(image);
            if (!MainImage) MainImage = image;
        }

        public void SetMainImage(int imageIndex)
        {
            if (imageIndex < 0 || imageIndex >= Images.Count) return;

            MainImage = Images[imageIndex];
        }
    }
}