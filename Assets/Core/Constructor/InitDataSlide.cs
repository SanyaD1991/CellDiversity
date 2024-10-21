using Core.Interface;
using Core.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Constructor
{
    public class InitDataSlide : MonoBehaviour
    {        
        [SerializeField] private Transform background;
        [SerializeField] private Transform interactive;

        public Transform GetBackgroundTransform => background;
        public Transform GetInteractiveTransform => interactive;

        private void Start()
        {
            SlideManager slideManager = GetComponent<SlideManager>();
            AllInit(slideManager.GetContent);
        }

        private void AllInit(List<Object> contents)
        {
            foreach (var content in contents)
            {               
                if (content is IConstructor constructor)
                {
                    constructor.Init(background, interactive);
                }
            } 
        }
    }
}
