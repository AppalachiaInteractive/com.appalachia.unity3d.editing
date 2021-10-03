#if UNITY_EDITOR

#region

using System;
using Appalachia.Core.Extensions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

namespace Appalachia.Core.Editing.Prefabs
{
    public sealed class PrefabSaveToken : IDisposable
    {
        private GameObject _prefab;
        private Scene _scene;
        private string _path;
        private Action<PrefabDisposalToken> _onDispose;

        public PrefabSaveToken(GameObject prefab, Scene scene, Action<PrefabDisposalToken> onDispose = null)
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
