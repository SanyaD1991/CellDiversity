using System;
using UnityEngine;

namespace Core.Model.Struct
{
    [Serializable]
    public struct GetPropertyIdentification
    {
        [SerializeField] private string _id;
        public string Id => _id;       
    }
}
