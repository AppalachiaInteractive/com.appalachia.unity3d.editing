using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Appalachia.Utility.Reflection;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Organization
{
    public static class AssetDatabaseScriptableOrganizer
    {
        [InitializeOnLoadMethod]
        public static void OrganizeScriptableObjects()
        {
            var soPaths = AssetDatabase.FindAssets("t:ScriptableObject")
                                       .Select(AssetDatabase.GUIDToAssetPath);

            var assetPaths = AssetDatabase.GetAllAssetPaths().Where(p => p.EndsWith(".asset"));

            var allPaths = soPaths.Concat(assetPaths).Distinct();

            var typePathCollection = new Dictionary<Type, List<string>>();

            foreach (var assetPath in allPaths)
            {
                var assetType = AssetDatabase.GetMainAssetTypeAtPath(assetPath);

                if (assetType == null)
                {
                    var allFileLines = File.ReadAllLines(assetPath)
                                           .ToArray();
                    var contentLines = allFileLines
                                      .Where(l => l.StartsWith(" "))
                                      .ToArray();

                    var fields = new List<string>();
                    var values = new List<string>();

                    foreach (var contentLine in contentLines)
                    {
                        if (!contentLine.Contains(':'))
                        {
                            continue;
                        }

                        var contentLineSplits = contentLine.Split(':');
                        var fieldName = contentLineSplits[0].Trim();
                        var value = contentLineSplits[1].Trim();

                        fields.Add(fieldName);
                        values.Add(value);
                    }

                    var type = AppaTypeFinder.FindTypeByFields<ScriptableObject>(
                        fields,
                        out var likelihood
                    );

                    if (likelihood < .6f)
                    {
                        LogResult(
                            "SKIPPING",
                            assetPath,
                            likelihood,
                            type,
                            string.Join("\n", allFileLines)
                        );
                        continue;
                    }

                    var replacementInstance = ScriptableObject.CreateInstance(type);
                    var scriptAsset = MonoScript.FromScriptableObject(replacementInstance);
                    var scriptPath = AssetDatabase.GetAssetPath(scriptAsset);
                    var scriptGuid = AssetDatabase.AssetPathToGUID(scriptPath);

                    for (var i = 0; i < allFileLines.Length; i++)
                    {
                        var line = allFileLines[i];

                        if (line.StartsWith("  m_Script: "))
                        {
                            //m_Script: {fileID: 11500000, guid: 82770e431bc44104fa70e98a63fd672d, type: 3}

                            var token = "guid: ";
                            var index = line.IndexOf(token);
                            var start = index + token.Length;

                            var oldScriptGuid = line.Substring(start, 24);

                            var newLine = line.Replace(oldScriptGuid, scriptGuid);
                            allFileLines[i] = newLine;
                        }
                    }

                    File.WriteAllLines(assetPath, allFileLines);

                    LogResult(
                        "SUCCESS",
                        assetPath,
                        likelihood,
                        type,
                        string.Join("\n", allFileLines)
                    );
                }
                else
                {
                    //Debug.Log($"{assetType.Name} | [{assetPath}]");

                    if (!typePathCollection.ContainsKey(assetType))
                    {
                        typePathCollection.Add(assetType, new List<string>());
                    }

                    typePathCollection[assetType].Add(assetPath);    
                }
            }
        }

        private static void LogResult(string result, string assetPath, float likelihood, Type type, string content)
        {
            Debug.LogWarning(
                result + " : " +
                assetPath +
                "\n---------------------\n" +
                likelihood +
                " : " +
                type?.Name +
                "\n---------------------\n" +
                content
            );
        }
    }
}
