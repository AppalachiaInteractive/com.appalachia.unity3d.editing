using Appalachia.Core.Aspects.Tracing;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Windows.PaneBased.Context;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public abstract class AppalachiaContextualWindowPane<TC> : AppalachiaWindowPane
        where TC : AppalachiaWindowPaneContext, new()
    {
        private const string _PRF_PFX = nameof(AppalachiaContextualWindowPane<TC>) + ".";
        private const string _TRACE_PFX = nameof(AppalachiaContextualWindowPane<TC>) + ".";

        private static readonly ProfilerMarker _PRF_OnBeforeInitialize =
            new(_PRF_PFX + nameof(OnBeforeInitialize));

        private static readonly ProfilerMarker _PRF_OnBeforeDraw = new(_PRF_PFX + nameof(OnBeforeDraw));

        private static readonly TraceMarker _TRACE_OnBeforeDraw = new(_TRACE_PFX + nameof(OnBeforeDraw));

        private static readonly TraceMarker _TRACE_OnBeforeDrawPaneContentStart =
            new(_TRACE_PFX + nameof(OnBeforeDrawPaneContentStart));

        private static readonly ProfilerMarker _PRF_OnBeforeDrawPaneContentStart =
            new(_PRF_PFX + nameof(OnBeforeDrawPaneContentStart));

        private static readonly TraceMarker _TRACE_OnBeforeInitialize =
            new(_TRACE_PFX + nameof(OnBeforeInitialize));

        public TC context { get; set; }

        private static readonly TraceMarker _TRACE_CheckContext = new TraceMarker(_TRACE_PFX + nameof(CheckContext));
        private static readonly ProfilerMarker _PRF_CheckContext = new ProfilerMarker(_PRF_PFX + nameof(CheckContext));
        private void CheckContext()
        {
            using (_TRACE_CheckContext.Auto())
            using (_PRF_CheckContext.Auto())
            {
                if (context == null)
                {
                    context = new TC();
                }
                if (!context.initialized)
                {
                    context.Initialize();
                }
            }
        }
        
        public override void OnBeforeDraw()
        {
            using (_TRACE_OnBeforeDraw.Auto())
            using (_PRF_OnBeforeDraw.Auto())
            {
                CheckContext();
                
                if ((Event.current.type == EventType.KeyDown) &&
                    context is IAppalachiaMenuWindowPaneContext c)
                {
                    var mousePosition = Event.current.mousePosition;

                    var targetMenuIndex = c.GetActiveMenuIndex(mousePosition);

                    if (Event.current.keyCode == KeyCode.DownArrow)
                    {
                        context.ChangeMenuSelection(targetMenuIndex, false);
                    }
                    else if (Event.current.keyCode == KeyCode.UpArrow)
                    {
                        context.ChangeMenuSelection(targetMenuIndex, true);
                    }

                    window.SafeRepaint();
                }
            }
        }

        public override void OnBeforeDrawPaneContentStart(out bool shouldDraw)
        {
            using (_TRACE_OnBeforeDrawPaneContentStart.Auto())
            using (_PRF_OnBeforeDrawPaneContentStart.Auto())
            {
                shouldDraw = true;

                CheckContext();

                var resetContext = fieldMetadataManager.Get<ButtonMetadata>("Reset Context");

                if (resetContext.Button())
                {
                    context.Reset();
                    context.Initialize();
                    shouldDraw = false;
                }
            }
        }

        public override void OnBeforeInitialize()
        {
            using (_TRACE_OnBeforeInitialize.Auto())
            using (_PRF_OnBeforeInitialize.Auto())
            {
               CheckContext();
            }
        }
    }
}
