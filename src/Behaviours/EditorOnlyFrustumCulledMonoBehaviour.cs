#region

using Unity.Profiling;
using UnityEngine;

#if UNITY_EDITOR

#endif

#endregion

namespace Appalachia.Editing.Behaviours
{
#if UNITY_EDITOR
    [ExecuteAlways]
    public abstract class EditorOnlyFrustumCulledMonoBehaviour : EditorOnlyMonoBehaviour
    {
        private const string _PRF_PFX = nameof(EditorOnlyFrustumCulledMonoBehaviour) + ".";

        protected bool visibilityEnabled;
        
        private static readonly ProfilerMarker _PRF_OnBecameVisible = new ProfilerMarker(_PRF_PFX + nameof(OnBecameVisible));
        private void OnBecameVisible()
        {
            using (_PRF_OnBecameVisible.Auto())
            {
                visibilityEnabled = true;
                enabled = true;
            }
        }

        private static readonly ProfilerMarker _PRF_OnBecameInvisible = new ProfilerMarker(_PRF_PFX + nameof(OnBecameInvisible));
        private void OnBecameInvisible()
        {
            using (_PRF_OnBecameInvisible.Auto())
            {
                visibilityEnabled = false;
                enabled = false;
            }
        }
    }
        
#endif
}
