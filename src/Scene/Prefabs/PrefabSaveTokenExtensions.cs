#region

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

namespace Appalachia.Core.Editing.Prefabs
{
    public static class PrefabSaveTokenExtensions
    {
        private static AutoDisposePreviewScene _previewScene = new AutoDisposePreviewScene();

        public static PrefabSaveToken ToMutable(this IPrefabSaveable saveable)
        {
            return new PrefabSaveToken(saveable.Prefab, _previewScene.previewScene, disp => { saveable.Prefab = disp.prefab; });
        }

        public static PrefabSaveToken ToMutable(this IPrefabPathSaveable saveable)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(saveable.PrefabPath);

            return new PrefabSaveToken(prefab, _previewScene.previewScene);
        }

        public static PrefabSaveToken ToMutable(this IPrefabSaveable saveable, Scene previewScene)
        {
            return new PrefabSaveToken(saveable.Prefab, previewScene, disp => { saveable.Prefab = disp.prefab; });
        }

        public static PrefabSaveToken ToMutable(this IPrefabPathSaveable saveable, Scene previewScene)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(saveable.PrefabPath);

            return new PrefabSaveToken(prefab, previewScene);
        }

        public static PrefabSaveToken ToMutable(this GameObject prefab, Scene previewScene)
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
