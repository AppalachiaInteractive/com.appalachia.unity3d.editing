#region

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace Appalachia.Core.Editing.AssetDB
{
    public static class AssetDatabaseHelper
    {
        public static T[] FindAssets<T>(string searchString = null)
            where T : Object
        {
            var searchType = typeof(T);
            var searchTypeName = searchType.Name;

            var guids = AssetDatabase.FindAssets($"t:{searchTypeName} {searchString ?? string.Empty}");

            var hits = 0;
            
            for (var i = 0; i < guids.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                var type = AssetDatabase.GetMainAssetTypeAtPath(path);

                if (searchType.IsAssignableFrom(type))
                {
                    hits += 1;
                }
            }

            if (hits == guids.Length)
            {
                var results = new T[guids.Length];

                for (var i = 0; i < guids.Length; i++)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                
                    results[i] = AssetDatabase.LoadAssetAtPath<T>(path);
                }

                return results;
            }
            else
            {
                var results = new List<T>(guids.Length);

                for (var i = 0; i < guids.Length; i++)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                
                    var j = AssetDatabase.LoadAssetAtPath<T>(path);

                    if (j != null)
                    {
                        results.Add(j);
                    }
                }

                return results.ToArray();
            }
        }
        
        public static List<T> FindAssetsList<T>(string searchString = null)
            where T : Object
        {
            var typename = typeof(T).Name;

            var guids = AssetDatabase.FindAssets($"t:{typename} {searchString ?? string.Empty}");
            var results = new List<T>(guids.Length);

            for (var i = 0; i < guids.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                
                var j = AssetDatabase.LoadAssetAtPath<T>(path);

                if (j != null)
                {
                    results.Add(j);
                }
            }

            return results;
        }
        
        public static List<Object> FindAssetsList(Type t, string searchString = null)
        {
            var typename = t.Name;

            var guids = AssetDatabase.FindAssets($"t:{typename} {searchString ?? string.Empty}");
            var results = new List<UnityEngine.Object>(guids.Length);

            for (var i = 0; i < guids.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                var cast = AssetDatabase.LoadAssetAtPath(path, t);

                if (cast != null)
                {
                    results.Add(cast);
                }
            }

            return results;
        }

        public static GameObject GetPrefabAsset(GameObject prefabInstance)
        {
            var path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(prefabInstance);

            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            return AssetDatabase.LoadAssetAtPath<GameObject>(path);
        }
    }
}
