using System.Collections.Generic;
using Appalachia.Core.Comparisons;
using Appalachia.Core.Preferences;
using Appalachia.Core.Scriptables;
using Appalachia.Editing.Core;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace Appalachia.Editing.Drawers
{
#if UNITY_EDITOR

    public abstract class MetadataLookupSelectionBaseDrawer<T, TCollection, TValue> : AppalachiaEditor<T>
        where T : MetadataLookupSelection<T, TCollection, TValue>
        where TCollection : MetadataLookupBase<TCollection, TValue>
        where TValue : AppalachiaScriptableObject<TValue>, ICategorizable
    {
        private static PREF<int> _itemsPerRow;
        protected Dictionary<string, GUITabPage> _tabs;
        protected Dictionary<string, List<TValue>> _tabItems;
        protected GUITabGroup _tabGroup;
        protected List<string> _categories;

        [Button]
        public void Reset()
        {
            _tabGroup = null;
            _tabs = null;
            _tabItems = null;
            _categories = null;
        }

        public override void OnInspectorGUI()
        {
            EnsureInitialized();

            _tabGroup.BeginGroup();

            var originalColor = GUI.color;

            for (var categoryID = 0; categoryID < _categories.Count; categoryID++)
            {
                var category = _categories[categoryID];

                var tab = _tabs[category];

                var tabItems = _tabItems[category];

                if (tab.BeginPage())
                {
                    var tabRows = 0;

                    var open = false;

                    for (var itemIndex = 0; itemIndex < tabItems.Count; itemIndex++)
                    {
                        var item = tabItems[itemIndex];

                        if (itemIndex == 0)
                        {
                            GUILayout.BeginHorizontal();
                            open = true;
                            tabRows += 1;
                        }
                        else if ((itemIndex > 0) && ((itemIndex % _itemsPerRow.v) == 0))
                        {
                            GUILayout.EndHorizontal();
                            GUILayout.BeginHorizontal();
                            open = true;
                            tabRows += 1;
                        }

                        GUI.color = Target.GetButtonRowColor(
                            tabRows,
                            Target.ButtonColorDrop.v,
                            Target.ButtonColor.v
                        );

                        if ((item.NiceName != category) && item.NiceName.StartsWith(category))
                        {
                            item.NiceName = item.NiceName.Substring(category.Length);
                        }

                        if (GUILayout.Button(item.NiceName, SirenixGUIStyles.Button))
                        {
                            Target.Selection(item);
                        }
                    }

                    if (open)
                    {
                        GUILayout.EndHorizontal();
                    }
                }

                tab.EndPage();
            }

            _tabGroup.EndGroup();

            GUI.color = originalColor;
        }

        private void EnsureInitialized()
        {
            if (_itemsPerRow == null)
            {
                _itemsPerRow = PREFS.REG("Appalachia/Collection Buttons", "Items Per Row", 4, 1, 25);
            }

            if (_tabGroup == null)
            {
                _tabGroup = new GUITabGroup();
            }

            if (_tabs == null)
            {
                _tabs = new Dictionary<string, GUITabPage>();
            }

            if (_tabItems == null)
            {
                _tabItems = new Dictionary<string, List<TValue>>();
            }

            if (_categories == null)
            {
                _categories = new List<string>();

                var items = Target.Instance.all;

                for (var i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    var category = item.Category;

                    if (string.IsNullOrWhiteSpace(category))
                    {
                        category = "Uncategorized";
                    }

                    if (category.StartsWith("_"))
                    {
                        continue;
                    }

                    if (!_tabs.ContainsKey(category))
                    {
                        _tabs.Add(category, _tabGroup.RegisterTab(category));

                        _categories.Add(category);

                        _tabItems.Add(category, new List<TValue>());
                    }

                    _tabItems[category].Add(item);
                }

                _categories.Sort();

                for (var i = 0; i < _categories.Count; i++)
                {
                    var tabItems = _tabItems[_categories[i]];

                    tabItems.Sort(ObjectComparer<TValue>.Instance);
                }
            }
        }
    }
#endif
}
