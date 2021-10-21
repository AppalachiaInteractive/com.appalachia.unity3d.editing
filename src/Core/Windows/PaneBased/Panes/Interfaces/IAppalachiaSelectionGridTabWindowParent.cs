using System.Linq;
using Appalachia.Core.Extensions;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces
{
    public interface IAppalachiaSelectionGridTabWindowParent : IAppalachiaTabbedWindowPaneParent
    {
        private const string _PRF_PFX = nameof(IAppalachiaTabbedWindowPaneParent) + ".";

        private static readonly ProfilerMarker _PRF_DrawAppalachiaTabbedWindowPane =
            new(_PRF_PFX + nameof(DrawAppalachiaTabbedWindowPane));
        
        void IAppalachiaTabbedWindowPaneParent.DrawAppalachiaTabbedWindowPane()
        {
            using (_PRF_DrawAppalachiaTabbedWindowPane.Auto())
            {
                fieldMetadataManager.Space(SpaceSize.SectionStartVertical);
                
                var selectionGrid = fieldMetadataManager.Get<SelectionGridMetadata>();

                if (!selectionGrid.hasBeenDrawn)
                {
                    selectionGrid.AddLayoutOption(GUILayout.Height(TabHeight));
                    selectionGrid.AddLayoutOption(GUILayout.MinWidth(40));
                    
                    var panes = TabPanes;
                    panes.Sort();

                    TabNames = panes.Select(p => p.TabName).ToArray();
                }
                
                OnDrawTabsStart();
                
                TabIndex = selectionGrid.Toolbar(TabIndex, TabNames);

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

                fieldMetadataManager.Space(SpaceSize.SectionEndVertical);
                AppalachiaEditorGUIHelper.HorizontalLineSeparator(bufferSize: 3f);
            }
        }
    }
}