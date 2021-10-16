using System;
using Appalachia.Editing.Core.State;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class MenuItemField : EditorUIFieldMetadata<MenuItemField>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.foldout;

        public override GUIStyle InitializeStyle()
        {
            var baseStyle = new GUIStyle(GUI.skin.button)
            {
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(0, 0, 0, 0),
                border = new RectOffset(0,  0, 0, 0),
                margin = new RectOffset(0,  0, 0, 0)
            };
            baseStyle.active.background = baseStyle.normal.background;

            return baseStyle;
        }

        public bool Draw(string menuItem)
        {
            hasBeenDrawn = true;
            DrawText(menuItem);

            var lastRect = GUILayoutUtility.GetLastRect();

            var result = GUI.Button(lastRect, string.Empty, GUIStyle.none);

            return result;
        }

        public bool Draw(string menuItem, Color backgroundColor)
        {
            hasBeenDrawn = true;
            UIStateStacks.backgroundColor.Push(backgroundColor);

            var result = Draw(menuItem);

            UIStateStacks.backgroundColor.Pop();

            return result;
        }

        public void DrawText(string menuItem)
        {
            hasBeenDrawn = true;
            EditorGUILayout.LabelField(menuItem, style);
        }
    }
}
