#region

using System;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Attributes.Drawers
{
    [CustomPropertyDrawer(typeof(SerializedEnumAttribute))]
    public class SerializedEnumDrawer : PropertyDrawer
    {
        private const string _PRF_PFX = nameof(SerializedEnumDrawer) + ".";
        private static readonly ProfilerMarker _PRF_OnGUI = new ProfilerMarker(_PRF_PFX + nameof(OnGUI));

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using (_PRF_OnGUI.Auto())
            {
                try
                {
                    var type = ((SerializedEnumAttribute) attribute).type;
                    var name = property.stringValue;
                    var value = default(Enum);
                    if (string.IsNullOrEmpty(name))
                    {
                        var values = Enum.GetValues(type);
                        if ((values != null) && (values.Length > 0))
                        {
                            value = (Enum) values.GetValue(0);
                        }
                    }
                    else
                    {
                        value = (Enum) Enum.Parse(type, name);
                    }

                    var newValue = EditorGUI.EnumPopup(position, label, value);
                    property.stringValue = newValue.ToString();
                }
                catch
                {
                }
            }
        }
    }
} // Hapki.Editor
