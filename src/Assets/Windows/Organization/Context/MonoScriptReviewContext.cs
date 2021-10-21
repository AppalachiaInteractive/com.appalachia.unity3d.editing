using System.Collections.Generic;
using Appalachia.CI.Integration.Assets;
using Appalachia.Editing.Assets.Windows.Organization.Metadata;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Appalachia.Utility.Reflection.Extensions;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Context
{
    public class MonoScriptReviewContext : AppalachiaWindowPaneContext,
                                           IAppalachiaOneMenuWindowPaneContext<MonoScriptReviewMetadata>
    {
        private const string _PRF_PFX = nameof(MonoScriptReviewContext) + ".";
        private static readonly ProfilerMarker _PRF_OnReset = new(_PRF_PFX + nameof(OnReset));
        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        private List<MonoScriptReviewMetadata> _items;

        public override int RequiredMenuCount => 1;

        public IList<MonoScriptReviewMetadata> MenuOneItems => _items;

        public override void ValidateMenuSelection(int menuIndex)
        {
            var menuSelection = GetMenuSelection(menuIndex);

            if (menuSelection.length != MenuOneItems.Count)
            {
                menuSelection.SetLength(MenuOneItems.Count);
            }
        }

        protected override void OnInitialize()
        {
            using (_PRF_OnInitialize.Auto())
            {
                if (_items == null)
                {
                    _items = new List<MonoScriptReviewMetadata>();
                }

                _items.Clear();

                if (_items == null)
                {
                    _items = new List<MonoScriptReviewMetadata>();
                }

                var objectInheritors = ReflectionExtensions.GetAllConcreteInheritors<Object>();

                foreach (var objectInheritor in objectInheritors)
                {
                    if (objectInheritor == null)
                    {
                        continue;
                    }

                    var script = AssetDatabaseManager.GetScriptFromType(objectInheritor);

                    var reviewMetadata =
                        new MonoScriptReviewMetadata {monoScriptType = objectInheritor, script = script};

                    if (script == null)
                    {
                        reviewMetadata.canBeLoaded = false;

                        var ns = objectInheritor.Namespace;

                        if (ns != null)
                        {
                            if (ns.StartsWith("Unity") ||
                                ns.StartsWith("TreeEditor") ||
                                ns.StartsWith("Packages.Rider") ||
                                ns.StartsWith("TMPro") ||
                                ns.StartsWith("TestRunner"))
                            {
                                continue;
                            }
                        }

                        if (objectInheritor.InheritsFrom(typeof(EditorWindow)))
                        {
                            continue;
                        }

                        if (objectInheritor.InheritsFrom(typeof(Editor)))
                        {
                            continue;
                        }

                        _items.Add(reviewMetadata);
                    }
                }
            }
        }

        protected override void OnReset()
        {
            using (_PRF_OnReset.Auto())
            {
                _items?.Clear();
            }
        }
    }
}
