using Appalachia.CI.Integration;
using Sirenix.Utilities.Editor;
using UnityEngine;
using UnityEditor;

namespace Appalachia.Editing.Core.Fields
{
    public class FolderPathFieldMetadata : PrefixLabelFieldBase<FolderPathFieldMetadata>
    {
        protected string _parentPath;
        protected override GUIStyle DefaultStyle => GUI.skin.textField;

        public string Draw(string value, string parentPath)
        {
            _parentPath = parentPath;

            return Draw(value);
        }

        public string Draw(string value)
        {
            if (_parentPath == null)
            {
                _parentPath = ProjectLocations.GetAssetsDirectoryPath();
            }

            //return SirenixEditorFields.FolderPathField(content, value, _parentPath, false, false, layout);
            return EditorGUILayout.TextField(value, style, layout);
        }
    }
}
