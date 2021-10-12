using System;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class SmallLabelMetadata : LabelMetadataBase<SmallLabelMetadata>
    {
        protected override GUIStyle DefaultStyle
        {
            get
            {
                if (_defaultStyle == null)
                {
                    _defaultStyle = new GUIStyle(GUI.skin.label)
                    {
                        border = new RectOffset(0, 0, 0, 0),
                        margin = new RectOffset(0, 0, 0, 0),
                        fontSize = 10
                    };
                }

                return _defaultStyle;
            }
        }
    }
}
