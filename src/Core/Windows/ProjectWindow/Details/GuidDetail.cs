using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the GUID of assets into the project window.
    /// </summary>
    public class GuidDetail : ProjectWindowDetailBase
    {
        public GuidDetail()
        {
            Name = "Guid";
            ColumnWidth = 230;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            return guid;
        }
    }
}
