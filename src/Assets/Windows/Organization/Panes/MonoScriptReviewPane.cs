using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Appalachia.Utility.Reflection.Extensions;
using Unity.Profiling;

namespace Appalachia.Editing.Assets.Windows.Organization.Panes
{
    public class MonoScriptReviewPane : AppalachiaMenuWindowPane<MonoScriptReviewContext>,
                                        IAppalachiaTabbedWindowPane
                                        
    {
        private const string _PRF_PFX = nameof(MonoScriptReviewPane) + ".";
        private const string _TRACE_PFX = nameof(MonoScriptReviewPane) + ".";

        private static readonly ProfilerMarker _PRF_ShouldDrawMenuItem =
            new(_PRF_PFX + nameof(ShouldDrawMenuItem));

        private static readonly ProfilerMarker _PRF_OnDrawPaneMenuItem =
            new(_PRF_PFX + nameof(OnDrawPaneMenuItem));

        private static readonly ProfilerMarker _PRF_OnInitialize = new(_PRF_PFX + nameof(OnInitialize));

        private static readonly ProfilerMarker _PRF_OnDrawPaneContent =
            new(_PRF_PFX + nameof(OnDrawPaneContent));

        private static readonly TraceMarker _TRACE_OnDrawPaneContent =
            new(_TRACE_PFX + nameof(OnDrawPaneContent));

        private static readonly TraceMarker _TRACE_OnInitialize = new(_TRACE_PFX + nameof(OnInitialize));

        private static readonly TraceMarker _TRACE_OnDrawPaneMenuItem =
            new(_TRACE_PFX + nameof(OnDrawPaneMenuItem));

        private static readonly TraceMarker _TRACE_ShouldDrawMenuItem =
            new(_TRACE_PFX + nameof(ShouldDrawMenuItem));

        private MonoScriptReviewContext _context;

        private PREF<bool> onlyIssues;

        public override bool ContentInScrollView => true;

        public override string PaneName => TabName;

        public int DesiredTabIndex => 10;

        public string TabName => "MonoScripts";

        public override void OnDrawPaneMenuItem(int menuIndex, int menuItemIndex, out bool isSelected)
        {
            using (_TRACE_OnDrawPaneMenuItem.Auto())
            using (_PRF_OnDrawPaneMenuItem.Auto())
            {
                var item = context.MenuOneItems[menuItemIndex];

                var itemName = item.monoScriptType.GetReadableName();
                var field = fieldMetadataManager.Get<MenuItemField>(itemName);

                isSelected = field.Draw(itemName);
            }
        }

        public override bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex)
        {
            using (_TRACE_ShouldDrawMenuItem.Auto())
            using (_PRF_ShouldDrawMenuItem.Auto())
            {
                var item = context.MenuOneItems[menuItemIndex];

                if (onlyIssues.v)
                {
                    return !item.canBeLoaded;
                }

                return true;
            }
        }

        public override void OnDrawPaneContent()
        {
            using (_TRACE_OnDrawPaneContent.Auto())
            using (_PRF_OnDrawPaneContent.Auto())
            {
                var selectedIndex = context.GetMenuSelection(0).currentIndex;

                var item = context.MenuOneItems[selectedIndex];

                var label = fieldMetadataManager.Get<LabelMetadata>(item.monoScriptType.GetReadableName());

                label.Draw();
            }
        }

        public override void OnInitialize()
        {
            using (_TRACE_OnInitialize.Auto())
            using (_PRF_OnInitialize.Auto())
            {
                ((IAppalachiaWindowPane) this).RegisterFilterPref(
                    ref onlyIssues,
                    "Asset Review",
                    "Only MonoScript Issues",
                    true
                );
            }
        }
    }
}
