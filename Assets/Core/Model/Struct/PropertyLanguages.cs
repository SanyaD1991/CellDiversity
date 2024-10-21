using Core.Model.Definitions.Attribute;
using System;
using UnityEngine;

namespace Core.Model.Struct
{
    [Serializable]
    public struct PropertyLanguages
    {
        [LanguagesId][SerializeField] private string _id;
        [TextArea(3, 10)][SerializeField] private string _value;

        public string Value => _value;
    }
}
