using System.Collections.Generic;

namespace Appalachia.Editing.Core.Windows.PaneBased.Context
{
    public interface IAppalachiaOneMenuWindowPaneContext<T1> : IAppalachiaMenuWindowPaneContext
    {
        public IList<T1> MenuOneItems { get; }

        public new int RequiredMenuCount => 1;

        public IEnumerable<T1> VisibleMenuOneItems => GetVisibleItems(0, MenuOneItems);

        protected IEnumerable<TL> GetVisibleItems<TL>(int menuIndex, IList<TL> items)
        {
            var menuSelection = GetMenuSelection(menuIndex);

            for (var menuItemIndex = 0; menuItemIndex < items.Count; menuItemIndex++)
            {
                var visible = menuSelection.IsVisible(menuItemIndex);

                if (!visible)
                {
                    continue;
                }

                var menuItem = items[menuItemIndex];

                yield return menuItem;
            }
        }
    }
}
