using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public class TextFieldMetadata : EditorUIFieldMetadata<TextFieldMetadata>
    {
        protected override GUIStyle DefaultStyle => GUI.skin.textField;

        public string Draw(string value)
        {
            return EditorGUILayout.TextField(content, value, style, layout);
        }
    }
}