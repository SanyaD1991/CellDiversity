using System;
using UnityEngine;

namespace Core.Model.Struct
{
    [Serializable]
    public struct GetPropertyLanguages
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;      
        

        public string Id => _id;
        public Sprite Icon => _icon;       
    }
}
