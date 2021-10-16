using System.Collections.Generic;
using Appalachia.CI.Integration.Assemblies;
using Appalachia.CI.Integration.Assets;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Extensions
{
    public static class AssemblyDefinitionMetadataExtensions
    {
        private const int prefixLabelWidth = 175;
        private const string _PRF_PFX = nameof(AssemblyDefinitionMetadataExtensions) + ".";

        private static readonly ProfilerMarker _PRF_Draw = new(_PRF_PFX + nameof(Draw));

        private static readonly ProfilerMarker _PRF_DrawHeader = new(_PRF_PFX + nameof(DrawHeader));

        private static readonly ProfilerMarker _PRF_DrawAssemblyOverview =
            new(_PRF_PFX + nameof(DrawAssemblyOverview));

        private static readonly ProfilerMarker _PRF_DrawFields = new(_PRF_PFX + nameof(DrawFields));
        private static readonly ProfilerMarker _PRF_DrawButtons = new(_PRF_PFX + nameof(DrawButtons));

        private static readonly ProfilerMarker _PRF_DrawReferences = new(_PRF_PFX + nameof(DrawReferences));

        public static void Draw(
            this AssemblyDefinitionMetadata metadata,
            AssemblyDefinitionAssetContext context,
            UIFieldMetadataManager fieldManager,
            bool useTestFiles)
        {
            using (_PRF_Draw.Auto())
            {
                DrawHeader(metadata, fieldManager, useTestFiles);

                DrawAssemblyOverview(metadata, fieldManager, useTestFiles);

                using (new EditorGUI.IndentLevelScope())
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        DrawFields(metadata, fieldManager, useTestFiles);
                    }

                    DrawButtons(metadata, context, fieldManager, useTestFiles);

                    DrawReferences(metadata, fieldManager, useTestFiles);
                }
            }
        }

        private static void DrawAssemblyOverview(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldManager,
            bool useTestFiles)
        {
            using (_PRF_DrawAssemblyOverview.Auto())
            {
                var palette = ColorPalettes.Editing;

                var field_issuesName = fieldManager.Get<LabelH5Metadata>("Naming Issues");
                var field_issuesAsse = fieldManager.Get<LabelH5Metadata>("Invalid Assembly");
                var field_issuesSort = fieldManager.Get<LabelH5Metadata>("Incorrect Sorting");
                var field_issuesGuid = fieldManager.Get<LabelH5Metadata>("Name-Based References");
                var field_issuesNone = fieldManager.Get<LabelH5Metadata>(" ");

                using (new GUILayout.HorizontalScope())
                {
                    (metadata.DoAllNamesMatch ? field_issuesNone : field_issuesName).Draw(palette.error);
                    (!metadata.HasInvalidAssemblies ? field_issuesNone : field_issuesAsse).Draw(
                        palette.warning
                    );
                    (!metadata.ShouldSortReferences ? field_issuesNone : field_issuesSort).Draw(
                        palette.notable
                    );
                    (metadata.DoesUseGuidReferences ? field_issuesNone : field_issuesGuid).Draw(
                        palette.warning2
                    );
                }
            }
        }

        private static void DrawButtons(
            AssemblyDefinitionMetadata metadata,
            AssemblyDefinitionAssetContext context,
            UIFieldMetadataManager fieldManager,
            bool useTestFiles)
        {
            using (_PRF_DrawButtons.Auto())
            {
                var palette = ColorPalettes.Editing;
                using (new EditorGUILayout.HorizontalScope())
                {
                    var selectButton = fieldManager.Get<MiniButtonMetadata>("Select");
                    var updateNamesButton = fieldManager.Get<MiniButtonMetadata>("Update Names");
                    var sortReferences = fieldManager.Get<MiniButtonMetadata>("Sort References");
                    var removeInvalidAssembliesButton =
                        fieldManager.Get<MiniButtonMetadata>("Remove Invalid Assemblies");
                    var convertToGuidReferencesButton =
                        fieldManager.Get<MiniButtonMetadata>("Convert To Guids");

                    if (selectButton.Button())
                    {
                        AssetDatabaseManager.SetSelection(metadata.asset);
                    }

                    if (updateNamesButton.Button(!metadata.DoAllNamesMatch, backgroundColor: palette.error))
                    {
                        metadata.UpdateNames(useTestFiles, true);
                    }

                    if (sortReferences.Button(
                        metadata.ShouldSortReferences,
                        backgroundColor: palette.notable
                    ))
                    {
                        metadata.SortReferences(useTestFiles, true);
                    }

                    if (removeInvalidAssembliesButton.Button(
                        metadata.HasInvalidAssemblies,
                        backgroundColor: palette.warning
                    ))
                    {
                        metadata.RemoveInvalidAssemblies(useTestFiles, true);
                    }

                    if (convertToGuidReferencesButton.Button(
                        !metadata.DoesUseGuidReferences,
                        backgroundColor: palette.warning2
                    ))
                    {
                        metadata.ConvertToGuidReferences(context.MenuOneItems, useTestFiles, true);
                    }
                }
            }
        }

        private static void DrawFields(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldManager,
            bool useTestFiles)
        {
            using (_PRF_DrawFields.Auto())
            {
                var palette = ColorPalettes.Editing;

                var field_assembly_current = fieldManager.Get<LabelH4Metadata>(
                    "Assembly Name (Current)",
                    f => f.SetPrefixLabelWidth(prefixLabelWidth)
                );
                var field_filename_current = fieldManager.Get<LabelH4Metadata>(
                    "File Name (Current)",
                    f => f.SetPrefixLabelWidth(prefixLabelWidth)
                );
                var field_root_namespace_current = fieldManager.Get<LabelH4Metadata>(
                    "Root Namespace (Current)",
                    f => f.SetPrefixLabelWidth(prefixLabelWidth)
                );

                var field_assembly_ideal = fieldManager.Get<LabelH4Metadata>(
                    "Assembly Name (Ideal)",
                    f => f.SetPrefixLabelWidth(prefixLabelWidth)
                );
                var field_filename_ideal = fieldManager.Get<LabelH4Metadata>(
                    "File Name (Ideal)",
                    f => f.SetPrefixLabelWidth(prefixLabelWidth)
                );
                var field_root_namespace_ideal = fieldManager.Get<LabelH4Metadata>(
                    "Root Namespace (Ideal)",
                    f => f.SetPrefixLabelWidth(prefixLabelWidth)
                );

                using (new GUILayout.VerticalScope())
                {
                    field_assembly_current.Draw(
                        metadata.assembly_current,
                        metadata.DoesAssemblyMatch ? Color.clear : palette.error
                    );
                    field_filename_current.Draw(
                        metadata.filename_current,
                        metadata.DoesFileNameMatch ? Color.clear : palette.error
                    );
                    field_root_namespace_current.Draw(
                        metadata.root_namespace_current,
                        metadata.DoesNamespaceMatch ? Color.clear : palette.error
                    );
                }

                using (new GUILayout.VerticalScope())
                {
                    field_assembly_ideal.Draw(
                        metadata.assembly_ideal,
                        metadata.DoesAssemblyMatch ? Color.clear : palette.error
                    );
                    field_filename_ideal.Draw(
                        metadata.filename_ideal,
                        metadata.DoesFileNameMatch ? Color.clear : palette.error
                    );
                    field_root_namespace_ideal.Draw(
                        metadata.root_namespace_ideal,
                        metadata.DoesNamespaceMatch ? Color.clear : palette.error
                    );
                }
            }
        }

        private static void DrawHeader(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldManager,
            bool useTestFiles)
        {
            using (_PRF_DrawHeader.Auto())
            {
                var palette = ColorPalettes.Editing;
                var field_header = fieldManager.Get<LabelH3Metadata>("Assembly Definition");

                var headerColor = Color.clear;
                if (!metadata.DoAllNamesMatch)
                {
                    headerColor = palette.error;
                }
                else if (metadata.HasInvalidAssemblies)
                {
                    headerColor = palette.warning;
                }

                field_header.Draw(metadata.path, headerColor);
            }
        }

        private static void DrawReferences(
            AssemblyDefinitionMetadata metadata,
            UIFieldMetadataManager fieldManager,
            bool useTestFiles)
        {
            using (_PRF_DrawReferences.Auto())
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    if (metadata.references == null)
                    {
                        metadata.references = new List<AssemblyDefinitionReferenceMetadata>();
                    }

                    foreach (var reference in metadata.references)
                    {
                        reference.Draw(fieldManager);
                    }
                }
            }
        }
    }
}
