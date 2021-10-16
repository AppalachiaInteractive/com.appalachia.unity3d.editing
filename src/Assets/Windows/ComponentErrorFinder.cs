using Appalachia.CI.Integration.Assets;
using Appalachia.Core.Constants;
using Appalachia.Editing.Core.Windows;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows
{
    public class ComponentErrorFinder : AppalachiaEditorWindow
    {
        private static int _goCount, _componentsCount, _missingCount;

        public void OnGUI()
        {
            if (GUILayout.Button("Find Missing Scripts in selected GameObjects"))
            {
                FindInSelected();
            }

            if (GUILayout.Button("Find Missing Scripts"))
            {
                FindAll();
            }

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Component Scanned:");
                EditorGUILayout.LabelField(
                    "" + (_componentsCount == -1 ? "---" : _componentsCount.ToString())
                );
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Object Scanned:");
                EditorGUILayout.LabelField("" + (_goCount == -1 ? "---" : _goCount.ToString()));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Possible Missing Scripts:");
                EditorGUILayout.LabelField("" + (_missingCount == -1 ? "---" : _missingCount.ToString()));
            }
            EditorGUILayout.EndHorizontal();
        }

        public static Object[] LoadAllAssetsAtPath(string assetPath)
        {
            return typeof(SceneAsset).Equals(AssetDatabaseManager.GetMainAssetTypeAtPath(assetPath))
                ?

                // prevent error "Do not use readobjectthreaded on scene objects!"
                new[] {AssetDatabaseManager.LoadMainAssetAtPath(assetPath)}
                : AssetDatabaseManager.LoadAllAssetsAtPath(assetPath);
        }

        [MenuItem(
            APPA_MENU.BASE_AppalachiaWindows +
            APPA_MENU.ASM_AppalachiaEditingAssets +
            nameof(ComponentErrorFinder)
        )]
        public static void ShowWindow()
        {
            GetWindow(typeof(ComponentErrorFinder));
        }

        private static void FindAll()
        {
            _componentsCount = 0;
            _goCount = 0;
            _missingCount = 0;

            var assetsPaths = AssetDatabaseManager.GetAllAssetPaths();

            foreach (var assetPath in assetsPaths)
            {
                var data = LoadAllAssetsAtPath(assetPath);
                foreach (var o in data)
                {
                    if (o != null)
                    {
                        if (o is GameObject)
                        {
                            FindInGO((GameObject) o);
                        }
                    }
                }
            }

            Debug.Log(
                $"Searched {_goCount} GameObjects, {_componentsCount} components, found {_missingCount} missing"
            );
        }

        private static void FindInGO(GameObject g)
        {
            _goCount++;
            var components = g.GetComponents<Component>();
            for (var i = 0; i < components.Length; i++)
            {
                _componentsCount++;
                if (components[i] == null)
                {
                    _missingCount++;
                    var s = g.name;
                    var t = g.transform;
                    while (t.parent != null)
                    {
                        var parent = t.parent;
                        s = parent.name + "/" + s;
                        t = parent;
                    }

                    Debug.Log(s + " has an empty script attached in position: " + i, g);
                }
            }

            // Now recurse through each child GO (if there are any):
            foreach (Transform childT in g.transform)
            {
                //Debug.Log("Searching " + childT.name  + " " );
                FindInGO(childT.gameObject);
            }
        }

        private static void FindInSelected()
        {
            var go = Selection.gameObjects;
            _goCount = 0;
            _componentsCount = 0;
            _missingCount = 0;
            foreach (var g in go)
            {
                FindInGO(g);
            }

            Debug.Log(
                $"Searched {_goCount} GameObjects, {_componentsCount} components, found {_missingCount} missing"
            );
        }
    }
}
