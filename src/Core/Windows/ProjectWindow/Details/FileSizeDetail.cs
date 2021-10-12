using System.IO;
using Appalachia.CI.Integration;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the file size of assets into the project window.
    /// </summary>
    public class FileSizeDetail : ProjectWindowDetailBase
    {
        public FileSizeDetail()
        {
            Name = "File Size";
            Alignment = TextAlignment.Right;
            ColumnWidth = 80;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            return EditorUtility.FormatBytes(GetFileSize(assetPath));
        }

        private long GetFileSize(string assetPath)
        {
            var fullAssetPath = string.Concat(
                ProjectLocations.GetAssetsDirectoryPath().Substring(0, ProjectLocations.GetAssetsDirectoryPath().Length - 7),
                "/",
                assetPath
            );
            var size = new FileInfo(fullAssetPath).Length;
            return size;
        }
    }
}
