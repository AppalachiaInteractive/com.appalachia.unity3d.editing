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

        public EditorGUILayout.ScrollViewScope GetScope()
        {
            hasBeenDrawn = true;
            var scope = new EditorGUILayout.ScrollViewScope(scrollPosition, style, layout)
            {
                handleScrollWheel = ShouldHandleScrollWheel()
            };

            scrollPosition = scope.scrollPosition;

            return scope;
        }

        public virtual bool ShouldHandleScrollWheel()
        {
            return true;
        }
    }
}
