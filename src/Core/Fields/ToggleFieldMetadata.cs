using System;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.State;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ToggleFieldMetadata : LabelledFieldMetadataBase<ToggleFieldMetadata>
    {
        protected override GUIStyle DefaultStyle => GUI.skin.toggle;

        public bool Toggle(bool value)
        {
            hasBeenDrawn = true;

            //using (new EditorGUILayout.HorizontalScope())
            {
                APPAGUI.StateStacks.labelWidth.Push(prefixLabelWidth);

                var result = EditorGUILayout.Toggle(content, value, style, layout);

                APPAGUI.StateStacks.labelWidth.Pop();

                return result;
            }
        }

        public bool Toggle(bool value, Color contentColor)
        {
            hasBeenDrawn = true;
            if (contentColor != Color.clear)
            {
                APPAGUI.StateStacks.contentColor.Push(contentColor);
            }

            var result = Toggle(value);
            if (contentColor != Color.clear)
            {
                APPAGUI.StateStacks.contentColor.Pop();
            }

            return result;
        }
    }
}
