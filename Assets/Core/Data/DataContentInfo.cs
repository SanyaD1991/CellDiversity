using Core.Constructor;
using Core.Interface;
using Core.Managers;
using Core.Model.Definitions;
using UnityEngine;
using TMPro;
using static Core.Model.Definitions.SlideDataButtonsDef;
using System.Collections.Generic;
using System.Linq;
using Core.Interact;
using static Core.Model.Definitions.SlideDataImageDef;

namespace Core.Data
{
    public class DataContentInfo : MonoBehaviour, IConstructor
    {       
        private TextItem label;
        private TextItem description;
        private SlideDataImageDef dataImage;

        public TextItem GetDescription => description;

        public void SetTextDescription(TextItem textItem)
        {           
            description = textItem;
        }

        public void SetTextLabel(TextItem textItem)
        {
            label = textItem;
        }

        public void SetDataImageDef(SlideDataImageDef data)
        {
            dataImage = data;
        }

        public void Init(Transform backgraund, Transform interactive)
        {
            List<LanguagesInit> languages = backgraund.GetComponentsInChildren<LanguagesInit>().ToList();       
            languages.AddRange(interactive.GetComponentsInChildren<LanguagesInit>().ToList());
           
            foreach (LanguagesInit language in languages) 
            {               
                switch (language.GetTypeText)
                {
                    case TypeText.Label:
                        if (label != null) language.SetText(label);
                    break;

                    case TypeText.Description:
                        if (description != null) language.SetText(description);
                    break;
                }            
            }
            if(dataImage == null)return;

            ControlScroll control = interactive.GetComponentInChildren<ControlScroll>();
            foreach (ImageContent data in dataImage.GetContent)
            {
                IContent contentObject = Instantiate(dataImage.GetSkin, control.GetRectTransform).GetComponent<IContent>();
                contentObject.SetText(data.GetText);
                contentObject.SetImage(data.GetImage);
            }
        }
    }
}
