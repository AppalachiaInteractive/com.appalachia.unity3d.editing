using Appalachia.Editing.Core.State;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public abstract class LabelMetadataBase<T> : LabelledFieldMetadataBase<T>
        where T : EditorUIFieldMetadata<T>
    {
        private const string _PRF_PFX = nameof(LabelMetadataBase<T>) + ".";
        private GUIContent _cachedContent;
        private string _cachedLabelValue;

        protected virtual void OnBeforeDraw()
        {
        }

        protected virtual void OnAfterDraw()
        {
        }

        private static readonly ProfilerMarker _PRF_Draw = new ProfilerMarker(_PRF_PFX + nameof(Draw));

        private static readonly ProfilerMarker _PRF_Draw_LabelField =
            new ProfilerMarker(_PRF_PFX + nameof(Draw) + ".LabelField");
        public void Draw()
        {
            using (_PRF_Draw.Auto())
            {
                UIStateStacks.labelWidth.Push(_prefixLabelWidth);

                OnBeforeDraw();

                using (_PRF_Draw_LabelField.Auto())
                {
                    EditorGUILayout.LabelField(content, style, layout);
                }

                OnAfterDraw();

                UIStateStacks.labelWidth.Pop();
            }
        }

        private static readonly ProfilerMarker _PRF_Draw_Label =
            new ProfilerMarker(_PRF_PFX + nameof(Draw) + ".Label");

        private static readonly ProfilerMarker _PRF_Draw_Label_LabelField =
            new ProfilerMarker(_PRF_PFX + nameof(Draw) + ".Label.LabelField");

        private static readonly ProfilerMarker _PRF_Draw_Label_NewContent =
            new ProfilerMarker(_PRF_PFX + nameof(Draw) + ".Label.NewContent");
        public void Draw(string labelValue)
        {
            using (_PRF_Draw_Label.Auto())
            {
                if (labelValue == null)
                {
                    Draw();
                    return;
                }

                UIStateStacks.labelWidth.Push(_prefixLabelWidth);

                using (_PRF_Draw_Label_NewContent.Auto())
                {
                    if (labelValue != _cachedLabelValue)
                    {
                        _cachedContent = new GUIContent(labelValue);
                        _cachedLabelValue = labelValue;
                    }
                }

                OnBeforeDraw();

                using (_PRF_Draw_Label_LabelField.Auto())
                {
                    EditorGUILayout.LabelField(content, _cachedContent, style, layout);
                }

                OnAfterDraw();

                UIStateStacks.labelWidth.Pop();
            }
        }

        private static readonly ProfilerMarker _PRF_Draw_LabelColor =
            new ProfilerMarker(_PRF_PFX + nameof(Draw) + ".LabelColor");
        public void Draw(string labelValue, Color contentColor)
        {
            using (_PRF_Draw_LabelColor.Auto())
            {
                if (contentColor != Color.clear)
                {
                    UIStateStacks.contentColor.Push(contentColor);
                }

                Draw(labelValue);

                if (contentColor != Color.clear)
                {
                    UIStateStacks.contentColor.Pop();
                }
            }
        }

        private static readonly ProfilerMarker _PRF_Draw_Color =
            new ProfilerMarker(_PRF_PFX + nameof(Draw) + ".Color");
        public void Draw(Color contentColor)
        {
            using (_PRF_Draw_Color.Auto())
            {
                Draw(null, contentColor);
            }
        }
    }
}
