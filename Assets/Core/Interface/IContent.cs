using Core.Constructor;
using Core.Model.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interface
{
    public interface IContent 
    {
        public void SetImage(Sprite iconImage);
        public void SetText(TextItem text);
    }
}
