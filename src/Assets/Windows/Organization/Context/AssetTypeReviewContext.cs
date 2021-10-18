using System;
using System.Collections.Generic;
using Appalachia.CI.Integration;
using Appalachia.CI.Integration.Assets;
using Appalachia.CI.Integration.FileSystem;
using Appalachia.CI.Integration.Paths;
using Appalachia.CI.Integration.Repositories;
using Appalachia.Core.Aspects.Tracing;
using Appalachia.Editing.Assets.Windows.Organization.Metadata;
using Appalachia.Editing.Core;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Unity.Profiling;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Assets.Windows.Organization.Context
{
    public class AssetTypeReviewContext<T> : AppalachiaWindowPaneContext,
                                             IAppalachiaOneMenuWindowPaneContext<TypeReviewMetadata>
        where T : Object
    {
        private const string _PRF_PFX = nameof(AssetTypeReviewContext<T>) + ".";
        private const string _TRACE_PFX = nameof(AssetTypeReviewContext<T>) + ".";
        private static readonly ProfilerMarker _PRF_OnReset = new(_PRF_PFX + nameof(OnReset));
        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));
        private static readonly ProfilerMarker _PRF_ReprocessType = new(_PRF_PFX + nameof(ReprocessType));
        private static readonly ProfilerMarker _PRF_ClearTypeState = new(_PRF_PFX + nameof(ClearTypeState));

        private static readonly ProfilerMarker _PRF_InitializeType = new(_PRF_PFX + nameof(InitializeType));

        private static readonly ProfilerMarker _PRF_InitializeTypeInstance =
            new(_PRF_PFX + nameof(InitializeTypeInstance));

        private static readonly ProfilerMarker _PRF_CorrectIssues = new(_PRF_PFX + nameof(CorrectIssues));

        private static readonly ProfilerMarker _PRF_CorrectAllIssues =
            new(_PRF_PFX + nameof(CorrectAllIssues));

        private static readonly TraceMarker _TRACE_OnInitialize = new(_TRACE_PFX + nameof(OnInitialize));
        private static readonly TraceMarker _TRACE_OnReset = new(_TRACE_PFX + nameof(OnReset));
        private static readonly TraceMarker _TRACE_ClearTypeState = new(_TRACE_PFX + nameof(ClearTypeState));

        private static readonly TraceMarker _TRACE_InitializeType = new(_TRACE_PFX + nameof(InitializeType));

        private static readonly TraceMarker _TRACE_InitializeTypeInstance =
            new(_TRACE_PFX + nameof(InitializeTypeInstance));

        public Func<Type, bool> typeExclusionCheck;
        public int totalInstances;
        public int totalIssueCount;
        public List<TypeReviewMetadata> types;

        public string[] assetPaths;

        public override int RequiredMenuCount => 1;

        public TypeReviewMetadata SelectedType
        {
            get
            {
                var selection = GetMenuSelection(0);
                var currentIndex = selection.currentIndex;

                return types[currentIndex];
            }
        }

        public IList<TypeReviewMetadata> MenuOneItems => types;

        private static string[] GetAssetPathsForType(Type t)
        {
            return AssetDatabaseManager.GetProjectAssetPaths(t);
        }

        private static string[] GetAssetPathsForType<T0>()
        {
            return GetAssetPathsForType(typeof(T0));
        }

        public override void ValidateMenuSelection(int menuIndex)
        {
            var menuSelection = GetMenuSelection(menuIndex);

            if (menuSelection.length != MenuOneItems.Count)
            {
                menuSelection.SetLength(MenuOneItems.Count);
            }
        }

        public void CorrectAllIssues(bool dryRun = true)
        {
            using (_PRF_CorrectAllIssues.Auto())
            {
                using var x = new EditorOnlyProgressBar("Correcting Issues", totalIssueCount, false, 1);

                using var y = new AssetEditingScope();

                for (var typeIndex = 0; typeIndex < types.Count; typeIndex++)
                {
                    var type = types[typeIndex];

                    if (!type.HasIssues)
                    {
                        continue;
                    }

                    x.Increment1AndShowProgress(type.type.Name);

                    CorrectIssues(type, dryRun);
                }
            }
        }

        public void CorrectIssues(TypeReviewMetadata assetTypeMetadata, bool dryRun = true)
        {
            using (_PRF_CorrectIssues.Auto())
            {
                var targetDirectoryMetadata = assetTypeMetadata.saveLocation;

                var repositories = assetTypeMetadata.repositories;

                foreach (var targetRepository in repositories)
                {
                    foreach (var locationData in targetRepository.locations)
                    {
                        if (locationData.isConventional)
                        {
                            continue;
                        }

                        var targetDirectory = locationData.correctionPath ??
                                              targetDirectoryMetadata.saveLocationMetadata;

                        var targetDirectoryRelativePath = targetDirectory.relativePath;

                        if (!dryRun)
                        {
                            targetDirectory.CreateDirectoryStructure();
                        }

                        foreach (var instance in locationData.instances)
                        {
                            var assetPath = AssetDatabaseManager.GetAssetPath(instance);

                            var assetFileName = AppaPath.GetFileName(assetPath);

                            var newAssetPath = AppaPath.Combine(targetDirectoryRelativePath, assetFileName);

                            if (dryRun)
                            {
                                var validateMove = AssetDatabaseManager.ValidateMoveAsset(
                                    assetPath,
                                    newAssetPath
                                );

                                Debug.Log($"{validateMove}: [{assetPath}] to [{newAssetPath}]");
                            }
                            else
                            {
                                AssetDatabaseManager.MoveAsset(assetPath, newAssetPath);
                                Debug.Log($"Moved [{assetPath}] to [{newAssetPath}].");
                            }
                        }
                    }
                }

                if (!dryRun)
                {
                    ReprocessType(assetTypeMetadata);
                }
            }
        }

        public void ReprocessType(TypeReviewMetadata assetTypeMetadata)
        {
            using (_PRF_ReprocessType.Auto())
            {
                var originalIndex = types.IndexOf(assetTypeMetadata);

                ClearTypeState(assetTypeMetadata);
                InitializeType(assetTypeMetadata, originalIndex);

                assetPaths = GetAssetPathsForType<T>();

                for (var index = 0; index < assetPaths.Length; index++)
                {
                    var soPath = assetPaths[index];
                    var asset = AssetDatabaseManager.LoadAssetAtPath(soPath, assetTypeMetadata.type);

                    InitializeTypeInstance(assetTypeMetadata, soPath, asset);
                }
            }
        }

        protected override void OnInitialize()
        {
            using (_TRACE_OnInitialize.Auto())
            using (_PRF_OnInitialize.Auto())
            {
                if ((typeof(T) == typeof(Object)) && (typeExclusionCheck == null))
                {
                    typeExclusionCheck = t => typeof(ScriptableObject).IsAssignableFrom(t);
                }

                if (types == null)
                {
                    types = new List<TypeReviewMetadata>();
                }

                assetPaths = GetAssetPathsForType<T>();

                totalInstances = assetPaths.Length;

                for (var index = 0; index < assetPaths.Length; index++)
                {
                    var assetPath = assetPaths[index];
                    Object asset = null;

                    var error = false;
                    try
                    {
                        asset = AssetDatabaseManager.LoadAssetAtPath(assetPath, typeof(T));
                    }
                    catch
                    {
                        error = true;
                    }

                    if (error)
                    {
                        continue;
                    }

                    if (asset == null)
                    {
                        continue;
                    }

                    var assetType = asset.GetType();

                    if ((typeExclusionCheck != null) && typeExclusionCheck(assetType))
                    {
                        continue;
                    }

                    var assetTypeMetadata = new TypeReviewMetadata {type = assetType};

                    ClearTypeState(assetTypeMetadata);

                    InitializeType(assetTypeMetadata);
                    InitializeTypeInstance(assetTypeMetadata, assetPath, asset);
                }
            }
        }

        protected override void OnReset()
        {
            using (_TRACE_OnReset.Auto())
            using (_PRF_OnReset.Auto())
            {
                types?.Clear();
                assetPaths = null;
                totalInstances = 0;
            }
        }

        private void ClearTypeState(TypeReviewMetadata assetTypeMetadata)
        {
            using (_TRACE_ClearTypeState.Auto())
            using (_PRF_ClearTypeState.Auto())
            {
                if (types.Contains(assetTypeMetadata))
                {
                    types.Remove(assetTypeMetadata);
                }
            }
        }

        private void InitializeType(TypeReviewMetadata typeReviewMetadata, int? forceIndex = null)
        {
            using (_TRACE_InitializeType.Auto())
            using (_PRF_InitializeType.Auto())
            {
                if (typeReviewMetadata.repositories == null)
                {
                    typeReviewMetadata.repositories = new List<RepositoryAssetSaveDirectories>();
                }

                typeReviewMetadata.issues = 0;

                AssetPathMetadata assetSaveLocation;

                if (typeof(ScriptableObject).IsAssignableFrom(typeReviewMetadata.type))
                {
                    assetSaveLocation =
                        AssetDatabaseManager.GetSaveLocationForScriptableObject(typeReviewMetadata.type);
                }
                else
                {
                    assetSaveLocation =
                        AssetDatabaseManager.GetSaveLocationForAsset(typeReviewMetadata.type, null);
                }

                var monoScript = AssetDatabaseManager.GetScriptFromType(typeReviewMetadata.type);

                var typeLocation = AssetPathMetadata.ForScript(monoScript);

                if ((typeLocation == null) && (assetSaveLocation == null))
                {
                    return;
                }

                if (forceIndex.HasValue)
                {
                    types.Insert(forceIndex.Value, typeReviewMetadata);
                }
                else
                {
                    types.Add(typeReviewMetadata);
                }

                var assetSaveLocationMetadata = new AssetSaveLocationMetadata
                {
                    typeMetadata = typeLocation, saveLocationMetadata = assetSaveLocation
                };

                typeReviewMetadata.saveLocation = assetSaveLocationMetadata;

                if (!assetSaveLocationMetadata.saveLocationMetadata.doesExist)
                {
                    typeReviewMetadata.issues += 1;
                    totalIssueCount += 1;
                }
            }
        }

        private void InitializeTypeInstance(
            TypeReviewMetadata assetTypeMetadata,
            string assetPath,
            Object asset)
        {
            using (_TRACE_InitializeTypeInstance.Auto())
            using (_PRF_InitializeTypeInstance.Auto())
            {
                var assetName = AppaPath.GetFileName(assetPath);
                var assetDirectoryRelativePath = assetPath.Replace(assetName, string.Empty).Trim('/');

                var repositoryFolders = ProjectLocations.GetAssetRepository(assetPath);

                if (repositoryFolders == null)
                {
                    repositoryFolders = RepositoryDirectoryMetadata.Empty();
                }

                if (assetTypeMetadata.repositories == null)
                {
                    assetTypeMetadata.repositories = new List<RepositoryAssetSaveDirectories>();
                }

                var typeRepositories = assetTypeMetadata.repositories;

                RepositoryAssetSaveDirectories repository = null;

                for (var index = 0; index < typeRepositories.Count; index++)
                {
                    var typeRepository = typeRepositories[index];

                    if (typeRepository.repository != repositoryFolders)
                    {
                        continue;
                    }

                    repository = typeRepository;
                    break;
                }

                if (repository == null)
                {
                    repository = new RepositoryAssetSaveDirectories
                    {
                        locations = new List<RepositorySubdirectory>(), repository = repositoryFolders
                    };

                    typeRepositories.Add(repository);
                }

                RepositorySubdirectory assetDirectory = null;

                foreach (var location in repository.locations)
                {
                    if (location.relativePath == assetDirectoryRelativePath)
                    {
                        assetDirectory = location;
                        break;
                    }
                }

                if (assetDirectory == null)
                {
                    assetDirectory = new RepositorySubdirectory(
                        repository.repository,
                        assetDirectoryRelativePath
                    );
                    repository.locations.Add(assetDirectory);
                }

                if (assetDirectory.instances == null)
                {
                    assetDirectory.instances = new List<Object>();
                }

                if (assetDirectory.lookup == null)
                {
                    assetDirectory.lookup = new HashSet<Object>();
                }

                if (assetDirectory.lookup.Contains(asset))
                {
                    return;
                }

                assetDirectory.instances.Add(asset);

                assetDirectory.lookup.Add(asset);

                if (assetTypeMetadata.locations == null)
                {
                    assetTypeMetadata.locations = new List<string>();
                }

                assetTypeMetadata.locations.Add(assetPath);

                AssetPathMetadata assetSaveLocation;

                if (typeof(ScriptableObject).IsAssignableFrom(assetTypeMetadata.type))
                {
                    assetSaveLocation =
                        AssetDatabaseManager.GetSaveLocationForScriptableObject(assetTypeMetadata.type);
                }
                else
                {
                    assetSaveLocation = AssetDatabaseManager.GetSaveLocationForAsset(
                        assetTypeMetadata.type,
                        assetPath
                    );
                }

                if (assetSaveLocation == null)
                {
                    return;
                }

                if (assetSaveLocation.relativePath == assetDirectory.relativePath)
                {
                    assetDirectory.isConventional = true;
                }

                if (assetDirectory.isConventional)
                {
                    return;
                }

                if (assetSaveLocation.relativePath != assetDirectory.relativePath)
                {
                    assetDirectory.isConventional = false;
                    assetDirectory.correctionPath = assetSaveLocation;

                    if (assetSaveLocation.pathType == AssetPathMetadataType.ProjectDataFolder)
                    {
                        var repoBasedSaveLocation =
                            AssetDatabaseManager.GetSaveLocationForAsset(assetTypeMetadata.type, assetPath);

                        var dir = (AppaDirectoryInfo) repoBasedSaveLocation.assetInfo;

                        if (dir.IsPathInAnySubdirectory(assetDirectory.relativePath))
                        {
                            assetDirectory.isConventional = true;
                        }

                        if (repoBasedSaveLocation != null)
                        {
                            assetDirectory.correctionPath = repoBasedSaveLocation;

                            if (assetDirectory.relativePath == repoBasedSaveLocation.relativePath)
                            {
                                assetDirectory.isConventional = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
