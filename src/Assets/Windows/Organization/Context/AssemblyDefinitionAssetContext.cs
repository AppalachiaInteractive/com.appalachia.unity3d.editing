using System.Collections.Generic;
using Appalachia.CI.Integration.Analysis;
using Appalachia.CI.Integration.Assemblies;
using Appalachia.CI.Integration.Assets;
using Appalachia.CI.Integration.Repositories;
using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Assets.Extensions;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Unity.Profiling;

namespace Appalachia.Editing.Assets.Windows.Organization.Context
{
    public class AssemblyDefinitionAssetContext : AppalachiaWindowPaneContext,
                                                  IAppalachiaOneMenuWindowPaneContext<
                                                      AssemblyDefinitionMetadata>
    {
        private const string _PRF_PFX = nameof(AssemblyDefinitionAssetContext) + ".";
        private const string _TRACE_PFX = nameof(AssemblyDefinitionAssetContext) + ".";

        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        private static readonly TraceMarker _TRACE_OnInitialize = new(_TRACE_PFX + nameof(OnInitialize));

        private static readonly ProfilerMarker _PRF_ValidateMenuSelection =
            new(_PRF_PFX + nameof(ValidateMenuSelection));

        private static readonly ProfilerMarker _PRF_OnReset = new(_PRF_PFX + nameof(OnReset));

        private static readonly ProfilerMarker _PRF_ValidateSummaryProperties =
            new(_PRF_PFX + nameof(ValidateSummaryProperties));

        private static readonly ProfilerMarker _PRF_ShouldShowInMenu =
            new(_PRF_PFX + nameof(ShouldShowInMenu));

        public AnalysisAggregate<AssemblyAnalysisType> aggregateAnalysis;

        public PREF<bool> appalachiaOnly;
        public PREF<bool> assetsOnly;
        public PREF<bool> generateTestFiles;
        public PREF<bool> onlyShowIssues;
        public PREF<AssemblyAnalysisType> issueType;

        private List<AssemblyDefinitionMetadata> assemblyDefinitionMetadatas;

        private List<string> assemblyDefinitionPaths;

        public override int RequiredMenuCount => 1;

        public int detailTabIndex;

        public IList<AssemblyDefinitionMetadata> MenuOneItems => assemblyDefinitionMetadatas;

        public override void ValidateMenuSelection(int menuIndex)
        {
            using (_PRF_ValidateMenuSelection.Auto())
            {
                var menuSelection = GetMenuSelection(menuIndex);

                if (menuSelection.length != MenuOneItems.Count)
                {
                    menuSelection.SetLength(MenuOneItems.Count);

                    ValidateSummaryProperties();
                }
            }
        }

        public bool ShouldShowInMenu(AssemblyDefinitionMetadata assembly)
        {
            using (_PRF_ShouldShowInMenu.Auto())
            {
                if (assembly == null)
                {
                    return false;
                }
                
                if (onlyShowIssues.Value && !assembly.analysis.AnyIssues)
                {
                    return false;
                }
                
                if (assembly.readOnly)
                {
                    return false;
                }

                if (appalachiaOnly.Value && !assembly.IsAppalachia)
                {
                    return false;
                }

                if (assetsOnly.Value && !assembly.IsAsset)
                {
                    return false;
                }
                
                if (onlyShowIssues.Value && (issueType.Value != AssemblyAnalysisType.All))
                {
                    var analysis = assembly.analysis;

                    if (!analysis.HasIssues(issueType.v))
                    {
                        return false;
                    }                    
                } 

                return true;
            }
        }

        public void ValidateSummaryProperties()
        {
            using (_PRF_ValidateSummaryProperties.Auto())
            {
                if (aggregateAnalysis == null)
                {
                    aggregateAnalysis = new AnalysisAggregate<AssemblyAnalysisType>();
                }

                foreach (var adm in assemblyDefinitionMetadatas)
                {
                    if (ShouldShowInMenu(adm))
                    {
                        aggregateAnalysis.Add(adm.analysis.AllIssues);
                    }
                }
            }
        }

        protected override void OnInitialize()
        {
            using (_TRACE_OnInitialize.Auto())
            using (_PRF_OnInitialize.Auto())
            {
                appalachiaOnly = PREFS.REG($"{G_}/Assembly Definitions", "Appalachia Only", true);

                assetsOnly = PREFS.REG($"{G_}/Assembly Definitions", "Assets Only", true);

                onlyShowIssues = PREFS.REG($"{G_}/Assembly Definitions", "Only issues", true);

                issueType = PREFS.REG($"{G_}/Assembly Definitions", "Issue Type", AssemblyAnalysisType.All);

                generateTestFiles = PREFS.REG($"{G_}/Assembly Definitions", "Test Files", true);

                assemblyDefinitionPaths = AssetDatabaseManager.FindAssetPathsByExtension(".asmdef");

                if (assemblyDefinitionMetadatas == null)
                {
                    assemblyDefinitionMetadatas = new List<AssemblyDefinitionMetadata>();
                }
                else
                {
                    assemblyDefinitionMetadatas.Clear();
                }

                assemblyDefinitionPaths.Sort();

                for (var index = 0; index < assemblyDefinitionPaths.Count; index++)
                {
                    var assemblyDefinitionPath = assemblyDefinitionPaths[index];

                    if (assemblyDefinitionPath == null)
                    {
                        continue;
                    }

                    var adm = AssemblyDefinitionMetadata.CreateNew(assemblyDefinitionPath);

                    assemblyDefinitionMetadatas.Add(adm);
                }

                foreach (var adm in assemblyDefinitionMetadatas)
                {
                    if (!adm.readOnly)
                    {
                        adm.SetReferences();
                    }
                }

                ValidateSummaryProperties();
            }
        }

        protected override void OnReset()
        {
            using (_PRF_OnReset.Auto())
            {
                aggregateAnalysis?.Reset();

                assemblyDefinitionMetadatas = null;
                assemblyDefinitionPaths = null;
            }
        }
    }
}
