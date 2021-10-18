using Appalachia.Core.Aspects.Tracing;
using Appalachia.Editing.Assets.Extensions;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Assets.Windows.Organization.Metadata;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Panes
{
    public class AssetTypeReviewPane<T> : AppalachiaMenuWindowPane<AssetTypeReviewContext<T>>,
                                          IAppalachiaTabbedWindowPane
        where T : Object
    {
        private const string _PRF_PFX = nameof(AssetTypeReviewPane<T>) + ".";
        private const string _TRACE_PFX = nameof(AssetTypeReviewPane<T>) + ".";

        private static readonly ProfilerMarker _PRF_DrawTypeInstances =
            new(_PRF_PFX + nameof(DrawTypeInstances));

        private static readonly ProfilerMarker _PRF_DrawPaneHeader =
            new(_PRF_PFX + nameof(DrawPaneHeader));

        private static readonly ProfilerMarker _PRF_OnDrawPaneContent =
            new(_PRF_PFX + nameof(OnDrawPaneContent));

        private static readonly ProfilerMarker _PRF_OnDrawPaneMenuItem =
            new(_PRF_PFX + nameof(OnDrawPaneMenuItem));

        private static readonly ProfilerMarker _PRF_DrawAssetSaveLocation =
            new(_PRF_PFX + nameof(DrawAssetSaveLocation));

        private static readonly ProfilerMarker _PRF_DrawTypeCorrectionSection =
            new(_PRF_PFX + nameof(DrawTypeCorrectionSection));

        private static readonly TraceMarker _TRACE_OnDrawPaneContent =
            new(_TRACE_PFX + nameof(OnDrawPaneContent));

        private static readonly TraceMarker _TRACE_OnDrawPaneMenuItem =
            new(_TRACE_PFX + nameof(OnDrawPaneMenuItem));

        private static readonly TraceMarker _TRACE_OnDrawPaneMenusStart =
            new(_TRACE_PFX + nameof(OnDrawPaneMenusStart));

        private static readonly TraceMarker _TRACE_DrawTypeCorrectionSection =
            new(_TRACE_PFX + nameof(DrawTypeCorrectionSection));

        private string _lastDrawnNamespace;
        public override bool ContentInScrollView => true;

        public override string PaneName => $"Assets Inheriting from [{typeof(T).Name}]";


        public int DesiredTabIndex => 100;

        public string TabName => $"Assets: {typeof(T).Name}";

        public override void OnDrawPaneMenuItem(int menuIndex, int menuItemIndex, out bool isSelected)
        {
            using (_TRACE_OnDrawPaneMenuItem.Auto())
            using (_PRF_OnDrawPaneMenuItem.Auto())
            {
                var typeReviewMetadata = context.types[menuItemIndex];

                var selectedIndex = context.GetMenuSelection(0).currentIndex;

                var backgroundColor = selectedIndex == menuItemIndex
                    ? ColorPalettes.Editing.selected
                    : typeReviewMetadata.HasIssues
                        ? ColorPalettes.Editing.error
                        : Color.clear;

                var namespaceDrawnString = " " + typeReviewMetadata.type.Namespace;
                var menuHeaderLabel = fieldMetadataManager.Get<SmallLabelMetadata>(namespaceDrawnString);

                var menuField = fieldMetadataManager.Get<MenuItemField>(typeReviewMetadata.type.Name);

                if (_lastDrawnNamespace != namespaceDrawnString)
                {
                    _lastDrawnNamespace = namespaceDrawnString;

                    menuHeaderLabel.Draw();
                }

                isSelected = menuField.Draw("    " + typeReviewMetadata.type.Name, backgroundColor);
            }
        }


        public override void DrawPaneHeader()
        {
            using (_PRF_DrawPaneHeader.Auto())
            {
                var header = fieldMetadataManager.Get<LabelH2Metadata>("Project Overview");

                header.Draw();

                using (new EditorGUI.IndentLevelScope())
                {
                    var labels_totalType =
                        fieldMetadataManager.Get<LabelMetadata>("Total Scriptable Object Types");
                    var labels_typeIssues = fieldMetadataManager.Get<LabelMetadata>("Types With Issues");
                    var labels_totalInstance =
                        fieldMetadataManager.Get<LabelMetadata>("Total Instance Count");
                    var labels_orphanedlInstances =
                        fieldMetadataManager.Get<LabelMetadata>("Orphaned Instance Count");

                    labels_totalType.SetPrefixLabelWidth(200);
                    labels_typeIssues.SetPrefixLabelWidth(200);
                    labels_totalInstance.SetPrefixLabelWidth(200);
                    labels_orphanedlInstances.SetPrefixLabelWidth(200);

                    var tiCount = context.totalIssueCount;

                    using (new GUILayout.HorizontalScope())
                    {
                        using (new GUILayout.VerticalScope())
                        {
                            labels_totalType.Draw(context.types.Count.ToString());
                            labels_totalInstance.Draw(context.totalInstances.ToString());
                        }

                        using (new GUILayout.VerticalScope())
                        {
                            labels_typeIssues.Draw(
                                tiCount.ToString(),
                                tiCount > 0 ? ColorPalettes.Editing.error : Color.clear
                            );
                        }
                    }

                    using (new GUILayout.HorizontalScope())
                    {
                        using (new GUILayout.VerticalScope())
                        {
                            var fixAllLocationsDryRun =
                                fieldMetadataManager.Get<ButtonMetadata>("Fix All Locations (Dry Run)");

                            if (fixAllLocationsDryRun.Button(tiCount > 0))
                            {
                                context.CorrectAllIssues();
                            }
                        }

                        using (new GUILayout.VerticalScope())
                        {
                            var fixAllLocations =
                                fieldMetadataManager.Get<ButtonMetadata>("Fix All Locations");

                            if (fixAllLocations.Button(tiCount > 0))
                            {
                                context.CorrectAllIssues(false);
                            }
                        }
                    }
                }

                AppalachiaEditorGUIHelper.HorizontalLineSeparator();
            }
        }

        public override bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex)
        {
            return true;
        }

        public override void OnDrawPaneContent()
        {
            using (_TRACE_OnDrawPaneContent.Auto())
            using (_PRF_OnDrawPaneContent.Auto())
            {
                var typeReviewMetadata = context.SelectedType;

                DrawAssetSaveLocation(typeReviewMetadata);

                AppalachiaEditorGUIHelper.HorizontalLineSeparator(AppalachiaEditorGUIHelper.LineColorH1);

                DrawTypeCorrectionSection(typeReviewMetadata);

                AppalachiaEditorGUIHelper.HorizontalLineSeparator(AppalachiaEditorGUIHelper.LineColorH1);

                DrawTypeInstances(typeReviewMetadata);
            }
        }

        public override void OnInitialize()
        {
        }

        private void DrawAssetSaveLocation(TypeReviewMetadata typeReviewMetadata)
        {
            using (_PRF_DrawAssetSaveLocation.Auto())
            {
                using (new EditorGUI.IndentLevelScope())
                using (new EditorGUI.DisabledScope())
                {
                    typeReviewMetadata.saveLocation.Draw(fieldMetadataManager);
                }
            }
        }

        private void DrawTypeCorrectionSection(TypeReviewMetadata typeReviewMetadata)
        {
            using (_TRACE_DrawTypeCorrectionSection.Auto())
            using (_PRF_DrawTypeCorrectionSection.Auto())
            {
                var assetType = context.SelectedType;

                var button_reprocess = fieldMetadataManager.Get<ButtonMetadata>("Re-analyze Type");
                var button_fixLocations = fieldMetadataManager.Get<ButtonMetadata>("Fix Locations");
                var button_fixLocationsDryRun =
                    fieldMetadataManager.Get<ButtonMetadata>("Fix Locations (Dry Run)");

                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.Space(EditorGUI.indentLevel * 15f, false);

                    using (new EditorGUILayout.VerticalScope())
                    {
                        if (button_reprocess.Button())
                        {
                            context.ReprocessType(assetType);
                        }

                        using (new EditorGUILayout.HorizontalScope())
                        {
                            using (new EditorGUILayout.VerticalScope())
                            {
                                if (button_fixLocationsDryRun.Button(typeReviewMetadata.HasIssues))
                                {
                                    context.CorrectIssues(context.SelectedType);
                                }

                                if (button_fixLocations.Button(typeReviewMetadata.HasIssues))
                                {
                                    context.CorrectIssues(context.SelectedType, false);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DrawTypeInstances(TypeReviewMetadata typeReviewMetadata)
        {
            using (_PRF_DrawTypeInstances.Auto())
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    foreach (var dir in typeReviewMetadata.repositories)
                    {
                        dir.Draw(fieldMetadataManager);
                    }
                }
            }
        }
    }
}
