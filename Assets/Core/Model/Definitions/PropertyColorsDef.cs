using Core.Model.Struct;
using System;
using UnityEngine;


namespace Core.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/PropertyColorsDef", fileName = "PropertyColorsDef")]
    [Serializable]
    public class PropertyColorsDef : ScriptableObject
    {
        [SerializeField] private GetPropertyColors[] _properties;
    

#if UNITY_EDITOR
        public GetPropertyColors[] PropertyForEditor => _properties;
#endif

        public Color GetColor(string id)
        {
            foreach (var property in _properties)
            {
                if (property.Id == id)
                {
                    return property.Color;
                }
            }
            return Color.white;
        }
    }
}