using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class MiniButtonRightMetadata : MiniButtonToolbarMetadata<MiniButtonRightMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.miniButtonRight;
    }
}
