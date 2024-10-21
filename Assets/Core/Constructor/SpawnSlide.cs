using Core.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Constructor
{    
    public class SpawnSlide : MonoBehaviour
    {
        [SerializeField] private SlideManager slide;
        [SerializeField] private List<Object> content;

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
            NavigationManager navigation = FindObjectOfType<NavigationManager>();
            if (navigation != null) navigation.AddSlide(slide, content);
        }
    }
}
