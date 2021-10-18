using System.Collections.Generic;
using Appalachia.CI.Integration;
using Appalachia.CI.Integration.FileSystem;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Unity.Profiling;

namespace Appalachia.Editing.Assets.Windows.Organization.Context
{
    public class DirectoryCleanupContext : AppalachiaWindowPaneContext
    {
        private const string _PRF_PFX = nameof(DirectoryCleanupContext) + ".";

        private static readonly ProfilerMarker _PRF_GetEmptyDirectories =
            new(_PRF_PFX + nameof(GetEmptyDirectories));

        private static readonly ProfilerMarker _PRF_OnReset = new(_PRF_PFX + nameof(OnReset));
        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        public List<AppaDirectoryInfo> emptyDirectories;

        public override int RequiredMenuCount => 1;

        public override void ValidateMenuSelection(int menuIndex)
        {
        }

        protected override void OnInitialize()
        {
            using (_PRF_OnInitialize.Auto())
            {
                if (emptyDirectories == null)
                {
                    emptyDirectories = new List<AppaDirectoryInfo>();
                }

                emptyDirectories.Clear();

                var assetsFolder = ProjectLocations.GetAssetsAppaDirectory();

                GetEmptyDirectories(assetsFolder, emptyDirectories);
            }
        }

        protected override void OnReset()
        {
            using (_PRF_OnReset.Auto())
            {
                emptyDirectories?.Clear();
            }
        }

        private static void GetEmptyDirectories(
            AppaDirectoryInfo current,
            List<AppaDirectoryInfo> emptyDirectories)
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

                    GetEmptyDirectories(childDirectory, emptyDirectories);
                }

                if (!childHadResults)
                {
                    var childFiles = current.GetFiles();

                    if (childFiles.Length == 0)
                    {
                        emptyDirectories.Add(current);
                    }
                }
            }
        }
    }
}
