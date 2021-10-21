// ReSharper disable UnusedParameter.Global

using Appalachia.Core.Aspects.Tracing;
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
        private const string _TRACE_PFX = nameof(AppalachiaMenuWindowPane<TC>) + ".";

        private static readonly ProfilerMarker _PRF_DrawAppalachiaMenuWindowPane =
            new(_PRF_PFX + nameof(OnBeforeDrawPaneContent));

        protected override bool DrawPreferences => false;

        protected virtual int MenuWidth => 300;

        public abstract bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex);

        public abstract void OnDrawPaneMenuItem(
            int menuIndex,
            int menuItemIndex,
            bool isSelected,
            out bool wasSelected,
            out float menuItemHeight);

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

        private static readonly ProfilerMarker _PRF_OnBeforeDraw = new ProfilerMarker(_PRF_PFX + nameof(OnBeforeDraw));
        private static readonly TraceMarker _TRACE_OnBeforeDraw = new TraceMarker(_TRACE_PFX + nameof(OnBeforeDraw));

        public override void OnBeforeDraw()
        {
            using (_TRACE_OnBeforeDraw.Auto())
            using (_PRF_OnBeforeDraw.Auto())
            {
                base.OnBeforeDraw();

                if ((Event.current.type == EventType.KeyDown) &&
                    context is IAppalachiaMenuWindowPaneContext c)
                {
                    var mousePosition = Event.current.mousePosition;

                    var targetMenuIndex = c.GetActiveMenuIndex(mousePosition);

                    var up = Event.current.keyCode == KeyCode.UpArrow;
                    var down = Event.current.keyCode == KeyCode.DownArrow;

                    if (up || down)
                    {
                        context.ChangeMenuSelection(targetMenuIndex, up);
                    }

                    var menuSelection = context.GetMenuSelection(targetMenuIndex);

                    var visibleCount = menuSelection.lastVisibleCount;

                    var maxDifference = menuItemHeight * 15;

                    var targetTime = menuSelection.currentVisibleIndex / (float) visibleCount;
                    var estimatedHeight = menuItemHeight * visibleCount;

                    var targetScrollY = targetTime * estimatedHeight;
                    var currentScrollY = menuScrollView.scrollPosition.y;

                    var difference = targetScrollY - currentScrollY;

                    if (targetScrollY < currentScrollY)
                    {
                        menuScrollView.scrollPosition.y = Mathf.Clamp(targetScrollY, 0, 10000);
                    }
                    else
                    {
                        if (difference > maxDifference)
                        {
                            var shift = difference - maxDifference;
                            
                            menuScrollView.scrollPosition.y = Mathf.Clamp(currentScrollY+shift, 0, 10000);                            
                        }
                    }
                }

                window.SafeRepaint();
            }
        }


        protected ScrollViewUIMetadata menuScrollView;
        protected float menuItemHeight;
        
        public override void OnBeforeDrawPaneContent()
        {
            using (_PRF_DrawAppalachiaMenuWindowPane.Auto())
            {
                OnDrawPaneMenusStart();
                for (var menuIndex = 0; menuIndex < context.RequiredMenuCount; menuIndex++)
                {
                    var menuSelection = context.GetMenuSelection(menuIndex);

                    context.ValidateMenuSelection(menuIndex);

                    if (menuScrollView == null)
                    {
                        menuScrollView = fieldMetadataManager.Get<ScrollViewUIMetadata>(
                            $"SV_{menuIndex}",
                            sv =>
                            {
                                sv.width = MenuWidth;
                                sv.AddLayoutOption(GUILayout.Width(MenuWidth));
                            }
                        );
                    }

                    using (new GUILayout.VerticalScope())
                    {
                        DrawPreferenceFields(false);

                        /*
                        UnityEditor.EditorGUILayout.LabelField(nameof(menuSelection.currentIndex), menuSelection.currentIndex.ToString());
                        UnityEditor.EditorGUILayout.LabelField(nameof(menuSelection.currentVisibleIndex), menuSelection.currentVisibleIndex.ToString());
                        var sp = menuScrollView.scrollPosition;
                        UnityEditor.EditorGUILayout.LabelField(
                            nameof(menuScrollView.scrollPosition),
                            $"x: {sp.x} y: {sp.y}"
                        );
                        UnityEditor.EditorGUILayout.LabelField(
                            "Scroll Time",
                            $"{menuSelection.scrollTime}%"
                        );*/
                        
                        using (menuScrollView.GetScope())
                        {
                            OnDrawPaneMenuStart(menuIndex);

                            menuSelection.ResetVisibility();

                            for (var menuItemIndex = 0; menuItemIndex < menuSelection.length; menuItemIndex++)
                            {
                                if (!ShouldDrawMenuItem(menuIndex, menuItemIndex))
                                {
                                    menuSelection.RecordIndexInformation(menuItemIndex, -1, false);

                                    continue;
                                }

                                menuSelection.RecordIndexInformation(
                                    menuItemIndex,
                                    menuSelection.visibleCount,
                                    true
                                );

                                var isSelected = menuSelection.IsSelected(menuItemIndex);

                                OnDrawPaneMenuItem(menuIndex, menuItemIndex, isSelected, out var wasSelected, out var menuItemHeightTemp);

                                if (menuItemHeightTemp != 0)
                                {
                                    menuItemHeight = menuItemHeightTemp;
                                }

                                if (wasSelected)
                                {
                                    menuSelection.SetSelected(menuItemIndex);
                                }
                            }

                            OnDrawPaneMenuEnd(menuIndex);
                        }

                        menuSelection.position = GUILayoutUtility.GetLastRect();
                    }
                }

                OnDrawPaneMenusEnd();
            }
        }
    }
}
