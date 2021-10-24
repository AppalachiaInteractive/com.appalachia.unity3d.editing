using System;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.State;
using Appalachia.Utility.Colors;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class MenuItemField : EditorUIFieldMetadata<MenuItemField>
    {
        private float _height;
        private string _lastIcon;
        public float height => _height;

        protected override GUIStyle DefaultStyle => EditorStyles.toolbarButton;

        public bool Draw(string menuItem, bool isSelected, string icon = null)
        {
            hasBeenDrawn = true;

            if (content.text != menuItem)
            {
                content.text = menuItem;
                content.tooltip = menuItem;
            }

            if (icon == null)
            {
                content.image = null;
            }
            else
            {
                if (content.image == null)
                {
                    content.image = EditorGUIIcons.GetIconContent(icon).image;
                    _lastIcon = icon;
                }
                else if (_lastIcon != icon)
                {
                    content.image = EditorGUIIcons.GetIconContent(icon).image;
                    _lastIcon = icon;
                }
            }

            var pushedBackgroundColor = false;
            if (isSelected && (UIStateStacks.backgroundColor.Current == Color.white))
            {
                var bgColor = ColorPalette.Default.ui.Middle.ScaleAlpha(.2f);
                UIStateStacks.backgroundColor.Push(bgColor);
                pushedBackgroundColor = true;
            }

            bool result;

            using (new GUILayout.HorizontalScope())
            {
                var spaceSize = APPAGUI.SPACE.SIZE.MenuItemPaddingLeft.MAKE_GET();
                var stripSize = APPAGUI.SPACE.SIZE.MenuItemSelectionStrip.MAKE_GET();

                result = GUILayout.Button(content, style, layout);

                var lastRect = GUILayoutUtility.GetLastRect();
                if ((Event.current != null) && (Event.current.type != EventType.Layout))
                {
                    _height = lastRect.height;
                }

                if (isSelected)
                {
                    var iconRect = new Rect(
                        (lastRect.x - spaceSize) + 1,
                        lastRect.y,
                        stripSize,
                        lastRect.height
                    );

                    EditorGUI.DrawRect(iconRect, ColorPalette.Default.highlight.Middle);
                }
            }

            if (pushedBackgroundColor)
            {
                UIStateStacks.backgroundColor.Pop();
            }

            return result;
        }

        public bool Draw(
            string menuItem,
            bool isSelected,
            Color backgroundColor,
            Color foregroundColor,
            string icon = null)
        {
            if (isSelected)
            {
                foregroundColor = foregroundColor.ScaleV(.75f);
                backgroundColor = backgroundColor.ScaleV(.75f);
            }

            if (backgroundColor != Color.clear)
            {
                UIStateStacks.backgroundColor.Push(backgroundColor);
            }

            if (foregroundColor != Color.clear)
            {
                UIStateStacks.color.Push(foregroundColor);
            }

            var result = Draw(menuItem, isSelected, icon);

            if (backgroundColor != Color.clear)
            {
                UIStateStacks.color.Pop();
            }

            if (foregroundColor != Color.clear)
            {
                UIStateStacks.backgroundColor.Pop();
            }

            return result;
        }

        public bool DrawBackground(
            string menuItem,
            bool isSelected,
            Color backgroundColor,
            string icon = null)
        {
            if (isSelected)
            {
                backgroundColor = backgroundColor.ScaleV(.75f);
            }

            if (backgroundColor != Color.clear)
            {
                UIStateStacks.backgroundColor.Push(backgroundColor);
            }

            var result = Draw(menuItem, isSelected, icon);

            if (backgroundColor != Color.clear)
            {
                UIStateStacks.backgroundColor.Pop();
            }

            return result;
        }

        public bool DrawForeground(
            string menuItem,
            bool isSelected,
            Color foregroundColor,
            string icon = null)
        {
            if (isSelected)
            {
                foregroundColor = foregroundColor.ScaleV(.75f);
            }

            if (foregroundColor != Color.clear)
            {
                UIStateStacks.color.Push(foregroundColor);
            }

            var result = Draw(menuItem, isSelected, icon);

            if (foregroundColor != Color.clear)
            {
                UIStateStacks.color.Pop();
            }

            return result;
        }

        public override GUILayoutOption[] InitializeLayout()
        {
            return new[] {GUILayout.ExpandWidth(true), GUILayout.Height(28f)};
        }

        public override GUIStyle InitializeStyle()
        {
            var baseStyle = new GUIStyle(EditorStyles.toolbarButton)
            {
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(0, 0, 0, 0),
                border = new RectOffset(0,  0, 0, 0),
                margin = new RectOffset(0,  0, 0, 0)
            };
            baseStyle.active.background = baseStyle.normal.background;

            return baseStyle;
        }
    }
}
