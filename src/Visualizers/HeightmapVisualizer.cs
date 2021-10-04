#if UNITY_EDITOR
using Appalachia.Editing.Visualizers.Base;
using UnityEngine;

namespace Appalachia.Editing.Visualizers
{
    public class HeightmapVisualizer : InstancedIndirectHeightmapMapVisualization
    {
        protected override bool ShouldRegenerate => false;

        protected override bool CanGenerate => texture != null;
        protected override void PrepareInitialGeneration()
        {
        }

        protected override void PrepareSubsequentGenerations()
        {
        }

        protected override void GetVisualizationInfo(Vector3 position, out Quaternion rotation, out Vector3 scale)
        {
            rotation = Quaternion.identity;
            scale = Vector3.one * visualizationSize;
        }
    }
}
#endif