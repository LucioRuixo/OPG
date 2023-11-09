using UnityEngine;

namespace OPG.Cards
{
    [ExecuteAlways]
    public class HorizontalCard : CardFormat
    {
        protected override Vector2Int cardAspectRatio => new Vector2Int(4, 3);
    }
}