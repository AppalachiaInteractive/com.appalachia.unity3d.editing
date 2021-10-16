using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.CI.Integration.Assets;
using Appalachia.CI.Integration.Paths;
using Appalachia.Utility.Reflection;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Metadata
{
    [Serializable]
    public class OrphanedAsset
    {
        private const string _PRF_PFX = nameof(OrphanedAsset) + ".";
        private const string token_guid = "guid: ";
        private const string token_m_script = "  m_Script: ";

        public List<AppaTypeFinderResult> analysisResults;

        public AssetPathMetadata assetPathMetadata;
        public List<AssetField> fields;
        public string originalScriptGUID;

        private static HashSet<string> _excludedFields = new()
        {
            "m_ObjectHideFlags",
            "m_CorrespondingSourceObject",
            "m_PrefabInstance",
            "m_PrefabAsset",
            "m_GameObject",
            "m_Enabled",
            "m_EditorHideFlags",
            "m_Script",
            "m_Name",
            "m_EditorClassIdentifier",
            "m_PrefabInternal"
        };

        private static readonly ProfilerMarker _PRF_CreateByPath = new(_PRF_PFX + nameof(CreateByPath));

        private static readonly ProfilerMarker _PRF_UpdateToNewType = new(_PRF_PFX + nameof(UpdateToNewType));

        public void UpdateToNewType(Type type)
        {
            using (_PRF_UpdateToNewType.Auto())
            {
                var replacementInstance = ScriptableObject.CreateInstance(type);
                var scriptAsset = MonoScript.FromScriptableObject(replacementInstance);
                var scriptPath = AssetDatabaseManager.GetAssetPath(scriptAsset);
                var scriptGuid = AssetDatabaseManager.AssetPathToGUID(scriptPath);

                var allFileLines = assetPathMetadata.GetFileLines();

                for (var i = 0; i < allFileLines.Length; i++)
                {
                    var line = allFileLines[i];

                    if (line.StartsWith("  m_Script: "))
                    {
                        //m_Script: {fileID: 11500000, guid: 82770e431bc44104fa70e98a63fd672d, type: 3}

                        var token = "guid: ";
                        var index = line.IndexOf(token);
                        var start = index + token.Length;

                        var oldScriptGuid = line.Substring(start, 32);

                        var newLine = line.Replace(oldScriptGuid, scriptGuid);
                        allFileLines[i] = newLine;
                    }
                }

                assetPathMetadata.WriteFileLines(allFileLines);
            }
        }

        public static OrphanedAsset CreateByPath<T>(string relativePath)
            where T : class
        {
            using (_PRF_CreateByPath.Auto())
            {
                var asset = new OrphanedAsset
                {
                    assetPathMetadata = new AssetPathMetadata(relativePath, false),
                    fields = new List<AssetField>()
                };

                var allFileLines = asset.assetPathMetadata.GetFileLines();

                var contentLines = allFileLines.Where(l => l.StartsWith(" ")).ToArray();

                for (var i = 0; i < allFileLines.Length; i++)
                {
                    var line = allFileLines[i];

                    if (line.Contains("{fileID: 0}"))
                    {
                        break;
                    }

                    if (line.StartsWith(token_m_script))
                    {
                        var index = line.IndexOf(token_guid);
                        var start = index + token_guid.Length;

                        asset.originalScriptGUID = line.Substring(start, 32);
                        break;
                    }
                }

                foreach (var contentLine in contentLines)
                {
                    if (contentLine.Contains(':'))
                    {
                        var contentLineSplitIndex = contentLine.IndexOf(':');

                        var fieldNameRaw = contentLine.Substring(0, contentLineSplitIndex);
                        var valueRaw = contentLine.Substring(contentLineSplitIndex + 1);

                        var fieldName = fieldNameRaw.Trim();

                        if (_excludedFields.Contains(fieldName))
                        {
                            continue;
                        }

                        var value = valueRaw.Trim();

                        var spacePadding = 0;
                        for (; spacePadding < fieldNameRaw.Length; spacePadding++)
                        {
                            if (fieldNameRaw[spacePadding] != ' ')
                            {
                                break;
                            }
                        }

                        var depth = spacePadding / 2;

                        var firstCharAfterSpace = fieldNameRaw[spacePadding];

                        if (firstCharAfterSpace == '-')
                        {
                            depth += 1;
                        }

                        if (depth == 1)
                        {
                            var assetField = new AssetField {key = fieldName, value = value};

                            asset.fields.Add(assetField);
                        }
                    }
                }

                asset.analysisResults = AppaTypeFinder.FindTypeByFields<T>(asset.fields.Select(f => f.key));

                return asset;
            }
        }
    }
}
