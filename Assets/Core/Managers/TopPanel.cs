using Core.Find;
using Core.Interact;
using UnityEngine;
namespace Core.Managers
{
    public class TopPanel : MonoBehaviour
    {
        [SerializeField] private GameObject[] buttonNavigation;
        [SerializeField] private GameObject additionalPanel;
        [SerializeField] private ControlAnimation controlAnimation;
        [SerializeField] private CheckPanel checkPanel;
        [SerializeField] private FindLanguagesText findLanguagesText;

        private bool isShow = true;

        private void Start()
        {
            checkPanel.Check(PlayerPrefsContainer.GetLanguages);
        }
        public void ActiveButtonNavigation(bool isActive)
        {
            foreach (GameObject buttons in buttonNavigation)
            {
                buttons.SetActive(isActive);
            }
        }

        public void UpdateText()
        {
            findLanguagesText.FindText(PlayerPrefsContainer.GetLanguages);
        }

        public void ShowPanel()
        {
            isShow = true;
            controlAnimation.PlayAnimationl("Show");
            print(isShow);
        }

        public void HidePanel()
        {
            isShow = false;
            controlAnimation.PlayAnimationl("Hide");
            print(isShow);
        }

        public void OnAnaliseShow()
        {
            if (!isShow) ShowPanel();
        }

        public void ActiveAdditionalPanel(bool isActive)
        {
            additionalPanel.SetActive(isActive);
        }
    }

}