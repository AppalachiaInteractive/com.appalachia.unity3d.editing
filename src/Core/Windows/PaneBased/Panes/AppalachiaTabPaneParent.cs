using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Fields;
using Appalachia.Utility.Extensions;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public abstract class AppalachiaTabPaneParent : AppalachiaWindowPane
    {
        #region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(AppalachiaTabPaneParent) + ".";
        private const string _TRACE_PFX = nameof(AppalachiaTabPaneParent) + ".";

        private static readonly TraceMarker _TRACE_DrawAppalachiaTabbedWindowPane =
            new(_TRACE_PFX + nameof(DrawAppalachiaTabbedWindowPane));

        private static readonly ProfilerMarker _PRF_DrawAppalachiaTabbedWindowPane =
            new(_PRF_PFX + nameof(DrawAppalachiaTabbedWindowPane));

        #endregion

        #region Preferences

        private PREF<int> _tabIndex;

        #endregion

        public string[] TabNames { get; set; }
        public abstract float TabHeight { get; }

        public abstract IList<AppalachiaWindowPane> TabPanes { get; }

        public abstract PaneParentStyle Style { get; }

        public abstract int TabColumns { get; set; }

        public virtual bool DrawTabsBeforeContent => true;

        public int TabIndex
        {
            get
            {
                if (_tabIndex == null)
                {
                    _tabIndex = PREFS.REG($"{PKG.Prefs.Group}/Tab State", PaneName, 0);
                }

                return _tabIndex;
            }
            set => _tabIndex.v = value;
        }

        public virtual void OnDrawTabsEnd()
        {
        }

        public virtual void OnDrawTabsStart()
        {
        }

        public void DrawAppalachiaTabbedWindowPane()
        {
            using (_TRACE_DrawAppalachiaTabbedWindowPane.Auto())
            using (_PRF_DrawAppalachiaTabbedWindowPane.Auto())
            {
                var tabGroup = fieldMetadataManager.Get<ButtonGroupMetadata>();

                if (!tabGroup.hasBeenDrawn)
                {
                    tabGroup.AddLayoutOption(GUILayout.Height(TabHeight));
                    tabGroup.AddLayoutOption(GUILayout.MinWidth(40));

                    var panes = TabPanes;
                    panes.Sort();

                    TabNames = panes.Select(p => p.TabName).ToArray();
                }

                if (TabNames.Length == 0)
                {
                    return;
                }

                OnDrawTabsStart();

                TabIndex = Style == PaneParentStyle.Toolbar
                    ? tabGroup.Toolbar(TabIndex, TabNames)
                    : tabGroup.SelectionGrid(TabIndex, TabNames, TabColumns);

                var selectedTab = TabNames[TabIndex];

                for (var i = 0; i < TabPanes.Count; i++)
                {
                    var tp = TabPanes[i];

                    if (tp.TabName == selectedTab)
                    {
                        DrawTabPaneChild(tp, tp.TabName);
                    }
                }

                OnDrawTabsEnd();
            }
        }
    }
}
