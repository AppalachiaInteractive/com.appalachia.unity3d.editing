#if UNITY_EDITOR
using System;
using Appalachia.Core.ObjectPooling;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Appalachia.Editing.Debugging.Handle
{
    internal class HandleState : SelfPoolingObject<HandleState>, IDisposable
    {
#pragma warning disable 612
        public HandleState()
#pragma warning restore 612
        {
            using (_PRF_HandleState.Auto())
            {
                _color = UnityEditor.Handles.color;
                _sRGB = GL.sRGBWrite;
                _zTest = UnityEditor.Handles.zTest;
            }
        }

        #region Fields and Autoproperties

        private bool _sRGB;

        private Color _color;
        private CompareFunction _zTest;

        #endregion

        public static HandleState New()
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                return h;
            }
        }

        public static HandleState New(bool sRGB)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                GL.sRGBWrite = sRGB;
                return h;
            }
        }

        public static HandleState New(Color color)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                UnityEditor.Handles.color = color;
                return h;
            }
        }

        public static HandleState New(Color color, bool sRGB)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                UnityEditor.Handles.color = color;
                GL.sRGBWrite = sRGB;
                return h;
            }
        }

        public static HandleState New(Color color, bool sRGB, CompareFunction zTest)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                UnityEditor.Handles.color = color;
                GL.sRGBWrite = sRGB;
                UnityEditor.Handles.zTest = zTest;
                return h;
            }
        }

        public static HandleState New(CompareFunction zTest)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                UnityEditor.Handles.zTest = zTest;
                return h;
            }
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            using (_PRF_Initialize.Auto())
            {
                _color = UnityEditor.Handles.color;
                _sRGB = GL.sRGBWrite;
                _zTest = UnityEditor.Handles.zTest;
            }
        }

        /// <inheritdoc />
        public override void Reset()
        {
            using (_PRF_Reset.Auto())
            {
                _color = UnityEditor.Handles.color;
                _sRGB = GL.sRGBWrite;
                _zTest = UnityEditor.Handles.zTest;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            using (_PRF_Dispose.Auto())
            {
                UnityEditor.Handles.color = _color;
                GL.sRGBWrite = _sRGB;
                UnityEditor.Handles.zTest = _zTest;

                Return();
            }
        }

        #endregion

        #region Profiling

        private static readonly ProfilerMarker _PRF_Dispose = new(_PRF_PFX + nameof(Dispose));

        // ReSharper disable once MemberHidesStaticFromOuterClass
        private static readonly ProfilerMarker _PRF_HandleState = new(_PRF_PFX + nameof(HandleState));

        private static readonly ProfilerMarker _PRF_New = new(_PRF_PFX + nameof(New));

        #endregion
    }
}
#endif
