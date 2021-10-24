using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class MiniButtonMidMetadata : MiniButtonToolbarMetadata<MiniButtonMidMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.miniButtonMid;
    }
}
