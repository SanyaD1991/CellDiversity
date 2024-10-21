using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Core.Interact
{
    public class ControlScroll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {  
        [SerializeField] private RectTransform content;       
        [SerializeField] private float snapSpeed = 10f;
        [SerializeField] private ScrollbarPoint scrollbar;
        [SerializeField] private GameObject LeftButton; 
        [SerializeField] private GameObject RightButton;

        private float[] elementPositions;
        private ScrollRect scrollRect;     
        private Coroutine snapCoroutine;
        private float startPosition;
        private float endPosition;
        private int elementCount;
        private int count = 0;

        public RectTransform GetRectTransform => content;

        private void Start()
        {
            scrollRect = GetComponent<ScrollRect>();        
            elementCount = content.childCount;      
            StartCoroutine(CalculateElementPositions());           
        }

        private IEnumerator CalculateElementPositions()
        {
            elementCount = content.childCount;
            scrollbar.InitScrollbar(elementCount);
            AnaliseButton();
            yield return new WaitForSeconds(0.5f);           
            elementPositions = new float[elementCount];
          
            for (int i = 0; i < elementCount; i++)
            {
                RectTransform element = content.GetChild(i).GetComponent<RectTransform>();             
                elementPositions[i] = element.localPosition.x;
            }
        } 

        private IEnumerator SnapToPosition(int target)
        {
            if (elementCount <= 0) yield break;
                float position = elementPositions[target] - elementPositions[0];
            while (Mathf.Abs(content.anchoredPosition.x + position) > 1f)
            {
                content.anchoredPosition = Vector2.Lerp(content.anchoredPosition, new Vector2(position * -1, content.anchoredPosition.y), Time.deltaTime * snapSpeed);
                yield return null;
            }         
            content.anchoredPosition = new Vector2(position * -1, content.anchoredPosition.y);
        }


        public void OnLeft()
        {
            StopMove();
            AddCounter();
            snapCoroutine = StartCoroutine(SnapToPosition(count));
            scrollbar.Check(count);
            AnaliseButton();
        }
        public void OnRight()
        {
            StopMove();
            DecreaseCounter();
            snapCoroutine = StartCoroutine(SnapToPosition(count));
            scrollbar.Check(count);
            AnaliseButton();
        }

        private void AddCounter()
        {
            if (count < elementCount - 1) count++; 
        }
        private void DecreaseCounter() 
        {
            if (count > 0) count--;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            startPosition = content.anchoredPosition.x;
            StopMove();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            endPosition = content.anchoredPosition.x;       
            if(startPosition == endPosition) return;
            if (startPosition > endPosition)
            {
                AddCounter();
            }
            else
            {
                DecreaseCounter();
            }            
            snapCoroutine = StartCoroutine(SnapToPosition(count));
            scrollbar.Check(count);
            AnaliseButton();
        }

        private void StopMove()
        {
            if (snapCoroutine != null)
            {
                StopCoroutine(snapCoroutine);
                snapCoroutine = null;
            }
        }

        private void AnaliseButton()
        {
            if (count == 0)
            {
                RightButton.SetActive(false);
            }
            else
            {
                RightButton.SetActive(true);
            }

            if (count == elementCount -1)
            {
                LeftButton.SetActive(false);
            }
            else
            {
                LeftButton.SetActive(true);
            }
        }
    }
}
