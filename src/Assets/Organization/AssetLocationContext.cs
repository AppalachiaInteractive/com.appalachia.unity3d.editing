using System;
using System.Collections.Generic;
using System.IO;
using Appalachia.CI.Integration;
using Appalachia.CI.Integration.Paths;
using Appalachia.CI.Integration.Repositories;
using Appalachia.Core.Assets;
using Appalachia.Editing.Core;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Assets.Organization
{
    internal class AssetLocationContext<T> where T : UnityEngine.Object
    {
        private const string _PRF_PFX = nameof(AssetLocationContext<T>) + ".";

        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

        public string svMenu;
        public string svContent;

        public int selectedIndex;
        public int totalInstances;

        private Dictionary<Type, int> _issuesByType;
        public Dictionary<Type, List<RepositoryAssetSaveDirectories>> allTypeRepositories;
        public Dictionary<Type, List<string>> assetLocations = new();
        public Dictionary<Type, AssetTypeMetadata> saveLocations = new();
        public HashSet<Type> typesHash;
        public HashSet<Type> typesIssuesHash;
        public List<Type> types;
        public List<Type> typesIssues;
        public Func<Type, bool> typeExclusionCheck;
        public Type SelectedType
        {
            get
            {
                if ((selectedIndex < 0) ||
                    (types == null) ||
                    (types.Count == 0) ||
                    (selectedIndex >= types.Count))
                {
                    return default;
                }

                return types[selectedIndex];
            }
        }

        public int SelectedTypeIssues => _issuesByType[SelectedType];

        public IReadOnlyList<RepositoryAssetSaveDirectories> SelectedTypeRepositoryDirectories
        {
            get
            {
                var type = SelectedType;

                var typeDirectory = allTypeRepositories[type];

                return typeDirectory;
            }
        }

        public void Initialize(string[] assetPaths, bool force = false)
        {
            using (_PRF_Initialize.Auto())
            {
                InitializeCollections();

                totalInstances = assetPaths.Length;

                if (saveLocations.Count == 0)
                {
                    for (var index = 0; index < assetPaths.Length; index++)
                    {
                        var assetPath = assetPaths[index];
                        Object asset;

                        try
                        {
                            asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(T));
                        }
                        catch
                        {
                            continue;
                        }

                        if (asset == null)
                        {
                            continue;
                        }
                        
                        var assetType = asset.GetType();

                        if (typeExclusionCheck != null && typeExclusionCheck(assetType))
                        {
                            continue;
                        }

                        if (force)
                        {
                            ClearTypeState(assetType);
                        }
                        
                        InitializeType(assetType);
                        InitializeTypeInstance(assetType, assetPath, asset);
                    }
                }
            }
        }

        private static readonly ProfilerMarker _PRF_InitializeCollections = new ProfilerMarker(_PRF_PFX + nameof(InitializeCollections));
        private void InitializeCollections()
        {
            using (_PRF_InitializeCollections.Auto())
            {
                if (saveLocations == null)
                {
                    saveLocations = new Dictionary<Type, AssetTypeMetadata>();
                }

                if (assetLocations == null)
                {
                    assetLocations = new Dictionary<Type, List<string>>();
                }

                if (allTypeRepositories == null)
                {
                    allTypeRepositories = new Dictionary<Type, List<RepositoryAssetSaveDirectories>>();
                }

                if (types == null)
                {
                    types = new List<Type>();
                }

                if (typesIssues == null)
                {
                    typesIssues = new List<Type>();
                }

                if (typesHash == null)
                {
                    typesHash = new HashSet<Type>();
                }

                if (typesIssuesHash == null)
                {
                    typesIssuesHash = new HashSet<Type>();
                }

                if (_issuesByType == null)
                {
                    _issuesByType = new Dictionary<Type, int>();
                }
            }
        }

        private static readonly ProfilerMarker _PRF_ReprocessType = new ProfilerMarker(_PRF_PFX + nameof(ReprocessType));
        public void ReprocessType(Type assetType)
        {

            using (_PRF_ReprocessType.Auto())
            {
                var originalIndex = types.IndexOf(assetType);
            
                ClearTypeState(assetType);
                InitializeType(assetType, originalIndex);
            
                var assetPaths = AssetDatabaseManager.GetProjectAssetPaths(typeof(T));

                for (var index = 0; index < assetPaths.Length; index++)
                {
                    var soPath = assetPaths[index];
                    var asset = AssetDatabase.LoadAssetAtPath(soPath, assetType);
                        
                    InitializeTypeInstance(assetType, soPath, asset);
                }
            }
        }

        private static readonly ProfilerMarker _PRF_ClearTypeState = new ProfilerMarker(_PRF_PFX + nameof(ClearTypeState));
        private void ClearTypeState(Type assetType)
        {

            using (_PRF_ClearTypeState.Auto())
            {
                if (saveLocations.ContainsKey(assetType))
                {
                    saveLocations.Remove(assetType);
                }

                if (assetLocations.ContainsKey(assetType))
                {
                    assetLocations.Remove(assetType);
                }

                if (allTypeRepositories.ContainsKey(assetType))
                {
                    allTypeRepositories.Remove(assetType);
                }

                if (types.Contains(assetType))
                {
                    types.Remove(assetType);
                }

                if (typesIssues.Contains(assetType))
                {
                    typesIssues.Remove(assetType);
                }

                if (typesHash.Contains(assetType))
                {
                    typesHash.Remove(assetType);
                }

                if (typesIssuesHash.Contains(assetType))
                {
                    typesIssuesHash.Remove(assetType);
                }

                if (_issuesByType.ContainsKey(assetType))
                {
                    _issuesByType.Remove(assetType);
                }
            }
        }

        private static readonly ProfilerMarker _PRF_InitializeType = new ProfilerMarker(_PRF_PFX + nameof(InitializeType));
        private void InitializeType(Type assetType, int? forceIndex = null)
        {
            using (_PRF_InitializeType.Auto())
            {
                if (!allTypeRepositories.ContainsKey(assetType))
                {
                    allTypeRepositories.Add(assetType, new List<RepositoryAssetSaveDirectories>());
                }

                if (!_issuesByType.ContainsKey(assetType))
                {
                    _issuesByType.Add(assetType, 0);
                }
            
                AssetPathMetadata assetSaveLocation;
            
                if (typeof(ScriptableObject).IsAssignableFrom(assetType))
                {
                    assetSaveLocation = AssetDatabaseManager.GetSaveLocationForScriptableObject(assetType);
                }
                else
                {
                    assetSaveLocation = AssetDatabaseManager.GetSaveLocationForAsset(assetType, null);
                }

                if (saveLocations.ContainsKey(assetType))
                {
                    return;
                }

                var monoScript = AssetDatabaseManager.GetScriptFromType(assetType);
                var typeLocation = AssetPathMetadata.ForScript(monoScript);

                if ((typeLocation == null) && (assetSaveLocation == null))
                {
                    return;
                }

                if (!typesHash.Contains(assetType))
                {
                    if (forceIndex.HasValue)
                    {
                        types.Insert(forceIndex.Value, assetType);
                    }
                    else
                    {
                        types.Add(assetType);
                    }
                    
                    typesHash.Add(assetType);
                }

                var result = new AssetTypeMetadata
                {
                    typeMetadata = typeLocation, saveLocationMetadata = assetSaveLocation
                };

                if (saveLocations.ContainsKey(assetType))
                {
                    saveLocations[assetType] = result;
                }
                else
                {
                    saveLocations.Add(assetType, result);
                }

                if (result.saveLocationMetadata.doesExist)
                {
                    return;
                }

                if (!typesIssuesHash.Contains(assetType))
                {
                    typesIssues.Add(assetType);
                    typesIssuesHash.Add(assetType);
                }

                _issuesByType[assetType] += 1;
            }
        }

        private static readonly ProfilerMarker _PRF_InitializeTypeInstance = new ProfilerMarker(_PRF_PFX + nameof(InitializeTypeInstance));
        private void InitializeTypeInstance(Type assetType, string assetPath, Object asset)
        {
            using (_PRF_InitializeTypeInstance.Auto())
            {
                var assetName = Path.GetFileName(assetPath);
                var assetDirectoryRelativePath = assetPath.Replace(assetName, string.Empty).Trim('/');

                var repositoryFolders = ProjectLocations.GetAssetRepository(assetPath);

                if (repositoryFolders == null)
                {
                    repositoryFolders = RepositoryDirectoryMetadata.Empty();
                }

                var typeRepositories = allTypeRepositories[assetType];

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
                        locations = new List<RepositorySubdirectory>(),
                        repository = repositoryFolders
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
                    assetDirectory = new RepositorySubdirectory(repository.repository, assetDirectoryRelativePath);
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

                if (!assetLocations.ContainsKey(assetType))
                {
                    assetLocations.Add(assetType, new List<string>());
                }

                assetLocations[assetType].Add(assetPath);

                AssetPathMetadata assetSaveLocation;
            
                if (typeof(ScriptableObject).IsAssignableFrom(assetType))
                {
                    assetSaveLocation = AssetDatabaseManager.GetSaveLocationForScriptableObject(assetType);
                }
                else
                {
                    assetSaveLocation = AssetDatabaseManager.GetSaveLocationForAsset(assetType, assetPath);
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
                            AssetDatabaseManager.GetSaveLocationForAsset(assetType, assetPath);

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
            
                if (assetDirectory.isConventional)
                {
                    return;
                } 

                if (typesIssuesHash.Contains(assetType))
                {
                    return;
                }

                typesIssuesHash.Add(assetType);
                typesIssues.Add(assetType);
            }
        }

        public void CorrectIssues(Type assetType, bool dryRun = true)
        {
            var targetDirectoryMetadata = saveLocations[assetType];

            var targetRepositories = allTypeRepositories[assetType];

            foreach (var targetRepository in targetRepositories)
            {
                foreach (var locationData in targetRepository.locations)
                {
                    if (locationData.isConventional)
                    {
                        continue;
                    }

                    var targetDirectory = locationData.correctionPath ?? targetDirectoryMetadata.saveLocationMetadata;

                    var targetDirectoryRelativePath = targetDirectory.relativePath;

                    if (!dryRun)
                    {
                        targetDirectory.CreateDirectoryStructure();
                    }

                    foreach (var instance in locationData.instances)
                    {
                        var assetPath = AssetDatabase.GetAssetPath(instance);

                        var assetFileName = Path.GetFileName(assetPath);

                        var newAssetPath = Path.Combine(targetDirectoryRelativePath, assetFileName);

                        if (dryRun)
                        {
                            var validateMove = AssetDatabase.ValidateMoveAsset(
                                assetPath,
                                newAssetPath
                            );

                            Debug.Log($"{validateMove}: [{assetPath}] to [{newAssetPath}]");
                        }
                        else
                        {
                            AssetDatabase.MoveAsset(assetPath, newAssetPath);
                            Debug.Log($"Moved [{assetPath}] to [{newAssetPath}].");
                        }
                    }
                }
            }

            if (!dryRun)
            {
                ReprocessType(assetType);
            }
        }

        public void CorrectAllIssues(bool dryRun = true)
        {
            using var x = new EditorOnlyProgressBar(
                "Correcting Issues",
                typesIssues.Count,
                false,
                1
            );
            
            using var y = new AssetEditingScope();
            
            for (var typeIndex = 0; typeIndex < typesIssues.Count; typeIndex++)
            {
                var issueType = typesIssues[typeIndex];

                x.Increment1AndShowProgress(issueType.Name);

                CorrectIssues(issueType, dryRun);
            }
        }
    }
}
