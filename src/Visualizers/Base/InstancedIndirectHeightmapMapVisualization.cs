#if UNITY_EDITOR
using Appalachia.Spatial;
using Sirenix.OdinInspector;
using Unity.Collections;
using UnityEngine;

namespace Appalachia.Editing.Visualizers.Base
{
    public abstract class InstancedIndirectHeightmapMapVisualization : InstancedIndirectGridVisualization
    {
        [HorizontalGroup("A"), PropertyOrder(-100)]
        [OnValueChanged(nameof(Regenerate))]
        public Texture2D texture;

        [HorizontalGroup("A"), PropertyOrder(-100)]
        [ShowInInspector, HideLabel]
        [PreviewField(ObjectFieldAlignment.Right, Height = 128)]
        public Texture2D preview => texture;

        public Vector3 size = Vector3.one;

        protected NativeArray<float> _data;

        protected override bool CanVisualize => _data.IsCreated;

        protected override Bounds GetBounds()
        {
            var center = _transform.position + (.5f * size);
            return new Bounds(center, size);
        }

        protected override void WhenDisabled()
        {
            texture = null;
        }

        protected override void GetGridPosition(Vector3 position, out float height, out Quaternion rotation, out Vector3 scale)
        {
            if (!_data.IsCreated)
            {
                _data = HeightmapJobHelper.LoadHeightData(texture, Allocator.Persistent);
            }

            var mapPosition = _transform.position;
            
            height = HeightmapJobHelper.GetWorldSpaceHeight(position, mapPosition, _data, texture.width, texture.height, size);
            
            position.y = height;

            var normal = HeightmapJobHelper.GetHeightmapNormal(position, mapPosition, _data, texture.width, texture.height, size);
            
            GetVisualizationInfo(position, out rotation, out scale);
        }

        protected abstract void GetVisualizationInfo(Vector3 position, out Quaternion rotation, out Vector3 scale);
    }
}

#endif