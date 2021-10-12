using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.ProjectWindow.Details
{
    /// <summary>
    ///     Draws the number of key of animation clips into the project window.
    /// </summary>
    public class AnimationKeyCountDetail : ProjectWindowDetailBase
    {
        public AnimationKeyCountDetail()
        {
            Name = "Animation Key Count";
            ColumnWidth = 50;
            Alignment = TextAlignment.Right;
        }

        public override string GetLabel(string guid, string assetPath, Object asset)
        {
            var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(assetPath);
            if (clip != null)
            {
                var bindings = AnimationUtility.GetCurveBindings(clip);
                var numKeys = 0;
                foreach (var binding in bindings)
                {
                    var curve = AnimationUtility.GetEditorCurve(clip, binding);
                    numKeys += curve.length;
                }

                return string.Format("{0:D}", numKeys);
            }

            return string.Empty;
        }
    }
}
