using System;
using System.Collections.Generic;
using UnityEngine;

namespace OPG.Progression
{
    using Cards;
    using Entities;
    using ProgressionProfiles;

    public class Progression : MonoBehaviour
    {
        static public event Action<Entity[]> OnRollProcessedEvent;

		public static void ProcessRoll(CardDataBase[] rolledCards, ref ProgressionProfile progressionProfile)
        {
            List<Entity> unlockedEntities = new List<Entity>();

            for (int i = 0; i < rolledCards.Length; i++)
            {
                CardDataBase rolledCard = rolledCards[i];
                string entityID = rolledCard.EntityID;

                if (!progressionProfile.IsEntityUnlocked(entityID))
                {
                    Entity entity = rolledCard.GetEntity();
                    progressionProfile.UnlockEntity(entityID, entity);

                    if (!unlockedEntities.Contains(entity)) unlockedEntities.Add(entity);
                }
            }

            OnRollProcessedEvent?.Invoke(unlockedEntities.ToArray());
        }
    }
}