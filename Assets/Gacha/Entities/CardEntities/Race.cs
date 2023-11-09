using UnityEngine;

namespace OPG.Entities
{
    using Cards;

    [CreateAssetMenu(fileName = "NewRace", menuName = "OPG Entities/Race")]
    public class Race : Entity<HorizontalCardData>
    {
        public override void DisplayInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}