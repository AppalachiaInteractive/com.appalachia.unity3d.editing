using Appalachia.CI.Integration.FileSystem;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the file suffix of assets into the project window.
    /// </summary>
    public class FileSuffixDetail : ProjectWindowDetailBase
    {
        public FileSuffixDetail()
        {
            Name = "File Suffix";
            ColumnWidth = 80;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            return AppaPath.GetExtension(assetPath);
        }

        [InitializeOnLoadMethod]
        private static void Initiailze()
        {
            ProjectWindowDetails.RegisterDetail(new FileSuffixDetail());
        }
    }
}
