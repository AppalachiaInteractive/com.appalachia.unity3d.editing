#if UNITY_EDITOR

#region

using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.CI.Constants;
using Appalachia.CI.Integration.Assets;
using Appalachia.Core.Attributes;
using Appalachia.Core.Math.Stats;
using Appalachia.Core.Math.Stats.Implementations;
using Appalachia.Core.Objects.Availability;
using Appalachia.Editing.Core;
using Appalachia.Utility.Extensions;
using Appalachia.Utility.Strings;
using Sirenix.OdinInspector;
using Unity.Profiling;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace Appalachia.Editing.Labels
{
    [CallStaticConstructorInEditor]
    public static class LabelManager
    {
        static LabelManager()
        {
            RegisterInstanceCallbacks.WithoutSorting()
                                     .When.Object<LabelSets>()
                                     .IsAvailableThen(i => _labelSets = i);
        }

        #region Static Fields and Autoproperties

        public static List<LabelData> labelDatas = new();

        [NonSerialized] private static AppaContext _context;

        private static Dictionary<Type, Dictionary<object, string>> _enumTypeLookup;

        private static LabelSets _labelSets;
        private static string[] _strings;

        private static ValueDropdownList<string> _labelDropdownList;

        #endregion

        public static bool Initialized => labelDatas?.Count > 0;

        public static string[] strings
        {
            get
            {
                if (_strings == null)
                {
                    InitializeLabels();
                }

                return _strings;
            }
        }

        public static ValueDropdownList<string> labelDropdownList
        {
            get
            {
                if (_labelDropdownList == null)
                {
                    InitializeLabels();
                }

                return _labelDropdownList;
            }
        }

        private static AppaContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new AppaContext(typeof(LabelManager));
                }

                return _context;
            }
        }

        public static void ApplyLabelsToPrefab<T>(GameObject asset, T value)
        {
            using (_PRF_ApplyLabelsToPrefab.Auto())
            {
                var labelHash = new HashSet<string>();
                var assetLabels = AssetDatabaseManager.GetLabels(asset);

                labelHash.AddRange(assetLabels);

                var renderers = asset.GetComponentsInChildren<MeshRenderer>();

                if (renderers.Length <= 0)
                {
                    return;
                }

                var changed = false;

                var lookupType = typeof(T);

                if (!_enumTypeLookup.ContainsKey(lookupType))
                {
                    return;
                }

                var typeLookup = _enumTypeLookup[lookupType];

                if (!typeLookup.ContainsKey(value))
                {
                    return;
                }

                foreach (var possibleLabel in typeLookup)
                {
                    if (((T)possibleLabel.Key).Equals(value))
                    {
                        if (!labelHash.Contains(possibleLabel.Value))
                        {
                            labelHash.Add(possibleLabel.Value);
                            changed = true;
                        }
                    }
                    else
                    {
                        if (labelHash.Contains(possibleLabel.Value))
                        {
                            labelHash.Remove(possibleLabel.Value);
                            changed = true;
                        }
                    }
                }

                if (changed)
                {
                    AssetDatabaseManager.SetLabels(asset, labelHash.ToArray());
                }
            }
        }

        public static LabelData GetLabelData(int i)
        {
            return labelDatas[i];
        }

        public static string GetLabelText(int i)
        {
            return strings[i];
        }

        public static void InitializeLabels()
        {
            using (_PRF_InitializeLabels.Auto())
            {
                var labels = new Dictionary<string, int>();

                var assetPaths = AssetDatabaseManager.FindAssets("t:Object")
                                                     .Select(AssetDatabaseManager.GUIDToAssetPath)
                                                     .ToArray();

                using (var progress = new EditorOnlyProgressBar(
                           "Building label list...",
                           assetPaths.Length,
                           true,
                           200
                       ))
                {
                    for (var i = 0; i < assetPaths.Length; i++)
                    {
                        if (progress.Cancelled)
                        {
                            if (labelDatas == null)
                            {
                                labelDatas = new List<LabelData>();
                            }

                            labelDatas.Clear();
                            return;
                        }

                        progress.Increment1AndShowProgressBasic();

                        var assetPath = assetPaths[i];

                        var obj = AssetDatabaseManager.LoadAssetAtPath<Object>(assetPath);

                        var labelSet = AssetDatabaseManager.GetLabels(obj);

                        for (var j = 0; j < labelSet.Length; j++)
                        {
                            var label = labelSet[j];

                            if (!labels.ContainsKey(label))
                            {
                                labels.Add(label, 1);
                            }
                            else
                            {
                                labels[label] += 1;
                            }
                        }
                    }
                }

                if (labelDatas == null)
                {
                    labelDatas = new List<LabelData>();
                }

                labelDatas.Clear();

                foreach (var labelSet in labels.OrderByDescending(l => l.Value))
                {
                    var newLabelData = new LabelData { label = labelSet.Key, count = labelSet.Value };

                    labelDatas.Add(newLabelData);
                }

                _strings = new string[labelDatas.Count];
                _labelDropdownList = new ValueDropdownList<string>();

                for (var i = 0; i < labelDatas.Count; i++)
                {
                    var label = labelDatas[i];

                    _strings[i] = label.label;
                    _labelDropdownList.Add(label.label, label.label);
                }
            }
        }

        public static void RegisterEnumTypeLabels<T>(T value, string label)
        {
            using (_PRF_RegisterEnumTypeLabels.Auto())
            {
                if (_enumTypeLookup == null)
                {
                    _enumTypeLookup = new Dictionary<Type, Dictionary<object, string>>();
                }

                if (!_enumTypeLookup.ContainsKey(typeof(T)))
                {
                    _enumTypeLookup.Add(typeof(T), new Dictionary<object, string>());
                }

                if (!_enumTypeLookup[typeof(T)].ContainsKey(value))
                {
                    _enumTypeLookup[typeof(T)].Add(value, label);
                }
                else
                {
                    _enumTypeLookup[typeof(T)][value] = label;
                }
            }
        }

        private static void ProcessLabelAssignments(LabelAssignmentCollection collection)
        {
            using (_PRF_ProcessLabelAssignments.Auto())
            {
                var assets =
                    AssetDatabaseManager.FindAssets(ZString.Format("l:{0} t:Prefab", collection.baseTerm));

                var statsTracker =
                    new StatsTrackerCollection<floatStatsTracker, float>(collection.terms.Length);

                using (new AssetEditingScope())
                {
                    for (var i = 0; i < assets.Length; i++)
                    {
                        var guid = assets[i];
                        var path = AssetDatabaseManager.GUIDToAssetPath(guid);
                        var asset = AssetDatabaseManager.LoadAssetAtPath<GameObject>(path);

                        var assetLabels = AssetDatabaseManager.GetLabels(asset);

                        var labelHash = new HashSet<string>();
                        labelHash.AddRange(assetLabels);

                        var renderers = asset.GetComponentsInChildren<MeshRenderer>();

                        if (renderers.Length <= 0)
                        {
                            continue;
                        }

                        var bounds = renderers[0].bounds;
                        var size = bounds.size;

                        var effectiveSize = Vector3.Scale(size, collection.multiplier);

                        var magnitude = effectiveSize.magnitude;

                        var matched = false;
                        var changed = false;

                        for (var termIndex = 0; termIndex < collection.terms.Length; termIndex++)
                        {
                            var term = collection.terms[termIndex];

                            if (!matched &&
                                ((magnitude < term.allowedMagnitude) ||
                                 (termIndex == (collection.terms.Length - 1))))
                            {
                                if (!labelHash.Contains(term.term))
                                {
                                    labelHash.Add(term.term);
                                    changed = true;
                                }

                                matched = true;

                                statsTracker[termIndex].Track(magnitude);
                            }
                            else if (labelHash.Contains(term.term))
                            {
                                labelHash.Remove(term.term);
                                changed = true;
                            }
                        }

                        if (changed)
                        {
                            AssetDatabaseManager.SetLabels(asset, labelHash.ToArray());
                        }
                    }

                    for (var termIndex = 0; termIndex < collection.terms.Length; termIndex++)
                    {
                        var term = collection.terms[termIndex];

                        var count = statsTracker[termIndex].Count;
                        var min = statsTracker[termIndex].Minimum;
                        var max = statsTracker[termIndex].Maximum;
                        var average = statsTracker[termIndex].Average;

                        //var median = statsTracker[termIndex].Median;

                        //Context.Log.Info($"[{term}]:  [ {count} ]  ||  Min: {min:F1}  Max: {max:F1}  Mean: {average:F1}  Median: {median:F1}");
                        Context.Log.Info(
                            ZString.Format(
                                "[{0}]:  [ {1} ]  ||  Min: {2:F1}  Max: {3:F1}  Mean: {4:F1}",
                                term,
                                count,
                                min,
                                max,
                                average
                            )
                        );
                    }
                }
            }
        }

        #region Menu Items

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Label Assembly Prefabs", priority = -1050)]
        public static void MENU_LabelAssemblyPrefabs()
        {
            ProcessLabelAssignments(_labelSets.assemblies);
        }

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Label Object Prefabs", priority = -1050)]
        public static void MENU_LabelObjectPrefabs()
        {
            ProcessLabelAssignments(_labelSets.objects);
        }

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Label Tree Prefabs", priority = -1050)]
        public static void MENU_LabelTreePrefabs()
        {
            ProcessLabelAssignments(_labelSets.trees);
        }

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Label Vegetation Prefabs", priority = -1050)]
        public static void MENU_LabelVegetationPrefabs()
        {
            ProcessLabelAssignments(_labelSets.vegetations);
        }

        #endregion

        #region Profiling

        private const string _PRF_PFX = nameof(LabelManager) + ".";

        private static readonly ProfilerMarker _PRF_ApplyLabelsToPrefab =
            new ProfilerMarker(_PRF_PFX + nameof(ApplyLabelsToPrefab));

        private static readonly ProfilerMarker _PRF_InitializeLabels =
            new ProfilerMarker(_PRF_PFX + nameof(InitializeLabels));

        private static readonly ProfilerMarker _PRF_RegisterEnumTypeLabels =
            new ProfilerMarker(_PRF_PFX + nameof(RegisterEnumTypeLabels));

        private static readonly ProfilerMarker _PRF_ProcessLabelAssignments =
            new ProfilerMarker(_PRF_PFX + nameof(ProcessLabelAssignments));

        #endregion
    }
}

#endif
