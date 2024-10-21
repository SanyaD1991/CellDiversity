using Core.Data;
using Core.Model.Definitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Core.Managers;

namespace Core.Find
{
    public class SearchText : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private List<DataContentInfo> dataContent = new();
        [SerializeField] private Transform UIContent;
        [SerializeField] private Transform UItempContent;
        

        private void Start()
        {
            if (inputField != null)
            {
                inputField.onValueChanged.AddListener(OnValueChanged);
                inputField.onEndEdit.AddListener(OnEndEdit);
                inputField.onSubmit.AddListener(OnSubmit);
                inputField.onSelect.AddListener(OnSelect);
            }
            //  dataContent = FindObjectOfType<AllData>().GetData;
        }

        //public List<Description> SearchDescriptions(string searchTerm)
        //{
        //    List<Description> results = new List<Description>();

        //    //foreach (var desc in descriptions)
        //    //{
        //    //    if (desc != null && desc.descriptionText.ToLower().Contains(searchTerm.ToLower()))
        //    //    {
        //    //        results.Add(desc);
        //    //    }
        //    //}

        //    return results;
        //}

        // Метод, который будет вызван при изменении текста
        private void OnValueChanged(string text)
        {
            Debug.Log("Текст изменен: " + text);
        }

        // Метод, который будет вызван при завершении редактирования
        private void OnEndEdit(string text)
        {
            Debug.Log("Редактирование завершено: " + text);
        }

        // Метод для обработки отправки
        private void OnSubmit(string text)
        {
            Search(text);
            Debug.Log("Отправка текста: " + text);
        }

        // Метод для выделения
        private void OnSelect(string text)
        {
            if (dataContent.Count == 0)
            {
                dataContent = FindObjectOfType<AllData>().GetData;
            }
        }

        private void Search(string text)
        {
            foreach (DataContentInfo content in dataContent) 
            {
                if (content.GetDescription.GetText().ToLower().Contains(text.ToLower()))
                {
                    content.transform.parent.SetParent(UIContent);
                   // content.gameObject.SetActive(true);
                }
                else
                {
                    content.transform.parent.SetParent(UItempContent);
                   // content.gameObject.SetActive(false);
                }
            }
        }
    }
}