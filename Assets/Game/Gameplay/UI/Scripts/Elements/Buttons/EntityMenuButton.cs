using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OPG.UI
{
    using Entities;

    public class EntityMenuButton : MonoBehaviour
    {
        public void Initialize(string text, Entity entity, EntityViewer entityViewer)
        {
            GetComponent<Button>().onClick.AddListener(() => entityViewer.Open(entity));
            GetComponentInChildren<TMP_Text>().text = text;
        }
    }
}