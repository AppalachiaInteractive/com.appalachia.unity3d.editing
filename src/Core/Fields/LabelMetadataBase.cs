using Appalachia.Editing.Core.State;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public abstract class LabelMetadataBase<T> : PrefixLabelFieldBase<T>
        where T : LabelMetadataBase<T>
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

                InitializePrefixLabel();

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
                                DrawPrefixLabel(selectable);

                                if (selectable)
                                {
                                    SelectableLabelField(_secondLabelContent, style, layout);
                                }
                                else
                                {
                                    EditorGUILayout.LabelField(_secondLabelContent, style, layout);
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
    }
}
