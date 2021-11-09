using Appalachia.CI.Integration.Assets;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the length of animation clips into the project window.
    /// </summary>
    public class AnimationLengthDetail : ProjectWindowDetailBase
    {
        public AnimationLengthDetail()
        {
            Name = "Animation Length";
            ColumnWidth = 70;
            Alignment = TextAlignment.Right;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            var clip = AssetDatabaseManager.LoadAssetAtPath<AnimationClip>(assetPath);
            if (clip != null)
            {
                return $"{clip.length:F3}";
            }

            return string.Empty;
        }

        [InitializeOnLoadMethod]
        private static void Initiailze()
        {
            ProjectWindowDetails.RegisterDetail(new AnimationLengthDetail());
        }
    }
}
