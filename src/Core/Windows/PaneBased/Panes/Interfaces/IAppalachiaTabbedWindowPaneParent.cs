using System.Collections.Generic;
using Appalachia.Editing.Core.Fields;
using Unity.EditorCoroutines.Editor;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public interface IAppalachiaTabbedWindowPaneParent : IAppalachiaPaneParent
    {
        public float TabHeight { get; }
        public IList<IAppalachiaTabbedWindowPane> TabPanes { get; }

        public int TabIndex { get; set; }
        public string[] TabNames { get; set; }
        public bool DrawTabsBeforeContent => true;

        public void DrawAppalachiaTabbedWindowPane()
        {
        }

        public void OnDrawTabsEnd()
        {
        }

        public void OnDrawTabsStart()
        {
        }

        public void DrawTabPaneChild(IAppalachiaTabbedWindowPane tp)
        {
            if (!tp.Initialized && !tp.Initializing)
            {
                EditorCoroutineUtility.StartCoroutine(tp.Initialize(), this);
            }
                        
            if (tp.window == null)
            {
                tp.window = window;
            }
                        
            using (fieldMetadataManager.Get<ScrollViewUIMetadata>($"TAB_{tp.TabName}").GetScope())
            {
                tp.OnDrawGUI();
            }
        }
    }
}
