using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.State;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public abstract class PrefixLabelFieldBase<T> : LabelledFieldMetadataBase<T>
        where T : PrefixLabelFieldBase<T>
    {
        private GUILayoutOption[] _prefixLayout;
        private GUIStyle _prefixStyle;

        public void DrawPrefixLabel(bool selectable = false)
        {
            InitializePrefixLabel();
            
            if (selectable)
            {
                _prefixLayout[^1] = GUILayout.MaxWidth(prefixLabelWidth);
                SelectableLabelField(content, _prefixStyle, _prefixLayout);
            }
            else
            {
                APPAGUI.StateStacks.labelWidth.Push(prefixLabelWidth);
                EditorGUILayout.PrefixLabel(content, style, _prefixStyle);
                APPAGUI.StateStacks.labelWidth.Pop();
            }
        }

        public void SelectableLabelField(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            var rect = EditorGUILayout.GetControlRect(false, labelHeight, style, options);
            EditorGUI.SelectableLabel(rect, content.text, style);
        }

        public void SetPrefixLabel(string label)
        {
            content.text = label;
        }

        protected void InitializePrefixLabel()
        {
            if (_prefixStyle == null)
            {
                _prefixStyle = new GUIStyle(style)
                {
                    alignment = TextAnchor.MiddleRight, fontSize = style.fontSize - 1
                };
            }

            if (_prefixLayout == null)
            {
                _prefixLayout = new GUILayoutOption[layout.Length + 2];

                for (var index = 0; index < layout.Length; index++)
                {
                    var layoutOption = layout[index];
                    _prefixLayout[index] = layoutOption;
                }

                _prefixLayout[^2] = GUILayout.ExpandWidth(false);
                _prefixLayout[^1] = GUILayout.MaxWidth(prefixLabelWidth);
            }
        }
    }
}
