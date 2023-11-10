using System;

namespace OPG.Entities
{
    using Cards;

    [Serializable]
    public class Location : BORRAR<HorizontalCardData>
    {
        protected override string ListedPrefix => "Location";

        //public override void DisplayFrontInfo(FrontFace frontFace)
        //{
        //    throw new NotImplementedException();
        //}
        //
        //public override void DisplayBackInfo(BackFace backFace)
        //{
        //    throw new NotImplementedException();
        //}
    }
}