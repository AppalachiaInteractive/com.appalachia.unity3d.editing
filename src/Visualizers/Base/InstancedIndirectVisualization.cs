#if UNITY_EDITOR
using Appalachia.Editing.Behaviours;
using Appalachia.Globals.Cameras;
using Sirenix.OdinInspector;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;

namespace Appalachia.Editing.Visualizers.Base
{
    public abstract class InstancedIndirectVisualization : EditorOnlyMonoBehaviour
    {
        private static readonly int IndirectShaderDataBuffer =
            Shader.PropertyToID("IndirectShaderDataBuffer");

        [OnValueChanged(nameof(Regenerate))]
        public CameraPreCullManager preCullManager;

        [OnValueChanged(nameof(Regenerate))]
        public Mesh visualizationMesh;

        [OnValueChanged(nameof(Regenerate))]
        public Material visualizationMaterial;

        [ReadOnly] public int visualizationCount;

        public ShadowCastingMode shadowMode = ShadowCastingMode.On;

        public bool receiveShadows = true;

        [ReadOnly] public int framesRendered;

        private Bounds _bounds;
        private int _bufferVisualizationCount;
        private Vector3[] _positions;

        private bool _prepared;
        private Quaternion[] _rotations;
        private Vector3[] _scales;

        protected IndirectShaderData[] _transforms;

        protected Material _visualizationMaterial;

        private ComputeBuffer indirectDataBuffer;

        protected abstract bool ShouldRegenerate { get; }
        protected abstract bool CanVisualize { get; }
        protected abstract bool CanGenerate { get; }

        public override EditorOnlyExclusionStyle exclusionStyle =>
            EditorOnlyExclusionStyle.Component;

        private void OnDisable()
        {
            indirectDataBuffer?.Release();
            indirectDataBuffer = null;
            _transforms = null;
            _positions = null;
            _rotations = null;
            _scales = null;

            WhenDisabled();
        }

        protected override void Internal_OnEnable()
        {
            Regenerate();
        }

        private void PreCull(Camera c)
        {
            if (ShouldRegenerate)
            {
                Regenerate();
            }

            if (!CanVisualize)
            {
                return;
            }

            if ((_visualizationMaterial != null) && _visualizationMaterial.enableInstancing)
            {
                framesRendered += 1;

                _visualizationMaterial.CopyPropertiesFromMaterial(visualizationMaterial);

                Graphics.DrawMeshInstancedProcedural(
                    visualizationMesh,
                    0,
                    _visualizationMaterial,
                    _bounds,
                    _transforms.Length,
                    null,
                    shadowMode,
                    receiveShadows,
                    0,
                    c,
                    LightProbeUsage.Off
                );
            }
        }

        [Button]
        protected void Regenerate()
        {
            if (!CanGenerate)
            {
                return;
            }

            framesRendered = 0;

            if (preCullManager == null)
            {
                preCullManager = FindObjectOfType<CameraPreCullManager>();
            }

            if (preCullManager == null)
            {
                return;
            }

            preCullManager.OnCameraPreCull -= PreCull;

            if (visualizationMesh == null)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var mf = go.GetComponent<MeshFilter>();
                visualizationMesh = mf.sharedMesh;

                DestroyImmediate(go);
            }

            if ((visualizationMaterial == null) || !visualizationMaterial.enableInstancing)
            {
                Debug.LogError(
                    "Visualization material must be assigned with one with instancing enabled."
                );

                return;
            }

            if (_visualizationMaterial != null)
            {
                DestroyImmediate(_visualizationMaterial);
            }

            _visualizationMaterial = new Material(visualizationMaterial);

            preCullManager.OnCameraPreCull += PreCull;

            if (!_prepared)
            {
                PrepareInitialGeneration();
                _prepared = true;
            }
            else
            {
                PrepareSubsequentGenerations();
            }

            _bounds = GetBounds();
            GetPositionData(_bounds, out _positions, out _rotations, out _scales);
        }

        protected abstract void PrepareInitialGeneration();
        protected abstract void PrepareSubsequentGenerations();

        protected abstract Bounds GetBounds();

        protected abstract void GetPositionData(
            Bounds bounds,
            out Vector3[] positions,
            out Quaternion[] rotations,
            out Vector3[] scales);

        protected abstract void WhenDisabled();

        protected void UpdateBuffers()
        {
            visualizationCount = _positions.Length;

            _transforms = new IndirectShaderData[visualizationCount];

            for (var i = 0; i < visualizationCount; ++i)
            {
                var matrix = Matrix4x4.Translate(_positions[i]) *
                             Matrix4x4.Rotate(_rotations[i]) *
                             Matrix4x4.Scale(_scales[i]);

                _transforms[i].PositionMatrix = matrix;
                _transforms[i].InversePositionMatrix = matrix.inverse;
            }

            if ((visualizationCount != _bufferVisualizationCount) || (indirectDataBuffer == null))
            {
                indirectDataBuffer?.Release();

                indirectDataBuffer = new ComputeBuffer(
                    visualizationCount,
                    UnsafeUtility.SizeOf<IndirectShaderData>()
                );
            }

            RefreshBuffers();
        }

        protected void RefreshBuffers()
        {
            indirectDataBuffer.SetData(_transforms);

            _visualizationMaterial.SetBuffer(IndirectShaderDataBuffer, indirectDataBuffer);

            _bufferVisualizationCount = _transforms.Length;
        }

        public struct IndirectShaderData
        {
            public Matrix4x4 PositionMatrix;
            public Matrix4x4 InversePositionMatrix;
        }
    }
}
#endif