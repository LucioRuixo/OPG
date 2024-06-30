using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OPG.UI
{
    using Entities;

    public class EntityMenuButton : MonoBehaviour
    {
        public void Initialize(string text, Entity entity, EntityViewer entityViewer, Submenu source)
        {
            GetComponent<Button>().onClick.AddListener(() => entityViewer.Open(entity, source));
            GetComponentInChildren<TMP_Text>().text = text;
        }
    }
}