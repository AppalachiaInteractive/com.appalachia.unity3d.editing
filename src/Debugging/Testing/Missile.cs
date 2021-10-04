using Appalachia.Core.Extensions;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Testing
{
    public class Missile : MonoBehaviour
    {
        public bool keepAlive;
        public double createdAt;
        public GameObject go;
        public Rigidbody rb;
        public Collider c;

        public double age => Time.time - createdAt;

        public void Initialize(GameObject go, Rigidbody rb, Collider c)
        {
            this.rb = rb;
            this.c = c;
            this.go = go;

            var splits = go.name.Split('_');

            var time = Time.time;

            if (splits.Length == 0)
            {
                go.name += $"_{time}";
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
                    go.name += $"_{time}";
                    createdAt = time;
                }
            }
        }

        public void Destroy()
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
}
