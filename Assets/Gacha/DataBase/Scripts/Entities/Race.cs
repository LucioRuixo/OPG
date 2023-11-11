using UnityEngine;

namespace OPG.Entities
{
    [CreateAssetMenu(fileName = "NewRace", menuName = "OPG Entities/Race")]
    public class Race : Entity
    {
        protected override string ListedPrefix => "Race";
    }
}