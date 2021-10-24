using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Appalachia.CI.Integration.Assets;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Core.Extensions;
using Appalachia.Editing.Core.Operations;
using Appalachia.Editing.Core.Windows;
using Appalachia.Utility.Reflection.Extensions;
using Sirenix.OdinInspector;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Assets.Windows
{
    public class AssetRenamer : AppalachiaEditorWindow
    {
        public enum ApplicationTarget
        {
            BothFileAndAssetName,
            FileNameOnly,
            AssetNameOnly
        }

        public enum FilterTarget
        {
            ObjectName,
            FileName,
            FilePath,
            ObjectNameOrFileName,
            ObjectNameAndFileName,
            ObjectNameOrFilePath,
            ObjectNameAndFilePath,
            ObjectNameOrFileNameOrFilePath,
            ObjectNameAndFileNameAndFilePath
        }

        [BoxGroup("Operations")]
        public ApplicationTarget operationTarget = ApplicationTarget.BothFileAndAssetName;

        [BoxGroup("Filters/Operations")]
        [HorizontalGroup("Filters/Operations/A")]
        [OnValueChanged(nameof(CalculateFilterEffectiveness), true)]
        [SmartLabel]
        [ToggleLeft]
        public bool invertFilter;

        [BoxGroup("Filters/Operations")]
        [OnValueChanged(nameof(CalculateFilterEffectiveness), true)]
        [InlineProperty]
        public FilterOperationMetadata listFilter = new(FilterOperation.Contains);

        [HorizontalGroup("Filters/Operations/A")]
        [OnValueChanged(nameof(CalculateFilterEffectiveness), true)]
        [SmartLabel]
        public FilterTarget filterTarget;

        [BoxGroup("Filters/Operations")]
        [ReadOnly]
        public int listObjectsSurvivingFilter;

        [BoxGroup(CenterLabel = false, GroupID = "Set", GroupName = "Set", Order = 2, ShowLabel = false)]
        [ListDrawerSettings(HideAddButton = true, DraggableItems = false)]
        [OnValueChanged(nameof(CalculateExample), IncludeChildren = true)]
        [AssetsOnly]
        public List<Object> objectsToRename = new();

        [InlineProperty]
        [BoxGroup("Operations")]
        [ListDrawerSettings(Expanded = true, AddCopiesLastElement = true)]
        [OnValueChanged(nameof(CalculateExample), IncludeChildren = true)]
        public List<StringOperationMetadata> operations =
            new() {new StringOperationMetadata(StringOperation.RemoveString)};

        [ReadOnly]
        [BoxGroup("Operations")]
        [SmartLabel]
        public string exampleInput;

        [ReadOnly]
        [BoxGroup("Operations")]
        [SmartLabel]
        public string exampleOutput;

        [BoxGroup("Filters/Query")]
        [SmartLabel]
        [OnValueChanged(nameof(CalculateQueryExample))]
        public string query;

        [ReadOnly]
        [BoxGroup("Filters/Query")]
        [ShowInInspector]
        [NonSerialized]
        [SmartLabel]
        public string queryExample = "N/A";

        [BoxGroup("Filters/Type")]
        [SmartLabel]
        [ValueDropdown(nameof(FilterTypes))]
        public Type type;

        private float currentOperationCount;

        private float maxNumberOfOperations;

        private ValueDropdownList<Type> _filterTypes;

        private bool _canFilterType => type != default;

        private bool _canQuery => !string.IsNullOrWhiteSpace(query) && !query.EndsWith(":");

        private bool CanApplyFilter => listObjectsSurvivingFilter > 0;

        private bool CanApplyNamingOperations =>
            (objectsToRename != null) &&
            (objectsToRename.Count > 0) &&
            (operations != null) &&
            (operations.Count > 0);

        private ValueDropdownList<Type> FilterTypes
        {
            get
            {
                if (_filterTypes == null)
                {
                    _filterTypes = new ValueDropdownList<Type>();
                }

                if (_filterTypes.Count == 0)
                {
                    var inheritors = typeof(Object).GetAllInheritors();

                    for (var i = 0; i < inheritors.Count; i++)
                    {
                        var inheritor = inheritors[i];

                        _filterTypes.Add(inheritor.GetReadableName(), inheritor);
                    }
                }

                return _filterTypes;
            }
        }

        [ButtonGroup("Filters/Query/Buttons")]
        [EnableIf(nameof(_canQuery))]
        public void AddQueryResults()
        {
            var assets = AssetDatabaseManager.FindAssets<Object>(query);
            var hash = assets.ToHashSet();
            hash.AddRange2(objectsToRename);
            objectsToRename = hash.ToList();
        }

        [ButtonGroup("Filters/Selection/Basic")]
        public void AddSelected()
        {
            var assets = Selection.GetFiltered<Object>(SelectionMode.Assets).Where(a => !(a is DefaultAsset));
            var hash = assets.ToHashSet();
            hash.AddRange(objectsToRename);
            objectsToRename = hash.ToList();
        }

        [ButtonGroup("Filters/Selection/Deep")]
        public void AddSelectedDeep()
        {
            var assets = Selection.GetFiltered<Object>(SelectionMode.DeepAssets)
                                  .Where(a => !(a is DefaultAsset));
            var hash = assets.ToHashSet();
            hash.AddRange2(objectsToRename);
            objectsToRename = hash.ToList();
        }

        [ButtonGroup("Filters/Type/Buttons")]
        [EnableIf(nameof(_canFilterType))]
        public void AddType()
        {
            var assets = AssetDatabaseManager.FindAssets(type).ToHashSet();
            assets.AddRange(objectsToRename);
            objectsToRename = assets.Distinct().ToList();
        }

        [BoxGroup("Filters/Operations")]
        [EnableIf(nameof(CanApplyFilter))]
        [Button]
        public void ApplyListFilter()
        {
            for (var i = objectsToRename.Count - 1; i >= 0; i--)
            {
                if (DoesFailFilter(i))
                {
                    objectsToRename.RemoveAt(i);
                }
            }
        }

        [EnableIf(nameof(CanApplyNamingOperations))]
        [BoxGroup("Operations")]
        [Button]
        public void ApplyNamingOperations()
        {
            try
            {
                using (new AssetEditingScope())
                {
                    currentOperationCount = 0f;
                    maxNumberOfOperations = objectsToRename.Count;

                    foreach (var obj in objectsToRename)
                    {
                        var assetPath = AssetDatabase.GetAssetPath(obj);

                        var originalFileName = Path.GetFileName(assetPath);
                        var originalAssetName = obj.name;

                        var newFileName = originalFileName;
                        var newAssetName = originalAssetName;

                        switch (operationTarget)
                        {
                            case ApplicationTarget.BothFileAndAssetName:
                                newFileName = ApplyStringOperations(newFileName,   operations);
                                newAssetName = ApplyStringOperations(newAssetName, operations);
                                break;
                            case ApplicationTarget.FileNameOnly:
                                newFileName = ApplyStringOperations(newFileName, operations);
                                break;
                            case ApplicationTarget.AssetNameOnly:
                                newAssetName = ApplyStringOperations(newAssetName, operations);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        UpdateProgressBar(1f, "Renaming Assets", obj.name);

                        if ((originalFileName == newFileName) && (originalAssetName == newAssetName))
                        {
                            continue;
                        }

                        if (originalAssetName != newAssetName)
                        {
                            obj.name = newAssetName;
                        }

                        if (originalFileName != newFileName)
                        {
                            AssetDatabase.RenameAsset(assetPath, newFileName);
                        }
                    }
                }
            }
            finally
            {
                HideProgressBar();
            }
        }

        [ButtonGroup("Setup", Order = 1)]
        public void CleanupObjectList()
        {
            for (var i = objectsToRename.Count - 1; i >= 0; i--)
            {
                if (objectsToRename[i] == null)
                {
                    objectsToRename.RemoveAt(i);
                }
            }

            objectsToRename = objectsToRename.Distinct().ToList();
        }

        [ButtonGroup("Filters/Query/Buttons")]
        [EnableIf(nameof(_canQuery))]
        public void ExactQueryResults()
        {
            var assets = AssetDatabaseManager.FindAssets<Object>(query);
            objectsToRename.Clear();
            objectsToRename.AddRange(assets);
        }

        [FoldoutGroup("Filters")]
        [BoxGroup("Filters/Selection")]
        [ButtonGroup("Filters/Selection/Basic")]
        public void ExactSelected()
        {
            var assets = Selection.GetFiltered<Object>(SelectionMode.Assets).Where(a => !(a is DefaultAsset));
            objectsToRename.Clear();
            objectsToRename.AddRange(assets);
        }

        [ButtonGroup("Filters/Selection/Deep")]
        public void ExactSelecteDeep()
        {
            var assets = Selection.GetFiltered<Object>(SelectionMode.DeepAssets)
                                  .Where(a => !(a is DefaultAsset));
            objectsToRename.Clear();
            objectsToRename.AddRange(assets);
        }

        [ButtonGroup("Filters/Type/Buttons")]
        [EnableIf(nameof(_canFilterType))]
        public void MatchingType()
        {
            var assets = AssetDatabaseManager.FindAssets(type);
            objectsToRename.Clear();
            objectsToRename.AddRange(assets);
        }

        [ButtonGroup("Setup2", Order = 1)]
        public void OnlyAssetFileNameMismatches()
        {
            for (var i = objectsToRename.Count - 1; i >= 0; i--)
            {
                var path = AssetDatabase.GetAssetPath(objectsToRename[i]);
                var filename = Path.GetFileNameWithoutExtension(path);

                if (filename == path)
                {
                    objectsToRename.RemoveAt(i);
                }
            }
        }

        [ButtonGroup("Filters/Query/Buttons")]
        [EnableIf(nameof(_canQuery))]
        public void RemoveAllButQueryResults()
        {
            var assets = AssetDatabaseManager.FindAssets<Object>(query).ToHashSet();
            objectsToRename = objectsToRename.Where(o => assets.Contains(o)).ToList();
        }

        [ButtonGroup("Filters/Selection/Basic")]
        public void RemoveAllButSelected()
        {
            var assets = Selection.GetFiltered<Object>(SelectionMode.Assets)
                                  .Where(a => !(a is DefaultAsset))
                                  .ToHashSet();
            objectsToRename = objectsToRename.Where(o => assets.Contains(o)).ToList();
        }

        [ButtonGroup("Filters/Selection/Deep")]
        public void RemoveAllButSelectedDeep()
        {
            var assets = Selection.GetFiltered<Object>(SelectionMode.DeepAssets)
                                  .Where(a => !(a is DefaultAsset))
                                  .ToHashSet();
            objectsToRename = objectsToRename.Where(o => assets.Contains(o)).ToList();
        }

        [ButtonGroup("Filters/Type/Buttons")]
        [EnableIf(nameof(_canFilterType))]
        public void RemoveAllButType()
        {
            var assets = AssetDatabaseManager.FindAssets(type).ToHashSet();
            objectsToRename = objectsToRename.Where(o => assets.Contains(o)).ToList();
        }

        [ButtonGroup("Setup2", Order = 1)]
        public void RemoveAssetFileNameMismatches()
        {
            for (var i = objectsToRename.Count - 1; i >= 0; i--)
            {
                var path = AssetDatabase.GetAssetPath(objectsToRename[i]);
                var filename = Path.GetFileNameWithoutExtension(path);

                if (filename != path)
                {
                    objectsToRename.RemoveAt(i);
                }
            }
        }

        [ButtonGroup("Setup2", Order = 1)]
        public void RemoveFolders()
        {
            for (var i = objectsToRename.Count - 1; i >= 0; i--)
            {
                if (objectsToRename[i] is DefaultAsset)
                {
                    objectsToRename.RemoveAt(i);
                }
            }
        }

        [ButtonGroup("Filters/Query/Buttons")]
        [EnableIf(nameof(_canQuery))]
        public void RemoveQueryResults()
        {
            var assets = AssetDatabaseManager.FindAssets<Object>(query).ToHashSet();
            objectsToRename = objectsToRename.Where(o => !assets.Contains(o)).ToList();
        }

        [ButtonGroup("Filters/Selection/Basic")]
        public void RemoveSelected()
        {
            var assets = Selection.GetFiltered<Object>(SelectionMode.Assets)
                                  .Where(a => !(a is DefaultAsset))
                                  .ToHashSet();
            objectsToRename = objectsToRename.Where(o => !assets.Contains(o)).ToList();
        }

        [ButtonGroup("Filters/Selection/Deep")]
        public void RemoveSelectedDeep()
        {
            var assets = Selection.GetFiltered<Object>(SelectionMode.DeepAssets)
                                  .Where(a => !(a is DefaultAsset))
                                  .ToHashSet();
            objectsToRename = objectsToRename.Where(o => !assets.Contains(o)).ToList();
        }

        [ButtonGroup("Filters/Type/Buttons")]
        [EnableIf(nameof(_canFilterType))]
        public void RemoveType()
        {
            var assets = AssetDatabaseManager.FindAssets(type).ToHashSet();
            objectsToRename = objectsToRename.Where(o => !assets.Contains(o)).ToList();
        }

        [ButtonGroup("Setup", Order = 1)]
        public void Reset()
        {
            objectsToRename = new List<Object>();
            operations = new List<StringOperationMetadata>();
            listFilter = new FilterOperationMetadata(FilterOperation.Contains);
            listObjectsSurvivingFilter = 0;
            exampleInput = string.Empty;
            exampleOutput = string.Empty;
        }

        [ButtonGroup("Setup", Order = 1)]
        public void ResetObjectList()
        {
            objectsToRename = new List<Object>();
        }

        private string ApplyStringOperations(string startingValue, List<StringOperationMetadata> ops)
        {
            var resultingValue = startingValue;

            foreach (var operation in ops)
            {
                resultingValue = operation.ApplyOperation(resultingValue);
            }

            return resultingValue;
        }

        private void CalculateExample()
        {
            if ((objectsToRename != null) &&
                (objectsToRename.Count > 0) &&
                (operations != null) &&
                (operations.Count > 0) &&
                (operations[0] != null))
            {
                exampleInput = objectsToRename[0].name;
                exampleOutput = ApplyStringOperations(exampleInput, operations);
            }
        }

        private void CalculateFilterEffectiveness()
        {
            listObjectsSurvivingFilter = 0;

            for (var i = objectsToRename.Count - 1; i >= 0; i--)
            {
                if (!DoesFailFilter(i))
                {
                    listObjectsSurvivingFilter += 1;
                }
            }
        }

        private void CalculateQueryExample()
        {
            if (!_canQuery)
            {
                queryExample = "N/A";
                return;
            }

            var results = AssetDatabase.FindAssets(query);

            if (results.Length == 0)
            {
                queryExample = "N/A";
                return;
            }

            var first = results[0];
            var firstPath = AssetDatabase.GUIDToAssetPath(first);
            queryExample = Path.GetFileName(firstPath);
        }

        private bool DoesFailFilter(int index)
        {
            var objToTest = objectsToRename[index];

            var objectNameMatch = listFilter.ApplyOperation(objToTest.name);
            var filePath = AssetDatabase.GetAssetPath(objToTest);
            var filePathMatch = listFilter.ApplyOperation(objToTest.name);
            var fileName = Path.GetFileName(filePath);
            var fileNameMatch = listFilter.ApplyOperation(fileName);

            bool matched;

            switch (filterTarget)
            {
                case FilterTarget.ObjectName:
                    matched = objectNameMatch;
                    break;
                case FilterTarget.FileName:
                    matched = fileNameMatch;
                    break;
                case FilterTarget.FilePath:
                    matched = filePathMatch;
                    break;
                case FilterTarget.ObjectNameOrFileName:
                    matched = objectNameMatch || fileNameMatch;
                    break;
                case FilterTarget.ObjectNameAndFileName:
                    matched = objectNameMatch && fileNameMatch;
                    break;
                case FilterTarget.ObjectNameOrFilePath:
                    matched = objectNameMatch || filePathMatch;
                    break;
                case FilterTarget.ObjectNameAndFilePath:
                    matched = objectNameMatch && filePathMatch;
                    break;
                case FilterTarget.ObjectNameOrFileNameOrFilePath:
                    matched = objectNameMatch || fileNameMatch || filePathMatch;
                    break;
                case FilterTarget.ObjectNameAndFileNameAndFilePath:
                    matched = objectNameMatch && fileNameMatch && filePathMatch;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (matched)
            {
                if (invertFilter)
                {
                    return true;
                }
            }
            else
            {
                if (!invertFilter)
                {
                    return true;
                }
            }

            return false;
        }

        private void HideProgressBar()
        {
            currentOperationCount = 0;
            maxNumberOfOperations = 0;
            EditorUtility.ClearProgressBar();
        }

        private void UpdateProgressBar(
            float change = 0,
            string header = "Renaming Assets",
            string message = "Processing Asset")
        {
            currentOperationCount += change;
            if (Math.Abs(currentOperationCount - maxNumberOfOperations) > float.Epsilon)
            {
                EditorUtility.DisplayProgressBar(
                    header,
                    message,
                    currentOperationCount / maxNumberOfOperations
                );
            }
            else
            {
                HideProgressBar();
            }
        }

        [MenuItem("Tools/Asset Renamer")]
        private static void OpenWindow()
        {
            var window = GetWindow<AssetRenamer>();

            // Nifty little trick to quickly position the window in the middle of the editor.
            window.position = window.position.AlignCenter(700, 700);
        }
    }
}
