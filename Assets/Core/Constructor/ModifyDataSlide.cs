using Core.Data;
using Core.Interface;
using Core.Model.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Constructor
{
    public class ModifyDataSlide : MonoBehaviour, IConstructor
    {
        [SerializeField] private GroupItem group;
        private Button[] buttons;

        public void Init(Transform backgraund, Transform interactive)
        {
            buttons = interactive.GetComponentsInChildren<Button>();          
            SlideDataButtonsDef dataDef = DefsFacade.I.GetData(group);
            SlideDataButtonsDef.Content[] content = dataDef.GetContentButtons;
            
            if(content.Length!= buttons.Length) return;
            
            for (int i=0; i < buttons.Length; i++)
            {
                DataContentInfo data = buttons[i].gameObject.AddComponent<DataContentInfo>();
                data.SetTextLabel(content[i].GetText);
                data.SetTextDescription(content[i].GetDescription);
                data.SetDataImageDef(content[i].GetImageContent);

                SpawnSlide spawnSlide = buttons[i].GetComponent<SpawnSlide>();
                spawnSlide.AddContent(data);
                spawnSlide.SetSlide(content[i].GetSlide);
            }
        }
    }
}