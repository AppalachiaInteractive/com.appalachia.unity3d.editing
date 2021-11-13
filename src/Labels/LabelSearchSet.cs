#if UNITY_EDITOR

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Appalachia.CI.Integration.Assets;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Utility.Logging;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace Appalachia.Editing.Labels
{
    [Serializable]
    public class LabelSearchSet
    {
        public LabelSearchSet()
        {
            terms = new List<LabelSearchTerm> {new()};
            exclusions = new List<LabelSearchTerm>();
        }

        [BoxGroup("B", ShowLabel = false)]
        [SmartLabel]
        [SerializeField]
        [InlineButton(nameof(RefreshLabels))]
        [OnValueChanged(nameof(ResetDisplayName))]
        public ExclusionStyle exclusionStyle;

        [BoxGroup("A", ShowLabel = false)]
        [SmartLabel]
        [SerializeField]
        [InlineButton(nameof(RefreshLabels))]
        [OnValueChanged(nameof(ResetDisplayName))]
        public LabelMatchStyle matchStyle;

        [BoxGroup("B", ShowLabel = false)]
        [ListDrawerSettings(Expanded = true)]
        [SerializeField]
        [OnValueChanged(nameof(ResetDisplayName))]
        public List<LabelSearchTerm> exclusions;

        [BoxGroup("A", ShowLabel = false)]
        [ListDrawerSettings(Expanded = true)]
        [SerializeField]
        [OnValueChanged(nameof(ResetDisplayName))]
        public List<LabelSearchTerm> terms;

        [NonSerialized] private int _exclusionCount;
        [NonSerialized] private int _termCount;

        [NonSerialized] private string _displayName;

        [NonSerialized] private StringBuilder _builder;
        [NonSerialized] private StringBuilder _logBuilder;

        public bool CanSearch => (terms != null) && (terms.Count > 0) && terms.Any(t => t.enabled);

        public int ExclusionCount => exclusions.Count(t => t.enabled);

        public int TermCount => terms.Count(t => t.enabled);

        public string DisplayName
        {
            get
            {
                try
                {
                    if (terms == null)
                    {
                        terms = new List<LabelSearchTerm>();
                    }

                    if (exclusions == null)
                    {
                        exclusions = new List<LabelSearchTerm>();
                    }

                    var enabledTermCount = TermCount;
                    var enabledExclusionCount = ExclusionCount;

                    if (string.IsNullOrWhiteSpace(_displayName) ||
                        (_termCount != enabledTermCount) ||
                        (_exclusionCount != enabledExclusionCount))
                    {
                        if (_builder == null)
                        {
                            _builder = new StringBuilder();
                        }

                        if ((terms == null) || (enabledTermCount == 0))
                        {
                            return null;
                        }

                        _builder.Clear();
                        _builder.Append($"Labels | Match If {matchStyle}: ");

                        for (var i = 0; i < terms.Count; i++)
                        {
                            var term = terms[i];

                            if (term.label == null)
                            {
                                term.enabled = false;
                                enabledTermCount -= 1;
                            }

                            if (!term.enabled)
                            {
                                continue;
                            }

                            _builder.Append($"{term.label}, ");
                        }

                        if (exclusions.Count > 0)
                        {
                            _builder.Append($" | Exclude If {matchStyle}: ");

                            for (var i = 0; i < exclusions.Count; i++)
                            {
                                var exclusion = exclusions[i];

                                if (exclusion.label == null)
                                {
                                    exclusion.enabled = false;
                                    enabledExclusionCount -= 1;
                                }

                                if (!exclusion.enabled)
                                {
                                    continue;
                                }

                                _builder.Append($"{exclusion.label}, ");
                            }
                        }

                        _termCount = enabledTermCount;
                        _exclusionCount = enabledExclusionCount;

                        var s = _builder.ToString();

                        _displayName = s.Substring(0, s.Length - 2);
                    }

                    return _displayName;
                }
                catch (Exception ex)
                {
                    AppaLog.Error(ex);
                    return null;
                }
            }
        }

        public void AddNewLabel()
        {
            terms.Add(new LabelSearchTerm());
        }

        public List<GameObject> GetAssetsMatchingAll()
        {
            return GetAssetsMatching(true);
        }

        public List<GameObject> GetAssetsMatchingAny()
        {
            return GetAssetsMatching(false);
        }

        public string GetSearchTerm()
        {
            if (_builder == null)
            {
                _builder = new StringBuilder();
            }

            _builder.Clear();

            _builder.Append("t: Prefab ");

            for (var i = 0; i < terms.Count; i++)
            {
                if (terms[i].enabled)
                {
                    _builder.Append($"l: {terms[i].label} ");
                }
            }

            return _builder.ToString();
        }

        public bool Matches(Object obj)
        {
            if (terms.Count == 0)
            {
                return false;
            }

            var labels = AssetDatabaseManager.GetLabels(obj);

            return Matches(labels);
        }

        public bool Matches(IEnumerable<string> labels, bool log = false)
        {
            var termCount = TermCount;
            var exclusionCount = ExclusionCount;

            if (_logBuilder == null)
            {
                _logBuilder = new StringBuilder();
            }

            _logBuilder.Clear();

            if (log)
            {
                _logBuilder.AppendLine($"Checking labels... [{string.Join(", ", labels)}]");
            }

            if (termCount == 0)
            {
                if (log)
                {
                    _logBuilder.AppendLine("  No search terms.");
                    AppaLog.Info($"FAIL: {_logBuilder}");
                }

                return false;
            }

            if (log)
            {
                _logBuilder.AppendLine();
                _logBuilder.AppendLine(
                    $"  TERMS: [{string.Join(", ", terms.Where(e => e.enabled).Select(e => e.label))}]"
                );
                _logBuilder.AppendLine();
            }

            bool included;
            bool excluded;

            switch (matchStyle)
            {
                case LabelMatchStyle.All:
                    if (log)
                    {
                        _logBuilder.AppendLine("  Match Style: ALL");
                    }

                    included = HasAll(labels, terms, log ? _logBuilder : null);
                    break;
                case LabelMatchStyle.Any:
                    if (log)
                    {
                        _logBuilder.AppendLine("  Match Style: ANY");
                    }

                    included = HasAny(labels, terms, log ? _logBuilder : null);
                    break;
                case LabelMatchStyle.MoreThanOne:
                    if (log)
                    {
                        _logBuilder.AppendLine("  Match Style: MORE THAN ONE");
                    }

                    included = HasMoreThanOne(labels, terms, log ? _logBuilder : null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (log)
            {
                _logBuilder.AppendLine($"  Inclusion check: {false}.");
            }

            if (!included)
            {
                if (log)
                {
                    AppaLog.Warn($"FAIL: {_logBuilder}");
                }

                return false;
            }

            if (exclusionCount == 0)
            {
                if (log)
                {
                    _logBuilder.AppendLine("  No exclusion terms.");
                    AppaLog.Info($"PASS: {_logBuilder}");
                }

                return true;
            }

            if (log)
            {
                _logBuilder.AppendLine();
                _logBuilder.AppendLine(
                    $"  EXCLUSIONS: [{string.Join(", ", exclusions.Where(e => e.enabled).Select(e => e.label))}]"
                );
                _logBuilder.AppendLine();
            }

            switch (exclusionStyle)
            {
                case ExclusionStyle.ExcludeIfAny:
                    if (log)
                    {
                        _logBuilder.AppendLine("  Exclusion Style: ANY");
                    }

                    excluded = HasAny(labels, exclusions, log ? _logBuilder : null);
                    break;
                case ExclusionStyle.ExcludeIfAll:
                    if (log)
                    {
                        _logBuilder.AppendLine("  Exclusion Style: ALL");
                    }

                    excluded = HasAll(labels, exclusions, log ? _logBuilder : null);
                    break;
                case ExclusionStyle.ExcludeIfMoreThanOne:
                    if (log)
                    {
                        _logBuilder.AppendLine("  Exclusion Style: MORE THAN ONE");
                    }

                    excluded = HasMoreThanOne(labels, exclusions, log ? _logBuilder : null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (log)
            {
                _logBuilder.AppendLine($"  Exclusion check: {excluded}.");

                if (excluded)
                {
                    AppaLog.Warn($"FAIL: {_logBuilder}");
                }
                else
                {
                    AppaLog.Info($"PASS: {_logBuilder}");
                }
            }

            return !excluded;
        }

        public void RefreshLabels()
        {
            LabelManager.InitializeLabels();
        }

        public void RemoveLabel(int i)
        {
            if ((terms.Count > i) && (i >= 0))
            {
                terms.RemoveAt(i);
            }
        }

        private List<GameObject> GetAssetsMatching(bool all)
        {
            var results = new List<GameObject>();
            var searchTerm = GetSearchTerm();

            var assetGuids = AssetDatabaseManager.FindAssets(searchTerm);

            if (all)
            {
                matchStyle = LabelMatchStyle.All;
            }
            else
            {
                matchStyle = LabelMatchStyle.Any;
            }

            for (var i = 0; i < assetGuids.Length; i++)
            {
                var assetGuid = assetGuids[i];
                var assetPath = AssetDatabaseManager.GUIDToAssetPath(assetGuid);

                var prefab = AssetDatabaseManager.LoadAssetAtPath<GameObject>(assetPath);

                if (Matches(prefab))
                {
                    results.Add(prefab);
                }
            }

            return results;
        }

        private void ResetDisplayName()
        {
            _displayName = null;
        }

        private static bool HasAll(
            IEnumerable<string> labels,
            List<LabelSearchTerm> searchTerms,
            StringBuilder _logBuilder = null)
        {
            if (searchTerms.Count == 0)
            {
                _logBuilder?.AppendLine("    No search terms.");
                return false;
            }

            ScanTerms(labels, searchTerms);

            for (var j = 0; j < searchTerms.Count; j++)
            {
                var term = searchTerms[j];

                if (!term.enabled)
                {
                    continue;
                }

                if (!term.found)
                {
                    _logBuilder?.AppendLine($"    Not Found: [{term.label}].");
                    return false;
                }
            }

            _logBuilder?.AppendLine("    Found all terms.");
            return true;
        }

        private static bool HasAny(
            IEnumerable<string> labels,
            List<LabelSearchTerm> searchTerms,
            StringBuilder _logBuilder = null)
        {
            if (searchTerms.Count == 0)
            {
                _logBuilder?.AppendLine("    No search terms.");
                return false;
            }

            ScanTerms(labels, searchTerms);

            for (var j = 0; j < searchTerms.Count; j++)
            {
                var term = searchTerms[j];

                if (!term.enabled)
                {
                    continue;
                }

                if (term.found)
                {
                    _logBuilder?.AppendLine($"    Found: [{term.label}].");
                    return true;
                }
            }

            _logBuilder?.AppendLine("    Did not find term.");
            return false;
        }

        private static bool HasMoreThanOne(
            IEnumerable<string> labels,
            List<LabelSearchTerm> searchTerms,
            StringBuilder _logBuilder = null)
        {
            if (searchTerms.Count < 2)
            {
                _logBuilder?.AppendLine("    Less than 2 search terms.");

                return false;
            }

            ScanTerms(labels, searchTerms);

            var count = 0;

            for (var j = 0; j < searchTerms.Count; j++)
            {
                var term = searchTerms[j];

                if (!term.enabled)
                {
                    continue;
                }

                if (term.found)
                {
                    count += 1;
                    _logBuilder?.AppendLine($"    Found [{count}/2]: [{term.label}].");
                }
            }

            _logBuilder?.AppendLine($"    Found [{count}/2] total.");
            return count > 1;
        }

        private static void ScanTerms(IEnumerable<string> labels, List<LabelSearchTerm> searchTerms)
        {
            for (var j = 0; j < searchTerms.Count; j++)
            {
                searchTerms[j].Reset();
            }

            foreach (var t in labels)
            {
                for (var j = 0; j < searchTerms.Count; j++)
                {
                    var searchTerm = searchTerms[j];

                    if (!searchTerm.enabled)
                    {
                        continue;
                    }

                    if (t == searchTerm.label)
                    {
                        searchTerm.found = true;
                    }
                }
            }
        }
    }
}

#endif