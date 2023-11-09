using UnityEngine;

namespace OPG.Cards
{
    [ExecuteAlways]
    public class VerticalCard : CardFormat
    {
        protected override Vector2Int cardAspectRatio => new Vector2Int(3, 4);
    }
}