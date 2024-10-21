using Core.Model.Struct;
using UnityEngine;

namespace Core.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/TextItem", fileName = "TextItem")]
    public class TextItem : ScriptableObject
    {       
        [SerializeField] private PropertyLanguages[] properties;
        public string GetText()
        {
            var languages = PlayerPrefsContainer.GetLanguages;
            if (properties.Length > languages)
            {
                return properties[languages].Value;
            }
            return null;
        }
    }
}
