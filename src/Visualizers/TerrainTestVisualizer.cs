#if UNITY_EDITOR
using Appalachia.Core.Extensions;
using Appalachia.Editing.Visualizers.Base;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace Appalachia.Editing.Visualizers
{
    public class TerrainTestVisualizer : InstancedIndirectHeightmapMapVisualization
    {
        [OnValueChanged(nameof(SetupTerrainTexture))]
        public Terrain terrain;

        protected override bool ShouldRegenerate => false;

        protected override bool CanGenerate => terrain != null;

        protected override void PrepareInitialGeneration()
        {
            if (terrain == null)
            {
                terrain = Terrain.activeTerrain;
            }
        }

        protected override void PrepareSubsequentGenerations()
        {
            if (terrain == null)
            {
                terrain = Terrain.activeTerrain;
            }
        }

        private void SetupTerrainTexture()
        {
            if (terrain == null)
            {
                terrain = Terrain.activeTerrain;
            }

            texture = terrain.terrainData.heightmapTexture.Capture();
            _transform.position = terrain.transform.position;
        }

        protected override void GetVisualizationInfo(
            Vector3 position,
            out Quaternion rotation,
            out Vector3 scale)
        {
            rotation = quaternion.identity;
            scale = Vector3.one * visualizationSize;
        }
    }
}

#endif