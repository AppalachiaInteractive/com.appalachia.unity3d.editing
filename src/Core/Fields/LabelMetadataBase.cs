using Appalachia.Editing.Core.State;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public abstract class LabelMetadataBase<T> : LabelledFieldMetadataBase<T>
        where T : EditorUIFieldMetadata<T>
    {
        #region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(LabelMetadataBase<T>) + ".";

        private static readonly ProfilerMarker _PRF_Draw = new(_PRF_PFX + nameof(Draw));

        private static readonly ProfilerMarker _PRF_Draw_LabelField =
            new(_PRF_PFX + nameof(Draw) + ".LabelField");

        private static readonly ProfilerMarker _PRF_Draw_Label = new(_PRF_PFX + nameof(Draw) + ".Label");

        private static readonly ProfilerMarker _PRF_Draw_Label_LabelField =
            new(_PRF_PFX + nameof(Draw) + ".Label.LabelField");

        private static readonly ProfilerMarker _PRF_Draw_Label_NewContent =
            new(_PRF_PFX + nameof(Draw) + ".Label.NewContent");

        private static readonly ProfilerMarker _PRF_Draw_LabelColor =
            new(_PRF_PFX + nameof(Draw) + ".LabelColor");

        private static readonly ProfilerMarker _PRF_Draw_Color = new(_PRF_PFX + nameof(Draw) + ".Color");

        #endregion

        private GUIContent _secondLabelContent;
        private GUILayoutOption[] _prefixLayout;
        private GUIStyle _prefixStyle;
        private string _secondLabelValue;

        protected virtual void OnAfterDraw()
        {
        }

        protected virtual void OnBeforeDraw()
        {
        }

        public void Draw(bool selectable = false)
        {
            using (_PRF_Draw.Auto())
            {
                hasBeenDrawn = true;

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

                using (new GUILayout.VerticalScope())
                {
                    OnBeforeDraw();

                    using (_PRF_Draw_LabelField.Auto())
                    {
                        if ((_secondLabelContent == null) || (_secondLabelContent.text == null))
                        {
                            if (selectable && (content.text != null))
                            {
                                SelectableLabelField(content, style, layout);
                            }
                            else
                            {
                                EditorGUILayout.LabelField(content, style, layout);
                            }
                        }
                        else
                        {
                            using (new GUILayout.HorizontalScope())
                            {
                                if (selectable)
                                {
                                    _prefixLayout[^1] = GUILayout.MaxWidth(prefixLabelWidth);
                                    SelectableLabelField(content,             _prefixStyle, _prefixLayout);
                                    SelectableLabelField(_secondLabelContent, style,        layout);
                                }
                                else
                                {
                                    UIStateStacks.labelWidth.Push(prefixLabelWidth);
                                    EditorGUILayout.PrefixLabel(content, style, _prefixStyle);
                                    EditorGUILayout.LabelField(_secondLabelContent, style, layout);
                                    UIStateStacks.labelWidth.Pop();
                                }
                            }
                        }
                    }

                    OnAfterDraw();
                }
            }
        }

        public void Draw(string prefixLabel, string labelValue, bool selectable = false)
        {
            using (_PRF_Draw_Label.Auto())
            {
                hasBeenDrawn = true;

                if (labelValue != _secondLabelValue)
                {
                    _secondLabelContent = new GUIContent(labelValue);
                    _secondLabelValue = labelValue;
                }

                content.text = prefixLabel;

                Draw(selectable);
            }
        }

        public void Draw(string prefixLabel, string labelValue, Color contentColor, bool selectable = false)
        {
            using (_PRF_Draw_LabelColor.Auto())
            {
                hasBeenDrawn = true;

                if (contentColor != Color.clear)
                {
                    UIStateStacks.contentColor.Push(contentColor);
                }

                content.text = prefixLabel;

                Draw(labelValue, selectable);

                if (contentColor != Color.clear)
                {
                    UIStateStacks.contentColor.Pop();
                }
            }
        }

        public void Draw(string labelValue, bool selectable = false)
        {
            using (_PRF_Draw_Label.Auto())
            {
                hasBeenDrawn = true;

                if (labelValue != _secondLabelValue)
                {
                    _secondLabelContent = new GUIContent(labelValue);
                    _secondLabelValue = labelValue;
                }

                Draw(selectable);
            }
        }

        public void Draw(string labelValue, Color contentColor, bool selectable = false)
        {
            using (_PRF_Draw_LabelColor.Auto())
            {
                hasBeenDrawn = true;

                if (contentColor != Color.clear)
                {
                    UIStateStacks.contentColor.Push(contentColor);
                }

                Draw(labelValue, selectable);

                if (contentColor != Color.clear)
                {
                    UIStateStacks.contentColor.Pop();
                }
            }
        }

        public void Draw(Color contentColor, bool selectable = false)
        {
            using (_PRF_Draw_Color.Auto())
            {
                hasBeenDrawn = true;

                Draw(null, contentColor, selectable);
            }
        }

        public void DrawOnly(string labelValue, bool selectable = false)
        {
            using (_PRF_Draw_Label.Auto())
            {
                hasBeenDrawn = true;

                content.text = labelValue;

                Draw(selectable);
            }
        }

        public void DrawOnly(string labelValue, Color contentColor, bool selectable = false)
        {
            using (_PRF_Draw_LabelColor.Auto())
            {
                hasBeenDrawn = true;

                if (contentColor != Color.clear)
                {
                    UIStateStacks.contentColor.Push(contentColor);
                }

                content.text = labelValue;

                Draw(selectable);

                if (contentColor != Color.clear)
                {
                    UIStateStacks.contentColor.Pop();
                }
            }
        }

        public void SelectableLabelField(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            var rect = EditorGUILayout.GetControlRect(false, labelHeight, style, options);
            EditorGUI.SelectableLabel(rect, content.text, style);
        }
    }
}
