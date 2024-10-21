using System;
using UnityEngine;

namespace Core.Model.Struct
{
    [Serializable]
    public struct GetPropertyColors
    {
        [SerializeField] private string _id;
        [SerializeField] private Color _color;


        public string Id => _id;
        public Color Color => _color;
    }
}
