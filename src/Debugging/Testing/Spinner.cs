using System;
using Appalachia.Core.Behaviours;
using Appalachia.Core.Editing.Attributes;
using Appalachia.Core.Layers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Core.Testing
{
    [ExecuteAlways]
    public class Spinner : InternalMonoBehaviour
    {
        public enum AxisSource
        {
            World = 0,
            Local = 10,
            Terrain = 20
        }
        
        [PropertyRange(.01f, 1f)]
        [SmartLabel]
        public float spinRate = .2f;

        [SmartLabel] 
        public AxisSource axisSource = AxisSource.World;

        private Transform _t;

        public void OnEnable()
        {
            _t = transform;
            _t.rotation = Quaternion.identity;
        }

        private RaycastHit[] _hits;
        
        public void Update()
        {
            var position = _t.position;
            var rotation = _t.rotation;

            Vector3 axis;

            switch (axisSource)
            {
                case AxisSource.World:
                    axis = Vector3.up;
                    break;
                case AxisSource.Local:
                    axis = _t.up;
                    break;
                case AxisSource.Terrain:
                    if (_hits == null)
                    {
                        _hits = new RaycastHit[3];
                    }

                    var hitCount = Physics.RaycastNonAlloc(_t.position, Vector3.down, _hits, 100f, LAYERS.Terrain.Mask);

                    if (hitCount > 0)
                    {
                        axis = _hits[0].normal;
                    }
                    else
                    {
                        axis = Vector3.up;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var adjustment = Time.deltaTime * spinRate * 360f;

            _t.rotation *= Quaternion.AngleAxis(adjustment, axis);
        }
    }
}
