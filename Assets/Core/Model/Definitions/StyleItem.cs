using Core.Model.Struct;
using Unity.Properties;
using UnityEngine;

namespace Core.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/StyleItem", fileName = "StyleItem")]
    public class StyleItem : ScriptableObject
    {          

        [Header("Active Color")]
        [SerializeField] private PropertyColors ActiveColorIcon;
        [SerializeField] private PropertyColors ActiveColorBorder;
        [SerializeField] private PropertyColors ActiveColorText;
        [Header("Diactive Color")]
        [SerializeField] private PropertyColors DiactiveColorIcon;
        [SerializeField] private PropertyColors DiactiveColorBorder;
        [SerializeField] private PropertyColors DiactiveColorText;
       
              
        public PropertyColors GetActiveColorIcon => ActiveColorIcon;
        public PropertyColors GetActiveColorBorder => ActiveColorBorder;
        public PropertyColors GetActiveColorText => ActiveColorText;
        public PropertyColors GetDiactiveColorIcon => DiactiveColorIcon;
        public PropertyColors GetDiactiveColorBorder => DiactiveColorBorder;
        public PropertyColors GetDiactiveColorText => DiactiveColorText;    
           
    }
        
       
    
}
