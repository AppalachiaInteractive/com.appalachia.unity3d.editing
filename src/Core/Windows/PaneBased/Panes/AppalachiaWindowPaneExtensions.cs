namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public static class AppalachiaWindowPaneExtensions
    {
        public static T SetWindow<T>(this T pane, IAppalachiaWindow window)
            where T : AppalachiaWindowPane
        {
            pane.SetWindowInternal(window);

            return pane;
        }
    }
}
