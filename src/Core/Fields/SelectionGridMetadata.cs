using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class SelectionGridMetadata : EditorUIFieldMetadata<SelectionGridMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.toolbarButton;

        public int Toolbar(int tab, string[] tabs, int xCount = 3)
        {
            hasBeenDrawn = true;
            return GUILayout.SelectionGrid(tab, tabs, xCount, style, layout);
        }
    }
}
