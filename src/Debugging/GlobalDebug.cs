#if UNITY_EDITOR

using System;
using Appalachia.Base.Scriptables;
using Appalachia.Globals.Shading;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Debugging
{
    [Serializable]
    public class GlobalDebug : SelfSavingSingletonScriptableObject<GlobalDebug>
    {
        [TitleGroup("Debug")]
        [OnValueChanged(nameof(Update))]
        public DebugMode debugMode = DebugMode.Off;

        [BoxGroup("Debug/Motion")]
        [HideLabel]
        [EnableIf(nameof(enableDebugMotion))]
        [OnValueChanged(nameof(Update))]
        public DebugMotion debugMotion = DebugMotion.PrimaryRoll;

        [BoxGroup("Debug/Mesh")]
        [HideLabel]
        [EnableIf(nameof(enableDebugMesh))]
        [OnValueChanged(nameof(Update))]
        public DebugMesh debugMesh = DebugMesh.VertexColorR;

        [BoxGroup("Debug/ Value Remapping")]
        [MinMaxSlider(0.0f, 1.0f)]
        [EnableIf(nameof(enableAny))]
        [OnValueChanged(nameof(Update))]
        public Vector2 remap = new(0f, 1f);

        private bool _enabled;
        private bool _initialized;

        private Shader debugShader;
        private bool enableAny => debugMode != DebugMode.Off;
        private bool enableDebugMotion => debugMode == DebugMode.DebugMotion;
        private bool enableDebugMesh => debugMode == DebugMode.DebugMesh;

        [Button]
        public void SelectShader()
        {
            Selection.activeObject = debugShader;
        }

        private void Initialize()
        {
            if (!_initialized)
            {
                _initialized = true;
                _enabled = false;
                debugShader = GSR.instance.debugShader;
                GSPL.Include(debugShader);
                remap = new Vector2(0f, 1f);

                SceneView.lastActiveSceneView.SetSceneViewShaderReplace(null, null);
                SceneView.lastActiveSceneView.Repaint();
            }
        }

        public void Update()
        {
            Initialize();

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
                        mode = (int) debugMotion;
                    }
                    else if (debugMode == DebugMode.DebugMesh)
                    {
                        mode = (int) debugMesh;
                    }

                    Shader.SetGlobalFloat(GSPL.Get(GSC.DEBUG._DEBUG_MODE), mode);
                    Shader.SetGlobalFloat(GSPL.Get(GSC.DEBUG._DEBUG_MIN),  remap.x);
                    Shader.SetGlobalFloat(GSPL.Get(GSC.DEBUG._DEBUG_MAX),  remap.y);

                    SceneView.lastActiveSceneView.Repaint();
                }
            }
        }
    }
}
#endif
