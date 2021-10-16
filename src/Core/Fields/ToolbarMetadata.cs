using System;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ToolbarMetadata : EditorUIFieldMetadata<ToolbarMetadata>
    {
        protected override GUIStyle DefaultStyle => GUI.skin.button;

        public int Toolbar(int tab, string[] tabs, GUI.ToolbarButtonSize size = GUI.ToolbarButtonSize.Fixed)
        {
            hasBeenDrawn = true;
            return GUILayout.Toolbar(tab, tabs, style, size, layout);
        }
    }
}
