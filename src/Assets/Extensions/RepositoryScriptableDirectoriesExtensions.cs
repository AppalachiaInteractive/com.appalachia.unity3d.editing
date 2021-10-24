using Appalachia.CI.Integration.Repositories;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;

namespace Appalachia.Editing.Assets.Extensions
{
    public static class RepositoryScriptableDirectoriesExtensions
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(RepositoryScriptableDirectoriesExtensions) + ".";
        private static readonly ProfilerMarker _PRF_Draw = new(_PRF_PFX + nameof(Draw));

#endregion

        public static void Draw(
            this RepositoryAssetSaveDirectories metadata,
            UIFieldMetadataManager fieldManager)
        {
            using (_PRF_Draw.Auto())
            {
                var header = fieldManager.Get<LabelH3Metadata>(
                    metadata.repository?.RepoName ?? "Non-Repository Instances"
                );

                header.Draw();

                foreach (var location in metadata.locations)
                {
                    location.Draw(fieldManager);
                }
            }
        }
    }
}
