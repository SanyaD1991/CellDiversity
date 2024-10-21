using Core.Model.Definitions.Attribute;
using Core.Model.Definitions;
using UnityEngine;
using System;

namespace Core.Model.Struct
{
    [Serializable]
    public class PropertyIdentification
    {
        [IdentificationId][SerializeField] private string _id;
        [SerializeField] private StyleItem _style;
        public StyleItem GetStyle() => _style;
        public int GetId => DefsFacade.I.Identities.GetId(_id);
        public void SetStyle(StyleItem style)
        {
            _style = style;
        }
    }
}
