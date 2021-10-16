using System.Collections.Generic;

namespace Appalachia.Editing.Core.Windows.PaneBased.Context
{
    public interface IAppalachiaTwoMenuWindowPaneContext<T1, T2> : IAppalachiaOneMenuWindowPaneContext<T1>
    {
        public IList<T2> MenuTwoItems { get; }

        public new int RequiredMenuCount => 2;

        public IEnumerable<T2> VisibleMenuTwoItems => GetVisibleItems(1, MenuTwoItems);
    }
}
