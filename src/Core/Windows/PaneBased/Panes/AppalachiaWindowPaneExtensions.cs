namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public static class AppalachiaWindowPaneExtensions
    {
        public static T SetWindow<T>(this T pane, AppalachiaPaneBasedWindowBase window)
            where T : AppalachiaWindowPane, new()
        {
            pane.window = window;
            return pane;
        }
    }
}
