using Core.Model.Definitions.Attribute;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Core.Model.Definitions.Editor
{
    [CustomPropertyDrawer(typeof(ColorsIdAttribute))]
    public class IdAttributeColor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var defs = DefsFacade.I.Colors.PropertyForEditor;
            var ids = new List<string>();
            var colors = new List<Color>();

            foreach (var propertyDef in defs)
            {
                ids.Add(propertyDef.Id);
                colors.Add(propertyDef.Color);
            }
            var index = Mathf.Max(ids.IndexOf(property.stringValue), 0);
            index = EditorGUI.Popup(position, property.displayName, index, ids.ToArray());            
            property.stringValue = ids[index];
        }
    }
}
