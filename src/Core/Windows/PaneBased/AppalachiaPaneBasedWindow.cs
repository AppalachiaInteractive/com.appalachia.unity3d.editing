using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased
{
    public abstract class AppalachiaPaneBasedWindow<TW, TP> : AppalachiaPaneBasedWindowBase
        where TW : AppalachiaPaneBasedWindow<TW, TP>
        where TP : AppalachiaWindowPane, new()
    {
        #region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(AppalachiaPaneBasedWindow<TW, TP>) + ".";
        private const string _TRACE_PFX = nameof(AppalachiaPaneBasedWindow<TW, TP>) + ".";
        private static readonly ProfilerMarker _PRF_OnGUI = new(_PRF_PFX + nameof(OnGUI));
        private static readonly ProfilerMarker _PRF_OnEnable = new(_PRF_PFX + nameof(OnEnable));
        private static readonly TraceMarker _TRACE_OnEnable = new(_TRACE_PFX + nameof(OnEnable));
        private static readonly TraceMarker _TRACE_OnGUI = new(_TRACE_PFX + nameof(OnGUI));
        private static readonly TraceMarker _TRACE_Get = new(_TRACE_PFX + nameof(Get));
        private static readonly ProfilerMarker _PRF_Get = new(_PRF_PFX + nameof(Get));

        #endregion

        public TP mainPane;

        #region Event Functions

        private void OnEnable()
        {
            using (_TRACE_OnEnable.Auto())
            using (_PRF_OnEnable.Auto())
            {
                PREF_STATES.Awake();

                minSize = new Vector2(640, 480);
            }
        }

        private void OnGUI()
        {
            using (_TRACE_OnGUI.Auto())
            using (_PRF_OnGUI.Auto())
            {
                try
                {
                    if (mainPane == null)
                    {
                        mainPane = new TP();
                    }

                    if (!mainPane.FullyInitialized && !mainPane.PaneIsInitializing)
                    {
                        ExecuteCoroutine(() => mainPane.Initialize());
                    }

                    if (mainPane.window == null)
                    {
                        mainPane.window = this;
                    }

                    mainPane.OnDrawGUI();

                    if (GUILayout.Button("Close"))
                    {
                        CloseWindow();
                    }
                }
                catch (APPAGUI.Exit)
                {
                }
            }
        }

        private void OnInspectorUpdate()
        {
            mainPane?.OnInspectorUpdate();
        }

        #endregion

        public static TW Get(string title)
        {
            using (_TRACE_Get.Auto())
            using (_PRF_Get.Auto())
            {
                var window = GetWindow<TW>(false, title, true);

                window.mainPane = new TP {window = window};

                return window;
            }
        }
    }
}
