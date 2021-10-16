using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Context
{
    public interface IAppalachiaMenuWindowPaneContext
    {
        public int RequiredMenuCount { get; }

        public AppalachiaWindowPaneMenuSelectionMetadata GetMenuSelection(int menuIndex);

        public int GetActiveMenuIndex(Vector2 mousePosition)
        {
            for (var menuIndex = 0; menuIndex < RequiredMenuCount; menuIndex++)
            {
                var menuRect = GetMenuSelection(menuIndex).position;

                if (menuRect.Contains(mousePosition))
                {
                    return menuIndex;
                }
            }

            return 0;
        }
    }
}
