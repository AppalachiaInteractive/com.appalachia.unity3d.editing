using Appalachia.Utility.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace Appalachia.Editing.Debugging.IngameDebugConsole.Commands
{
    public class SceneCommands
    {
        [ConsoleMethod("scene.load", "Loads a scene")]
        [Preserve]
        public static void LoadScene(string sceneName)
        {
            LoadSceneInternal(sceneName, false, LoadSceneMode.Single);
        }

        [ConsoleMethod("scene.load", "Loads a scene")]
        [Preserve]
        public static void LoadScene(string sceneName, LoadSceneMode mode)
        {
            LoadSceneInternal(sceneName, false, mode);
        }

        [ConsoleMethod("scene.loadasync", "Loads a scene asynchronously")]
        [Preserve]
        public static void LoadSceneAsync(string sceneName)
        {
            LoadSceneInternal(sceneName, true, LoadSceneMode.Single);
        }

        [ConsoleMethod("scene.loadasync", "Loads a scene asynchronously")]
        [Preserve]
        public static void LoadSceneAsync(string sceneName, LoadSceneMode mode)
        {
            LoadSceneInternal(sceneName, true, mode);
        }

        [ConsoleMethod("scene.restart", "Restarts the active scene")]
        [Preserve]
        public static void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        [ConsoleMethod("scene.unload", "Unloads a scene")]
        [Preserve]
        public static void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        private static void LoadSceneInternal(string sceneName, bool isAsync, LoadSceneMode mode)
        {
            if (SceneManager.GetSceneByName(sceneName).IsValid())
            {
                AppaLog.Info("Scene " + sceneName + " is already loaded");
                return;
            }

            if (isAsync)
            {
                SceneManager.LoadSceneAsync(sceneName, mode);
            }
            else
            {
                SceneManager.LoadScene(sceneName, mode);
            }
        }
    }
}
