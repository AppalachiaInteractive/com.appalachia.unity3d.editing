#region

using Unity.Profiling;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Core.Behaviours
{
#if UNITY_EDITOR
    [ExecuteAlways]
    public abstract class EditorOnlyFrustumCulledBehaviour<T> : EditorOnlyAppalachiaBehaviour<T>
        where T : EditorOnlyFrustumCulledBehaviour<T>
    {
        #region Fields and Autoproperties

        protected bool visibilityEnabled;

        #endregion

        #region Event Functions

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

        #endregion

        #region Profiling

        private static readonly ProfilerMarker _PRF_OnBecameInvisible =
            new(_PRF_PFX + nameof(OnBecameInvisible));

        private static readonly ProfilerMarker _PRF_OnBecameVisible = new(_PRF_PFX + nameof(OnBecameVisible));

        #endregion
    }
#endif
}
