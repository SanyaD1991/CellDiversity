using System.Collections.Generic;
using UnityEngine;

namespace Core.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private PropertyLanguagesDef _propertyLanguages;
        [SerializeField] private PropertyColorsDef _propertyColors;
        [SerializeField] private PropertyIdentificationDef _propertyIdentification;
        [SerializeField] private PropertyItemDef _propertyItems;

        public PropertyColorsDef Colors => _propertyColors;
        public PropertyLanguagesDef Languages => _propertyLanguages;
        public PropertyIdentificationDef Identities => _propertyIdentification;
        public PropertyItemDef Items => _propertyItems;

        public SlideDataButtonsDef GetData(GroupItem group)
        {
            return _propertyItems.GetData(group);
        }

        public List<SlideDataButtonsDef> GetData()
        {
            return _propertyItems.GetData();
        }

        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDef() : _instance;
        private static DefsFacade LoadDef()
        {
            return _instance = Resources.Load<DefsFacade>("DefsFacade");
        }
    }
}
