using Core.Model.Definitions;
using Core.Model.Definitions.Attribute;
using System;
using UnityEngine;

namespace Core.Model.Struct
{
    [Serializable]
    public struct PropertyColors
    {
        [ColorsId][SerializeField] private string _id;      
        public string Id=>_id;
        public Color Color => DefsFacade.I.Colors.GetColor(_id);
    }
}
