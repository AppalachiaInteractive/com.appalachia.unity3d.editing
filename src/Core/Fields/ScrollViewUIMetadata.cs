using System;
using Appalachia.Editing.Core.Layout;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ScrollViewUIMetadata : EditorUIFieldMetadata<ScrollViewUIMetadata>
    {
        public float width;
        public Vector2 scrollPosition;

        private GUIStyle _horizontalScrollbar;
        private GUIStyle _verticalScrollbar;
        public bool AlwaysShowHorizontal { get; set; }

        public bool AlwaysShowVertical { get; set; }

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

        protected GUIStyle HorizontalScrollbar
        {
            get
            {
                if (_horizontalScrollbar == null)
                {
                    _horizontalScrollbar = new GUIStyle(GUI.skin.horizontalScrollbar);
                }

                return _horizontalScrollbar;
            }
        }

        protected GUIStyle VerticalScrollbar
        {
            get
            {
                if (_verticalScrollbar == null)
                {
                    _verticalScrollbar = new GUIStyle(GUI.skin.verticalScrollbar);
                }

                return _verticalScrollbar;
            }
        }

        public virtual bool ShouldHandleScrollWheel()
        {
            return true;
        }

        public IDisposable GetScope()
        {
            hasBeenDrawn = true;

            var scope = new EditorGUILayout.ScrollViewScope(
                scrollPosition,
                AlwaysShowHorizontal,
                AlwaysShowVertical,
                HorizontalScrollbar,
                VerticalScrollbar,
                style,
                layout
            ) {handleScrollWheel = ShouldHandleScrollWheel()};

            scrollPosition = scope.scrollPosition;

            return scope;
        }

        public override GUILayoutOption[] InitializeLayout()
        {
            return APPAGUI.ExpandWidth().ExpandHeight();
        }
    }
}
