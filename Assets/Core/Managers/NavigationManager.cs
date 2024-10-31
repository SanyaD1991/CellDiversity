using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Core.Managers
{
    public class NavigationManager : MonoBehaviour
    {
        [SerializeField] private TopPanel topPanel;
        [SerializeField] private GameObject startSlide;
        [SerializeField] private Transform hierarchy;      
        [SerializeField] private List<SlideManager> slideManagers = new List<SlideManager>();

        private Action SheduledAction;
        private bool inAction;

        private void TrySheduleAction(Action action)
        {
            if (SheduledAction == null) SheduledAction = action;
        }

        public void AddSlide(SlideManager slide, List<UnityEngine.Object> content, UnityEvent[] unityEvents)
        {
            if (inAction) return;
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
                slide.SetActionStart(unityEvents[0]);
                slide.SetActionDestroy(unityEvents[1]);
                slideManagers.Add(slide);
                AnaliseButtonnavigation();
                inAction=true;
            });
            UpdateShedule();
        }

        public void RemoveSlide()
        {
            if (inAction) return;
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
                inAction = true;
            });
            UpdateShedule();
        }

        public void HomeSlide()
        {
            if (inAction) return;
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
                inAction = true;
            });
            UpdateShedule();
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
            topPanel.ActiveAdditionalPanel(slideManagers[i].IsShowAdditionalPanel);
            
        }
       
        private void UpdateShedule()
        {
            SheduledAction?.Invoke();
            SheduledAction = null;
            inAction=false;
        }
    }
}
