using System.Collections.Generic;
using Appalachia.Editing.Assets.Windows.Organization.Context;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces;
using Unity.Profiling;

namespace Appalachia.Editing.Assets.Windows.Organization.Panes
{
    public class GeneralAssetReviewPane : AppalachiaMenuWindowPane<GeneralAssetReviewContext>,
                                          IAppalachiaTabbedWindowPane,
                                          IAppalachiaTabbedWindowPaneParent
    {
        private const float TAB_HEIGHT = 22F;
        private const string _PRF_PFX = nameof(GeneralAssetReviewPane) + ".";

        private const string PANE_NAME = "General Asset Review";

        private static readonly ProfilerMarker _PRF_OnDrawPaneMenuItem =
            new(_PRF_PFX + nameof(OnDrawPaneMenuItem));

        public int TabIndex { get; set; }
        public string[] TabNames { get; set; }
        public override bool ContentInScrollView => true;

        public override string PaneName => PANE_NAME;

        public int DesiredTabIndex => 1000;

        public string TabName => "General";

        public IReadOnlyList<IAppalachiaWindowPane> ChildPanes =>
            (IReadOnlyList<IAppalachiaWindowPane>) TabPanes;

        public float TabHeight => TAB_HEIGHT;

        public IList<IAppalachiaTabbedWindowPane> TabPanes =>
            ((IAppalachiaWindowPane) this).GetTabPanes(
                PANE_NAME,
                () => new List<IAppalachiaTabbedWindowPane>
                {
                    new MonoScriptReviewPane().SetWindow(window),
                    new ShaderReviewPane().SetWindow(window),
                    new DirectoryCleanupPane().SetWindow(window)
                }
            );

        public override bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex)
        {
            return true;
        }

        public override void OnDrawPaneMenuItem(
            int menuIndex,
            int menuItemIndex,
            bool isSelected,
            out bool wasSelected,
            out float menuItemHeight)
        {
            using (_PRF_OnDrawPaneMenuItem.Auto())
            {
                var field = fieldMetadataManager.Get<MenuItemField>($"PMI_{menuItemIndex}");

                var assetType = context.MenuOneItems[menuItemIndex];

                wasSelected = field.Draw(assetType.ToString(), isSelected, null);
                
                menuItemHeight = field.height;
            }
        }

        public override void OnDrawPaneContent()
        {
        }

        public override void OnInitialize()
        {
        }
    }
}
