using Core.Constructor;
using Core.Model.Struct;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;


namespace Core.Managers
{
    public class SlideManager : MonoBehaviour 
    {
        [SerializeField] private PropertyIdentification[] DinamicStyle;
        [SerializeField] private bool isShowAdditionalPanel = true;
        private UnityEvent EventStart;
        private UnityEvent EventDestroy;

        private void Start() 
        {
            EventStart?.Invoke();
        }
        public void SetActionStart(UnityEvent action)
        {
            EventStart = action;
        }
        public void SetActionDestroy(UnityEvent action)
        {
            EventDestroy = action;
        }

        private List<Object> content;
        public bool IsShowAdditionalPanel => isShowAdditionalPanel;
        public List<Object> GetContent => content;
        public void SetContent(List<Object> item)
        {
            content = item;
        }

        private void FindAndEditStyle()
        {
            StyleInit[] styles = FindObjectsOfType<StyleInit>();       
            for (int i = 0; i < DinamicStyle.Length; i++) 
            {
                for (int j = 0; j < styles.Length; j++)
                {
                    if (styles[j].GetIdStyle() == DinamicStyle[i].GetId)
                    {
                        styles[j].Init(DinamicStyle[i].GetStyle());
                    }
                }
            }
        }

        private void OnEnable()
        {
            FindAndEditStyle();            
        }

        private void OnDestroy()
        {
            EventDestroy?.Invoke();
        }
    }
}
