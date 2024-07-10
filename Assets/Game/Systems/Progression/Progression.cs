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

        static public void ProcessEpisodeLog(int logCount, ProgressionProfileHandler ppHandler) => ppHandler.LogEpisodes(logCount);

        static public void ProcessRoll(CardDataBase[] rolledCards, ProgressionProfileHandler ppHandler)
        {
            List<CardDataBase> newRolledCards = new List<CardDataBase>();
            List<Entity> unlockedEntities = new List<Entity>();

            for (int i = 0; i < rolledCards.Length; i++)
            {
                CardDataBase rolledCard = rolledCards[i];
                ProcessEntity(rolledCard, ref unlockedEntities, ppHandler);
                ProcessCard(rolledCard, ref newRolledCards, ppHandler);
            }

            OnRollProcessedEvent?.Invoke(newRolledCards.ToArray(), unlockedEntities.ToArray());
        }

        static private void ProcessCard(CardDataBase card, ref List<CardDataBase> newRolledCards, ProgressionProfileHandler ppHandler)
        {
            if (ppHandler.WasCardRolled(card.ID)) return;

            ppHandler.RegisterRolledCard(card);
            if (!newRolledCards.Contains(card)) newRolledCards.Add(card);
        }

        static private void ProcessEntity(CardDataBase card, ref List<Entity> unlockedEntities, ProgressionProfileHandler ppHandler)
        {
            string entityID = card.EntityID;

            if (ppHandler.IsEntityUnlocked(entityID)) return;

            Entity entity = card.GetEntity();
            ppHandler.UnlockEntity(entityID, entity);

            if (!unlockedEntities.Contains(entity)) unlockedEntities.Add(entity);
        }
    }
}