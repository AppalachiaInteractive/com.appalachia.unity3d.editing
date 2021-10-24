using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Menus
{
    public static class MenuUtilities
    {
        public static void EditForEachComponent<T>(Action<T> action)
        {
            try
            {
                AssetDatabase.StartAssetEditing();

                ForEachComponent(action);
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
                AssetDatabase.Refresh();
            }
        }

        public static void ForEachComponent<T>(Action<T> action)
        {
            var objs = Selection.objects;

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
            var objs = Selection.objects;

            foreach (var obj in objs)
            {
                var path = AssetDatabase.GetAssetPath(obj);
                var subAssets = AssetDatabase.LoadAllAssetRepresentationsAtPath(path);

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
            var objs = Selection.objects;

            foreach (var obj in objs)
            {
                var path = AssetDatabase.GetAssetPath(obj);
                var subAssets = AssetDatabase.LoadAllAssetRepresentationsAtPath(path);

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
            var objs = Selection.gameObjects;

            foreach (var obj in objs)
            {
                yield return function(obj);
            }
        }

        public static void ForEachGameObjectSelection(Action<GameObject> action)
        {
            var objs = Selection.gameObjects;

            foreach (var obj in objs)
            {
                action(obj);
            }
        }
    }
}
