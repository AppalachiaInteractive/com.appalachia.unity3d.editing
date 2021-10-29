using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.CI.Integration.Assets;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Core.Extensions;
using Appalachia.Editing.Assets;
using Appalachia.Editing.Core;
using Appalachia.Editing.Core.Windows;
using Appalachia.Utility.Colors;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Labels
{
    public class LabelCleaner : AppalachiaEditorWindow
    {
        private static LabelCleaner _instance;

        [UnityEditor.MenuItem(PKG.Menu.Appalachia.Tools.Base + "Labels/Label Manager Window", priority = -10)]
        private static void OpenWindow()
        {
            _instance = GetWindow<LabelCleaner>();

            // Nifty little trick to quickly position the window in the middle of the editor.
            _instance.position = _instance.position.AlignCenter(700, 700);
        }

        [DidReloadScripts]
        private static void RebuildListCodeReload()
        {
            if (_instance != null)
            {
                _instance.BuildLabelList();
            }
        }

#region Cleaning

        [TabGroup("Cleaning")]
        [Button]
        [PropertyOrder(-100)]
        public void BuildLabelList()
        {
            LabelManager.InitializeLabels();
            labelDatas = LabelManager.labelDatas;
        }

        [TabGroup("Cleaning")]
        [ListDrawerSettings(
            Expanded = true,
            NumberOfItemsPerPage = 10,
            HideAddButton = true,
            HideRemoveButton = true
        )]
        [PropertyOrder(-99)]
        public List<LabelData> labelDatas;

        private bool _canApply =>
            ((LabelManager.labelDatas?.Count ?? 0) > 0) && (!_showQuery || (queryResults.Length > 0));

        [TabGroup("Cleaning")]
        [PropertyOrder(-90)]
        [SmartLabel]
        public LabelApplicationMode applicationMode;

        private bool _showQuery =>
            (applicationMode == LabelApplicationMode.QueryOnly) ||
            (applicationMode == LabelApplicationMode.AllButQuery);

        [TabGroup("Cleaning")]
        [PropertyOrder(-89)]
        [ShowIf(nameof(_showQuery))]
        [SmartLabel]
        [OnValueChanged(nameof(TestQuery))]
        public string query;

        private void TestQuery()
        {
            var hits = AssetDatabase.FindAssets(query);

            queryResults = hits
                          .Select(
                               h => AssetDatabase.LoadAssetAtPath<Object>(AssetDatabase.GUIDToAssetPath(h))
                           )
                          .ToArray();
        }

        [ShowIf(nameof(_showQuery))]
        [ReadOnly]
        [ListDrawerSettings(NumberOfItemsPerPage = 8, DraggableItems = false, HideAddButton = true)]
        [PropertyOrder(0)]
        public Object[] queryResults;

        private Color buttonColor => _canApply ? Colors.ForestGreen : Colors.CadmiumYellow;

        [TabGroup("Cleaning")]
        [GUIColor(nameof(buttonColor))]
        [PropertyOrder(-80)]
        [Button]
        [EnableIf(nameof(_canApply))]
        public void ApplyLabelChanges()
        {
            IEnumerable<Object> objects;
            int count;

            switch (applicationMode)
            {
                case LabelApplicationMode.All:
                {
                    var assetPaths = AssetDatabase.GetAllAssetPaths()
                                                  .Where(
                                                       ap => AssetDatabase.GetMainAssetTypeAtPath(ap) ==
                                                             typeof(GameObject)
                                                   )
                                                  .ToArray();
                    objects = assetPaths.Select(AssetDatabase.LoadAssetAtPath<Object>);
                    count = assetPaths.Length;
                }
                    break;
                case LabelApplicationMode.Selected:
                {
                    var filtered = Selection.GetFiltered<GameObject>(SelectionMode.Assets);
                    objects = filtered;
                    count = filtered.Length;
                }
                    break;
                case LabelApplicationMode.AllButSelected:
                {
                    var filtered = Selection.GetFiltered<GameObject>(SelectionMode.Assets);

                    var assetPaths = AssetDatabase.GetAllAssetPaths()
                                                  .Where(
                                                       ap => AssetDatabase.GetMainAssetTypeAtPath(ap) ==
                                                             typeof(GameObject)
                                                   )
                                                  .ToArray();

                    objects = assetPaths.Select(AssetDatabase.LoadAssetAtPath<Object>).Except(filtered);

                    count = assetPaths.Length - filtered.Length;
                }
                    break;
                case LabelApplicationMode.AllButQuery:
                {
                    var assetPaths = AssetDatabase.GetAllAssetPaths()
                                                  .Where(
                                                       ap => AssetDatabase.GetMainAssetTypeAtPath(ap) ==
                                                             typeof(GameObject)
                                                   )
                                                  .ToArray();

                    objects = assetPaths.Select(AssetDatabase.LoadAssetAtPath<Object>).Except(queryResults);

                    count = assetPaths.Length - queryResults.Length;
                }
                    break;
                case LabelApplicationMode.QueryOnly:
                {
                    objects = queryResults;
                    count = queryResults.Length;
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ApplyLabelChanges(objects, count);
        }

        private void ApplyLabelChanges(IEnumerable<Object> assets, int count)
        {
            using (new AssetEditingScope())
            {
                var effectiveLabels = LabelManager.labelDatas.Where(
                                                       ld => ld.applyLabel ||
                                                             ld.deleteLabel ||
                                                             !string.IsNullOrWhiteSpace(ld.switchTo)
                                                   )
                                                  .ToArray();

                using (var progress = new EditorOnlyProgressBar("Applying label changes...", count, false))
                {
                    foreach (var asset in assets)
                    {
                        progress.Increment1AndShowProgressBasic();

                        var labelSet = AssetDatabase.GetLabels(asset).ToList();
                        var applyChanges = false;

                        for (var index = labelSet.Count - 1; index >= 0; index--)
                        {
                            var label = labelSet[index];

                            foreach (var effectiveLabel in effectiveLabels)
                            {
                                if (label != effectiveLabel.label)
                                {
                                    continue;
                                }

                                if (effectiveLabel.deleteLabel)
                                {
                                    labelSet.RemoveAt(index);
                                    applyChanges = true;
                                }

                                else if (!string.IsNullOrWhiteSpace(effectiveLabel.switchTo))
                                {
                                    labelSet[index] = effectiveLabel.switchTo.Trim();
                                    applyChanges = true;
                                }
                            }
                        }

                        if (applyChanges)
                        {
                            AssetDatabase.SetLabels(asset, labelSet.ToArray());
                        }
                    }
                }
            }

            BuildLabelList();
        }

#endregion
    }
}
