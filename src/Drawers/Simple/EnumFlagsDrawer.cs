#region

using Appalachia.Core.Attributes.Editing;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Drawers.Simple
{
    [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
    public class EnumFlagsDrawer : PropertyDrawer
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(EnumFlagsDrawer) + ".";
        private static readonly ProfilerMarker _PRF_OnGUI = new(_PRF_PFX + nameof(OnGUI));

#endregion

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using (_PRF_OnGUI.Auto())
            {
                property.intValue = EditorGUI.MaskField(
                    position,
                    label,
                    property.intValue,
                    property.enumNames
                );
            }
        }
    }
} // Hapki.Editor
