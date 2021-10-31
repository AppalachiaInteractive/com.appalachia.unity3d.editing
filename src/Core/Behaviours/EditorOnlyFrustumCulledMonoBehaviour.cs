#region

using Unity.Profiling;
using UnityEngine;

#if UNITY_EDITOR

#endif

#endregion

namespace Appalachia.Editing.Core.Behaviours
{
#if UNITY_EDITOR
    [ExecuteAlways]
    public abstract class EditorOnlyFrustumCulledBehaviour : EditorOnlyBehaviour
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(EditorOnlyFrustumCulledBehaviour) + ".";

        private static readonly ProfilerMarker _PRF_OnBecameVisible = new(_PRF_PFX + nameof(OnBecameVisible));

        private static readonly ProfilerMarker _PRF_OnBecameInvisible =
            new(_PRF_PFX + nameof(OnBecameInvisible));

#endregion

        protected bool visibilityEnabled;

        private void OnBecameInvisible()
        {
            using (_PRF_OnBecameInvisible.Auto())
            {
                visibilityEnabled = false;
                enabled = false;
            }
        }

        private void OnBecameVisible()
        {
            using (_PRF_OnBecameVisible.Auto())
            {
                visibilityEnabled = true;
                enabled = true;
            }
        }
    }

#endif
}
