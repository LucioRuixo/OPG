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
        static public event Action<CardDataBase[], Entity[]> OnRollProcessedEvent;

		public static void ProcessRoll(CardDataBase[] rolledCards, ref ProgressionProfile progressionProfile)
        {
            List<CardDataBase> newRolledCards = new List<CardDataBase>();
            List<Entity> unlockedEntities = new List<Entity>();

            for (int i = 0; i < rolledCards.Length; i++)
            {
                CardDataBase rolledCard = rolledCards[i];
                ProcessEntity(rolledCard, ref unlockedEntities, ref progressionProfile);
                ProcessCard(rolledCard, ref newRolledCards, ref progressionProfile);
            }

            OnRollProcessedEvent?.Invoke(newRolledCards.ToArray(), unlockedEntities.ToArray());
        }

        private static void ProcessCard(CardDataBase card, ref List<CardDataBase> newRolledCards, ref ProgressionProfile progressionProfile)
        {
            if (progressionProfile.WasCardRolled(card.ID)) return;

            progressionProfile.RegisterRolledCard(card);
            if (!newRolledCards.Contains(card)) newRolledCards.Add(card);
        }

        private static void ProcessEntity(CardDataBase card, ref List<Entity> unlockedEntities, ref ProgressionProfile progressionProfile)
        {
            string entityID = card.EntityID;

            if (progressionProfile.IsEntityUnlocked(entityID)) return;

            Entity entity = card.GetEntity();
            progressionProfile.UnlockEntity(entityID, entity);

            if (!unlockedEntities.Contains(entity)) unlockedEntities.Add(entity);
        }
    }
}