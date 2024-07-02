using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    [CreateAssetMenu(fileName = "NewSaga", menuName = "OPG Cards/Saga")]
    public class Saga : ScriptableObject, INameable
    {
        [SerializeField] new private string name;
        public string Name => name;

        [SerializeField] private string lastEpisode;
        public string LastEpisode => lastEpisode;
    }
}