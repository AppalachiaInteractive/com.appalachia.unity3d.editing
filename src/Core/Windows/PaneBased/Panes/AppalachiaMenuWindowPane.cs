// ReSharper disable UnusedParameter.Global

using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Context.Contexts;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public abstract class AppalachiaMenuWindowPane<TC> : AppalachiaContextualWindowPane<TC>
        where TC : AppaMenuContext, new()
    {
        #region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(AppalachiaMenuWindowPane<TC>) + ".";
        private const string _TRACE_PFX = nameof(AppalachiaMenuWindowPane<TC>) + ".";

        private static readonly ProfilerMarker _PRF_DrawAppalachiaMenuWindowPane =
            new(_PRF_PFX + nameof(OnBeforeDrawPaneContent));

        private static readonly ProfilerMarker _PRF_OnBeforeDraw = new(_PRF_PFX + nameof(OnBeforeDraw));
        private static readonly TraceMarker _TRACE_OnBeforeDraw = new(_TRACE_PFX + nameof(OnBeforeDraw));

        #endregion

        protected float menuItemHeight;

        protected ScrollViewUIMetadata menuScrollView;

        protected virtual bool AlwaysShowMenuHorizontalScrollbar => true;
        protected virtual bool AlwaysShowMenuVerticalScrollbar => true;

        protected override bool DrawPreferences => false;

        public abstract bool ShouldDrawMenuItem(int menuIndex, int menuItemIndex);

        public abstract void DrawSelectedContent(bool show);

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

        public override void OnBeforeDraw()
        {
            using (_TRACE_OnBeforeDraw.Auto())
            using (_PRF_OnBeforeDraw.Auto())
            {
                base.OnBeforeDraw();

                if (Event.current.type == EventType.KeyDown)
                {
                    var mousePosition = Event.current.mousePosition;

                    var targetMenuIndex = context.GetActiveMenuIndex(mousePosition);

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

                            menuScrollView.scrollPosition.y = Mathf.Clamp(currentScrollY + shift, 0, 10000);
                        }
                    }
                }

                window.SafeRepaint();
            }
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

                    if (menuScrollView == null)
                    {
                        menuScrollView = fieldMetadataManager.Get<ScrollViewUIMetadata>(
                            $"{PaneName}_SV_{menuIndex}",
                            sv =>
                            {
                                sv.width = context.MenuWidth;
                                sv.AlwaysShowVertical = AlwaysShowMenuVerticalScrollbar;
                                sv.AlwaysShowHorizontal = AlwaysShowHorizontalScrollbar;
                            }
                        );
                    }

                    using (new GUILayout.VerticalScope(APPAGUI.Width(context.MenuWidth).ExpandWidth(false)))
                    {
                        PreferencesDrawer.DrawPreferenceFields(false);

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

                                OnDrawPaneMenuItem(
                                    menuIndex,
                                    menuItemIndex,
                                    isSelected,
                                    out var wasSelected,
                                    out var menuItemHeightTemp
                                );

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

        public override void OnDrawPaneContent()
        {
            var menuSelection = context.GetMenuSelection(0);
            var menuItemIndex = menuSelection.currentIndex;

            var visibility = menuSelection.IsVisible(menuItemIndex);

            DrawSelectedContent(visibility);
        }
    }
}
