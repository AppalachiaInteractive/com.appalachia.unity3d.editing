#if UNITY_EDITOR

using System;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Core.Debugging;
using Appalachia.Core.Objects.Initialization;
using Appalachia.Core.Objects.Root;
using Appalachia.Core.Shading;
using Appalachia.Utility.Async;
using Sirenix.OdinInspector;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Debugging
{
    [Serializable]
    public class RendererDebuggingSettings : SingletonAppalachiaObject<RendererDebuggingSettings>
    {
        #region Fields and Autoproperties

        [BoxGroup("Debug/Mesh")]
        [HideLabel]
        [EnableIf(nameof(enableDebugMesh))]
        [OnValueChanged(nameof(Update))]
        public DebugMesh debugMesh = DebugMesh.VertexColorR;

        [TitleGroup("Debug")]
        [OnValueChanged(nameof(Update))]
        public DebugMode debugMode = DebugMode.Off;

        [BoxGroup("Debug/Motion")]
        [HideLabel]
        [EnableIf(nameof(enableDebugMotion))]
        [OnValueChanged(nameof(Update))]
        public DebugMotion debugMotion = DebugMotion.PrimaryRoll;

        [SmartLabel]
        [BoxGroup("Debug/Shader")]
        public Shader debugShader;

        [BoxGroup("Debug/ Value Remapping")]
        [MinMaxSlider(0.0f, 1.0f)]
        [EnableIf(nameof(enableAny))]
        [OnValueChanged(nameof(Update))]
        public Vector2 remap = new(0f, 1f);

        private bool _enabled;
        private bool _initialized;

        #endregion

        private bool enableAny => debugMode != DebugMode.Off;
        private bool enableDebugMesh => debugMode == DebugMode.DebugMesh;
        private bool enableDebugMotion => debugMode == DebugMode.DebugMotion;

        [Button]
        public void SelectShader()
        {
            using (_PRF_SelectShader.Auto())
            {
                Selection.activeObject = debugShader;
            }
        }

        public void Update()
        {
            using (_PRF_Update.Auto())
            {
                if (!DependenciesAreReady || !FullyInitialized)
                {
                    return;
                }

                if (SceneView.lastActiveSceneView != null)
                {
                    if (debugMode == DebugMode.Off)
                    {
                        if (_enabled)
                        {
                            _enabled = false;

                            SceneView.lastActiveSceneView.SetSceneViewShaderReplace(null, null);
                            SceneView.lastActiveSceneView.Repaint();
                        }
                    }
                    else
                    {
                        _enabled = true;

                        SceneView.lastActiveSceneView.SetSceneViewShaderReplace(debugShader, null);

                        var mode = 0;

                        if (debugMode == DebugMode.DebugMotion)
                        {
                            mode = (int)debugMotion;
                        }
                        else if (debugMode == DebugMode.DebugMesh)
                        {
                            mode = (int)debugMesh;
                        }

                        Shader.SetGlobalFloat(GSPL.Get(GSC.DEBUG._DEBUG_MODE), mode);
                        Shader.SetGlobalFloat(GSPL.Get(GSC.DEBUG._DEBUG_MIN),  remap.x);
                        Shader.SetGlobalFloat(GSPL.Get(GSC.DEBUG._DEBUG_MAX),  remap.y);

                        SceneView.lastActiveSceneView.Repaint();
                    }
                }
            }
        }

        /// <inheritdoc />
        protected override async AppaTask Initialize(Initializer initializer)
        {
            await base.Initialize(initializer);

            using (_PRF_Initialize.Auto())
            {
                if (!_initialized)
                {
                    _initialized = true;
                    _enabled = false;

                    //debugShader = _GSR.debugShader;
                    GSPL.Include(debugShader);
                    remap = new Vector2(0f, 1f);

                    SceneView.lastActiveSceneView.SetSceneViewShaderReplace(null, null);
                    SceneView.lastActiveSceneView.Repaint();
                }
            }
        }

        #region Profiling

        private static readonly ProfilerMarker _PRF_SelectShader =
            new ProfilerMarker(_PRF_PFX + nameof(SelectShader));

        private static readonly ProfilerMarker _PRF_Update = new ProfilerMarker(_PRF_PFX + nameof(Update));

        #endregion
    }
}
#endif
