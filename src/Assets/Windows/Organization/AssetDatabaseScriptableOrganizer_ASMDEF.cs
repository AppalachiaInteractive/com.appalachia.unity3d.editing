using System;
using Appalachia.CI.Integration.Assemblies;
using Appalachia.Core.Assets;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Assets.Extensions;
using Appalachia.Editing.Assets.Organization;
using Appalachia.Editing.Core.Colors;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public partial class AssetDatabaseScriptableOrganizer
    {
        private const string TAB_ASSEMBLIES = "Assembly Definitions";
        private const string ASMDEF_CONTENT = "ASMDEF_CONTENT";
        private const string G_ = "Appalachia/Asset Database/Organization";

        private AssemblyDefinitionAssetIssuesContext _adaiContext;

        private PREF<bool> generateTestFiles;

        private PREF<bool> onlyShowIssues;
        private PREF<bool> appalachiaOnly;

        private static readonly ProfilerMarker _PRF_InitializeAssemblyDefinitionIssues = new ProfilerMarker(_PRF_PFX + nameof(InitializeAssemblyDefinitionIssues));
        private void InitializeAssemblyDefinitionIssues()
        {
            using (_PRF_InitializeAssemblyDefinitionIssues.Auto())
            {
                if (_adaiContext == null)
                {
                    appalachiaOnly = PREFS.REG(G_,    "Appalachia Only",    true);
                    onlyShowIssues = PREFS.REG(G_,    "Only Show issues",    true);
                    generateTestFiles = PREFS.REG(G_, "Generate Test Files", true);

                    onlyShowIssues.OnAwake -= OnPreferenceAwake;
                    appalachiaOnly.OnAwake -= OnPreferenceAwake;
                    generateTestFiles.OnAwake -= OnPreferenceAwake;
                    onlyShowIssues.OnAwake += OnPreferenceAwake;
                    appalachiaOnly.OnAwake += OnPreferenceAwake;
                    generateTestFiles.OnAwake += OnPreferenceAwake;

                    _fieldManager.Add<ScrollViewUIMetadata>(ASMDEF_CONTENT);

                    _adaiContext = new AssemblyDefinitionAssetIssuesContext();

                    var asmdefPaths = AssetDatabaseManager.GetAssetPathsByExtension(".asmdef");

                    _adaiContext.Initialize(asmdefPaths);
                }
            }
        }

        private static Func<AssemblyDefinitionMetadata, bool>[] _checks;
        
        private static bool OnlyShowIssues(AssemblyDefinitionMetadata a) => !a.AnyIssues;
        private static bool ExcludeReadOnly(AssemblyDefinitionMetadata a) => a.readOnly;
        private static bool AppalachiaOnly(AssemblyDefinitionMetadata a) => !a.filename_current.StartsWith("Appalachia");
        private static bool AlwaysFalse(AssemblyDefinitionMetadata a) => false;
        
        private Func<AssemblyDefinitionMetadata, bool>[] GetChecks()
        {
            if (_checks == null)
            {
                _checks = new Func<AssemblyDefinitionMetadata, bool>[3];
            }

            _checks[0] = onlyShowIssues.Value ? OnlyShowIssues : AlwaysFalse;
            _checks[1] = true ? ExcludeReadOnly : AlwaysFalse;
            _checks[2] = appalachiaOnly.Value ? AppalachiaOnly : AlwaysFalse;

            return _checks;
        }

        private static readonly ProfilerMarker _PRF_DrawAssemblyDefinitionAssetIssues = new ProfilerMarker(_PRF_PFX + nameof(DrawAssemblyDefinitionAssetIssues));
        private void DrawAssemblyDefinitionAssetIssues()
        {
            using (_PRF_DrawAssemblyDefinitionAssetIssues.Auto())
            {

                var palette = ColorPalettes.Editing;

                var headerLabel = _fieldManager.Get<LabelH2Metadata>(TAB_ASSEMBLIES);
                var toggleAppalachiaOnly = _fieldManager.Get<ToggleFieldMetadata>("Appalachia Only");
                var toggleOnlyShowIssues = _fieldManager.Get<ToggleFieldMetadata>("Only Show Issues");
                var generateTestFilesLabel =
                    _fieldManager.Get<ToggleFieldMetadata>("Generate Test Files");

                var rescanButton = _fieldManager.Get<MiniButtonMetadata>("Rescan Issues");
                var updateNamesButton = _fieldManager.Get<MiniButtonMetadata>("Update Names");
                var sortReferences = _fieldManager.Get<MiniButtonMetadata>("Sort References");
                var removeInvalidAssembliesButton =
                    _fieldManager.Get<MiniButtonMetadata>("Remove Invalid Assemblies");
                var convertToGuidReferences = _fieldManager.Get<MiniButtonMetadata>("Convert To Guids");

                using (new GUILayout.HorizontalScope())
                {
                    headerLabel.Draw();
                    
                    appalachiaOnly.Value = toggleAppalachiaOnly.Toggle(appalachiaOnly.Value);
                    onlyShowIssues.Value = toggleOnlyShowIssues.Toggle(onlyShowIssues.Value);

                    generateTestFiles.Value = generateTestFilesLabel.Toggle(generateTestFiles.Value);
                }

                var checks = GetChecks();
                
                using (new GUILayout.HorizontalScope())
                {
                    if (rescanButton.Button())
                    {
                        _adaiContext = null;
                        InitializeAssemblyDefinitionIssues();
                    }

                    if (updateNamesButton.Button(_adaiContext.anyNameIssues, backgroundColor: palette.error))
                    {
                        ProcessAssemblyCollection(
                            true,
                            assembly => assembly.UpdateNames(generateTestFiles.Value, false),
                            checks
                        );
                    }

                    if (sortReferences.Button(_adaiContext.anySortingIssues, backgroundColor: palette.notable))
                    {
                        ProcessAssemblyCollection(
                            true,
                            assembly => assembly.SortReferences(generateTestFiles.Value, false),
                            checks
                        );
                    }

                    if (removeInvalidAssembliesButton.Button(
                        _adaiContext.anyInvalidReferenceIssues,
                        backgroundColor: palette.warning
                    ))
                    {
                        ProcessAssemblyCollection(
                            true,
                            assembly => assembly.RemoveInvalidAssemblies(generateTestFiles.Value, false),
                            checks
                        );
                    }

                    if (convertToGuidReferences.Button(
                        _adaiContext.anyNonGuidReferences,
                        backgroundColor: palette.warning2
                    ))
                    {
                        ProcessAssemblyCollection(
                            true,
                            assembly => assembly.ConvertToGuidReferences(_adaiContext.assemblyDefinitionMetadatas, generateTestFiles.Value, false),
                            checks
                        );
                    }
                }

                EditorGUILayout.Space(10f);
                
                using (_fieldManager.Get<ScrollViewUIMetadata>(ASMDEF_CONTENT).GetScope())
                {
                    ProcessAssemblyCollection(
                        false,
                        assembly => assembly.Draw(_adaiContext, _fieldManager, generateTestFiles.Value),
                        checks
                    );
                }
            }
        }

        private static readonly ProfilerMarker _PRF_ProcessAssemblyCollection = new ProfilerMarker(_PRF_PFX + nameof(ProcessAssemblyCollection));
        
        private void ProcessAssemblyCollection(
            bool refreshAssets,
            Action<AssemblyDefinitionMetadata> action,
            Func<AssemblyDefinitionMetadata, bool>[] skipAssembly)
        {

            using (_PRF_ProcessAssemblyCollection.Auto())
            {
                using (new AssetEditingScope(refreshAssets))
                {
                    for (var index = 0; index < _adaiContext.assemblyDefinitionMetadatas.Count; index++)
                    {
                        var assembly = _adaiContext.assemblyDefinitionMetadatas[index];

                        var skip = false;
                        if (skipAssembly != null)
                        {
                            for (var i = 0; i < skipAssembly.Length; i++)
                            {
                                var assemblySkipCheck = skipAssembly[i];

                                if (assemblySkipCheck == null)
                                {
                                    continue;
                                }
                                
                                if (assemblySkipCheck(assembly))
                                {
                                    skip = true;
                                    break;
                                }
                            }
                        }

                        if (skip)
                        {
                            continue;
                        }
                        
                        action(assembly);
                    }
                }
            }
        }
    }
}
