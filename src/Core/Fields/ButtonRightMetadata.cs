using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ButtonRightMetadata : ButtonToolbarMetadata<ButtonRightMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.miniButtonRight;
    }
}