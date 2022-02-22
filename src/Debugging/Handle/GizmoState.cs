#if UNITY_EDITOR
using System;
using Appalachia.Utility.Pooling.Objects;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Handle
{
    internal class GizmoState : SelfPoolingObject<GizmoState>, IDisposable
    {
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

        #region Fields and Autoproperties

        private bool _sRGB;

        private Color _color;

        #endregion

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

        /// <inheritdoc />
        public override void Initialize()
        {
            using (_PRF_Initialize.Auto())
            {
                _color = Gizmos.color;
                _sRGB = GL.sRGBWrite;
            }
        }

        /// <inheritdoc />
        public override void Reset()
        {
            using (_PRF_Reset.Auto())
            {
                _color = Gizmos.color;
                _sRGB = GL.sRGBWrite;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            using (_PRF_Dispose.Auto())
            {
                Gizmos.color = _color;
                GL.sRGBWrite = _sRGB;

                Return();
            }
        }

        #endregion

        #region Profiling

        private static readonly ProfilerMarker _PRF_Dispose = new(_PRF_PFX + nameof(Dispose));

        // ReSharper disable once MemberHidesStaticFromOuterClass\
        private static readonly ProfilerMarker _PRF_GizmoState = new(_PRF_PFX + nameof(GizmoState));

        private static readonly ProfilerMarker _PRF_New = new(_PRF_PFX + nameof(New));

        #endregion
    }
}

#endif
