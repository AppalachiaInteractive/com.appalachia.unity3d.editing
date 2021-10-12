using System;
using Appalachia.Core.Assets;
using Appalachia.Editing.Assets.Extensions;
using Appalachia.Editing.Assets.Organization;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public partial class AssetDatabaseScriptableOrganizer
    {
        private const string TAB_SCRIPTABLE = "Scriptable Locations";
        private const string TAB_ASSET = "Asset Locations";

        private const string SO_PANE = "SO_PANE";
        private const string SO_CONTENT = "SO_CONTENT";
        private const string ASSET_PANE = "ASSET_PANE";
        private const string ASSET_CONTENT = "ASSET_CONTENT";

        private static readonly ProfilerMarker _PRF_InitializeScriptableLocations =
            new(_PRF_PFX + nameof(InitializeAssetLocations));

        private AssetLocationContext<Object> _assetContent;

        private AssetLocationContext<ScriptableObject> _slContext;

        private void InitializeAllAssetLocations()
        {
            InitializeAssetLocations(ref _slContext,    SO_PANE,    SO_CONTENT);
            InitializeAssetLocations(ref _assetContent, ASSET_PANE, ASSET_CONTENT);
        }

        private void InitializeAssetLocations<T>(
            ref AssetLocationContext<T> context,
            string menuName,
            string contentName)
            where T : Object
        {
            using (_PRF_InitializeScriptableLocations.Auto())
            {
                if (context?.types?.Count > 0)
                {
                    return;
                }

                context ??= new AssetLocationContext<T>();
                context.svMenu = menuName;
                context.svContent = contentName;

                if (typeof(T) == typeof(UnityEngine.Object))
                {
                    context.typeExclusionCheck = t => typeof(ScriptableObject).IsAssignableFrom(t);
                }

                _fieldManager.Add<ScrollViewUIMetadata>(
                    context.svMenu,
                    onInitialize: field => { field.AddLayoutOption(GUILayout.Width(250)); }
                );

                _fieldManager.Add<ScrollViewUIMetadata>(context.svContent);

                var assetPaths = AssetDatabaseManager.GetProjectAssetPaths(typeof(T));

                context.Initialize(assetPaths);
            }
        }

        private void DrawAssetLocations<T>(AssetLocationContext<T> context)
            where T : Object
        {
            if (Event.current.type == EventType.KeyDown)
            {
                Repaint();

                if (Event.current.keyCode == KeyCode.DownArrow)
                {
                    context.selectedIndex = Math.Min(
                        context.types.Count - 1,
                        context.selectedIndex + 1
                    );
                }
                else if (Event.current.keyCode == KeyCode.UpArrow)
                {
                    context.selectedIndex = Math.Max(0, context.selectedIndex - 1);
                }
            }

            using (new GUILayout.HorizontalScope())
            {
                DrawPaneMenu(context);

                DrawPaneContent(context);
            }
        }

        private void DrawPaneMenu<T>(AssetLocationContext<T> context)
            where T : Object
        {
            using (_fieldManager.Get<ScrollViewUIMetadata>(context.svMenu).GetScope())
            {
                string _lastDrawnNamespace = null;

                for (var index = 0; index < context.types.Count; index++)
                {
                    var assetType = context.types[index];

                    var backgroundColor = context.selectedIndex == index
                        ? ColorPalettes.Editing.selected
                        : context.typesIssues.Contains(assetType)
                            ? ColorPalettes.Editing.error
                            : Color.clear;

                    var namespaceDrawnString = " " + assetType.Namespace;
                    var menuHeaderLabel =
                        _fieldManager.Get<SmallLabelMetadata>(namespaceDrawnString);

                    var menuField = _fieldManager.Get<MenuItemField>(assetType.Name);

                    //var assetMetadata = context.saveLocations[assetType];
                    //var pathType = assetMetadata.saveLocationMetadata.pathType;

                    /*var icon = pathType == AssetPathMetadataType.ProjectDataFolder ? EditorGUIIcons.Enum.aboutwindow_mainheader : EditorGUIIcons.Enum.alertdialog;

                    var iconContent = EditorGUIIcons.GetIconContent(icon);

                    menuField.AlterContent(c => c.image = iconContent.image);*/

                    if (_lastDrawnNamespace != namespaceDrawnString)
                    {
                        _lastDrawnNamespace = namespaceDrawnString;

                        menuHeaderLabel.Draw();
                    }

                    if (menuField.Draw("    " + assetType.Name, backgroundColor))
                    {
                        context.selectedIndex = index;
                    }
                }
            }
        }

        private void DrawPaneContent<T>(AssetLocationContext<T> context)
            where T : Object
        {
            using (_fieldManager.Get<ScrollViewUIMetadata>(context.svContent).GetScope())
            {
                DrawProjectOverview(context);

                EditorGUILayout.Space(6f, false);
                DrawAssetSaveLocation(context);

                AssetUIHelper.HorizontalLineSeparator(AssetUIHelper.LineColorH1);

                DrawTypeCorrectionSection(context);

                AssetUIHelper.HorizontalLineSeparator(AssetUIHelper.LineColorH1);

                DrawTypeInstances(context);
            }
        }

        private void DrawProjectOverview<T>(AssetLocationContext<T> context)
            where T : Object
        {
            var header = _fieldManager.Get<LabelH2Metadata>("Project Overview");

            header.Draw();

            using (new EditorGUI.IndentLevelScope())
            {
                var labels_totalType =
                    _fieldManager.Get<LabelMetadata>("Total Scriptable Object Types");
                var labels_typeIssues = _fieldManager.Get<LabelMetadata>("Types With Issues");
                var labels_totalInstance = _fieldManager.Get<LabelMetadata>("Total Instance Count");
                var labels_orphanedlInstances =
                    _fieldManager.Get<LabelMetadata>("Orphaned Instance Count");

                var fixAllLocationsDryRun =
                    _fieldManager.Get<ButtonMetadata>("Fix All Locations (Dry Run)");
                var fixAllLocations = _fieldManager.Get<ButtonMetadata>("Fix All Locations");
                _fieldManager.Get<ButtonMetadata>("Fix All Orphans (Dry Run)");
                _fieldManager.Get<ButtonMetadata>("Fix All Orphans");

                labels_totalType.SetPrefixLabelWidth(200);
                labels_typeIssues.SetPrefixLabelWidth(200);
                labels_totalInstance.SetPrefixLabelWidth(200);
                labels_orphanedlInstances.SetPrefixLabelWidth(200);

                var tiCount = context.typesIssues.Count;
                var oaCount = _oaContext.orphans.Count;

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
                        labels_orphanedlInstances.Draw(
                            oaCount.ToString(),
                            oaCount > 0 ? ColorPalettes.Editing.error : Color.clear
                        );
                    }
                }

                using (new GUILayout.HorizontalScope())
                {
                    using (new GUILayout.VerticalScope())
                    {
                        if (fixAllLocationsDryRun.Button(tiCount > 0))
                        {
                            context.CorrectAllIssues();
                        }

                        /*if (fixAllOrphansDryRun.Button(_oaContext.fixableOrphans > 0))
                        {
                        }*/
                    }

                    using (new GUILayout.VerticalScope())
                    {
                        if (fixAllLocations.Button(tiCount > 0))
                        {
                            context.CorrectAllIssues(false);
                        }

                        /*if (fixAllOrphans.Button(_oaContext.fixableOrphans > 0))
                        {
                        }*/
                    }
                }
            }

            AssetUIHelper.HorizontalLineSeparator();
        }

        private void DrawAssetSaveLocation<T>(AssetLocationContext<T> context)
            where T : Object
        {
            var assetType = context.SelectedType;

            var scriptableSaveLocation = context.saveLocations[assetType];

            using (new EditorGUI.IndentLevelScope())
            using (new EditorGUI.DisabledScope())
            {
                scriptableSaveLocation.Draw(_fieldManager);
            }
        }

        private void DrawTypeCorrectionSection<T>(AssetLocationContext<T> context)
            where T : Object
        {
            var assetType = context.SelectedType;

            var button_reprocess = _fieldManager.Get<ButtonMetadata>("Re-analyze Type");
            var button_fixLocations = _fieldManager.Get<ButtonMetadata>("Fix Locations");
            var button_fixLocationsDryRun =
                _fieldManager.Get<ButtonMetadata>("Fix Locations (Dry Run)");

            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.Space(EditorGUI.indentLevel * 15f, false);

                using (new EditorGUILayout.VerticalScope())
                {
                    //EditorGUILayout.Space(EditorGUI.indentLevel * 15f, false);

                    if (button_reprocess.Button())
                    {
                        context.ReprocessType(assetType);
                    }

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        using (new EditorGUILayout.VerticalScope())
                        {
                            if (button_fixLocationsDryRun.Button(
                                context.typesIssuesHash.Contains(assetType)
                            ))
                            {
                                context.CorrectIssues(context.SelectedType);
                            }

                            if (button_fixLocations.Button(
                                context.typesIssuesHash.Contains(assetType)
                            ))
                            {
                                context.CorrectIssues(context.SelectedType, false);
                            }
                        }

                        /*using (new EditorGUILayout.VerticalScope())
                        {
                            if (button_fixOrphansDryRun.Button(_oaContext.fixableOrphans > 0))
                            {
                            }

                            if (button_fixOrphans.Button(_oaContext.fixableOrphans > 0))
                            {
                            }
                        }*/
                    }
                }
            }
        }

        private void DrawTypeInstances<T>(AssetLocationContext<T> context)
            where T : Object
        {
            using (new EditorGUI.IndentLevelScope())
            {
                foreach (var dir in context.SelectedTypeRepositoryDirectories)
                {
                    dir.Draw(_fieldManager);
                }
            }
        }
    }
}

