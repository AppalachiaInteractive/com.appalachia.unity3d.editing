// ReSharper disable UnusedParameter.Global

using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public abstract class AppalachiaMenuWindowPane<TC> : AppalachiaContextualWindowPane<TC>
        where TC : AppalachiaWindowPaneContext, new()
    {
        private const string _PRF_PFX = nameof(AppalachiaMenuWindowPane<TC>) + ".";

        private static readonly ProfilerMarker _PRF_DrawAppalachiaMenuWindowPane =
            new(_PRF_PFX + nameof(OnBeforeDrawPaneContent));

        public abstract void OnDrawPaneMenuItem(int menuIndex, int menuItemIndex, out bool isSelected);

        public abstract bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex);

        public virtual void OnDrawPaneMenuEnd(int menuIndex)
        {
        }

        public virtual void OnDrawPaneMenusEnd()
        {
        }

        public virtual void OnDrawPaneMenusStart()
        {
        }

        public virtual void OnDrawPaneMenuStart(int menuIndex)
        {
        }

        public override void OnBeforeDrawPaneContent()
        {
            using (_PRF_DrawAppalachiaMenuWindowPane.Auto())
            {
                OnDrawPaneMenusStart();

                for (var menuIndex = 0; menuIndex < context.RequiredMenuCount; menuIndex++)
                {
                    var menuSelection = context.GetMenuSelection(menuIndex);
                    
                    context.ValidateMenuSelection(menuIndex);
                    
                    using (fieldMetadataManager.Get<ScrollViewUIMetadata>($"SV_{menuIndex}").GetScope())
                    {
                        OnDrawPaneMenuStart(menuIndex);

                        menuSelection.ResetVisibility();

                        for (var menuItemIndex = 0; menuItemIndex < menuSelection.length; menuItemIndex++)
                        {
                            if (!ShouldDrawMenuItem(menuIndex, menuItemIndex))
                            {
                                continue;
                            }

                            menuSelection.RecordIndexInformation(menuItemIndex, menuSelection.visibleCount);

                            OnDrawPaneMenuItem(menuIndex, menuItemIndex, out var isSelected);

                            if (isSelected)
                            {
                                menuSelection.SetSelected(menuItemIndex);
                            }
                        }

                        OnDrawPaneMenuEnd(menuIndex);
                    }

                    menuSelection.position = GUILayoutUtility.GetLastRect();
                }

                OnDrawPaneMenusEnd();
            }
        }
    }
}
