using Appalachia.Core.Objects.Root;
using Appalachia.Utility.Extensions;
using Appalachia.Utility.Strings;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Testing
{
    public sealed class Missile : AppalachiaBehaviour<Missile>
    {
        #region Fields and Autoproperties

        public bool keepAlive;
        public Collider c;
        public double createdAt;
        public GameObject go;
        public Rigidbody rb;

        #endregion

        public double age => Time.time - createdAt;

        public void Destroy()
        {
            using (_PRF_Destroy.Auto())
            {
                if (keepAlive)
                {
                    return;
                }

                go.DestroySafely();
                if (rb != null)
                {
                    rb.DestroySafely();
                }

                if (c != null)
                {
                    c.DestroySafely();
                }
            }
        }

        public void InitializeComponents(GameObject go, Rigidbody rb, Collider c)
        {
            using (_PRF_InitializeComponents.Auto())
            {
                this.rb = rb;
                this.c = c;
                this.go = go;

                var splits = go.name.Split('_');

                var time = Time.time;

                if (splits.Length == 0)
                {
                    go.name = ZString.Format("{0}_{1}", go.name, time);

                    createdAt = time;
                }
                else
                {
                    var last = splits[splits.Length - 1];
                    if (double.TryParse(last, out var created))
                    {
                        createdAt = created;
                    }
                    else
                    {
                        go.name += ZString.Format("_{0}", time);
                        createdAt = time;
                    }
                }
            }
        }

        #region Profiling

        private static readonly ProfilerMarker _PRF_Destroy = new ProfilerMarker(_PRF_PFX + nameof(Destroy));

        private static readonly ProfilerMarker _PRF_InitializeComponents =
            new ProfilerMarker(_PRF_PFX + nameof(InitializeComponents));

        #endregion
    }
}
