using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Extensions;
using Appalachia.Editing.Core.Operations;
using Appalachia.Editing.Core.Windows;
using Appalachia.Utility.Extensions;
using Sirenix.OdinInspector;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Assets.Windows
{
    public class GameObjectRenamer : AppalachiaEditorWindow
    {
        [BoxGroup(CenterLabel = false, GroupID = "Set", GroupName = "Set", Order = 2, ShowLabel = false)]
        [OnValueChanged(nameof(CalculateFilterEffectiveness), true)]
        public bool filterList;

        [BoxGroup(CenterLabel = false, GroupID = "Set", GroupName = "Set", Order = 2, ShowLabel = false)]
        [ShowIf(nameof(filterList))]
        [OnValueChanged(nameof(CalculateFilterEffectiveness), true)]
        public bool invertFilter;

        [BoxGroup(CenterLabel = false, GroupID = "Set", GroupName = "Set", Order = 2, ShowLabel = false)]
        [ShowIf(nameof(filterList))]
        [OnValueChanged(nameof(CalculateFilterEffectiveness), true)]
        [InlineProperty]
        public FilterOperationMetadata listFilter = new(FilterOperation.Contains);

        [BoxGroup(CenterLabel = false, GroupID = "Set", GroupName = "Set", Order = 2, ShowLabel = false)]
        [ShowIf(nameof(filterList))]
        [ReadOnly]
        public int listObjectsPassingFilter;

        [BoxGroup(CenterLabel = false, GroupID = "Set", GroupName = "Set", Order = 2, ShowLabel = false)]
        [ListDrawerSettings(HideAddButton = true, DraggableItems = false)]
        [OnValueChanged(nameof(CalculateExample), IncludeChildren = true)]
        [SceneObjectsOnly]
        public List<Object> objectsToRename = new();

        [InlineProperty]
        [BoxGroup(
            CenterLabel = true,
            GroupID = "Operations",
            GroupName = "Operations",
            Order = 3,
            ShowLabel = true
        )]
        [ListDrawerSettings(Expanded = true, AddCopiesLastElement = true)]
        [OnValueChanged(nameof(CalculateExample), IncludeChildren = true)]
        public List<StringOperationMetadata> operations =
            new() {new StringOperationMetadata(StringOperation.RemoveString)};

        [ReadOnly]
        [BoxGroup(
            CenterLabel = true,
            GroupID = "Operations",
            GroupName = "Operations",
            Order = 3,
            ShowLabel = true
        )]
        public string exampleInput;

        [ReadOnly]
        [BoxGroup(
            CenterLabel = true,
            GroupID = "Operations",
            GroupName = "Operations",
            Order = 3,
            ShowLabel = true
        )]
        public string exampleOutput;

        private float currentOperationCount;

        private float maxNumberOfOperations;

        private bool CanApplyFilter => filterList && (listObjectsPassingFilter > 0);

        private bool CanApplyNamingOperations =>
            (objectsToRename != null) &&
            (objectsToRename.Count > 0) &&
            (operations != null) &&
            (operations.Count > 0);

        [BoxGroup(CenterLabel = false, GroupID = "Set", GroupName = "Set", Order = 2, ShowLabel = false)]
        [ShowIf(nameof(filterList))]
        [EnableIf(nameof(CanApplyFilter))]
        [Button]
        public void ApplyListFilter()
        {
            for (var i = objectsToRename.Count - 1; i >= 0; i--)
            {
                if (listFilter.ApplyOperation(objectsToRename[i].name))
                {
                    if (invertFilter)
                    {
                        objectsToRename.RemoveAt(i);
                    }
                }
                else
                {
                    if (!invertFilter)
                    {
                        objectsToRename.RemoveAt(i);
                    }
                }
            }
        }

        [Button]
        [BoxGroup(
            CenterLabel = true,
            GroupID = "Operations",
            GroupName = "Operations",
            Order = 3,
            ShowLabel = true
        )]
        [EnableIf(nameof(CanApplyNamingOperations))]
        public void ApplyNamingOperations()
        {
            try
            {
                currentOperationCount = 0f;
                maxNumberOfOperations = objectsToRename.Count;

                foreach (var obj in objectsToRename)
                {
                    obj.name = ApplyStringOperations(obj.name, operations);

                    UpdateProgressBar(1f, "Renaming Assets", obj.name);
                }
            }
            finally
            {
                HideProgressBar();
            }
        }

        [ButtonGroup(GroupID = "Setup", GroupName = "Setup", Order = 1)]
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

        [ButtonGroup(GroupID = "Setup", GroupName = "Setup", Order = 1)]
        [Button]
        public void Reset()
        {
            objectsToRename = new List<Object>();
            operations = new List<StringOperationMetadata>();
            filterList = false;
            listFilter = new FilterOperationMetadata(FilterOperation.Contains);
            listObjectsPassingFilter = 0;
            exampleInput = string.Empty;
            exampleOutput = string.Empty;
        }

        [ButtonGroup(GroupID = "Setup", GroupName = "Setup", Order = 1)]
        [Button]
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
            listObjectsPassingFilter = 0;

            if (!filterList)
            {
                return;
            }

            for (var i = objectsToRename.Count - 1; i >= 0; i--)
            {
                if (listFilter.ApplyOperation(objectsToRename[i].name))
                {
                    if (!invertFilter)
                    {
                        listObjectsPassingFilter += 1;
                    }
                }
                else
                {
                    if (invertFilter)
                    {
                        listObjectsPassingFilter += 1;
                    }
                }
            }
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

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Game Object Renamer")]
        private static void OpenWindow()
        {
            var window = GetWindow<GameObjectRenamer>();

            // Nifty little trick to quickly position the window in the middle of the editor.
            window.position = window.position.AlignCenter(700, 700);
        }
    }
}
