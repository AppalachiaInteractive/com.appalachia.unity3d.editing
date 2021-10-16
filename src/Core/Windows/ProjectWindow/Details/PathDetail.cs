using Appalachia.CI.Integration.FileSystem;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the file path of assets into the project window.
    /// </summary>
    public class PathDetail : ProjectWindowDetailBase
    {
        public PathDetail()
        {
            Name = "Path";
            ColumnWidth = 400;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            return AppaPath.GetDirectoryName(assetPath);
        }

        [InitializeOnLoadMethod]
        private static void Initiailze()
        {
            ProjectWindowDetails.RegisterDetail(new PathDetail());
        }
    }
}
