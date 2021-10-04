using System;
using System.Collections.Generic;
using Appalachia.Core.Attributes;
using Appalachia.Editing.Preferences;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Assets
{
    [InitializeOnLoad]
    public static class AssetDatabaseSaveManager
    {
        public static PREF<int> _SAVE_FRAME_DELAY;
        public static PREF<bool> _SAVE_ON_ENABLE;

        [NonSerialized] public static int LastSaveAt;

        [NonSerialized] public static bool QueuedSoon;
        [NonSerialized] public static bool QueuedNextFrame;
        [NonSerialized] private static int _suspensionDepth;
        [NonSerialized] private static int _deferralDepth;

        private static bool _explicitlyStarted;

        private static readonly PREF<bool> log = PREFS.REG(
            "Asset Database",
            "Log Deferrals",
            false
        );

        private static Dictionary<string, Action> _postActions;

        public static bool ImportDeferred => _deferralDepth > 0;
        public static bool ImportSuspended => _suspensionDepth > 0;

        [ExecuteOnEnable]
        private static void OnEnable()
        {
            _SAVE_FRAME_DELAY = PREFS.REG("Assets", "Save Frame Delay",                 30);
            _SAVE_ON_ENABLE = PREFS.REG("Assets",   "Save On Enable (After Compiling)", true);

            if (_SAVE_ON_ENABLE.v)
            {
                AssetDatabase.SaveAssets();
            }

            LastSaveAt = 0;
            QueuedSoon = false;
            QueuedNextFrame = false;
            _suspensionDepth = 0;
            _deferralDepth = 0;
        }

        //private static Action execution;
        [ExecuteOnUpdate]
        private static void OnUpdate()
        {
            /*if (execution == null)
            {
                execution = StaticRoutine.CreateDelegate(typeof(AssetDatabaseSaveManager), nameof(ExecuteSave));
            }

            execution();*/
            ExecuteSave();
        }

        [MenuItem("Assets/Start Asset Editing")]
        public static void StartAssetEditing()
        {
            AssetDatabase.StartAssetEditing();
            _explicitlyStarted = true;
            _suspensionDepth += 1;
        }

        [MenuItem("Assets/Start Asset Editing")]
        public static void StopAssetEditing()
        {
            AssetDatabase.StopAssetEditing();
            _explicitlyStarted = false;
            _suspensionDepth -= 1;
        }

        public static bool RequestSuspendImport(out IDisposable scope)
        {
            if (EditorApplication.isPlaying ||
                EditorApplication.isCompiling ||
                EditorApplication.isPaused ||
                EditorApplication.isUpdating ||
                Application.isBatchMode ||
                Application.isPlaying)
            {
                scope = null;
                return false;
            }

            scope = new DeferredAssetEditingScope();
            return true;
        }

        private static void Log(string prefix)
        {
            if (!log.v)
            {
                return;
            }

            Debug.LogWarning(
                $"{prefix}| Deferral depth: {_deferralDepth:000} | Suspension depth: {_suspensionDepth:000}"
            );
        }

        private static void ExecuteSave()
        {
            if (_explicitlyStarted)
            {
                return;
            }

            if (!ImportDeferred && ImportSuspended)
            {
                Log("Flushing import pauses.  ");

                var iteration = 0;
                while (ImportSuspended)
                {
                    AssetDatabase.StopAssetEditing();
                    _suspensionDepth -= 1;

                    iteration += 1;

                    //Log($"Flushing import pause. Iteration: {iteration} ");
                }

                return;
            }

            if (!QueuedSoon && !QueuedNextFrame)
            {
                return;
            }

            var waitThreshold = QueuedNextFrame ? 1 : _SAVE_FRAME_DELAY.v;

            var frameTime = Time.frameCount;
            var timeSinceLastSave = frameTime - LastSaveAt;

            if (timeSinceLastSave < waitThreshold)
            {
                return;
            }

            SaveAssetsNow();
        }

        public static void SaveAssetsSoon()
        {
            QueuedSoon = true;
        }

        public static void SaveAssetsNextFrame(string key = null, Action post = null)
        {
            if ((key != null) && (post != null))
            {
                if (_postActions == null)
                {
                    _postActions = new Dictionary<string, Action>();
                }

                if (!_postActions.ContainsKey(key))
                {
                    _postActions.Add(key, post);
                }
            }

            QueuedNextFrame = true;
        }

        public static void SaveAssetsNow()
        {
            LastSaveAt = Time.frameCount;

            if (_postActions != null)
            {
                foreach (var postAction in _postActions)
                {
                    var action = postAction.Value;

                    action();
                }

                _postActions.Clear();
            }

            AssetDatabase.SaveAssets();

            AssetDatabase.Refresh();

            QueuedSoon = false;
            QueuedNextFrame = false;
        }

        private class DeferredAssetEditingScope : IDisposable
        {
            public DeferredAssetEditingScope()
            {
                if (!ImportSuspended)
                {
                    AssetDatabase.StartAssetEditing();
                    _suspensionDepth += 1;
                    _deferralDepth += 1;
                    Log("Suspending import pause. ");
                }
                else
                {
                    _deferralDepth += 1;

                    //Log("Additional import pause scope. ");    
                }
            }

            void IDisposable.Dispose()
            {
                _deferralDepth -= 1;

                //Log("Disposing import pause scope. ");
            }
        }
    }
}
