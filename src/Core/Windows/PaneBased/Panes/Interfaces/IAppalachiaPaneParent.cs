using System.Collections.Generic;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public interface IAppalachiaPaneParent : IAppalachiaWindowPane
    {
        public IReadOnlyList<IAppalachiaWindowPane> ChildPanes { get; }
    }
}
