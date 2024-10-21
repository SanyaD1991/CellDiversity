using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Core.Interact
{
    public class SwitchAction : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnEnabled;
        [SerializeField] private UnityEvent OnDisabled;
        private bool isCheck;
        private bool isBlock;


        public void OnSwitch()
        {
            StartCoroutine(InvokeAction());
        }

        private IEnumerator InvokeAction()
        {
            if (isBlock) yield break;
            isBlock = true;
            if (!isCheck)
            {  
                OnDisabled?.Invoke(); 
            }
            else
            {
                OnEnabled?.Invoke();
            }            
            isCheck = !isCheck;
            yield return new WaitForSeconds(1);
            isBlock = false;
        }
    }
}
