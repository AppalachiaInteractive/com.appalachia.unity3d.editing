using System;
using System.Collections.Generic;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public interface IAppalachiaTabbedWindowPane : IAppalachiaWindowPane, IComparable<IAppalachiaTabbedWindowPane>, IComparable
    {
        public int DesiredTabIndex { get; }
        public string TabName { get; }

        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            return obj is IAppalachiaTabbedWindowPane other
                ? CompareTo(other)
                : throw new ArgumentException(
                    $"Object must be of type {nameof(IAppalachiaTabbedWindowPane)}"
                );
        }

        int IComparable<IAppalachiaTabbedWindowPane>.CompareTo(IAppalachiaTabbedWindowPane other)
        {
            return DesiredTabIndex.CompareTo(other.DesiredTabIndex);
        }

        public static bool operator >(IAppalachiaTabbedWindowPane left, IAppalachiaTabbedWindowPane right)
        {
            return Comparer<IAppalachiaTabbedWindowPane>.Default.Compare(left, right) > 0;
        }

        public static bool operator >=(IAppalachiaTabbedWindowPane left, IAppalachiaTabbedWindowPane right)
        {
            return Comparer<IAppalachiaTabbedWindowPane>.Default.Compare(left, right) >= 0;
        }

        public static bool operator <(IAppalachiaTabbedWindowPane left, IAppalachiaTabbedWindowPane right)
        {
            return Comparer<IAppalachiaTabbedWindowPane>.Default.Compare(left, right) < 0;
        }

        public static bool operator <=(IAppalachiaTabbedWindowPane left, IAppalachiaTabbedWindowPane right)
        {
            return Comparer<IAppalachiaTabbedWindowPane>.Default.Compare(left, right) <= 0;
        }
    }
}
