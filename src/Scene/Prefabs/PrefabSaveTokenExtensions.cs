#region

using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Scene.Prefabs
{
    public static class PrefabSaveTokenExtensions
    {
        private static AutoDisposePreviewScene _previewScene;

        public static PrefabSaveToken ToMutable(this IPrefabSaveable saveable)
        {
            return new(saveable.Prefab, _previewScene.previewScene, disp =>
            {
                saveable.Prefab = disp.prefab;
            });
        }

        public static PrefabSaveToken ToMutable(this IPrefabPathSaveable saveable)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(saveable.PrefabPath);

            return new PrefabSaveToken(prefab, _previewScene.previewScene);
        }

        public static PrefabSaveToken ToMutable(
            this IPrefabSaveable saveable,
            UnityEngine.SceneManagement.Scene previewScene)
        {
            return new(saveable.Prefab, previewScene, disp => { saveable.Prefab = disp.prefab; });
        }

        public static PrefabSaveToken ToMutable(
            this IPrefabPathSaveable saveable,
            UnityEngine.SceneManagement.Scene previewScene)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(saveable.PrefabPath);

            return new PrefabSaveToken(prefab, previewScene);
        }

        public static PrefabSaveToken ToMutable(
            this GameObject prefab,
            UnityEngine.SceneManagement.Scene previewScene)
        {
            if (!PrefabUtility.IsPartOfPrefabAsset(prefab))
            {
                return null;
            }

            return new PrefabSaveToken(prefab, previewScene);
        }

        public static PrefabSaveToken ToMutable(this GameObject prefab)
        {
            if (!PrefabUtility.IsPartOfPrefabAsset(prefab))
            {
                return null;
            }

            return new PrefabSaveToken(prefab, _previewScene.previewScene);
        }
    }
}
