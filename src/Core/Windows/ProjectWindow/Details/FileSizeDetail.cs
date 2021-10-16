using System.Collections.Generic;
using Appalachia.CI.Integration;
using Appalachia.CI.Integration.FileSystem;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the file size of assets into the project window.
    /// </summary>
    public class FileSizeDetail : ProjectWindowDetailBase
    {
        private static Dictionary<long, string> _formatLookup;
        private static Dictionary<string, AppaFileInfo> _lookup;

        public FileSizeDetail()
        {
            Name = "File Size";
            Alignment = TextAlignment.Right;
            ColumnWidth = 80;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            var fileSize = GetFileSize(assetPath);

            if (_formatLookup == null)
            {
                _formatLookup = new Dictionary<long, string>();
            }

            if (!_formatLookup.ContainsKey(fileSize))
            {
                _formatLookup.Add(fileSize, EditorUtility.FormatBytes(fileSize));
            }

            return _formatLookup[fileSize];
        }

        private long GetFileSize(string assetPath)
        {
            if (_lookup == null)
            {
                _lookup = new Dictionary<string, AppaFileInfo>();
            }

            if (!_lookup.ContainsKey(assetPath))
            {
                var fullAssetPath = string.Concat(
                    ProjectLocations.GetAssetsDirectoryPath()
                                    .Substring(0, ProjectLocations.GetAssetsDirectoryPath().Length - 7),
                    "/",
                    assetPath
                );

                _lookup.Add(assetPath, new AppaFileInfo(fullAssetPath));
            }

            return _lookup[assetPath].Length;
        }

        [InitializeOnLoadMethod]
        private static void Initiailze()
        {
            ProjectWindowDetails.RegisterDetail(new FileSizeDetail());
        }
    }
}
