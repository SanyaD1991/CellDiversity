using Core.Managers;
using System;
using UnityEngine;

namespace Core.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/SlideDataButtensDef", fileName = "SlideDataButtensDef")]
    public class SlideDataButtonsDef : ScriptableObject
    {
        [SerializeField] private GroupItem group;
        [SerializeField] private GameObject button;
        [SerializeField] private Content[] contentButtons;

        public bool CompareGroup(GroupItem groupItem) => group == groupItem;

        public GameObject GetButton => button;
        public Content[] GetContentButtons => contentButtons;


        [Serializable]
        public struct Content
        {
            [SerializeField] private TextItem item;
            [SerializeField] private Vector3 position;
            [SerializeField] private SlideManager slideManager;
            [SerializeField] private TextItem description;
            [SerializeField] private SlideDataImageDef imageContent;

            public TextItem GetDescription => description;
            public SlideManager GetSlide => slideManager;
            public TextItem GetText => item;
            public Vector3 Position => position;
            public SlideDataImageDef GetImageContent => imageContent;
        }
    }
}
