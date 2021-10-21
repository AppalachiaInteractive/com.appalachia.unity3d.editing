using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ButtonLeftMetadata : ButtonToolbarMetadata<ButtonLeftMetadata>
    {
        protected override GUIStyle DefaultStyle => EditorStyles.miniButtonLeft;
    }
}
