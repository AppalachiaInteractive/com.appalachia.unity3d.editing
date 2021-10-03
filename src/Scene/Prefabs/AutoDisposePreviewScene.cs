#region

using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

#endregion

namespace Appalachia.Core.Editing.Prefabs
{
    public struct AutoDisposePreviewScene
    {
        private static Scene _previewScene;

        public Scene previewScene
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

        private static readonly Finalizer finalizer = new Finalizer();

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
