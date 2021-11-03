using Appalachia.Core.Preferences;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Debugging
{
    public static class GameViewTracker
    {
        #region Preferences

        private static readonly PREF<bool> s_Enabled = PREFS.REG(PKG.Prefs.Group, "GameView", true);

        #endregion

        private const string NAME = "Toggle GameView tracking %T";

        private static Camera _mainCamera;

        [MenuItem(PKG.Menu.Appalachia.RootTools.Base + NAME, priority = PKG.Menu.Appalachia.RootTools.Priority)]
        public static void ToggleGameViewTracking()
        {
            ToggleEnabled();
        }

        [MenuItem(PKG.Menu.Appalachia.RootTools.Base + NAME, true, priority = PKG.Menu.Appalachia.RootTools.Priority)]
        public static bool ToggleGameViewTrackingValidate()
        {
            Menu.SetChecked(PKG.Menu.Appalachia.Tools.Base + NAME, s_Enabled.v);
            return true;
        }

        private static void Disable()
        {
            SceneView.duringSceneGui -= sceneGUICallback;
            s_Enabled.v = false;
        }

        private static void Enable()
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;

                if (_mainCamera == null)
                {
                    _mainCamera = Object.FindObjectOfType<Camera>();
                }
            }

            SceneView.duringSceneGui -= sceneGUICallback;
            SceneView.duringSceneGui += sceneGUICallback;
            s_Enabled.v = true;
        }

        [InitializeOnLoadMethod]
        private static void InitializeOnLoadMethod()
        {
            EditorApplication.update += ResetState;
        }

        private static void ResetState()
        {
            EditorApplication.update -= ResetState;

            if (s_Enabled.v)
            {
                Enable();
            }
        }

        private static void sceneGUICallback(SceneView s)
        {
            if (_mainCamera == null)
            {
                return;
            }

            if (!s.camera.orthographic)
            {
                var transform = s.camera.transform;
                _mainCamera.transform.SetPositionAndRotation(
                    transform.position /*- (0.1f * transform.forward)*/,
                    transform.rotation
                );
            }
        }

        private static void ToggleEnabled()
        {
            if (!s_Enabled.v)
            {
                Enable();
            }
            else
            {
                Disable();
            }
        }
    }
}
