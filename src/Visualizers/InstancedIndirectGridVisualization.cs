#if UNITY_EDITOR
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Editing.Visualizers
{
    public abstract class InstancedIndirectGridVisualization : InstancedIndirectVisualization
    {
        #region Fields and Autoproperties

        [PropertyOrder(-101)]
        [OnValueChanged(nameof(Regenerate))]
        [PropertyRange(.1f, 10f)]
        public float visualizationDensity = 1f;

        [PropertyOrder(-100)]
        [OnValueChanged(nameof(Regenerate))]
        [PropertyRange(.05f, 1f)]
        public float visualizationSize = .25f;

        #endregion

        protected abstract void GetGridPosition(
            Vector3 position,
            out float height,
            out Quaternion rotation,
            out Vector3 scale);

        protected override void GetPositionData(
            Bounds bounds,
            out Vector3[] positions,
            out Quaternion[] rotations,
            out Vector3[] scales)
        {
            var xCount = (int)(bounds.size.x * visualizationDensity);
            var zCount = (int)(bounds.size.z * visualizationDensity);

            visualizationCount = xCount * zCount;

            positions = new Vector3[visualizationCount];
            rotations = new Quaternion[visualizationCount];
            scales = new Vector3[visualizationCount];

            for (var x = 0; x < xCount; x++)
            for (var z = 0; z < zCount; z++)
            {
                var index = (x * zCount) + z;

                var position_X = bounds.min.x + ((x / (float)xCount) * bounds.size.x);
                var position_Z = bounds.min.z + ((z / (float)zCount) * bounds.size.z);

                var position = new Vector3(position_X, 0f, position_Z);

                GetGridPosition(position, out var height, out var rotation, out var scale);

                position.y = height;

                positions[index] = position;
                rotations[index] = rotation;
                scales[index] = scale;
            }
        }
    }
}
#endif
