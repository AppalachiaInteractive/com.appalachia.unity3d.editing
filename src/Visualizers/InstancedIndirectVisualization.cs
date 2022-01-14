#if UNITY_EDITOR
using Appalachia.Core.Objects.Initialization;
using Appalachia.Editing.Core.Behaviours;
using Appalachia.Utility.Async;
using Sirenix.OdinInspector;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Appalachia.Editing.Visualizers
{
    public abstract class
        InstancedIndirectVisualization : EditorOnlyAppalachiaBehaviour<InstancedIndirectVisualization>
    {
        #region Constants and Static Readonly

        private static readonly int IndirectShaderDataBuffer =
            Shader.PropertyToID("IndirectShaderDataBuffer");

        #endregion

        #region Fields and Autoproperties

        public bool receiveShadows = true;
        [ReadOnly] public int framesRendered;

        [ReadOnly] public int visualizationCount;

        [OnValueChanged(nameof(Regenerate))]
        public Material visualizationMaterial;

        [OnValueChanged(nameof(Regenerate))]
        public Mesh visualizationMesh;

        public ShadowCastingMode shadowMode = ShadowCastingMode.On;

        protected IndirectShaderData[] _transforms;

        protected Material _visualizationMaterial;

        private bool _prepared;

        private Bounds _bounds;

        private ComputeBuffer indirectDataBuffer;
        private int _bufferVisualizationCount;
        private Quaternion[] _rotations;
        private Vector3[] _positions;
        private Vector3[] _scales;

        #endregion

        protected abstract bool CanGenerate { get; }
        protected abstract bool CanVisualize { get; }

        protected abstract bool ShouldRegenerate { get; }

        #region Event Functions

        private void OnPreCull()
        {
            using (_PRF_OnPreCull.Auto())
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
                        Camera.current,
                        LightProbeUsage.Off
                    );
                }
            }
        }

        #endregion

        protected abstract Bounds GetBounds();

        protected abstract void GetPositionData(
            Bounds bounds,
            out Vector3[] positions,
            out Quaternion[] rotations,
            out Vector3[] scales);

        protected abstract void PrepareInitialGeneration();
        protected abstract void PrepareSubsequentGenerations();

        protected override async AppaTask Initialize(Initializer initializer)
        {
            await base.Initialize(initializer);

            using (_PRF_Initialize.Auto())
            {
                Regenerate();
            }
        }
        

        protected override async AppaTask WhenDisabled()
        {
            using (_PRF_WhenDisabled.Auto())
            {
                await base.WhenDisabled();

                indirectDataBuffer?.Release();
                indirectDataBuffer = null;
                _transforms = null;
                _positions = null;
                _rotations = null;
                _scales = null;
            }
        }

        protected void RefreshBuffers()
        {
            using (_PRF_RefreshBuffers.Auto())
            {
                indirectDataBuffer.SetData(_transforms);

                _visualizationMaterial.SetBuffer(IndirectShaderDataBuffer, indirectDataBuffer);

                _bufferVisualizationCount = _transforms.Length;
            }
        }

        [Button]
        protected void Regenerate()
        {
            using (_PRF_Regenerate.Auto())
            {
                if (!CanGenerate)
                {
                    return;
                }

                framesRendered = 0;

                if (visualizationMesh == null)
                {
                    var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    var mf = go.GetComponent<MeshFilter>();
                    visualizationMesh = mf.sharedMesh;

                    DestroyImmediate(go);
                }

                if ((visualizationMaterial == null) || !visualizationMaterial.enableInstancing)
                {
                    Context.Log.Error(
                        "Visualization material must be assigned with one with instancing enabled."
                    );

                    return;
                }

                if (_visualizationMaterial != null)
                {
                    DestroyImmediate(_visualizationMaterial);
                }

                _visualizationMaterial = new Material(visualizationMaterial);

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
        }

        protected void UpdateBuffers()
        {
            using (_PRF_UpdateBuffers.Auto())
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
        }

        #region Nested type: IndirectShaderData

        public struct IndirectShaderData
        {
            #region Fields and Autoproperties

            public Matrix4x4 InversePositionMatrix;
            public Matrix4x4 PositionMatrix;

            #endregion
        }

        #endregion

        #region Profiling

        private static readonly ProfilerMarker _PRF_OnPreCull =
            new ProfilerMarker(_PRF_PFX + nameof(OnPreCull));

        private static readonly ProfilerMarker _PRF_RefreshBuffers =
            new ProfilerMarker(_PRF_PFX + nameof(RefreshBuffers));

        private static readonly ProfilerMarker _PRF_Regenerate =
            new ProfilerMarker(_PRF_PFX + nameof(Regenerate));

        private static readonly ProfilerMarker _PRF_UpdateBuffers =
            new ProfilerMarker(_PRF_PFX + nameof(UpdateBuffers));

        #endregion
    }
}
#endif
