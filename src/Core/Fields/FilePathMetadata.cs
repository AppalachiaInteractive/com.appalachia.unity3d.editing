using System;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class FilePathMetadata : LabelMetadataBase<FilePathMetadata>
    {
        protected override GUIStyle DefaultStyle
        {
            get
            {
                if (_defaultStyle == null)
                {
                    _defaultStyle = new GUIStyle(GUI.skin.label);
                    _defaultStyle.border = new RectOffset(0, 0, 0, 0);
                    _defaultStyle.margin = new RectOffset(0, 0, 0, 0);
                    _defaultStyle.wordWrap = true;
                    _defaultStyle.fontSize = 11;
                }

                return _defaultStyle;
            }
        }
    }
}
