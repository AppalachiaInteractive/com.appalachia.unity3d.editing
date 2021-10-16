using System;
using Appalachia.Editing.Core.State;
using Appalachia.Utility.Colors;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public abstract class ButtonMetadataBase<T> : LabelledFieldMetadataBase<T>
        where T : EditorUIFieldMetadata<T>
    {
        public bool Button(bool enabled = true, Color contentColor = default, Color backgroundColor = default)
        {
            hasBeenDrawn = true;
            
            if (contentColor != Color.clear)
            {
                UIStateStacks.contentColor.Push(contentColor.ScaleA(enabled ? 1f : .5f));
            }

            if (backgroundColor != Color.clear)
            {
                UIStateStacks.backgroundColor.Push(backgroundColor.ScaleA(enabled ? 1f : .25f));
            }

            using var scope = new EditorGUI.DisabledScope(!enabled);

            var result = GUILayout.Button(content, style, layout);

            if (contentColor != Color.clear)
            {
                UIStateStacks.contentColor.Pop();
            }

            if (backgroundColor != Color.clear)
            {
                UIStateStacks.backgroundColor.Pop();
            }

            return result;
        }
    }
}
