using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ButtonMidMetadata : ButtonToolbarMetadata<ButtonMidMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.miniButtonMid;
    }
}
