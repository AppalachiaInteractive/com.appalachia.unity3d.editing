using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the wrap mode of texture assets into the project window.
    /// </summary>
    public class TextureWrapModeDetail : ProjectWindowDetailBase
    {
        private static readonly string[] _wrapModeStrings = {"Rpt", "Clp", "Mrr", "MrO"};

        public TextureWrapModeDetail()
        {
            Name = "Texture Wrap Mode";
            ColumnWidth = 70;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            var texture = asset as Texture;

            var wu = Mathf.Clamp((int) texture.wrapModeU, 0, 3);
            var wv = Mathf.Clamp((int) texture.wrapModeV, 0, 3);

            if (wu == wv)
            {
                return _wrapModeStrings[wu];
            }

            return $"{_wrapModeStrings[wu]}|{_wrapModeStrings[wv]}";
        }

        [InitializeOnLoadMethod]
        private static void Initiailze()
        {
            ProjectWindowDetails.RegisterDetail(new TextureWrapModeDetail());
        }
    }
}
