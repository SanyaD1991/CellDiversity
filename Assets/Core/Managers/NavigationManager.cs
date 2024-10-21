using System;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Managers
{
    public class NavigationManager : MonoBehaviour
    {
        [SerializeField] private TopPanel topPanel;
        [SerializeField] private GameObject startSlide;
        [SerializeField] private Transform hierarchy;      
        [SerializeField] private List<SlideManager> slideManagers = new List<SlideManager>();

        private Action SheduledAction;
        private void Update()
        {
            if (SheduledAction == null) return;
            SheduledAction.Invoke();
            SheduledAction = null;
        }

        public void AddSlide(SlideManager slide, List<UnityEngine.Object> content)
        {
            TrySheduleAction(() =>
            {
                if (slideManagers.Count > 0)
                {
                    slideManagers[slideManagers.Count - 1].gameObject.SetActive(false);
                }
                else
                {
                    if (startSlide != null) startSlide.SetActive(false);
                }
                slide = Instantiate(slide, hierarchy.transform);               
                slide.SetContent(content);
                slideManagers.Add(slide);
                AnaliseButtonnavigation();
            });
        }

        public void RemoveSlide()
        {
            TrySheduleAction(() =>
            {
                int Count = slideManagers.Count - 1;
                if (slideManagers.Count > 1 && slideManagers[Count] != null)
                {
                    slideManagers[slideManagers.Count - 2].gameObject.SetActive(true);
                    Destroy(slideManagers[Count].gameObject);
                    slideManagers.RemoveAt(Count);
                }
                AnaliseButtonnavigation();
                topPanel.UpdateText();
            });
        }

        public void HomeSlide()
        {
            TrySheduleAction(() =>
            {
                SlideManager slideHome = slideManagers[0];
                for (int i = 1; i < slideManagers.Count; i++)
                {
                    Destroy(slideManagers[i].gameObject);
                }
                slideManagers.Clear();
                slideManagers.Add(slideHome);
                slideHome.gameObject.SetActive(true);
                AnaliseButtonnavigation();
                topPanel.UpdateText();
            });
        }  
    
        private void AnaliseButtonnavigation()
        {
            if (slideManagers.Count > 1)
            {
                topPanel.ActiveButtonNavigation(true);
            }
            else
            {
                topPanel.ActiveButtonNavigation(false);
            }          
            int i = slideManagers.Count - 1;
            topPanel.ActiveAdditionalPanel(slideManagers[i].isShowAdditionalPanel);
            
        }

        private void TrySheduleAction(Action action)
        {
            if (SheduledAction == null) SheduledAction = action;
        }       
    }
}
