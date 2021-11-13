#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Appalachia.Editing.Core.Menus
{
    public static class MenuUtilities
    {
        public static void EditForEachComponent<T>(Action<T> action)
        {
            try
            {
                UnityEditor.AssetDatabase.StartAssetEditing();

                ForEachComponent(action);
            }
            finally
            {
                UnityEditor.AssetDatabase.StopAssetEditing();
                UnityEditor.AssetDatabase.Refresh();
            }
        }

        public static void ForEachComponent<T>(Action<T> action)
        {
            var objs = UnityEditor.Selection.objects;

            foreach (var obj in objs)
            {
                T target;

                if (obj is GameObject gameObj)
                {
                    target = gameObj.GetComponent<T>();
                }
                else
                {
                    target = (T) (object) obj;
                }

                if (target == null)
                {
                    continue;
                }

                action(target);
            }
        }

        public static void ForEachEmbedded<T>(Action<T> action)
        {
            var objs = UnityEditor.Selection.objects;

            foreach (var obj in objs)
            {
                var path = UnityEditor.AssetDatabase.GetAssetPath(obj);
                var subAssets = UnityEditor.AssetDatabase.LoadAllAssetRepresentationsAtPath(path);

                if (subAssets.Length == 0)
                {
                    continue;
                }

                foreach (var subAsset in subAssets)
                {
                    if (subAsset is T embedded)
                    {
                        action(embedded);
                    }
                }
            }
        }

        public static void ForEachEmbeddedAll<T>(Action<List<T>> action)
        {
            var objs = UnityEditor.Selection.objects;

            foreach (var obj in objs)
            {
                var path = UnityEditor.AssetDatabase.GetAssetPath(obj);
                var subAssets = UnityEditor.AssetDatabase.LoadAllAssetRepresentationsAtPath(path);

                if (subAssets.Length == 0)
                {
                    continue;
                }

                var subs = new List<T>();
                foreach (var subAsset in subAssets)
                {
                    if (subAsset is T embedded)
                    {
                        subs.Add(embedded);
                    }
                }

                if (subs.Count > 0)
                {
                    action(subs);
                }
            }
        }

        public static IEnumerable<T> ForEachGameObjectSelection<T>(Func<GameObject, T> function)
        {
            var objs = UnityEditor.Selection.gameObjects;

            foreach (var obj in objs)
            {
                yield return function(obj);
            }
        }

        public static void ForEachGameObjectSelection(Action<GameObject> action)
        {
            var objs = UnityEditor.Selection.gameObjects;

            foreach (var obj in objs)
            {
                action(obj);
            }
        }
    }
}

#endif