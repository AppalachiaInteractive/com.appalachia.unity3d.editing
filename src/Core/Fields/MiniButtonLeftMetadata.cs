using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class MiniButtonLeftMetadata : MiniButtonToolbarMetadata<MiniButtonLeftMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.miniButtonLeft;
    }
}
