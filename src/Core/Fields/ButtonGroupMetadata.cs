using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ButtonGroupMetadata : EditorUIFieldMetadata<ButtonGroupMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.toolbarButton;

        public int SelectionGrid(int tab, string[] tabs, int xCount = 3)
        {
            if (xCount == 0)
            {
                xCount = 3;
            }

            hasBeenDrawn = true;
            return GUILayout.SelectionGrid(tab, tabs, xCount, style, layout);
        }

        public int Toolbar(int tab, string[] tabs, GUI.ToolbarButtonSize size = GUI.ToolbarButtonSize.Fixed)
        {
            hasBeenDrawn = true;
            return GUILayout.Toolbar(tab, tabs, style, size, layout);
        }

        public override GUILayoutOption[] InitializeLayout()
        {
            return new[] {GUILayout.ExpandWidth(true)};
        }
    }
}
