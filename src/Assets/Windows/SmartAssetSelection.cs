using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Extensions;
using Appalachia.Editing.Core.Operations;
using Appalachia.Editing.Core.Windows;
using Appalachia.Utility.Extensions;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows
{
    public class SmartAssetSelection : AppalachiaEditorWindow
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
        [OnValueChanged(nameof(UpdateSelection), IncludeChildren = true)]
        [AssetsOnly]
        public List<Object> selections = new();

        private bool CanApplyFilter => filterList && (listObjectsPassingFilter > 0);

        [BoxGroup(CenterLabel = false, GroupID = "Set", GroupName = "Set", Order = 2, ShowLabel = false)]
        [ShowIf(nameof(filterList))]
        [EnableIf(nameof(CanApplyFilter))]
        [Button]
        public void ApplyListFilter()
        {
            for (var i = selections.Count - 1; i >= 0; i--)
            {
                if (listFilter.ApplyOperation(selections[i].name))
                {
                    if (invertFilter)
                    {
                        selections.RemoveAt(i);
                    }
                }
                else
                {
                    if (!invertFilter)
                    {
                        selections.RemoveAt(i);
                    }
                }
            }
        }

        [ButtonGroup(GroupID = "Setup", GroupName = "Setup", Order = 1)]
        public void CleanupObjectList()
        {
            for (var i = selections.Count - 1; i >= 0; i--)
            {
                if (selections[i] == null)
                {
                    selections.RemoveAt(i);
                }
            }

            selections = selections.Distinct().ToList();
        }

        [ButtonGroup(GroupID = "Setup", GroupName = "Setup", Order = 1)]
        [Button]
        public void Reset()
        {
            selections = new List<Object>();
            filterList = false;
            listFilter = new FilterOperationMetadata(FilterOperation.Contains);
            listObjectsPassingFilter = 0;
        }

        [ButtonGroup(GroupID = "Setup", GroupName = "Setup", Order = 1)]
        [Button]
        public void ResetObjectList()
        {
            selections = new List<Object>();
        }

        private void CalculateFilterEffectiveness()
        {
            listObjectsPassingFilter = 0;

            if (!filterList)
            {
                return;
            }

            for (var i = selections.Count - 1; i >= 0; i--)
            {
                if (listFilter.ApplyOperation(selections[i].name))
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

        [Button(ButtonSizes.Large)]
        [PropertyOrder(500)]
        private void UpdateSelection()
        {
            Selection.objects = selections.ToArray();
        }

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Smart Asset Selection")]
        private static void OpenWindow()
        {
            var window = GetWindow<SmartAssetSelection>();

            // Nifty little trick to quickly position the window in the middle of the editor.
            window.position = window.position.AlignCenter(700, 700);
        }
    }
}
