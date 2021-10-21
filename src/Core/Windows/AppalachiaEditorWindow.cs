using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Appalachia.Core.Extensions;
using Appalachia.Core.Extensions.Helpers;
using Appalachia.Core.Preferences;
using Sirenix.OdinInspector;
using Unity.EditorCoroutines.Editor;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

namespace Appalachia.Editing.Core.Windows
{
    public abstract class AppalachiaEditorWindow : EditorWindow
    {
        private const float REPAINT_THRESHOLD = .1F;
        private const string _PRF_PFX = nameof(AppalachiaEditorWindow) + ".";

        protected static Random rng = new();

        private static readonly ProfilerMarker _PRF_OnPreferenceAwake =
            new(_PRF_PFX + nameof(OnPreferenceAwake));

        private static readonly ProfilerMarker _PRF_CloseWindow = new(_PRF_PFX + nameof(CloseWindow));

        private static readonly ProfilerMarker _PRF_SetToggleCollection =
            new(_PRF_PFX + nameof(SetToggleCollection));

        private static readonly ProfilerMarker _PRF_OpenWindow = new(_PRF_PFX + nameof(OpenWindow));
        private static readonly ProfilerMarker _PRF_OnSceneGUI = new(_PRF_PFX + nameof(OnSceneGUI));

        private static readonly ProfilerMarker _PRF_ExecuteCoroutine =
            new(_PRF_PFX + nameof(ExecuteCoroutine));

        private static readonly ProfilerMarker _PRF_BeginExecution = new(_PRF_PFX + nameof(BeginExecution));

        private static readonly ProfilerMarker _PRF_EndExecution = new(_PRF_PFX + nameof(EndExecution));

        private static readonly ProfilerMarker _PRF_ExecuteCoroutineEnumerator =
            new(_PRF_PFX + nameof(ExecuteCoroutineEnumerator));

        [FoldoutGroup("Execution", false, -1000)]
        [PropertyOrder(-99)]
        [ShowInInspector]
        public bool cancelOnError = true;

        [FoldoutGroup("Execution", false, -1000)]
        [PropertyOrder(-98)]
        [ShowInInspector]
        public bool forceCancelImmediately;

        [FoldoutGroup("Execution", false, -1000)]
        [ReadOnly]
        [PropertyOrder(-1)]
        [ShowInInspector]
        public bool isExecutingCoroutine;

        [FoldoutGroup("Execution", false, -1000)]
        [ReadOnly]
        [PropertyOrder(-3)]
        [ShowInInspector]
        [DisplayAsString]
        public DateTime lastExecutionTime;

        [FoldoutGroup("Execution", false, -1000)]
        [ReadOnly]
        [PropertyOrder(-2)]
        [ShowInInspector]
        public double executionTime;

        [FoldoutGroup("Execution", false, -1000)]
        [PropertyOrder(-100)]
        [ShowInInspector]
        [Range(1, 200)]
        public int stepSize = 10;

        private readonly Stopwatch _stopwatch = new();

        private bool _hasRepaintBeenRequested;

        private float _lastRepaintTime;

        public void ExecuteCoroutine(Func<IEnumerator> coroutine)
        {
            using (_PRF_ExecuteCoroutine.Auto())
            {
                EditorCoroutineUtility.StartCoroutine(ExecuteCoroutineEnumerator(coroutine), this);
            }
        }

        public void SafeRepaint()
        {
            if (CanRepaint() && ShouldRepaint())
            {
                ExecuteRepaint();
            }
            else
            {
                _hasRepaintBeenRequested = true;                
            }
        }

        protected IEnumerator ExecuteCoroutineEnumerator(Func<IEnumerator> coroutine)
        {
            using (_PRF_ExecuteCoroutineEnumerator.Auto())
            {
                try
                {
                    BeginExecution();

                    var count = -1;

                    var routineResults = coroutine();

                    while (true)
                    {
                        if (forceCancelImmediately)
                        {
                            break;
                        }

                        count += 1;
                        object current = null;

                        try
                        {
                            if (!routineResults.MoveNext())
                            {
                                break;
                            }

                            current = routineResults.Current;
                        }
                        catch (Exception ex)
                        {
                            DebugHelper.LogError($"Error executing coroutine: [{ex}");

                            if (cancelOnError)
                            {
                                break;
                            }
                        }

                        if ((count % stepSize) == 0)
                        {
                            yield return current;
                        }
                    }
                }
                finally
                {
                    EndExecution();
                }
            }
        }

        protected void BeginExecution()
        {
            using (_PRF_BeginExecution.Auto())
            {
                isExecutingCoroutine = true;
                _stopwatch.Restart();
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

        protected virtual void DrawSceneGUI()
        {
        }

        protected void EndExecution()
        {
            using (_PRF_EndExecution.Auto())
            {
                _stopwatch.Stop();
                lastExecutionTime = DateTime.Now;
                executionTime = _stopwatch.Elapsed.TotalSeconds;
                isExecutingCoroutine = false;
            }
        }

        protected void OnDestroy()
        {
            // When the window is destroyed, remove the delegate
            // so that it will no longer do any drawing.
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        protected void OnPreferenceAwake<T>(PREF<T> pref)
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

        private bool ShouldRepaint()
        {
            var elapsed = Time.realtimeSinceStartup - _lastRepaintTime;

            if (elapsed > REPAINT_THRESHOLD)
            {
                return true;
            }

            return false;
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

            if (!ShouldRepaint())
            {
                return false;
            }

            return true;
        }

        private void ExecuteRepaint()
        {
            _hasRepaintBeenRequested = false;
            _lastRepaintTime = Time.realtimeSinceStartup;
            Repaint();
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
