using System.Collections.Generic;
using System.IO;
using System.Linq;
using Appalachia.CI.Integration;
using Appalachia.Core.Assets;
using Unity.Profiling;

namespace Appalachia.Editing.Assets.Organization
{
    internal class DirectoryCleanupContext
    {
        private const string _PRF_PFX = nameof(DirectoryCleanupContext) + ".";

        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

        public List<DirectoryInfo> emptyDirectories;

        public void Initialize()
        {
            using (_PRF_Initialize.Auto())
            {
                if (emptyDirectories == null)
                {
                    emptyDirectories = new List<DirectoryInfo>();
                }

                var assetsFolder = ProjectLocations.GetAssetsDirectoryInfo();
                
                emptyDirectories = GetEmptyDirectories(assetsFolder).ToList();
            }
        }

        private static readonly ProfilerMarker _PRF_GetEmptyDirectories = new ProfilerMarker(_PRF_PFX + nameof(GetEmptyDirectories));
        private static IEnumerable<DirectoryInfo> GetEmptyDirectories(DirectoryInfo current)
        {
            using (_PRF_GetEmptyDirectories.Auto())
            {
                var childDirectories = current.EnumerateDirectories();

                var childHadResults = false;
            
                foreach (var childDirectory in childDirectories)
                {
                    if (childDirectory.Name.EndsWith("~") || childDirectory.Name.StartsWith("~"))
                    {
                        childHadResults = true;
                        continue;
                    }
                    if (childDirectory.Name.StartsWith("."))
                    {
                        childHadResults = true;
                        continue;
                    }
                
                    var childResults = GetEmptyDirectories(childDirectory);

                    foreach (var childResult in childResults)
                    {
                        childHadResults = true;
                    
                        yield return childResult;
                    
                    }
                }

                if (!childHadResults)
                {
                    var childFiles = current.GetFiles();

                    if (childFiles.Length == 0)
                    {
                        yield return current;
                    }                
                }
            }
        }
    }
}
