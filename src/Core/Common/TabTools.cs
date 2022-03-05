using System.Collections.Generic;

namespace Appalachia.Editing.Core.Common
{
    public static class TabTools
    {
        #region Constants and Static Readonly

        public const string DELIM = "|";

        #endregion

        #region Static Fields and Autoproperties

        private static Dictionary<string, string[]> _tabLookup;

        #endregion

        public static int GetIndex(this string[] tabs, string tabName)
        {
            for (var index = 0; index < tabs.Length; index++)
            {
                var tab = tabs[index];
                if (tabName == tab)
                {
                    return index;
                }
            }

            return 0;
        }

        public static string GetName(this string[] tabs, int index)
        {
            return tabs[index];
        }

        public static string[] GetTabs(this string tabString, string delimiter = DELIM)
        {
            if (_tabLookup == null)
            {
                _tabLookup = new Dictionary<string, string[]>();
            }

            if (_tabLookup.TryGetValue(tabString, out var result)) return result;

            var splits = tabString.Split(delimiter);

            _tabLookup.Add(tabString, splits);

            return splits;
        }

        public static bool IsSelected(this string[] tabs, int index, string name)
        {
            return tabs[index] == name;
        }
    }
}
