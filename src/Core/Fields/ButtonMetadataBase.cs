using System;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.State;
using Appalachia.Utility.Colors;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public abstract class ButtonMetadataBase<T> : LabelledFieldMetadataBase<T>, IButtonMetadata
        where T : EditorUIFieldMetadata<T>
    {
        public bool Button(bool enabled = true, Color contentColor = default, Color backgroundColor = default)
        {
            hasBeenDrawn = true;

            if (contentColor != Color.clear)
            {
                APPAGUI.StateStacks.contentColor.Push(contentColor.ScaleA(enabled ? 1f : .5f));
            }

            if (backgroundColor != Color.clear)
            {
                APPAGUI.StateStacks.backgroundColor.Push(backgroundColor.ScaleA(enabled ? 1f : .25f));
            }

            using var scope = new EditorGUI.DisabledScope(!enabled);

            var result = GUILayout.Button(content, style, layout);

            if (contentColor != Color.clear)
            {
                APPAGUI.StateStacks.contentColor.Pop();
            }

            if (backgroundColor != Color.clear)
            {
                APPAGUI.StateStacks.backgroundColor.Pop();
            }

            return result;
        }
    }
}
