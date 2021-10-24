#region

using System;
using Appalachia.CI.Constants;
using Unity.Mathematics;
using UnityEditor;

#endregion

#if UNITY_EDITOR

#endif

namespace Appalachia.Editing.Core
{
    public class EditorOnlyProgressBar : IDisposable
    {
        public EditorOnlyProgressBar(string title, float total, bool cancellable, int showEvery = 15)
        {
#if UNITY_EDITOR
            _title = title;
            _total = math.max(total, 1.0f);
            _cancellable = cancellable;
            _showEvery = math.max(1, showEvery);
#endif
        }

        private readonly bool _cancellable;
        private readonly float _total;
        private readonly int _showEvery;

        private readonly object _lock = new();
        private readonly string _title;
        private bool _cancelled;

        private bool _hasShownBar;
        private float _increment;
        private int _counter;

        public bool Cancellable => _cancellable;

        public bool Cancelled => _cancelled;

        public void Increment(float value)
        {
#if UNITY_EDITOR
            lock (_lock)
            {
                _increment += value;
            }
#endif
        }

        public void Increment1AndShowProgress(string info)
        {
#if UNITY_EDITOR
            Increment(1);
            ShowProgress(info);
#endif
        }

        public bool Increment1AndShowProgressAndIsCancelled(string info)
        {
#if UNITY_EDITOR
            Increment1AndShowProgress(info);
#endif
            return _cancelled;
        }

        public void Increment1AndShowProgressBasic()
        {
#if UNITY_EDITOR
            Increment1AndShowProgress($"{_increment} / {_total}");
#endif
        }

        public bool Increment1AndShowProgressBasicAndIsCancelled()
        {
#if UNITY_EDITOR
            Increment1AndShowProgressBasic();
#endif
            return _cancelled;
        }

        public void IncrementAndShowProgress(float value, string info)
        {
#if UNITY_EDITOR
            Increment(value);
            ShowProgress(info);
#endif
        }

        public void IncrementAndShowProgressBasic(float value)
        {
#if UNITY_EDITOR
            IncrementAndShowProgress(value, $"{_increment} / {_total}");
#endif
        }

        public void ShowProgress(string title, string info, float total, float current)
        {
#if UNITY_EDITOR
            _counter += 1;

            if ((_counter % _showEvery) == 0)
            {
                if (_cancellable)
                {
                    _cancelled = EditorUtility.DisplayCancelableProgressBar(title, info, current / total);
                    _hasShownBar = true;
                }
                else
                {
                    EditorUtility.DisplayProgressBar(title, info, current / total);
                    _hasShownBar = true;
                }
            }
#endif
        }

        public void Dispose()
        {
#if UNITY_EDITOR
            if (_hasShownBar)
            {
                EditorUtility.ClearProgressBar();
            }
#endif
        }

        private void ShowProgress(string info)
        {
#if UNITY_EDITOR
            ShowProgress(_title, info, _total, _increment);
#endif
        }

        [MenuItem(
            APPA_MENU.BASE_AppalachiaTools + APPA_MENU.ASM_AppalachiaEditingCore + "Clear Progress Bar"
        )]
        public static void ClearProgressBar()
        {
            EditorUtility.ClearProgressBar();
        }
    }
}
