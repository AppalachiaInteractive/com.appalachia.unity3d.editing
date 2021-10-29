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
            using (new GUILayout.HorizontalScope())
            {
                DrawPrefixLabel();
                return EditorGUILayout.FloatField(value, style, layout);
            }
        }
    }
}