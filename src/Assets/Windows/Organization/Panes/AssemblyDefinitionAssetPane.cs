using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Assets.Windows.Organization.Drawers;
using Appalachia.Editing.Core;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces;
using Appalachia.Utility.src.Colors;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Panes
{
    public class AssemblyDefinitionAssetPane : AppalachiaMenuWindowPane<AssemblyDefinitionAssetContext>,
                                               IAppalachiaTabbedWindowPane
    {
        private const string _PRF_PFX = nameof(AssemblyDefinitionAssetPane) + ".";

        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        private static readonly ProfilerMarker _PRF_OnDrawPaneMenusStart =
            new(_PRF_PFX + nameof(OnDrawPaneMenusStart));

        private static readonly ProfilerMarker _PRF_ShouldDrawMenuItem =
            new(_PRF_PFX + nameof(ShouldDrawMenuItem));

        private static readonly ProfilerMarker _PRF_OnDrawPaneMenuItem =
            new(_PRF_PFX + nameof(OnDrawPaneMenuItem));

        private static readonly ProfilerMarker _PRF_OnDrawPaneContent =
            new(_PRF_PFX + nameof(OnDrawPaneContent));

        private static readonly ProfilerMarker _PRF_OnDrawPaneContentStart =
            new(_PRF_PFX + nameof(OnDrawPaneContentStart));

        private AssemblyDefinitionAssetContext _context;

        public override bool ContentInScrollView => true;
        public override string PaneName => TabName;

        public int DesiredTabIndex => 1;

        public string TabName => "Assembly Definitions";

        protected override int MenuWidth => 250;
        

        public override bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex)
        {
            using (_PRF_ShouldDrawMenuItem.Auto())
            {
                var assemblyDefinitionMetadata = context.MenuOneItems[menuItemIndex];

                if (!context.ShouldShowInMenu(assemblyDefinitionMetadata))
                {
                    return false;
                }

                return true;
            }
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
                using (new GUILayout.HorizontalScope())
                {
                    var metadata = context.MenuOneItems[menuItemIndex];
                    var analysis = metadata.analysis;

                    var backgroundColor = analysis.AnyIssues ? metadata.IssueColor.ScaleA(.2f) : Color.clear;

                    var icon = analysis.AnyIssues
                        ? EditorGUIIcons.console_erroricon_sml
                        : isSelected
                            ? EditorGUIIcons.console_infoicon_sml
                            : EditorGUIIcons.console_infoicon_inactive_sml;

                    var menuField = fieldMetadataManager.Get<MenuItemField>(
                        $"{metadata.Name}.MIF_{menuIndex}",
                        f =>
                        {
                            f.AlterStyle(s => s.fontSize = 10);
                            f.AddLayoutOption(GUILayout.Height(24f));
                        }
                    );

                    wasSelected = false;

                    UnityEditor.EditorGUIUtility.SetIconSize(Vector2.one * 14);

                    if (menuField.DrawBackground(
                        metadata.assembly_current,
                        isSelected,
                        backgroundColor,
                        icon
                    ))
                    {
                        wasSelected = true;
                    }

                    menuItemHeight = menuField.height;

                    UnityEditor.EditorGUIUtility.SetIconSize(Vector2.zero);
                }
            }
        }

        public override void OnPreferencesChanged()
        {
            context.ValidateSummaryProperties();
        }

        public override void OnDrawPaneContent()
        {
            using (_PRF_OnDrawPaneContent.Auto())
            {
                fieldMetadataManager.Space(SpaceSize.SectionStartVertical);

                var menuItemIndex = context.GetMenuSelection(0).currentIndex;

                if (context.MenuOneItems.Count <= menuItemIndex)
                {
                    context.Reset();
                    context.Initialize();
                }

                var assemblyDefinitionMetadata = context.MenuOneItems[menuItemIndex];

                AssemblyDrawer.DrawAssemblyDefinitionMetadata(
                    assemblyDefinitionMetadata,
                    context,
                    fieldMetadataManager,
                    context.generateTestFiles.Value
                );
            }
        }

        public override void OnDrawPaneContentStart()
        {
            using (_PRF_OnDrawPaneContentStart.Auto())
            {
                AssemblyDrawer.DrawTopLevelAssemblyButtons(context, fieldMetadataManager);
            }
        }

        public override void OnInitialize()
        {
            using (_PRF_OnInitialize.Auto())
            {
                ((IAppalachiaWindowPane) this).RegisterFilterPref(context.appalachiaOnly);

                ((IAppalachiaWindowPane) this).RegisterFilterPref(context.assetsOnly);

                ((IAppalachiaWindowPane) this).RegisterFilterPref(context.onlyShowIssues);

                ((IAppalachiaWindowPane) this).RegisterFilterPref(
                    context.issueType,
                    () => context.onlyShowIssues.v
                );

                ((IAppalachiaWindowPane) this).RegisterFilterPref(context.generateTestFiles);
            }
        }

        private static Color highlightColor => ColorPalette.Default.highlight.Middle;
        private static Color notableColor => ColorPalette.Default.notable.Quarter;
        
        protected override void DrawContextButtons()
        {
            var button = fieldMetadataManager.Get<ButtonMetadata>("Reanalyze All");

            if (button.Button(backgroundColor:notableColor))
            {
                context.aggregateAnalysis = null;
                
                foreach (var assembly in context.MenuOneItems)
                {
                    assembly.Reanalyze();
                }

                context.ValidateSummaryProperties();
            }
        }
    }
}
