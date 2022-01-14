#if UNITY_EDITOR
namespace Appalachia.Editing.Scene.Prefabs
{
    public struct AutoDisposePreviewScene
    {
        #region Constants and Static Readonly

        private static readonly Finalizer finalizer = new();

        #endregion

        #region Static Fields and Autoproperties

        private static UnityEngine.SceneManagement.Scene _previewScene;

        #endregion

        public UnityEngine.SceneManagement.Scene previewScene
        {
            get
            {
                if ((_previewScene == default) ||
                    !UnityEditor.SceneManagement.EditorSceneManager.IsPreviewScene(_previewScene))
                {
                    _previewScene = UnityEditor.SceneManagement.EditorSceneManager.NewPreviewScene();
                }

                return _previewScene;
            }
        }

        #region Nested type: Finalizer

        #region Nested Types

        private sealed class Finalizer
        {
            ~Finalizer()
            {
                if (UnityEditor.SceneManagement.EditorSceneManager.IsPreviewScene(_previewScene))
                {
                    UnityEditor.SceneManagement.EditorSceneManager.ClosePreviewScene(_previewScene);
                }
            }
        }

        #endregion

        #endregion
    }
}
#endif
