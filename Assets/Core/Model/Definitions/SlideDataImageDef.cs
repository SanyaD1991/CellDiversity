using System;
using UnityEngine;

namespace Core.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/SlideDataImageDef", fileName = "SlideDataImageDef")]
    public class SlideDataImageDef : ScriptableObject
    {
        [SerializeField] GameObject Skin;
        [SerializeField] ImageContent[] contents;

        public GameObject GetSkin => Skin;
        public ImageContent[] GetContent => contents;

        [Serializable]
        public struct ImageContent
        {
            [SerializeField] private Sprite image;
            [SerializeField] private TextItem textImageDescription;

            public Sprite GetImage => image;
            public TextItem GetText => textImageDescription;
        }        
    }
}
