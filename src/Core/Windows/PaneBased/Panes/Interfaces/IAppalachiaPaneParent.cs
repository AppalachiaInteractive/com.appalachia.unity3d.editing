using System.Collections.Generic;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces
{
    public interface IAppalachiaPaneParent : IAppalachiaWindowPane
    {
        public IReadOnlyList<IAppalachiaWindowPane> ChildPanes { get; }
    }
}
