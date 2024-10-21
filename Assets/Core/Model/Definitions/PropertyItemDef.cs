using System.Collections.Generic;
using UnityEngine;

namespace Core.Model.Definitions
{
    public enum GroupItem
    {
        Bacterium,
        Archaea,
        Protozoa,
        Mushrooms,
        Microalgae
    }
    [CreateAssetMenu(menuName = "Defs/PropertyItemDef", fileName = "PropertyItemDef")]
    public class PropertyItemDef : ScriptableObject
    {
        [SerializeField] private SlideDataButtonsDef[] slideDataButtonsDefs;

        public List<SlideDataButtonsDef> GetData()
        {
            List<SlideDataButtonsDef> data = new List<SlideDataButtonsDef>();
            foreach (var def in slideDataButtonsDefs)
            {
                data.Add(def);              
            }
            return data;
        }
        public SlideDataButtonsDef GetData(GroupItem groupItem)
        {
            foreach (var def in slideDataButtonsDefs) 
            {
                if(def.CompareGroup(groupItem))
                {
                    return def;
                }
            }
            return null;
        }
    }
}
