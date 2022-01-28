#if UNITY_EDITOR

#region

using Appalachia.CI.Integration.Assets;
using Appalachia.Utility.Constants;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Scene.Prefabs
{
    public static class PrefabSaveTokenExtensions
    {
        #region Static Fields and Autoproperties

        private static AutoDisposePreviewScene _previewScene;

        #endregion

        public static PrefabSaveToken ToMutable(this IPrefabSaveable saveable)
        {
            return new(
                saveable.Prefab,
                _previewScene.previewScene,
                disp => { saveable.Prefab = disp.prefab; }
            );
        }

        public static PrefabSaveToken ToMutable(this IPrefabPathSaveable saveable)
        {
            using var scope = APPASERIALIZE.OnAfterDeserialize();
            var prefab = AssetDatabaseManager.LoadAssetAtPath<GameObject>(saveable.PrefabPath);

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
            using var scope = APPASERIALIZE.OnAfterDeserialize();
            var prefab = AssetDatabaseManager.LoadAssetAtPath<GameObject>(saveable.PrefabPath);

            return new PrefabSaveToken(prefab, previewScene);
        }

        public static PrefabSaveToken ToMutable(
            this GameObject prefab,
            UnityEngine.SceneManagement.Scene previewScene)
        {
            if (!UnityEditor.PrefabUtility.IsPartOfPrefabAsset(prefab))
            {
                return null;
            }

            return new PrefabSaveToken(prefab, previewScene);
        }

        public static PrefabSaveToken ToMutable(this GameObject prefab)
        {
            if (!UnityEditor.PrefabUtility.IsPartOfPrefabAsset(prefab))
            {
                return null;
            }

            return new PrefabSaveToken(prefab, _previewScene.previewScene);
        }
    }
}

#endif
