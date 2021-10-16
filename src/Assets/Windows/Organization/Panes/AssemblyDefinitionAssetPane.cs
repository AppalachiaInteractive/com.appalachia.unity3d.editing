using Appalachia.CI.Integration.Assemblies;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Assets.Extensions;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization.Panes
{
    public class AssemblyDefinitionAssetPane : AppalachiaMenuWindowPane<AssemblyDefinitionAssetContext>,
                                               IAppalachiaTabbedWindowPane
    {
        private const string _PRF_PFX = nameof(AssemblyDefinitionAssetPane) + ".";

        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        private AssemblyDefinitionAssetContext _context;

        private PREF<bool> appalachiaOnly;
        private PREF<bool> generateTestFiles;
        private PREF<bool> onlyShowIssues;

        public override bool ContentInScrollView => true;
        public override string PaneName => TabName;

        public int DesiredTabIndex => 1;

        public string TabName => "Assembly Definitions";

        public override void OnDrawPaneMenuItem(int menuIndex, int menuItemIndex, out bool isSelected)
        {
            var assemblyDefinitionMetadata = context.MenuOneItems[menuItemIndex];
            var backgroundColor = GetAssemblyDefinitionColor(assemblyDefinitionMetadata);

            var menuField = fieldMetadataManager.Get<MenuItemField>($"MIF_{menuIndex}");

            isSelected = false;

            if (menuField.Draw("    " + assemblyDefinitionMetadata.assembly_current, backgroundColor))
            {
                isSelected = true;
            }
        }

        public override bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex)
        {
            var assemblyDefinitionMetadata = context.MenuOneItems[menuItemIndex];

            if (onlyShowIssues.Value && !assemblyDefinitionMetadata.AnyIssues)
            {
                return false;
            }

            if (assemblyDefinitionMetadata.readOnly)
            {
                return false;
            }

            if (appalachiaOnly.Value && !assemblyDefinitionMetadata.filename_current.StartsWith("Appalachia"))
            {
                return false;
            }

            return true;
        }

        public override void OnDrawPaneContent()
        {
            EditorGUILayout.Space(10f);

            var menuItemIndex = context.GetMenuSelection(0).currentIndex;

            var assemblyDefinitionMetadata = context.MenuOneItems[menuItemIndex];

            assemblyDefinitionMetadata.Draw(context, fieldMetadataManager, generateTestFiles.Value);
        }

        public override void OnInitialize()
        {
            using (_PRF_OnInitialize.Auto())
            {
                ((IAppalachiaWindowPane) this).RegisterFilterPref(
                    ref appalachiaOnly,
                    "Assembly Definitions",
                    "Appalachia Only",
                    true
                );

                ((IAppalachiaWindowPane) this).RegisterFilterPref(
                    ref onlyShowIssues,
                    "Assembly Definitions",
                    "Only issues",
                    true
                );

                ((IAppalachiaWindowPane) this).RegisterFilterPref(
                    ref generateTestFiles,
                    "Assembly Definitions",
                    "Test Files",
                    true
                );
            }
        }

        public override void OnDrawPaneContentStart()
        {
            var palette = ColorPalettes.Editing;

            using (new GUILayout.HorizontalScope())
            {
                var updateNamesButton = fieldMetadataManager.Get<MiniButtonMetadata>("Update Names");

                if (updateNamesButton.Button(context.anyNameIssues, backgroundColor: palette.error))
                {
                    using var assetScope = new AssetEditingScope();
                    foreach (var assembly in context.MenuOneItems)
                    {
                        assembly.UpdateNames(generateTestFiles.Value, false);
                    }
                }

                var sortReferences = fieldMetadataManager.Get<MiniButtonMetadata>("Sort References");

                if (sortReferences.Button(context.anySortingIssues, backgroundColor: palette.notable))
                {
                    using var assetScope = new AssetEditingScope();
                    foreach (var assembly in context.MenuOneItems)
                    {
                        assembly.SortReferences(generateTestFiles.Value, false);
                    }
                }

                var removeInvalidAssembliesButton =
                    fieldMetadataManager.Get<MiniButtonMetadata>("Remove Invalid Assemblies");

                if (removeInvalidAssembliesButton.Button(
                    context.anyInvalidReferenceIssues,
                    backgroundColor: palette.warning
                ))
                {
                    using var assetScope = new AssetEditingScope();
                    foreach (var assembly in context.MenuOneItems)
                    {
                        assembly.RemoveInvalidAssemblies(generateTestFiles.Value, false);
                    }
                }

                var convertToGuidReferences =
                    fieldMetadataManager.Get<MiniButtonMetadata>("Convert To Guids");
                if (convertToGuidReferences.Button(
                    context.anyNonGuidReferences,
                    backgroundColor: palette.warning2
                ))
                {
                    using var assetScope = new AssetEditingScope();
                    foreach (var assembly in context.MenuOneItems)
                    {
                        assembly.ConvertToGuidReferences(
                            context.MenuOneItems,
                            generateTestFiles.Value,
                            false
                        );
                    }
                }
            }
        }

        private static Color GetAssemblyDefinitionColor(AssemblyDefinitionMetadata adm)
        {
            var palette = ColorPalettes.Editing;

            if (adm.ShouldUpdateNames)
            {
                return palette.error;
            }

            if (adm.ShouldSortReferences)
            {
                return palette.notable;
            }

            if (adm.HasInvalidAssemblies)
            {
                return palette.warning;
            }

            if (adm.DoesUseNameReferences)
            {
                return palette.warning2;
            }

            return Color.clear;
        }
    }
}
