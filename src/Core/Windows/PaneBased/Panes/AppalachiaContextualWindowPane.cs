using System.Collections;
using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Context.Contexts;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public abstract class AppalachiaContextualWindowPane<TC> : AppalachiaWindowPane
        where TC : AppaMenuContext, new()
    {
        #region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(AppalachiaContextualWindowPane<TC>) + ".";
        private const string _TRACE_PFX = nameof(AppalachiaContextualWindowPane<TC>) + ".";

        private static readonly ProfilerMarker _PRF_OnBeforeInitialize =
            new(_PRF_PFX + nameof(OnBeforeInitialize));

        private static readonly TraceMarker _TRACE_OnBeforeDrawPaneContentStart =
            new(_TRACE_PFX + nameof(OnBeforeDrawPaneContentStart));

        private static readonly ProfilerMarker _PRF_OnBeforeDrawPaneContentStart =
            new(_PRF_PFX + nameof(OnBeforeDrawPaneContentStart));

        private static readonly TraceMarker _TRACE_OnBeforeInitialize =
            new(_TRACE_PFX + nameof(OnBeforeInitialize));

        private static readonly ProfilerMarker _PRF_OnAfterInitialize =
            new(_PRF_PFX + nameof(OnAfterInitialize));

        private static readonly TraceMarker _TRACE_OnAfterInitialize =
            new(_TRACE_PFX + nameof(OnAfterInitialize));

        #endregion

        protected virtual bool ContextPaneIsInitialized { get; set; }

        public TC context { get; set; }

        public override bool IsInitialized =>
            ContextPaneIsInitialized && (context != null) && context.Initialized;

        protected virtual void DrawContextButtons()
        {
        }

        public override IEnumerator OnAfterInitialize()
        {
            using (_TRACE_OnAfterInitialize.Auto())
            using (_PRF_OnAfterInitialize.Auto())
            {
                ContextPaneIsInitialized = true;
                yield break;
            }
        }

        public override void OnBeforeDrawPaneContentStart(out bool shouldDraw)
        {
            using (_TRACE_OnBeforeDrawPaneContentStart.Auto())
            using (_PRF_OnBeforeDrawPaneContentStart.Auto())
            {
                shouldDraw = true;

                var resetContext = fieldMetadataManager.Get<ButtonMetadata>("Reset Context");

                APPAGUI.SPACE.SIZE.ButtonPaddingLeft.MAKE();

                using (new GUILayout.HorizontalScope())
                {
                    if (resetContext.Button())
                    {
                        context.Reset();
                        shouldDraw = false;
                        return;
                    }

                    DrawContextButtons();
                }
            }
        }

        public override IEnumerator OnBeforeInitialize()
        {
            using (_TRACE_OnBeforeInitialize.Auto())
            using (_PRF_OnBeforeInitialize.Auto())
            {
                if (context == null)
                {
                    context = new TC();
                }

                return context.Check();
            }
        }
    }
}
