using UnityEngine;

namespace OPG.Entities
{
    using Cards;

    [CreateAssetMenu(fileName = "NewRace", menuName = "OPG Entities/Race")]
    public class Race : Entity<HorizontalCardData>
    {
        protected override string ListedPrefix => "Race";

        public override void DisplayFrontInfo(FrontFace frontFace)
        {
            throw new System.NotImplementedException();
        }

        public override void DisplayBackInfo(BackFace backFace)
        {
            throw new System.NotImplementedException();
        }
    }
}