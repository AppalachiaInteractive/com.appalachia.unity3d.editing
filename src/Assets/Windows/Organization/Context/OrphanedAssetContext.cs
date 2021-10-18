using System.Collections.Generic;
using System.Linq;
using Appalachia.CI.Integration.Assets;
using Appalachia.CI.Integration.FileSystem;
using Appalachia.Editing.Assets.Windows.Organization.Metadata;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Context
{
    public class OrphanedAssetContext : AppalachiaWindowPaneContext,
                                        IAppalachiaOneMenuWindowPaneContext<OrphanedAsset>
    {
        private const string _PRF_PFX = nameof(OrphanedAssetContext) + ".";
        private static readonly ProfilerMarker _PRF_OnReset = new(_PRF_PFX + nameof(OnReset));
        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        public int fixableOrphans;

        private List<OrphanedAsset> _orphans;
        private List<string> _relativeAssetPaths;

        public override void ValidateMenuSelection(int menuIndex)
        {
            var menuSelection = GetMenuSelection(menuIndex);
            
            if (menuSelection.length != MenuOneItems.Count)
            {
                menuSelection.SetLength(MenuOneItems.Count);
            }
        }

        public override int RequiredMenuCount => 1;

        public IList<OrphanedAsset> MenuOneItems => _orphans;

        protected override void OnInitialize()
        {
            using (_PRF_OnInitialize.Auto())
            {
                _relativeAssetPaths = AssetDatabaseManager.GetAssetPathsByExtension(".asset");

                _orphans = new List<OrphanedAsset>();

                foreach (var relativeAssetPath in _relativeAssetPaths)
                {
                    var assetType = AssetDatabaseManager.GetMainAssetTypeAtPath(relativeAssetPath);

                    var absolute = new AppaFileInfo(relativeAssetPath);

                    if (!absolute.Exists)
                    {
                        continue;
                    }

                    if (assetType == null)
                    {
                        var orphan = OrphanedAsset.CreateByPath<ScriptableObject>(relativeAssetPath);
                        _orphans.Add(orphan);

                        if (orphan.analysisResults.Any(ar => ar.likelihood > .5f))
                        {
                            fixableOrphans += 1;
                        }
                    }
                }
            }
        }

        protected override void OnReset()
        {
            using (_PRF_OnReset.Auto())
            {
                _orphans?.Clear();
                _relativeAssetPaths?.Clear();
            }
        }
    }
}
