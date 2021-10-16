using Appalachia.CI.Integration.Assets;
using Appalachia.CI.Integration.Extensions;
using Appalachia.CI.Integration.FileSystem;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Panes
{
    public class DirectoryCleanupPane : AppalachiaContextualWindowPane<DirectoryCleanupContext>,
                                        IAppalachiaTabbedWindowPane
    {
        private const string _PRF_PFX = nameof(DirectoryCleanupPane) + ".";

        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        private static readonly ProfilerMarker _PRF_OnDrawPaneContent =
            new(_PRF_PFX + nameof(OnDrawPaneContent));

        public override bool ContentInScrollView => true;

        public override string PaneName => "Directory Cleanup";

        public int DesiredTabIndex => 10009;
        public string TabName => "Directories";

        public override void OnDrawPaneContent()
        {
            using (_PRF_OnDrawPaneContent.Auto())
            {
                for (var index = 0; index < context.emptyDirectories.Count; index++)
                {
                    var directory = context.emptyDirectories[index];
                    var deleted = false;

                    var relativePath = directory.FullPath.ToRelativePath();

                    var label = fieldMetadataManager.Get<LabelH4Metadata>(relativePath);
                    var show = fieldMetadataManager.Get<MiniButtonMetadata>("Show");
                    var delete = fieldMetadataManager.Get<MiniButtonMetadata>("Delete");

                    using (new GUILayout.HorizontalScope())
                    {
                        label.Draw();

                        if (show.Button())
                        {
                            AssetDatabaseManager.SetSelection(directory.FullPath);
                        }

                        if (delete.Button())
                        {
                            var path = directory.FullPath;
                            var metadataPath = $"{path}.meta";

                            directory.Delete();
                            AppaFile.Delete(metadataPath);

                            AssetDatabaseManager.Refresh();
                            deleted = true;
                        }
                    }

                    if (deleted)
                    {
                        context.emptyDirectories.RemoveAt(index);
                    }
                }
            }
        }

        public override void OnInitialize()
        {
            using (_PRF_OnInitialize.Auto())
            {
            }
        }
    }
}
