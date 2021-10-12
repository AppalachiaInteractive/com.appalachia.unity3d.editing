using Appalachia.Core.Preferences;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Debugging
{
    public static class GameViewTracker
    {
        private const string k_MenuName = "Tools/Toggle GameView tracking %T";

        private static Camera _mainCamera;

        // Custom labels can be defined.
        private static readonly PREF<bool> s_Enabled = PREFS.REG("Appalachia/Tracking", "GameView", true);

        [InitializeOnLoadMethod]
        private static void InitializeOnLoadMethod()
        {
            EditorApplication.update += ResetState;
        }

        [MenuItem(k_MenuName, true)]
        public static bool ToggleGameViewTrackingValidate()
        {
            Menu.SetChecked(k_MenuName, s_Enabled.v);
            return true;
        }

        [MenuItem(k_MenuName, priority = 1050)]
        public static void ToggleGameViewTracking()
        {
            ToggleEnabled();
        }

        private static void ResetState()
        {
            EditorApplication.update -= ResetState;

            if (s_Enabled.v)
            {
                Enable();
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

        private static void Enable()
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }

            SceneView.duringSceneGui -= sceneGUICallback;
            SceneView.duringSceneGui += sceneGUICallback;
            s_Enabled.v = true;
        }

        private static void Disable()
        {
            SceneView.duringSceneGui -= sceneGUICallback;
            s_Enabled.v = false;
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
    }
}
