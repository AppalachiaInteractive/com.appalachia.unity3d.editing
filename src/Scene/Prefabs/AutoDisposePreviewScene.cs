#region

using UnityEditor.SceneManagement;

#endregion

namespace Appalachia.Editing.Scene.Prefabs
{
    public struct AutoDisposePreviewScene
    {
        private static UnityEngine.SceneManagement.Scene _previewScene;

        public UnityEngine.SceneManagement.Scene previewScene
        {
            get
            {
                if ((_previewScene == default) || !EditorSceneManager.IsPreviewScene(_previewScene))
                {
                    _previewScene = EditorSceneManager.NewPreviewScene();
                }

                return _previewScene;
            }
        }

        private static readonly Finalizer finalizer = new();

        private sealed class Finalizer
        {
            ~Finalizer()
            {
                if (EditorSceneManager.IsPreviewScene(_previewScene))
                {
                    EditorSceneManager.ClosePreviewScene(_previewScene);
                }
            }
        }
    }
}
