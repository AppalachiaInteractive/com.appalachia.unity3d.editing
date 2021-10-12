using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Organization
{
    internal class OrphanedAssetContext
    {
        private const string _PRF_PFX = nameof(OrphanedAssetContext) + ".";

        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

        public int fixableOrphans;
        public List<OrphanedAsset> orphans;
        public bool[] toggles;
        public bool[] togglesFields;
        public bool[] togglesResults;

        public void Initialize(IEnumerable<string> allRelativePaths)
        {
            using (_PRF_Initialize.Auto())
            {
                orphans = new List<OrphanedAsset>();

                foreach (var relativeAssetPath in allRelativePaths)
                {
                    var assetType = AssetDatabase.GetMainAssetTypeAtPath(relativeAssetPath);

                    var absolute = new FileInfo(relativeAssetPath);

                    if (!absolute.Exists)
                    {
                        continue;
                    }

                    if (assetType == null)
                    {
                        var orphan =
                            OrphanedAsset.CreateByPath<ScriptableObject>(relativeAssetPath);
                        orphans.Add(orphan);

                        if (orphan.analysisResults.Any(ar => ar.likelihood > .5f))
                        {
                            fixableOrphans += 1;
                        }
                    }
                }
            }
        }
    }
}
