using System.Collections.Generic;
using Appalachia.CI.Integration.Assemblies;
using Appalachia.CI.Integration.Assets;
using Appalachia.Core.Aspects.Tracing;
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
        public bool anyInvalidReferenceIssues;

        public bool anyNameIssues;
        public bool anyNonGuidReferences;
        public bool anySortingIssues;
        private List<AssemblyDefinitionMetadata> assemblyDefinitionMetadatas;

        private List<string> assemblyDefinitionPaths;

        public override int RequiredMenuCount => 1;

        public IList<AssemblyDefinitionMetadata> MenuOneItems => assemblyDefinitionMetadatas;

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
            using (_TRACE_OnInitialize.Auto())
            using (_PRF_OnInitialize.Auto())
            {
                assemblyDefinitionPaths = AssetDatabaseManager.GetAssetPathsByExtension(".asmdef");

                if (assemblyDefinitionMetadatas == null)
                {
                    assemblyDefinitionMetadatas = new List<AssemblyDefinitionMetadata>();
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

                var admReferenceLookup = new Dictionary<string, AssemblyDefinitionMetadata>();

                foreach (var adm in assemblyDefinitionMetadatas)
                {
                    admReferenceLookup.Add(adm.guid,             adm);
                    admReferenceLookup.Add(adm.assembly_current, adm);
                }

                foreach (var adm in assemblyDefinitionMetadatas)
                {
                    adm.SetReferences(admReferenceLookup);

                    if (!adm.readOnly)
                    {
                        anyNameIssues = anyNameIssues || !adm.DoAllNamesMatch;
                        anySortingIssues = anySortingIssues || adm.ShouldSortReferences;
                        anyInvalidReferenceIssues = anyInvalidReferenceIssues || adm.HasInvalidAssemblies;
                        anyNonGuidReferences = anyNonGuidReferences || !adm.DoesUseGuidReferences;
                    }
                }
            }
        }

        protected override void OnReset()
        {
            assemblyDefinitionPaths?.Clear();
            assemblyDefinitionMetadatas?.Clear();
            anyNameIssues = false;
            anySortingIssues = false;
            anyInvalidReferenceIssues = false;
            anyNonGuidReferences = false;
        }
    }
}
