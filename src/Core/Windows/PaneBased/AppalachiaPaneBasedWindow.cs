using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Windows.PaneBased.Panes;
using Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces;
using Unity.EditorCoroutines.Editor;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased
{
    public abstract class AppalachiaPaneBasedWindow<TW, TP> : AppalachiaPaneBasedWindowBase
        where TW : AppalachiaPaneBasedWindow<TW, TP>
        where TP : IAppalachiaWindowPane, new()
    {
        private const string _PRF_PFX = nameof(AppalachiaPaneBasedWindow<TW, TP>) + ".";
        private const string _TRACE_PFX = nameof(AppalachiaPaneBasedWindow<TW, TP>) + ".";

        public TP mainPane;
        private static readonly ProfilerMarker _PRF_OnGUI = new(_PRF_PFX + nameof(OnGUI));
        private static readonly ProfilerMarker _PRF_OnEnable = new(_PRF_PFX + nameof(OnEnable));
        private static readonly TraceMarker _TRACE_OnEnable = new(_TRACE_PFX + nameof(OnEnable));
        private static readonly TraceMarker _TRACE_OnGUI = new(_TRACE_PFX + nameof(OnGUI));
        private static readonly TraceMarker _TRACE_Get = new(_TRACE_PFX + nameof(Get));
        private static readonly ProfilerMarker _PRF_Get = new(_PRF_PFX + nameof(Get));

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
                if (mainPane == null)
                {
                    mainPane = new TP();
                }

                if (!mainPane.Initialized && !mainPane.Initializing)
                {
                    EditorCoroutineUtility.StartCoroutine(mainPane.Initialize(), this);
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
        }

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
