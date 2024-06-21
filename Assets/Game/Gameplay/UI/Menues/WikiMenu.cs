using TMPro;
using UnityEngine;

namespace OPG.UI
{
    using Entities;
    using Progression;

    public class WikiMenu : Menu
    {
        [Space]

        [SerializeField] private RectTransform entities;

        [Space]

        [SerializeField] private GameObject buttonPrefab;

        private void Awake() => Progression.OnRollProcessedEvent += OnRollProcessed;

        private void OnDestroy() => Progression.OnRollProcessedEvent -= OnRollProcessed;

        private void OnRollProcessed(Entity[] unlockedEntities)
        {
            if (unlockedEntities.Length == 0) return;

            for (int i = 0; i < unlockedEntities.Length; i++)
            {
                TextMeshProUGUI newEntity = Instantiate(buttonPrefab, entities).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                newEntity.text = unlockedEntities[i].DisplayName;
            }
        }
    }
}