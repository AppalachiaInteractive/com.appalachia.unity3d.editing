#region

using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Attributes.Drawers
{
    [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
    public class EnumFlagsDrawer : PropertyDrawer
    {
        private const string _PRF_PFX = nameof(EnumFlagsDrawer) + ".";
        private static readonly ProfilerMarker _PRF_OnGUI = new ProfilerMarker(_PRF_PFX + nameof(OnGUI));
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using (_PRF_OnGUI.Auto())
            {
                property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
            }
        }
    }
} // Hapki.Editor
