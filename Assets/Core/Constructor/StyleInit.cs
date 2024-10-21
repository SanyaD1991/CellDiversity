using Core.Model.Definitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;
using Unity.VisualScripting;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using Core.Model.Struct;

namespace Core.Constructor
{
    public class StyleInit : MonoBehaviour
    {
        [SerializeField] private PropertyIdentification Id;
        //[SerializeField] StyleItem item;
        [SerializeField] bool isActive;
        [SerializeField] private UnityEvent OnActive;
        [SerializeField] private UnityEvent OnDeactive;

        private Image border;
        private Image icon;
        private TextMeshProUGUI text;

        public bool IsActive => isActive;

        private void Awake()
        {
            FindImageandText();            
            Init();
        }

        private void Init()
        {
            if (isActive)
            {
                Activate(false);
            }
            else
            {
                Deactivate();
            }
        }
        public void Init(StyleItem style)
        {
            Id.SetStyle(style);
            Init();
        }

        private void FindImageandText()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
            Image[] images = GetComponentsInChildren<Image>();

            if (images.Length==0)
            {
                return;
            }
            if (images.Length > 1) icon = images[1];
            border = images[0];
        }

        private void SetImageColor(Image here, Color color)
        {
            if (here==null)
            {
                return;
            }
            here.color = color;
        }
        private void SetTextColor(TextMeshProUGUI text, Color color)
        {
            if (text==null)
            {
                return;
            }
            text.color = color;
        }      

       

        public void Activate(bool isInvoke = true)
        {
            StyleItem style = Id.GetStyle();
            if(style==null) return; 
            isActive = true;
            SetImageColor(border, style.GetActiveColorBorder.Color);
            SetImageColor(icon, style.GetActiveColorIcon.Color);
            SetTextColor(text, style.GetActiveColorText.Color);
            if (isInvoke) { OnActive?.Invoke(); }
        }

        public void Deactivate()
        {
            StyleItem style = Id.GetStyle();
            if (style == null) return;
            isActive = false;
            SetImageColor(border, style.GetDiactiveColorBorder.Color);
            SetImageColor(icon, style.GetDiactiveColorIcon.Color);
            SetTextColor(text, style.GetDiactiveColorText.Color);
            OnDeactive?.Invoke();
        }

        public int GetIdStyle()
        {
           return Id.GetId;
        }
    }
}
