#if UNITY_EDITOR

#region

using System;
using Appalachia.CI.Integration.Assets;
using Appalachia.Utility.Extensions;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Scene.Prefabs
{
    public sealed class PrefabSaveToken : IDisposable
    {
        public PrefabSaveToken(
            GameObject prefab,
            UnityEngine.SceneManagement.Scene scene,
            Action<PrefabDisposalToken> onDispose = null)
        {
            _prefab = prefab;
            _scene = scene;
            _path = AssetDatabaseManager.GetAssetPath(prefab);

            if (UnityEditor.SceneManagement.EditorSceneManager.IsPreviewScene(_scene))
            {
                var sceneObjects = _scene.GetRootGameObjects();

                for (var i = sceneObjects.Length - 1; i >= 0; i--)
                {
                    sceneObjects[i].DestroySafely();
                }
            }

            UnityEditor.PrefabUtility.LoadPrefabContentsIntoPreviewScene(_path, _scene);
            var objs = _scene.GetRootGameObjects();
            Mutable = objs[0];
            _onDispose = onDispose;
        }

        #region Fields and Autoproperties

        public GameObject Mutable { get; private set; }

        private Action<PrefabDisposalToken> _onDispose;
        private GameObject _prefab;
        private UnityEngine.SceneManagement.Scene _scene;
        private string _path;

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (UnityEditor.PrefabUtility.HasPrefabInstanceAnyOverrides(Mutable, false))
            {
                UnityEditor.PrefabUtility.SaveAsPrefabAsset(Mutable, _path);
                _prefab = AssetDatabaseManager.LoadAssetAtPath<GameObject>(_path);
            }

            _onDispose?.Invoke(new PrefabDisposalToken(_prefab, _path));

            _prefab = null;
            _scene = default;
            _path = null;
            Mutable = null;
            _onDispose = null;
        }

        #endregion
    }
}

#endif
