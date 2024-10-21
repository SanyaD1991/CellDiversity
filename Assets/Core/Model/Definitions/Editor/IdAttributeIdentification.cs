using Core.Model.Definitions.Attribute;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Core.Model.Definitions.Editor
{
    [CustomPropertyDrawer(typeof(IdentificationIdAttribute))]
    public class IdAttributeIdentification : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var defs = DefsFacade.I.Identities.PropertyForEditor;
            var ids = new List<string>();           

            foreach (var propertyDef in defs)
            {
                ids.Add(propertyDef.Id);             
            }

            var index = Mathf.Max(ids.IndexOf(property.stringValue), 0);
            index = EditorGUI.Popup(position, property.displayName, index, ids.ToArray());
            property.stringValue = ids[index];
        }
    }
}
