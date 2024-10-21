using Core.Model.Struct;
using System;
using UnityEngine;


namespace Core.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/PropertyLanguagesDef", fileName = "PropertyLanguagesDef")]
    [Serializable]
    public class PropertyLanguagesDef : ScriptableObject
    {
        [SerializeField] private GetPropertyLanguages[] _properties;
        public Sprite GetIcon(string id)
        {
            for (int i = 0; i < _properties.Length; i++)
            {
                if (_properties[i].Id == id)
                {
                    return _properties[i].Icon;
                }
            }
            return default;
        }


#if UNITY_EDITOR
        public GetPropertyLanguages[] PropertyForEditor => _properties;
#endif
    }
}