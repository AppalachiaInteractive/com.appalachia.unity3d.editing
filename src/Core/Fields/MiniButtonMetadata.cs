using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class MiniButtonMetadata : ButtonMetadataBase<MiniButtonMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.miniButton;

        public override GUILayoutOption[] InitializeLayout()
        {
            return new[] {GUILayout.ExpandWidth(true)};
        }
    }
}
