using System.Collections.Generic;
using Appalachia.Editing.Assets.Windows.Organization.Panes;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces;
using UnityEngine;

namespace Appalachia.Editing.Assets.Windows.Organization
{
    public class AssetDatabaseOrganizerPane : AppalachiaWindowPane, IAppalachiaSelectionGridTabWindowParent
    {
        public const string PANE_NAME = "Asset Database Organizer";
        private const float TAB_HEIGHT = 28f;
        private const string _PRF_PFX = nameof(AssetDatabaseOrganizerPane) + ".";

        public int TabIndex { get; set; }
        public string[] TabNames { get; set; }

        public override bool ContentInScrollView => false;

        public override string PaneName => PANE_NAME;

        public IReadOnlyList<IAppalachiaWindowPane> ChildPanes =>
            (IReadOnlyList<IAppalachiaWindowPane>) TabPanes;

        public float TabHeight => TAB_HEIGHT;

        public IList<IAppalachiaTabbedWindowPane> TabPanes =>
            ((IAppalachiaWindowPane) this).GetTabPanes(
                PANE_NAME,
                () => new List<IAppalachiaTabbedWindowPane>
                {
                    new AssemblyDefinitionAssetPane().SetWindow(window),
                    new AssetTypeReviewPane<Object>().SetWindow(window),
                    new AssetTypeReviewPane<ScriptableObject>().SetWindow(window),
                    new GeneralAssetReviewPane().SetWindow(window),
                    new OrphanedAssetPane().SetWindow(window)
                }
            );

        
        public override void OnDrawPaneContent()
        {
        }

        public override void OnInitialize()
        {
        }
    }
}
