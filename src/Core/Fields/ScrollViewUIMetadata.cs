using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ScrollViewUIMetadata : EditorUIFieldMetadata<ScrollViewUIMetadata>
    {
        public Vector2 scrollPosition;

        protected override GUIStyle DefaultStyle
        {
            get
            {
                if (_defaultStyle == null)
                {
                    _defaultStyle = new GUIStyle(GUI.skin.scrollView);
                }

                return _defaultStyle;
            }
        }

        public virtual bool ShouldHandleScrollWheel()
        {
            return true;
        }

        public EditorGUILayout.ScrollViewScope GetScope()
        {
            var scope = new EditorGUILayout.ScrollViewScope(scrollPosition, style, layout)
            {
                handleScrollWheel = ShouldHandleScrollWheel()
            };

            scrollPosition = scope.scrollPosition;

            return scope;
        }
    }
}
