using Core.Constructor;
using Core.Interface;
using Core.Model.Definitions;
using UnityEngine;
using UnityEngine.UI;
using static Core.Model.Definitions.SlideDataButtonsDef;

namespace Core.Data
{   
    public class DataContentButtons : MonoBehaviour, IConstructor
    {
        [SerializeField] private GroupItem group;
        [SerializeField] private Button mainButton;

        public void Init(Transform backgraund, Transform interactive)
        {
            InstantiatemainLogo(backgraund);
            SlideDataButtonsDef data = DefsFacade.I.GetData(group);
            foreach (Content content in data.GetContentButtons)
            {
              GameObject button = Instantiate(data.GetButton, interactive);
              button.transform.localPosition = content.Position;
              button.GetComponent<LanguagesInit>().SetText(content.GetText);
            }
        }

        private void InstantiatemainLogo(Transform backgraund)
        {
            GameObject main = Instantiate(mainButton.gameObject, backgraund);
            main.transform.localPosition = new Vector3(660, 0, 0);
            main.GetComponent<Button>().interactable=false;
        }
    }
}

