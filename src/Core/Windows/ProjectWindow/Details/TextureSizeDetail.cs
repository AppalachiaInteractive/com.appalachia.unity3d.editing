using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the width and height of texture assets into the project window.
    /// </summary>
    public class TextureSizeDetail : ProjectWindowDetailBase
    {
        public TextureSizeDetail()
        {
            Name = "Texture Size";
            ColumnWidth = 80;
            Alignment = TextAlignment.Right;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            var texture = asset as Texture;
            if (texture == null)
            {
                return string.Empty;
            }

            return $"{texture.width}x{texture.height}";
        }

        [InitializeOnLoadMethod]
        private static void Initiailze()
        {
            ProjectWindowDetails.RegisterDetail(new TextureSizeDetail());
        }
    }
}
