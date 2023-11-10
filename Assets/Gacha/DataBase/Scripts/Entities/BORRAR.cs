using UnityEngine;

namespace OPG.Entities
{
    public abstract class BORRAR<CardFormat> : Entity where CardFormat : Cards.CardFormatData, new()
    {
    }
}