using System.Linq;
using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Extensions;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public interface IAppalachiaToolbarTabWindowPaneParent : IAppalachiaTabbedWindowPaneParent
    {
        private const string _PRF_PFX = nameof(IAppalachiaTabbedWindowPaneParent) + ".";
        private const string _TRACE_PFX = nameof(IAppalachiaToolbarTabWindowPaneParent) + ".";

        private static readonly TraceMarker _TRACE_DrawAppalachiaTabbedWindowPane =
            new TraceMarker(_TRACE_PFX + nameof(DrawAppalachiaTabbedWindowPane));

        private static readonly ProfilerMarker _PRF_DrawAppalachiaTabbedWindowPane =
            new(_PRF_PFX + nameof(DrawAppalachiaTabbedWindowPane));

        void IAppalachiaTabbedWindowPaneParent.DrawAppalachiaTabbedWindowPane()
        {
            using (_TRACE_DrawAppalachiaTabbedWindowPane.Auto())
            using (_PRF_DrawAppalachiaTabbedWindowPane.Auto())
            {
                var toolbar = fieldMetadataManager.Get<ToolbarMetadata>();

                if (!toolbar.hasBeenDrawn)
                {
                    toolbar.AddLayoutOption(GUILayout.Height(TabHeight));
                    toolbar.AddLayoutOption(GUILayout.MinWidth(40));

                    var panes = TabPanes;
                    panes.Sort();

                    TabNames = panes.Select(p => p.TabName).ToArray();
                }

                OnDrawTabsStart();

                TabIndex = toolbar.Toolbar(TabIndex, TabNames);

                var selectedTab = TabNames[TabIndex];

                for (var i = 0; i < TabPanes.Count; i++)
                {
                    var tp = TabPanes[i];

                    if (tp.TabName == selectedTab)
                    {
                        DrawTabPaneChild(tp);
                    }
                }

                OnDrawTabsEnd();
            }
        }
    }
}
