#if UNITY_EDITOR

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Appalachia.CI.Integration.Assets;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Core.Objects.Root;
using Appalachia.Utility.Strings;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace Appalachia.Editing.Labels
{
    [Serializable]
    public class LabelSearchSet : AppalachiaBase
    {
        public LabelSearchSet(Object owner) : base(owner)
        {
            terms = new List<LabelSearchTerm> { new(owner) };
            exclusions = new List<LabelSearchTerm>();
        }

        #region Fields and Autoproperties

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

        #endregion

        public override string Name => GetSearchTerm();

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
                        _builder.Append(ZString.Format("Labels | Match If {0}: ", matchStyle));

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

                            _builder.Append(ZString.Format("{0}, ", term.label));
                        }

                        if (exclusions.Count > 0)
                        {
                            _builder.Append(ZString.Format(" | Exclude If {0}: ", matchStyle));

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

                                _builder.Append(ZString.Format("{0}, ", exclusion.label));
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
                    Context.Log.Error(ex);
                    return null;
                }
            }
        }

        public void AddNewLabel()
        {
            terms.Add(new LabelSearchTerm(_owner));
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
                    _builder.Append(ZString.Format("l: {0} ", terms[i].label));
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
                _logBuilder.AppendLine(ZString.Format("Checking labels... [{0}]", string.Join(", ", labels)));
            }

            if (termCount == 0)
            {
                if (log)
                {
                    _logBuilder.AppendLine("  No search terms.");
                    Context.Log.Info(ZString.Format("FAIL: {0}", _logBuilder));
                }

                return false;
            }

            if (log)
            {
                _logBuilder.AppendLine();
                _logBuilder.AppendLine(
                    ZString.Format(
                        "  TERMS: [{0}]",
                        string.Join(", ", terms.Where(e => e.enabled).Select(e => e.label))
                    )
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
                _logBuilder.AppendLine(ZString.Format("  Inclusion check: {0}.", false));
            }

            if (!included)
            {
                if (log)
                {
                    Context.Log.Warn(ZString.Format("FAIL: {0}", _logBuilder));
                }

                return false;
            }

            if (exclusionCount == 0)
            {
                if (log)
                {
                    _logBuilder.AppendLine("  No exclusion terms.");
                    Context.Log.Info(ZString.Format("PASS: {0}", _logBuilder));
                }

                return true;
            }

            if (log)
            {
                _logBuilder.AppendLine();
                _logBuilder.AppendLine(
                    ZString.Format(
                        "  EXCLUSIONS: [{0}]",
                        string.Join(", ", exclusions.Where(e => e.enabled).Select(e => e.label))
                    )
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
                _logBuilder.AppendLine(ZString.Format("  Exclusion check: {0}.", excluded));

                if (excluded)
                {
                    Context.Log.Warn(ZString.Format("FAIL: {0}", _logBuilder));
                }
                else
                {
                    Context.Log.Info(ZString.Format("PASS: {0}", _logBuilder));
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
                    _logBuilder?.AppendLine(ZString.Format("    Not Found: [{0}].", term.label));
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
                    _logBuilder?.AppendLine(ZString.Format("    Found: [{0}].", term.label));
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
                    _logBuilder?.AppendLine(ZString.Format("    Found [{0}/2]: [{1}].", count, term.label));
                }
            }

            _logBuilder?.AppendLine(ZString.Format("    Found [{0}/2] total.", count));
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
    }
}

#endif
