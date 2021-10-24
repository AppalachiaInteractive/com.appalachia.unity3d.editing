using System;
using Appalachia.Core.ObjectPooling;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Handle
{
    internal class GizmoState : SelfPoolingObject<GizmoState>, IDisposable
    {
#region Profiling And Tracing Markers

        // ReSharper disable once MemberHidesStaticFromOuterClass
        private const string _PRF_PFX = nameof(GizmoState) + ".";
        private static readonly ProfilerMarker _PRF_GizmoState = new(_PRF_PFX + nameof(GizmoState));
        private static readonly ProfilerMarker _PRF_Dispose = new(_PRF_PFX + nameof(Dispose));

        private static readonly ProfilerMarker _PRF_New = new(_PRF_PFX + nameof(New));
        private static readonly ProfilerMarker _PRF_Reset = new(_PRF_PFX + nameof(Reset));
        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

#endregion

#pragma warning disable 612
        public GizmoState()
#pragma warning restore 612
        {
            using (_PRF_GizmoState.Auto())
            {
                _color = Gizmos.color;
                _sRGB = GL.sRGBWrite;
            }
        }

        private bool _sRGB;

        private Color _color;

        public void Dispose()
        {
            using (_PRF_Dispose.Auto())
            {
                Gizmos.color = _color;
                GL.sRGBWrite = _sRGB;

                Return();
            }
        }

        public override void Initialize()
        {
            using (_PRF_Initialize.Auto())
            {
                _color = Gizmos.color;
                _sRGB = GL.sRGBWrite;
            }
        }

        public override void Reset()
        {
            using (_PRF_Reset.Auto())
            {
                _color = Gizmos.color;
                _sRGB = GL.sRGBWrite;
            }
        }

        public static GizmoState New()
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                return h;
            }
        }

        public static GizmoState New(bool sRGB)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                GL.sRGBWrite = sRGB;
                return h;
            }
        }

        public static GizmoState New(Color color)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                Gizmos.color = color;
                return h;
            }
        }

        public static GizmoState New(Color color, bool sRGB)
        {
            using (_PRF_New.Auto())
            {
                var h = Get();
                Gizmos.color = color;
                GL.sRGBWrite = sRGB;
                return h;
            }
        }
    }
}
