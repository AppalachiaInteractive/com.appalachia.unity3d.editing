using Appalachia.Editing.Core.Layout;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public class FloatFieldMetadata : PrefixLabelFieldBase<FloatFieldMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.numberField;

        public float Draw(float value)
        {
            using (APPAGUI.Horizontal())
            {
                DrawPrefixLabel();
                return EditorGUILayout.FloatField(value, style, layout);
            }
        }
    }
}