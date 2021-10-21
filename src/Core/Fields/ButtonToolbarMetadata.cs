using System;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public abstract class ButtonToolbarMetadata<T> : ButtonMetadataBase<T>
        where T : EditorUIFieldMetadata<T>
    {
        public override GUILayoutOption[] InitializeLayout()
        {
            return new[] {GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(28)};
        }
    }
}
