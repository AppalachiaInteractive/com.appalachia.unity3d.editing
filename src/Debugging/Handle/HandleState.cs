using System;
using Appalachia.Core.ObjectPooling;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Appalachia.Editing.Debugging.Handle
{
    internal class HandleState : SelfPoolingObject<HandleState>, IDisposable
    {
#region Profiling And Tracing Markers

        // ReSharper disable once MemberHidesStaticFromOuterClass
        private const string _PRF_PFX = nameof(HandleState) + ".";
        private static readonly ProfilerMarker _PRF_HandleState = new(_PRF_PFX + nameof(HandleState));
        private static readonly ProfilerMarker _PRF_Dispose = new(_PRF_PFX + nameof(Dispose));

        private static readonly ProfilerMarker _PRF_New = new(_PRF_PFX + nameof(New));
        private static readonly ProfilerMarker _PRF_Reset = new(_PRF_PFX + nameof(Reset));
        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

#endregion

#pragma warning disable 612
        public HandleState()
#pragma warning restore 612
        {
            using (_PRF_HandleState.Auto())
            {
                _color = Handles.color;
                _sRGB = GL.sRGBWrite;
                _zTest = Handles.zTest;
            }
        }

        private bool _sRGB;

        private Color _color;
        private CompareFunction _zTest;

        public void Dispose()
        {
            using (_PRF_Dispose.Auto())
            {
                Handles.color = _color;
                GL.sRGBWrite = _sRGB;
                Handles.zTest = _zTest;

                Return();
            }
        }

        public override void Initialize()
        {
            using (_PRF_Initialize.Auto())
            {
                _color = Handles.color;
                _sRGB = GL.sRGBWrite;
                _zTest = Handles.zTest;
            }
        }

        public override void Reset()
        {
            using (_PRF_Reset.Auto())
            {
                _color = Handles.color;
                _sRGB = GL.sRGBWrite;
                _zTest = Handles.zTest;
            }
        }

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
                Handles.color = color;
                return h;
            }
        }

        public static HandleState New(Color color, bool sRGB)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                Handles.color = color;
                GL.sRGBWrite = sRGB;
                return h;
            }
        }

        public static HandleState New(Color color, bool sRGB, CompareFunction zTest)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                Handles.color = color;
                GL.sRGBWrite = sRGB;
                Handles.zTest = zTest;
                return h;
            }
        }

        public static HandleState New(CompareFunction zTest)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                Handles.zTest = zTest;
                return h;
            }
        }
    }
}
