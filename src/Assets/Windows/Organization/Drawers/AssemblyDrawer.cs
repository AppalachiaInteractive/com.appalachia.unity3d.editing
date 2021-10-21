using System;
using System.Collections.Generic;
using Appalachia.CI.Constants;
using Appalachia.CI.Integration.Assemblies;
using Appalachia.CI.Integration.Assets;
using Appalachia.CI.Integration.Repositories;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.State;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Appalachia.Utility.Colors;
using Unity.Profiling;
using UnityEditorInternal;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Drawers
{
    public static class AssemblyDrawer
    {
        private const int DETAIL_LABEL_HEIGHT = 20;
        private const int HEADER_LABEL_HEIGHT = 35;
        private const int HIGHLIGHT_FIELDS_LABEL_HEIGHT = 22;
        private const int NF_LABEL_WIDTH = 80;
        private const int PREFIX_LABEL_WIDTH = 125;
        private const int REFERENCE_PREFIX_WIDTH = 300;

        private const string _PRF_PFX = nameof(AssemblyDrawer) + ".";

        private static readonly ProfilerMarker _PRF_DrawAssemblyDefinitionMetadata =
            new(_PRF_PFX + nameof(DrawAssemblyDefinitionMetadata));

        private static readonly ProfilerMarker _PRF_DrawHeader = new(_PRF_PFX + nameof(DrawHeader));

        private static readonly ProfilerMarker _PRF_DrawAssemblyOverview =
            new(_PRF_PFX + nameof(DrawAssemblyOverview));

        private static readonly ProfilerMarker _PRF_DrawFields =
            new(_PRF_PFX + nameof(DrawAssemblyNamingFields));

        private static readonly ProfilerMarker _PRF_DrawButtons = new(_PRF_PFX + nameof(DrawButtons));

        private static readonly ProfilerMarker _PRF_DrawReferences = new(_PRF_PFX + nameof(DrawReferences));

        private static readonly ProfilerMarker _PRF_DrawDependencies =
            new(_PRF_PFX + nameof(DrawDependencies));

        private static readonly ProfilerMarker _PRF_DrawNamespaceFolders =
            new(_PRF_PFX + nameof(DrawNamespaceFolders));

        private static readonly ProfilerMarker _PRF_DrawReference = new(_PRF_PFX + nameof(DrawReference));

        private static AssemblyDefinitionAnalysisMetadata _defaultAnalysis;

        private static readonly ProfilerMarker _PRF_UpdateAllMenuButton =
            new(_PRF_PFX + nameof(UpdateAllMenuButton));

        public static string CurrentEditor // works fast, doesn't validate if executable really exists
            =>
                UnityEditor.EditorPrefs.GetString("kScriptsDefaultApp");

        public static void DrawAssemblyDefinitionMetadata(
            AssemblyDefinitionMetadata metadata,
            AssemblyDefinitionAssetContext context,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawAssemblyDefinitionMetadata.Auto())
            {
                DrawHeader(metadata, fieldMetadataManager, useTestFiles);

                DrawAssemblyOverview(metadata, fieldMetadataManager, useTestFiles);

                AppalachiaEditorGUIHelper.HorizontalLineSeparator();

                using (UIStateStacks.indentLevel.Auto())
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        DrawAssemblyNamingFields(metadata, fieldMetadataManager, useTestFiles);
                    }

                    AppalachiaEditorGUIHelper.HorizontalLineSeparator();

                    DrawButtons(metadata, context, fieldMetadataManager, useTestFiles);

                    AppalachiaEditorGUIHelper.HorizontalLineSeparator();
                    fieldMetadataManager.Space(SpaceSize.SectionDividerVertical);
                    AppalachiaEditorGUIHelper.HorizontalLineSeparator();

                    using (new GUILayout.HorizontalScope())
                    {
                        var details = fieldMetadataManager.Get<ToolbarMetadata>("Assembly Details");

                        context.detailTabIndex = details.Toolbar(
                            context.detailTabIndex,
                            new[] {"Dependencies", "References", "Opportunities", "Namespace Folders"},
                            GUI.ToolbarButtonSize.FitToContents
                        );
                    }

                    if (context.detailTabIndex == 0)
                    {
                        DrawDependencies(metadata, fieldMetadataManager, useTestFiles);
                    }
                    else if (context.detailTabIndex == 1)
                    {
                        DrawReferences(metadata, fieldMetadataManager, useTestFiles);
                    }
                    else if (context.detailTabIndex == 2)
                    {
                        DrawOpportunities(metadata, fieldMetadataManager, useTestFiles);
                    }
                    else
                    {
                        DrawNamespaceFolders(metadata, fieldMetadataManager, useTestFiles);
                    }
                }
            }
        }

        public static void DrawTopLevelAssemblyButtons(
            AssemblyDefinitionAssetContext context,
            UIFieldMetadataManager fieldMetadataManager)
        {
            var scope = new GUILayout.HorizontalScope();
            var menuSelection = context.GetMenuSelection(0);

            if (_defaultAnalysis == null)
            {
                _defaultAnalysis = new AssemblyDefinitionAnalysisMetadata(null);
            }

            var aggregates = context.aggregateAnalysis;

            var columns = _defaultAnalysis.IssueDisplayColumns;
            var defaultIssues = _defaultAnalysis.AllIssues;
            _defaultAnalysis.SetIssueColors();

            var issueCount = defaultIssues.Count;

            for (var issueIndex = 0; issueIndex < issueCount; issueIndex++)
            {
                if ((issueIndex > 0) && ((issueIndex % columns) == 0))
                {
                    scope.Dispose();

                    scope = new GUILayout.HorizontalScope();
                }

                var left = (issueIndex % columns) == 0;
                var right = ((issueIndex % columns) == (columns - 1)) || (issueIndex == (issueCount - 1));

                var defaultIssue = defaultIssues[issueIndex];

                var labelName = $"Fix {defaultIssue.name}";

                IButtonMetadata button;

                if (left)
                {
                    button = fieldMetadataManager.Get<MiniButtonLeftMetadata>(labelName);
                }
                else if (right)
                {
                    button = fieldMetadataManager.Get<MiniButtonRightMetadata>(labelName);
                }
                else
                {
                    button = fieldMetadataManager.Get<MiniButtonMidMetadata>(labelName);
                }

                UpdateAllMenuButton(
                    context,
                    button,
                    defaultIssue.color,
                    aggregates.HasIssues(defaultIssue.type),
                    menuSelection,
                    assembly => assembly.analysis.IssueByType(defaultIssue.type)
                                        .Correct(context.generateTestFiles.v, false)
                );
            }

            scope.Dispose();
            AppalachiaEditorGUIHelper.HorizontalLineSeparator(bufferSize: 3f);
        }

        private static void DrawAssemblyButtons(
            AssemblyDefinitionMetadata metadata,
            AssemblyDefinitionAssetContext context,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawAssemblyOverview.Auto())
            {
                var scope = new GUILayout.HorizontalScope(GUILayout.ExpandWidth(true));

                var analysis = metadata.analysis;
                var columns = analysis.IssueDisplayColumns;
                var issues = analysis.AllIssues;
                var scopeCount = 0;

                var buttons = new List<AnalysisButtonAction>();

                buttons.Add(
                    new AnalysisButtonAction(
                        "All Issues",
                        analysis.AnyIssues,
                        ColorPalette.Default.bad.Last,
                        analysis
                    )
                );

                foreach (var issue in issues)
                {
                    buttons.Add(new AnalysisButtonAction(issue.name, issue.HasIssue, issue.color, issue));
                }

                var buttonCount = buttons.Count;

                for (var index = 0; index < buttonCount; index++)
                {
                    var buttonAction = buttons[index];

                    if ((index > 0) && ((index % columns) == 0))
                    {
                        scope.Dispose();

                        scope = new GUILayout.HorizontalScope(GUILayout.ExpandWidth(true));
                        scopeCount = 0;
                    }

                    var left = (index % columns) == 0;
                    var right = ((index % columns) == (columns - 1)) || (index == (buttonCount - 1));
                    var none = (index == (buttonCount - 1)) && (scopeCount == 0);

                    var labelName = $"Fix {buttonAction.labelName}";

                    IButtonMetadata button;

                    if (left)
                    {
                        button = fieldMetadataManager.Get<MiniButtonLeftMetadata>(labelName);
                    }
                    else if (right)
                    {
                        button = fieldMetadataManager.Get<MiniButtonRightMetadata>(labelName);
                    }
                    else if (none)
                    {
                        button = fieldMetadataManager.Get<MiniButtonMetadata>(labelName);
                    }
                    else
                    {
                        button = fieldMetadataManager.Get<MiniButtonMidMetadata>(labelName);
                    }

                    scopeCount += 1;

                    if (button.Button(buttonAction.hasIssue, backgroundColor: buttonAction.color))
                    {
                        buttonAction.Correct(useTestFiles, true);
                        metadata.Reanalyze();
                    }
                }

                scope.Dispose();
            }
        }

        private static void DrawAssemblyNamingFields(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawFields.Auto())
            {
                var field_assembly_current = fieldMetadataManager.Get<LabelH4Metadata>(
                    "Assembly (Current)",
                    f => f.SetPrefixLabelWidth(PREFIX_LABEL_WIDTH)
                );
                var field_filename_current = fieldMetadataManager.Get<LabelH4Metadata>(
                    "File (Current)",
                    f => f.SetPrefixLabelWidth(PREFIX_LABEL_WIDTH)
                );

                var field_assembly_ideal = fieldMetadataManager.Get<LabelH4Metadata>(
                    "Assembly (Ideal)",
                    f => f.SetPrefixLabelWidth(PREFIX_LABEL_WIDTH)
                );
                var field_filename_ideal = fieldMetadataManager.Get<LabelH4Metadata>(
                    "File (Ideal)",
                    f => f.SetPrefixLabelWidth(PREFIX_LABEL_WIDTH)
                );

                var field_dependency_level = fieldMetadataManager.Get<LabelH4Metadata>(
                    "Dependency Level",
                    f => f.SetPrefixLabelWidth(PREFIX_LABEL_WIDTH)
                );

                var field_namespace = fieldMetadataManager.Get<LabelH4Metadata>(
                    "Namespace",
                    f => f.SetPrefixLabelWidth(PREFIX_LABEL_WIDTH)
                );

                var ani = metadata.analysis.NameAssembly;
                var fni = metadata.analysis.NameFile;

                var drawIdeals = ani.HasIssue || fni.HasIssue;

                using (new GUILayout.VerticalScope())
                {
                    field_assembly_current.Draw(
                        metadata.assembly_current,
                        ani.HasIssue ? ani.color : Color.clear,
                        true
                    );

                    if (drawIdeals)
                    {
                        field_assembly_ideal.Draw(metadata.assembly_ideal, true);
                    }

                    field_dependency_level.Draw(metadata.GetAssemblyDependencyLevel().ToString());
                }

                using (new GUILayout.VerticalScope())
                {
                    field_filename_current.Draw(
                        metadata.filename_current,
                        fni.HasIssue ? fni.color : Color.clear,
                        true
                    );

                    if (drawIdeals)
                    {
                        field_filename_ideal.Draw(metadata.filename_ideal, true);
                    }

                    field_namespace.Draw(metadata.root_namespace_current);
                }
            }
        }

        private static void DrawAssemblyOverview(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawAssemblyOverview.Auto())
            {
                var scope = new GUILayout.HorizontalScope();

                var palette = ColorPalettes.Default;
                var columns = metadata.analysis.IssueDisplayColumns;

                for (var index = 0; index < metadata.analysis.AllIssues.Count; index++)
                {
                    if ((index > 0) && ((index % columns) == 0))
                    {
                        scope.Dispose();

                        scope = new GUILayout.HorizontalScope();
                    }

                    var issue = metadata.analysis.AllIssues[index];

                    var issueLabel = fieldMetadataManager.Get<LabelH5Metadata>(
                        $"{metadata.root_namespace_current}.{issue.name}",
                        f =>
                        {
                            f.AlterContent(c => c.text = issue.name);
                            f.SetLabelHeight(HIGHLIGHT_FIELDS_LABEL_HEIGHT);
                            f.AlterStyle(s => s.alignment = TextAnchor.MiddleCenter);
                        }
                    );

                    if (issue.HasIssue)
                    {
                        issueLabel.Draw(issue.color, true);
                    }
                    else
                    {
                        issueLabel.Draw(palette.disabled.Middle, true);
                    }
                }

                scope.Dispose();
            }
        }


        private static Color highlightColor => ColorPalette.Default.highlight.Middle;
        private static Color notableColor => ColorPalette.Default.notable.Quarter;
        
        private static void DrawButtons(
            AssemblyDefinitionMetadata metadata,
            AssemblyDefinitionAssetContext context,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawButtons.Auto())
            {
                using (new GUILayout.HorizontalScope())
                {
                    fieldMetadataManager.Space(SpaceSize.ButtonPaddingLeft);

                    using (new GUILayout.VerticalScope())
                    {
                        using (new GUILayout.HorizontalScope(GUILayout.ExpandWidth(true)))
                        {
                            var selectButton = fieldMetadataManager.Get<MiniButtonLeftMetadata>("Select");
                            var reanalyzeButton =
                                fieldMetadataManager.Get<MiniButtonMidMetadata>("Reanalyze");
                            var dotsettingsButton =
                                fieldMetadataManager.Get<MiniButtonMidMetadata>("Open .dotSettings");
                            var packageButton =
                                fieldMetadataManager.Get<MiniButtonMidMetadata>("Open package.json");
                            var asmdefButton =
                                fieldMetadataManager.Get<MiniButtonRightMetadata>("Open .asmdef");
                            
                            if (selectButton.Button(backgroundColor:notableColor))
                            {
                                AssetDatabaseManager.SetSelection(metadata.asset);
                            }
                            
                            if (reanalyzeButton.Button(backgroundColor:notableColor))
                            {
                                metadata.Reanalyze();
                            }

                            if (dotsettingsButton.Button(backgroundColor:highlightColor))
                            {
                                InternalEditorUtility.OpenFileAtLineExternal(metadata.dotSettingsPath, 1);
                            }

                            if (packageButton.Button(backgroundColor:highlightColor))
                            {
                                AssetDatabaseManager.OpenAsset(metadata.repository.PackageAsset);
                            }

                            if (asmdefButton.Button(backgroundColor:highlightColor))
                            {
                                AssetDatabaseManager.OpenAsset(metadata.asset);
                            }
                        }

                        DrawAssemblyButtons(metadata, context, fieldMetadataManager, useTestFiles);
                    }

                    fieldMetadataManager.Space(SpaceSize.ButtonPaddingRight);
                }
            }
        }

        private static void DrawDependencies(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawDependencies.Auto())
            {
                using (UIStateStacks.indentLevel.Auto())
                {
                    if (metadata.dependencies == null)
                    {
                        metadata.dependencies = new List<RepositoryDependencyMetadata>();
                    }

                    foreach (var dependency in metadata.dependencies)
                    {
                        if (dependency.HasIssue)
                        {
                            DrawDependency(metadata, fieldMetadataManager, dependency);                        
                        }
                    }

                    foreach (var dependency in metadata.dependencies)
                    {
                        if (!dependency.HasIssue)
                        {
                            DrawDependency(metadata, fieldMetadataManager, dependency);                          
                        }
                    }
                }
            }
        }

        private static void DrawDependency(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldMetadataManager,
            RepositoryDependencyMetadata dependency)
        {
            var name = dependency.repository != null ? dependency.repository.PackageName : dependency.name;
            var version = dependency.repository != null
                ? dependency.repository.PackageVersion
                : dependency.version;

            string prefix;

            if (!dependency.IsValid)
            {
                prefix = "INVALID".Bold();
            }
            else if (dependency.IsMissing)
            {
                prefix = "MISSING".Bold();
            }
            else if (dependency.IsOutOfDate)
            {
                prefix = "OUTDATED".Bold();
            }
            else
            {
                prefix = "Valid".Italic();
            }

            var label_prefix = fieldMetadataManager.Get<LabelH5Metadata>(
                $"{metadata.Name}.{name}.{prefix}",
                m =>
                {
                    m.AlterContent(c => c.text = prefix);
                    m.AlterStyle(s => s.alignment = TextAnchor.MiddleCenter);
                    m.SetLabelHeight(DETAIL_LABEL_HEIGHT);
                    m.SetPrefixLabelWidth(120);
                    m.AddLayoutOption(GUILayout.Width(120), GUILayout.ExpandWidth(false));
                }
            );
            var label_name = fieldMetadataManager.Get<LabelH5Metadata>(
                $"{metadata.Name}.{name}.{name}",
                m =>
                {
                    m.AlterContent(c => c.text = name);
                    m.AlterStyle(s => s.alignment = TextAnchor.MiddleLeft);
                    m.SetLabelHeight(DETAIL_LABEL_HEIGHT);
                    m.SetPrefixLabelWidth(300);
                    m.AddLayoutOption(GUILayout.Width(300), GUILayout.ExpandWidth(false));
                }
            );
            var label_version = fieldMetadataManager.Get<LabelH5Metadata>(
                $"{metadata.Name}.{name}.{version}",
                m =>
                {
                    m.AlterContent(c => c.text = version);
                    m.AlterStyle(s => s.alignment = TextAnchor.MiddleRight);
                    m.SetLabelHeight(DETAIL_LABEL_HEIGHT);
                    m.SetPrefixLabelWidth(100);
                    m.AddLayoutOption(GUILayout.Width(100), GUILayout.ExpandWidth(false));
                }
            );

            using (new GUILayout.HorizontalScope(GUILayout.ExpandHeight(false)))
            {
                label_prefix.Draw(dependency.IssueColor);
                label_version.Draw(dependency.IsOutOfDate ? dependency.IssueColor : Color.clear, true);
                label_name.Draw(!dependency.IsMissing ? dependency.IssueColor : Color.clear, true);
            }
        }

        private static void DrawHeader(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawHeader.Auto())
            {
                var field_header = fieldMetadataManager.Get<LabelH3Metadata>(
                    "Assembly Definition",
                    f =>
                    {
                        f.SetPrefixLabelWidth(120);
                        f.SetLabelHeight(HEADER_LABEL_HEIGHT);
                        f.AddLayoutOption(GUILayout.ExpandWidth(true));
                        f.AlterStyle(s => s.alignment = TextAnchor.MiddleCenter);
                        f.AlterStyle(
                            s =>
                            {
                                var margin = s.margin;
                                margin.left +=
                                    (int) fieldMetadataManager.GetSpace(SpaceSize.HeaderPaddingLeft);
                                s.margin = margin;
                            }
                        );
                    }
                );

                using (new GUILayout.HorizontalScope())
                {
                    field_header.Draw(metadata.path, true);
                }
            }
        }

        private static void DrawNamespaceFolders(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (UIStateStacks.indentLevel.Auto())
            {
                foreach (var folder in metadata.dotSettings.AllFolders)
                {
                    var pathField = fieldMetadataManager.Get<LabelMetadata>(
                        $"{metadata.Name}.{folder.path}",
                        m =>
                        {
                            m.AlterContent(c => c.text = "Path");
                            m.SetPrefixLabelWidth(NF_LABEL_WIDTH);
                        }
                    );
                    var encodedField = fieldMetadataManager.Get<LabelMetadata>(
                        $"{metadata.Name}.{folder.encoded}",
                        m =>
                        {
                            m.AlterContent(c => c.text = "Encoded");
                            m.SetPrefixLabelWidth(NF_LABEL_WIDTH);
                        }
                    );

                    var pathIssue = !folder.excluded;
                    var encodingIssue = folder.encodingIssue;

                    var pathColor = pathIssue
                        ? metadata.analysis.GetColor(AssemblyAnalysisType.NamespaceFoldersExclusions)
                        : Color.clear;
                    
                    var encodedColor = encodingIssue
                        ? metadata.analysis.GetColor(AssemblyAnalysisType.NamespaceFoldersEncoding)
                        : Color.clear;

                    var hasPath = !string.IsNullOrWhiteSpace(folder.path);
                    var hasEncoded = !string.IsNullOrWhiteSpace(folder.encoded);
                    
                    pathField.Draw(hasPath ? folder.path : "not decoded".Italic(), pathColor, true);
                    encodedField.Draw(hasEncoded ? folder.encoded : "root".Italic(), encodedColor, true);

                    AppalachiaEditorGUIHelper.HorizontalLineSeparator();
                }
            }
        }

        private static void DrawOpportunities(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawReferences.Auto())
            {
                using (UIStateStacks.indentLevel.Auto())
                {
                    if (metadata.opportunities == null)
                    {
                        metadata.opportunities = new List<AssemblyDefinitionReferenceMetadata>();
                    }

                    foreach (var reference in metadata.opportunities)
                    {
                        DrawReference(reference, fieldMetadataManager);
                    }
                }
            }
        }

        private static void DrawReference(
            AssemblyDefinitionReferenceMetadata reference,
            UIFieldMetadataManager fieldMetadataManager)
        {
            using (_PRF_DrawReference.Auto())
            {
                var referenceLabel = fieldMetadataManager.Get<LabelMetadata>(reference.guid);

                referenceLabel.SetPrefixLabelWidth(REFERENCE_PREFIX_WIDTH);

                referenceLabel.Draw(reference.ToString(), reference.IssueColor, true);
            }
        }

        private static void DrawReferences(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldMetadataManager,
            bool useTestFiles)
        {
            using (_PRF_DrawReferences.Auto())
            {
                using (UIStateStacks.indentLevel.Auto())
                {
                    if (metadata.references == null)
                    {
                        metadata.references = new List<AssemblyDefinitionReferenceMetadata>();
                    }

                    foreach (var reference in metadata.references)
                    {
                        if (reference.HasIssue)
                        {
                            DrawReference(reference, fieldMetadataManager);                            
                        }
                    }

                    foreach (var reference in metadata.references)
                    {
                        if (!reference.HasIssue)
                        {
                            DrawReference(reference, fieldMetadataManager);                            
                        }
                    }
                }
            }
        }

        private static void UpdateAllMenuButton(
            AssemblyDefinitionAssetContext context,
            IButtonMetadata button,
            Color backgroundColor,
            bool enabled,
            AppalachiaWindowPaneMenuSelectionMetadata menuSelection,
            Action<AssemblyDefinitionMetadata> action)
        {
            using (_PRF_UpdateAllMenuButton.Auto())
            {
                if (button.Button(enabled, backgroundColor: backgroundColor))
                {
                    using (new AssetEditingScope())
                    {
                        for (var index = 0; index < context.MenuOneItems.Count; index++)
                        {
                            if (!menuSelection.IsVisible(index))
                            {
                                continue;
                            }

                            var assembly = context.MenuOneItems[index];

                            action(assembly);
                        }
                    }

                    AssetDatabaseManager.Refresh();
                    context.Reset();
                    context.Initialize();
                }
            }
        }
    }
}
