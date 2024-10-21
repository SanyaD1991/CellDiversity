using Core.Model.Definitions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core.Constructor
{
    public enum TypeText
    {
        Label,
        Description,
        DescriptionImage
    }
    public class LanguagesInit : MonoBehaviour
    {
        [SerializeField] TypeText typeText;
        [SerializeField] TextItem item;
        private TextMeshProUGUI textName;
        public TypeText GetTypeText => typeText;
        public TextItem GetItem => item;
        private void Start()
        {
            textName = GetComponentInChildren<TextMeshProUGUI>();
            Init();
        }

        public void SetText(TextItem text)
        {
            item = text;
        }
        public void Init()
        {
            if (item == null) return;
            string text = item.GetText();
            if (text != null) textName.text = text;
        }
    }
}
