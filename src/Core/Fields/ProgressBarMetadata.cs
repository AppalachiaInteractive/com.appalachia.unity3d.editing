using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ProgressBarMetadata : EditorUIFieldMetadata<ProgressBarMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.label;

        public void Draw(float value, string text, params GUILayoutOption[] options)
        {
            hasBeenDrawn = true;
            
            var p = GUILayoutUtility.GetRect(content, style, options);

            if (text == null)
            {
                text = value.ToString("N3");
            }

            EditorGUI.ProgressBar(p, value, text);
            GUILayout.Space(5);
        }

        public void Draw(float value, string text = null)
        {
            hasBeenDrawn = true;
            Draw(value, text, GUILayout.ExpandWidth(true));
        }
        
        public void Draw(float width, float value, string text = null)
        {
            hasBeenDrawn = true;
            Draw(value, text, GUILayout.Width(width));
        }
    }
}
