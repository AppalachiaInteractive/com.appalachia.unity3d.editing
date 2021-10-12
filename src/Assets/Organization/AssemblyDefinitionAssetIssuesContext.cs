using System.Collections.Generic;
using Appalachia.CI.Integration.Assemblies;
using Unity.Profiling;

namespace Appalachia.Editing.Assets.Organization
{
    public class AssemblyDefinitionAssetIssuesContext
    {
        private const string _PRF_PFX = nameof(AssemblyDefinitionAssetIssuesContext) + ".";

        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

        public List<AssemblyDefinitionMetadata> assemblyDefinitionMetadatas;
        
        public bool anyNameIssues;
        public bool anySortingIssues;
        public bool anyInvalidReferenceIssues;
        public bool anyNonGuidReferences;
        
        public void Initialize(List<string> assemblyDefinitionPaths)
        {
            using (_PRF_Initialize.Auto())
            {
                if (assemblyDefinitionMetadatas == null)
                {
                    assemblyDefinitionMetadatas = new List<AssemblyDefinitionMetadata>();
                }

                assemblyDefinitionPaths.Sort();

                foreach (var assemblyDefinitionPath in assemblyDefinitionPaths)
                {
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
                    admReferenceLookup.Add(adm.guid, adm);
                    admReferenceLookup.Add(adm.assembly_current, adm);;
                }

                foreach (var adm in assemblyDefinitionMetadatas)
                {
                    adm.SetReferences(admReferenceLookup);

                    if (!adm.readOnly)
                    {
                        anyNameIssues = anyNameIssues || !adm.DoAllNamesMatch;
                        anySortingIssues = anySortingIssues || adm.ShouldSortReferences;
                        anyInvalidReferenceIssues =
                            anyInvalidReferenceIssues || adm.HasInvalidAssemblies;
                        anyNonGuidReferences = anyNonGuidReferences || !adm.DoesUseGuidReferences;
                    }
                }
            }
        }
    }
}
