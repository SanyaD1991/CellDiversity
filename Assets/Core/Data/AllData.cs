using Core.Constructor;
using Core.Interface;
using Core.Managers;
using Core.Model.Definitions;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Core.Model.Definitions.SlideDataButtonsDef;

namespace Core.Data
{
    public class AllData : MonoBehaviour, IConstructor
    {
        [SerializeField] private GameObject _button;
        [SerializeField] private SlideManager _slide;
        private List<DataContentInfo> dataContent = new();

        public List<DataContentInfo> GetData => dataContent;
        public void Init(Transform backgraund, Transform interactive)
        {
            List<SlideDataButtonsDef> data = DefsFacade.I.GetData();
            foreach (SlideDataButtonsDef dataDef in data)
            {
                foreach (Content content in dataDef.GetContentButtons)
                {
                    GameObject button = Instantiate(_button, interactive);                   
                    button.GetComponentInChildren<LanguagesInit>().SetText(content.GetText);
                    button.GetComponentInChildren<SpawnSlide>().SetSlide(_slide);
                    DataContentInfo dataContentInfo = button.GetComponentInChildren<SpawnSlide>().AddComponent<DataContentInfo>();
                    dataContentInfo.SetTextLabel(content.GetText);
                    dataContentInfo.SetDataImageDef(content.GetImageContent);
                    dataContentInfo.SetTextDescription(content.GetDescription);
                    dataContent.Add(dataContentInfo);
                    button.GetComponentInChildren<SpawnSlide>().AddContent(dataContentInfo);
                }
            }
        }
    }
}
