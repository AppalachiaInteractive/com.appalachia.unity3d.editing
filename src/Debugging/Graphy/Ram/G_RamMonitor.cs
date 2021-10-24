using UnityEngine;
using UnityEngine.Profiling;

#if UNITY_5_5_OR_NEWER

#endif

namespace Appalachia.Editing.Debugging.Graphy.Ram
{
    public class G_RamMonitor : MonoBehaviour
    {
#region Methods -> Unity Callbacks

        private void Update()
        {
            AllocatedRam = Profiler.GetTotalAllocatedMemoryLong() / 1048576f;
            ReservedRam = Profiler.GetTotalReservedMemoryLong() / 1048576f;
            MonoRam = Profiler.GetMonoUsedSizeLong() / 1048576f;
        }

#endregion

#region Properties -> Public

        public float AllocatedRam { get; private set; }
        public float ReservedRam { get; private set; }
        public float MonoRam { get; private set; }

#endregion
    }
}
