using Appalachia.Editing.Core.Layout;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public class ColorFieldMetadata : PrefixLabelFieldBase<ColorFieldMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.colorField;

        public Color Draw(Color value)
        {
            using (APPAGUI.Horizontal())
            {
                DrawPrefixLabel();
                return EditorGUILayout.ColorField(value, layout);
            }
        }
    }
}