using Core.Constructor;
using Core.Interface;
using Core.Model.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interact
{
    public class ControlImage : MonoBehaviour, IContent
    {
        [SerializeField] private Image icon;
        [SerializeField] private LanguagesInit label;

        public void SetImage(Sprite iconImage)
        {
            icon.sprite = iconImage;
        }

        public void SetText(TextItem text)
        {
            label.SetText(text);
        }
    }
}
