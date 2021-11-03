using System;
using System.Collections;
using System.Collections.Generic;
using Appalachia.Core.Context.Elements;
using Appalachia.Core.Extensions;
using Appalachia.Utility.Extensions;
using Sirenix.OdinInspector;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

namespace Appalachia.Editing.Core.Windows
{
    [InitializeOnLoad]
    public abstract class AppalachiaEditorWindow : EditorWindow, IAppalachiaWindow
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(AppalachiaEditorWindow) + ".";

        protected static Random rng = new();

        private static readonly ProfilerMarker _PRF_OnPreferenceAwake =
            new(_PRF_PFX + nameof(OnPreferenceAwake));

        private static readonly ProfilerMarker _PRF_CloseWindow = new(_PRF_PFX + nameof(CloseWindow));

        private static readonly ProfilerMarker _PRF_SetToggleCollection =
            new(_PRF_PFX + nameof(SetToggleCollection));

        private static readonly ProfilerMarker _PRF_OpenWindow = new(_PRF_PFX + nameof(OpenWindow));
        private static readonly ProfilerMarker _PRF_OnSceneGUI = new(_PRF_PFX + nameof(OnSceneGUI));

#endregion

        private const float REPAINT_THRESHOLD = .1F;

        [FoldoutGroup("Execution", false, -1000)]
        [PropertyOrder(-99)]
        [ShowInInspector]
        public bool cancelOnError = true;

        [FoldoutGroup("Execution", false, -1000)]
        [PropertyOrder(-98)]
        [ShowInInspector]
        public bool forceCancelImmediately;

        [FoldoutGroup("Execution", false, -1000)]
        [PropertyOrder(-100)]
        [ShowInInspector]
        [Range(1, 200)]
        public int stepSize = 10;

        private AppaCoroutineRunner _coroutineRunner;

        private bool _hasRepaintBeenRequested;

        private float _lastRepaintTime;

        [FoldoutGroup("Execution", false, -1000)]
        [ReadOnly]
        [PropertyOrder(-1)]
        [ShowInInspector]
        public bool isExecutingCoroutine => _coroutineRunner?.IsExecutingCoroutine ?? false;

        [FoldoutGroup("Execution", false, -1000)]
        [ReadOnly]
        [PropertyOrder(-3)]
        [ShowInInspector]
        [DisplayAsString]
        public DateTime lastExecutionTime => _coroutineRunner?.LastExecutionTime ?? DateTime.MinValue;

        [FoldoutGroup("Execution", false, -1000)]
        [ReadOnly]
        [PropertyOrder(-2)]
        [ShowInInspector]
        public double executionTime => _coroutineRunner?.ExecutionTime ?? 0f;

        protected virtual void DrawSceneGUI()
        {
        }

        public void ExecuteCoroutine(Func<IEnumerator> coroutine)
        {
            if (_coroutineRunner == null)
            {
                _coroutineRunner = new AppaCoroutineRunner();
            }

            _coroutineRunner.CancelOnError = cancelOnError;
            _coroutineRunner.ForceCancelImmediately = forceCancelImmediately;
            _coroutineRunner.StepSize = stepSize;

            _coroutineRunner.ExecuteCoroutine(coroutine);
        }

        public void SafeRepaint(bool forceRepaint = false)
        {
            if (CanRepaint() && ShouldRepaint(forceRepaint))
            {
                ExecuteRepaint();
            }
            else
            {
                if (forceRepaint)
                {
                    _lastRepaintTime = 0f;
                }

                _hasRepaintBeenRequested = true;
            }
        }

        protected void CloseWindow()
        {
            using (_PRF_CloseWindow.Auto())
            {
                Close();
                GUIUtility.ExitGUI();
            }
        }

        protected void OnDestroy()
        {
            // When the window is destroyed, remove the delegate
            // so that it will no longer do any drawing.
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        protected void OnPreferenceAwake()
        {
            using (_PRF_OnPreferenceAwake.Auto())
            {
                SafeRepaint();
            }
        }

        private bool CanRepaint()
        {
            return Event.current is not {type: EventType.Repaint};
        }

        private void ExecuteRepaint()
        {
            _hasRepaintBeenRequested = false;
            _lastRepaintTime = Time.realtimeSinceStartup;
            Repaint();
        }

        private bool MustRepaint()
        {
            if (!_hasRepaintBeenRequested)
            {
                return false;
            }

            if (!CanRepaint())
            {
                return false;
            }

            if (!ShouldRepaint(false))
            {
                return false;
            }

            return true;
        }

        // Window has been selected
        private void OnFocus()
        {
            // Remove delegate listener if it has previously
            // been assigned.
            SceneView.duringSceneGui -= OnSceneGUI;

            // Add (or re-add) the delegate.
            SceneView.duringSceneGui += OnSceneGUI;
        }

        private void OnGUI()
        {
            if (MustRepaint())
            {
                ExecuteRepaint();
            }
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            using (_PRF_OnSceneGUI.Auto())
            {
                // Do your drawing here using UnityEditor.Handles.
                Handles.BeginGUI();

                DrawSceneGUI();

                // Do your drawing here using GUI.
                Handles.EndGUI();
            }
        }

        private bool ShouldRepaint(bool forceRepaint)
        {
            if (forceRepaint)
            {
                return true;
            }

            var elapsed = Time.realtimeSinceStartup - _lastRepaintTime;

            if (elapsed > REPAINT_THRESHOLD)
            {
                return true;
            }

            return false;
        }

        protected static void OpenWindow<T>()
            where T : AppalachiaEditorWindow
        {
            using (_PRF_OpenWindow.Auto())
            {
                var window = GetWindow<T>();

                // Nifty little trick to quickly position the window in the middle of the editor.
                window.position = window.position.AlignCenter(400, 300);
            }
        }

        protected static void SetToggleCollection(ref Dictionary<Type, bool> toggles, IEnumerable<Type> types)
        {
            using (_PRF_SetToggleCollection.Auto())
            {
                if (toggles == null)
                {
                    toggles = new Dictionary<Type, bool>();
                }

                foreach (var type in types)
                {
                    if (!toggles.ContainsKey(type))
                    {
                        toggles.Add(type, false);
                    }
                }
            }
        }

        protected static void SetToggleCollection(ref bool[] toggles, int size)
        {
            using (_PRF_SetToggleCollection.Auto())
            {
                if (toggles == null)
                {
                    toggles = new bool[size];
                }
                else if (size != toggles.Length)
                {
                    Array.Resize(ref toggles, size);
                }
            }
        }
    }
}
