using System.IO;
using Appalachia.CI.Integration.Extensions;
using Appalachia.Core.Assets;
using Appalachia.Editing.Assets.Organization;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public partial class AssetDatabaseScriptableOrganizer
    {
        private const string TAB_CLEANUP = "Directory Cleanup";
        private const string CLEANUP_CONTENT = "CLEANUP_CONTENT";

        private static readonly ProfilerMarker _PRF_InitializeDirectoryCleanup =
            new(_PRF_PFX + nameof(InitializeDirectoryCleanup));
        
        private DirectoryCleanupContext _cleanupContext;
        private void InitializeDirectoryCleanup()
        {
            using (_PRF_InitializeDirectoryCleanup.Auto())
            {
                _fieldManager.Add<ScrollViewUIMetadata>(CLEANUP_CONTENT);
                
                if (_cleanupContext == null)
                {
                    _cleanupContext = new DirectoryCleanupContext();

                    _cleanupContext.Initialize();
                }
            }
        }

        private static readonly ProfilerMarker _PRF_DrawDirectoryCleanup = new ProfilerMarker(_PRF_PFX + nameof(DrawDirectoryCleanup));
        private void DrawDirectoryCleanup()
        {
            using (_PRF_DrawDirectoryCleanup.Auto())
            {
                var headerLabel = _fieldManager.Get<LabelH2Metadata>(TAB_CLEANUP);
                var rescanButton = _fieldManager.Get<ButtonMetadata>("Rescan Issues");
                var emptyDirectoriesLabel = _fieldManager.Get<LabelH3Metadata>("Empty Directories");

                headerLabel.Draw();

                if (rescanButton.Button())
                {
                    _cleanupContext = null;
                    InitializeDirectoryCleanup();
                }
            
                using (_fieldManager.Get<ScrollViewUIMetadata>(CLEANUP_CONTENT).GetScope())
                {
                    emptyDirectoriesLabel.Draw();
                
                    for (var index = 0; index < _cleanupContext.emptyDirectories.Count; index++)
                    {
                        var directory = _cleanupContext.emptyDirectories[index];

                        DrawEmptyDirectory(directory, out var deleted);

                        if (deleted)
                        {
                            _cleanupContext.emptyDirectories.RemoveAt(index);
                            index--;
                        }
                    }
                }
            }
        }

        private static readonly ProfilerMarker _PRF_DrawEmptyDirectory = new ProfilerMarker(_PRF_PFX + nameof(DrawEmptyDirectory));
        private void DrawEmptyDirectory(DirectoryInfo directory, out bool deleted)
        {
            using (_PRF_DrawEmptyDirectory.Auto())
            {
                deleted = false;
            
                var relativePath = directory.FullName.ToRelativePath();
            
                var label = _fieldManager.Get<LabelH4Metadata>(relativePath);
                var show = _fieldManager.Get<MiniButtonMetadata>("Show");
                var delete = _fieldManager.Get<MiniButtonMetadata>("Delete");

                using (new GUILayout.HorizontalScope())
                {
                    label.Draw();
                
                    if (show.Button(true))
                    {
                        AssetDatabaseManager.SetSelection(directory.FullName);                    
                    }

                    if (delete.Button(true))
                    {
                        var path = directory.FullName;
                        var metadataPath = $"{path}.meta";
                    
                        directory.Delete();
                        File.Delete(metadataPath);;
                        AssetDatabase.Refresh();
                        deleted = true;
                    }
                }
            }
        }

    }
}
