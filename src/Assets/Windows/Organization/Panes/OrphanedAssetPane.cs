using Appalachia.Editing.Assets.Extensions;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces;
using Unity.Profiling;
using UnityEditor;

namespace Appalachia.Editing.Assets.Windows.Organization.Panes
{
    public class OrphanedAssetPane : AppalachiaMenuWindowPane<OrphanedAssetContext>,
                                     IAppalachiaTabbedWindowPane
    {
        private const string _PRF_PFX = nameof(OrphanedAssetPane) + ".";

        private static readonly ProfilerMarker _PRF_OnDrawPaneMenuItem =
            new(_PRF_PFX + nameof(OnDrawPaneMenuItem));

        private static readonly ProfilerMarker _PRF_OnDrawPaneContent =
            new(_PRF_PFX + nameof(OnDrawPaneContent));

        private OrphanedAssetContext _context;

        public override bool ContentInScrollView => true;
        public override string PaneName => "Orphaned Assets";

        public int DesiredTabIndex => 99999;

        public string TabName => "Orphans";

        public override bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex)
        {
            return true;
        }

        public override void OnDrawPaneMenuItem(
            int menuIndex,
            int menuItemIndex,
            bool isSelected,
            out bool wasSelected,
            out float menuItemHeight)
        {
            using (_PRF_OnDrawPaneMenuItem.Auto())
            {
                var menuField = fieldMetadataManager.Get<MenuItemField>($"{menuItemIndex}");

                var menuItem = context.MenuOneItems[menuItemIndex];

                wasSelected = menuField.Draw(menuItem.assetPathMetadata.name, isSelected);
                
                menuItemHeight = menuField.height;
            }
        }

        public override void OnDrawPaneContent()
        {
            using (_PRF_OnDrawPaneContent.Auto())
            {
                var selection = context.GetMenuSelection(0);
                var currentIndex = selection.currentIndex;

                if (context.MenuOneItems.Count == 0)
                {
                    return;
                }

                var orphan = context.MenuOneItems[currentIndex];

                using (new EditorGUI.DisabledScope())
                {
                    orphan.originalScriptGUID = EditorGUILayout.TextField(
                        "Original Script GUID",
                        orphan.originalScriptGUID
                    );
                }

                EditorGUILayout.Separator();

                orphan.assetPathMetadata.Draw(fieldMetadataManager);

                EditorGUILayout.Separator();

                using (new EditorGUI.IndentLevelScope())
                using (new EditorGUI.DisabledScope())
                {
                    foreach (var field in orphan.fields)
                    {
                        EditorGUILayout.TextField(field.key, field.value);
                    }

                    EditorGUILayout.Separator();

                    foreach (var result in orphan.analysisResults)
                    {
                        EditorGUILayout.TextField("Type", result.matchType.Name);
                        EditorGUILayout.Slider("Likelihood", result.likelihood, 0f, 1f);

                        EditorGUILayout.TextField("Matched Fields", string.Join("\n", result.fieldsMatched));
                    }
                }

                EditorGUILayout.Separator();
                AppalachiaEditorGUIHelper.HorizontalLineSeparator(AppalachiaEditorGUIHelper.LineColorH3);
            }
        }

        public override void OnInitialize()
        {
        }
    }
}
