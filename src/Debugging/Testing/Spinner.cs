using System;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Core.Layers;
using Appalachia.Core.Objects.Initialization;
using Appalachia.Core.Objects.Root;
using Appalachia.Utility.Async;
using Sirenix.OdinInspector;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Testing
{
    [ExecuteAlways]
    public sealed class Spinner : AppalachiaBehaviour<Spinner>
    {
        public enum AxisSource
        {
            World = 0,
            Local = 10,
            Terrain = 20
        }

        #region Fields and Autoproperties

        [SmartLabel] public AxisSource axisSource = AxisSource.World;

        [PropertyRange(.01f, 1f)]
        [SmartLabel]
        public float spinRate = .2f;

        private RaycastHit[] _hits;

        private Transform _t;

        #endregion

        #region Event Functions

        public void Update()
        {
            using (_PRF_Update.Auto())
            {
                if (!DependenciesAreReady || !FullyInitialized)
                {
                    return;
                }

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

                        var hitCount = Physics.RaycastNonAlloc(
                            _t.position,
                            Vector3.down,
                            _hits,
                            100f,
                            Layers.ByName.Terrain.Mask
                        );

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

        #endregion

        protected override async AppaTask Initialize(Initializer initializer)
        {
            using (_PRF_Initialize.Auto())
            {
                await base.Initialize(initializer);

                _t = transform;
                _t.rotation = Quaternion.identity;
            }
        }

        #region Profiling

        private const string _PRF_PFX = nameof(Spinner) + ".";

        private static readonly ProfilerMarker _PRF_Update = new ProfilerMarker(_PRF_PFX + nameof(Update));

        private static readonly ProfilerMarker _PRF_Initialize =
            new ProfilerMarker(_PRF_PFX + nameof(Initialize));

        #endregion
    }
}
