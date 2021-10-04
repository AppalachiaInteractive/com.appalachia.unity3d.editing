#if UNITY_EDITOR

#region

using System;
using Appalachia.Core.Extensions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Scene.Prefabs
{
    public sealed class PrefabSaveToken : IDisposable
    {
        private Action<PrefabDisposalToken> _onDispose;
        private string _path;
        private GameObject _prefab;
        private UnityEngine.SceneManagement.Scene _scene;

        public PrefabSaveToken(
            GameObject prefab,
            UnityEngine.SceneManagement.Scene scene,
            Action<PrefabDisposalToken> onDispose = null)
        {
            _prefab = prefab;
            _scene = scene;
            _path = AssetDatabase.GetAssetPath(prefab);

            if (EditorSceneManager.IsPreviewScene(_scene))
            {
                var sceneObjects = _scene.GetRootGameObjects();

                for (var i = sceneObjects.Length - 1; i >= 0; i--)
                {
                    sceneObjects[i].DestroySafely();
                }
            }

            PrefabUtility.LoadPrefabContentsIntoPreviewScene(_path, _scene);
            var objs = _scene.GetRootGameObjects();
            Mutable = objs[0];
            _onDispose = onDispose;
        }

        public GameObject Mutable { get; private set; }

        public void Dispose()
        {
            if (PrefabUtility.HasPrefabInstanceAnyOverrides(Mutable, false))
            {
                PrefabUtility.SaveAsPrefabAsset(Mutable, _path);
                _prefab = AssetDatabase.LoadAssetAtPath<GameObject>(_path);
            }

            _onDispose?.Invoke(new PrefabDisposalToken(_prefab, _path));

            _prefab = null;
            _scene = default;
            _path = null;
            Mutable = null;
            _onDispose = null;
        }
    }
}

#endif