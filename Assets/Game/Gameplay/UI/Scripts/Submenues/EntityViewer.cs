using System.Collections.Generic;
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

        private ProgressionProfileHandler ppHandler;

        private Entity lastEntity;

        private List<TMP_Text> infoFields = new List<TMP_Text>();

        public void Initialize(ProgressionProfileHandler ppHandler) => this.ppHandler = ppHandler;

        public void Open(Entity entity, Submenu source)
        {
            lastEntity = entity;

            Open(source);
        }

        public override void UpdateContent()
        {
            imageField.sprite = ppHandler.EntityProgressionsByID[lastEntity.ID].MainImage;

            nameField.text = lastEntity.DisplayName;

            IDescriptions descriptedEntity = (IDescriptions)lastEntity;
            if (descriptedEntity != null)
            {
                descriptionField.gameObject.SetActive(true);
                descriptionField.text = descriptedEntity.SelectedDescription;
            }
            else descriptionField.gameObject.SetActive(false);

            InstantiateInfoFields();
        }

        private void InstantiateInfoFields()
        {
            foreach (TMP_Text infoField in infoFields) Destroy(infoField.gameObject);
            infoFields.Clear();

            string[] infoTexts = lastEntity.GetInfoTexts();
            for (int i = 0; i < infoTexts.Length; i++)
            {
                TMP_Text infoField = Instantiate(UIUtils.GetMenuTextFieldPrefab(), infoFieldContainer).GetComponent<TMP_Text>();
                infoField.text = infoTexts[i];
                infoField.fontSize = InfoFontSize;

                infoFields.Add(infoField);
            }
        }
    }
}