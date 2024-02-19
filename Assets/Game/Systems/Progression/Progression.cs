using UnityEngine;

namespace OPG.Progression
{
    using Cards;
    using Entities;
    using ProgressionProfiles;

    public class Progression : MonoBehaviour
    {
		public static void ProcessRoll(CardDataBase[] rolledCards, ref ProgressionProfile progressionProfile)
        {
            for (int i = 0; i < rolledCards.Length; i++)
            {
                CardDataBase rolledCard = rolledCards[i];
                string entityID = rolledCard.EntityID;

                if (!progressionProfile.EntitiesByID.ContainsKey(entityID))
                {
                    Entity entity = rolledCard.GetEntity();
                    progressionProfile.EntitiesByID.Add(entityID, entity);
                }
            }
        }
    }
}