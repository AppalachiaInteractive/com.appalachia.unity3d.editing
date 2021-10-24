using System;
using Appalachia.Editing.Core.Layout;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public abstract class LabelledFieldMetadataBase<T> : EditorUIFieldMetadata<T>
        where T : EditorUIFieldMetadata<T>
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(LabelledFieldMetadataBase<T>) + ".";

        private static readonly ProfilerMarker _PRF_InitializeContent =
            new(_PRF_PFX + nameof(InitializeContent));

#endregion

        public string iconName;
        public string text;
        public string tooltip;
        private int _labelHeight;

        private int _prefixLabelWidth;

        public int DefaultLabelHeight => 18;
        public int DefaultLabelWidth => 150;

        protected int labelHeight => _labelHeight == 0 ? DefaultLabelHeight : _labelHeight;

        protected int prefixLabelWidth => _prefixLabelWidth == 0 ? DefaultLabelWidth : _prefixLabelWidth;

        public void SetLabelHeight(float height)
        {
            _labelHeight = (int) height;
        }

        public void SetLabelHeight(int height)
        {
            _labelHeight = height;
        }

        public void SetLabelHeight(APPAGUI.SPACE.SIZE height)
        {
            _labelHeight = (int) height;
        }

        public void SetPrefixLabelWidth(float width)
        {
            _prefixLabelWidth = (int) width;
        }

        public void SetPrefixLabelWidth(int width)
        {
            _prefixLabelWidth = width;
        }

        public void SetPrefixLabelWidth(APPAGUI.SPACE.SIZE width)
        {
            _prefixLabelWidth = (int) width;
        }

        public override GUIContent InitializeContent()
        {
            using (_PRF_InitializeContent.Auto())
            {
                if (string.IsNullOrWhiteSpace(iconName) && string.IsNullOrWhiteSpace(text))
                {
                    return new GUIContent(identifier);
                }

                if (string.IsNullOrWhiteSpace(iconName))
                {
                    if (string.IsNullOrWhiteSpace(tooltip))
                    {
                        return new GUIContent(text);
                    }

                    return new GUIContent(text, tooltip);
                }

                if (string.IsNullOrWhiteSpace(text))
                {
                    if (string.IsNullOrWhiteSpace(tooltip))
                    {
                        return EditorGUIUtility.IconContent(iconName);
                    }

                    return EditorGUIUtility.IconContent(iconName, tooltip);
                }

                var result = EditorGUIUtility.IconContent(iconName);
                result.text = text;
                result.tooltip = tooltip;

                return result;
            }
        }
    }
}
