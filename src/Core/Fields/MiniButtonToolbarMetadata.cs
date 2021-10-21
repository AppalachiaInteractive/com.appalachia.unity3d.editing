using System;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public abstract class MiniButtonToolbarMetadata<T> : ButtonMetadataBase<T>
        where T : EditorUIFieldMetadata<T>
    {
        public override GUILayoutOption[] InitializeLayout()
        {
            return new[] {GUILayout.ExpandWidth(true)};
        }
    }
}
