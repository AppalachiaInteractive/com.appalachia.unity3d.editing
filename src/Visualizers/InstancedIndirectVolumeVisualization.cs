#if UNITY_EDITOR
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Editing.Visualizers
{
    public abstract class InstancedIndirectVolumeVisualization : InstancedIndirectVisualization
    {
        [OnValueChanged(nameof(Regenerate))]
        public Vector3 visualizationDensity = Vector3.one;

        [OnValueChanged(nameof(Regenerate))]
        public float visualizationSize = .25f;

        protected override void GetPositionData(
            Bounds bounds,
            out Vector3[] positions,
            out Quaternion[] rotations,
            out Vector3[] scales)
        {
            var xCount = (int) (bounds.size.x * visualizationDensity.x);
            var yCount = (int) (bounds.size.y * visualizationDensity.y);
            var zCount = (int) (bounds.size.z * visualizationDensity.z);

            visualizationCount = xCount * yCount * zCount;

            positions = new Vector3[visualizationCount];
            rotations = new Quaternion[visualizationCount];
            scales = new Vector3[visualizationCount];

            Vector3 position;
            Quaternion rotation;
            Vector3 scale;

            for (var x = 0; x < xCount; x++)
            for (var y = 0; y < yCount; y++)
            for (var z = 0; z < zCount; z++)
            {
                var index = (x * yCount * zCount) + (y * zCount) + z;

                var position_X = bounds.min.x + ((x / (float) xCount) * bounds.size.x);
                var position_Y = bounds.min.y + ((y / (float) yCount) * bounds.size.y);
                var position_Z = bounds.min.z + ((z / (float) zCount) * bounds.size.z);

                position = new Vector3(position_X, position_Y, position_Z);
                positions[index] = position;

                GetRotationAndScale(index, x, y, z, position, out rotation, out scale);

                rotations[index] = rotation;
                scales[index] = scale;
            }
        }

        // ReSharper disable once UnusedParameter.Global
        protected virtual void GetRotationAndScale(
            int index,
            int xIndex,
            int yIndex,
            int zIndex,
            Vector3 position,
            out Quaternion rotation,
            out Vector3 scale)
        {
            rotation = Quaternion.identity;
            scale = Vector3.one * visualizationSize;
        }
    }
}
#endif
