using System;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ButtonMetadata : ButtonMetadataBase<ButtonMetadata>
    {
        protected override GUIStyle DefaultStyle => GUI.skin.button;

    }
}
