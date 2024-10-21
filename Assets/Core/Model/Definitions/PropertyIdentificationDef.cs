using Core.Model.Struct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/PropertyIdentificationDef", fileName = "PropertyIdentificationDef")]
    public class PropertyIdentificationDef : ScriptableObject
    {
        [SerializeField] private GetPropertyIdentification[] _properties;
        public int GetId(string id)
        {
            for (int i = 0; i < _properties.Length; i++)
            {
                if (_properties[i].Id == id)
                {
                    return i;
                }
            }
            return default;
        }

#if UNITY_EDITOR
        public GetPropertyIdentification[] PropertyForEditor => _properties;
#endif

    }
}
