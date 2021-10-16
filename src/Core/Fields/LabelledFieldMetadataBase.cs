using System;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public abstract class LabelledFieldMetadataBase<T> : EditorUIFieldMetadata<T>
        where T : EditorUIFieldMetadata<T>
    {
        private const string _PRF_PFX = nameof(LabelledFieldMetadataBase<T>) + ".";
        public string iconName;
        public string text;
        public string tooltip;

        private static readonly ProfilerMarker _PRF_InitializeContent =
            new(_PRF_PFX + nameof(InitializeContent));

        protected int _prefixLabelWidth;

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

        public void SetPrefixLabelWidth(int width)
        {
            _prefixLabelWidth = width;
        }
    }
}
