using Core.Interface;
using Core.Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Constructor
{    
    public class SpawnSlide : MonoBehaviour
    {
        [SerializeField] private SlideManager slide;
        [SerializeField] private List<Object> content;
        [SerializeField] private UnityEvent EventStart;
        [SerializeField] private UnityEvent EventDestroy;
        public void SetSlide(SlideManager _slide)
        {
            slide = _slide;
        }
        public void AddContent(object item)
        {          
           content.Add((Object)item);
        }

        public void OnSpawn()
        {
            UnityEvent[] unityEvents = new UnityEvent[2];
            unityEvents[0] = EventStart;
            unityEvents[1] = EventDestroy;

            NavigationManager navigation = FindObjectOfType<NavigationManager>();
            if (navigation != null) navigation.AddSlide(slide, content, unityEvents);         
        } 
    }
}
