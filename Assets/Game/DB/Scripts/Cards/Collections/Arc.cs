using UnityEngine;

namespace OPG.Cards
{
    using Utils;

    [CreateAssetMenu(fileName = "NewArc", menuName = "OPG Cards/Arc")]
    public class Arc : ScriptableObject, INameable
    {
        [SerializeField] new private string name;
        public string Name => name;

        [SerializeField] private string lastEpisode;
        public string LastEpisode => lastEpisode;

        [SerializeField] private Saga saga;
        public Saga Saga => saga;
    }
}