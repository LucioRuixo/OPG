using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OPG.UI
{
    using Entities;
    using ProgressionProfiles;
    using Utils;
    using Utils.UI;

    public class EntityViewer : Submenu
    {
        #region Constants
        private const float InfoFontSize = 25f;
        #endregion

        [Space]

        [SerializeField] private Image imageField;
        [SerializeField] private TMP_Text nameField;
        [SerializeField] private TMP_Text descriptionField;

        [Space]

        [SerializeField] private RectTransform infoFieldContainer;

        private ProgressionProfile progressionProfile;

        public void Initialize(ProgressionProfile progressionProfile) => this.progressionProfile = progressionProfile;

        public void Open(Entity entity)
        {
            Open();

            imageField.sprite = progressionProfile.EntityProgressionsByID[entity.ID].MainImage;

            nameField.text = entity.DisplayName;

            IDescriptions descriptedEntity = (IDescriptions)entity;
            if (descriptedEntity != null)
            {
                descriptionField.gameObject.SetActive(true);
                descriptionField.text = descriptedEntity.SelectedDescription;
            }
            else descriptionField.gameObject.SetActive(false);

            string[] infoTexts = entity.GetInfoTexts();
            for (int i = 0; i < infoTexts.Length; i++)
            {
                TMP_Text infoField = Instantiate(UIUtils.GetMenuTextFieldPrefab(), infoFieldContainer).GetComponent<TMP_Text>();
                infoField.text = infoTexts[i];
                infoField.fontSize = InfoFontSize;
            }
        }
    }
}