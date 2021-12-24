using System;
using System.Collections.Generic;
using Appalachia.Core.Objects.Root;
using Sirenix.OdinInspector;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Debugging
{
    [ExecuteAlways]
    public sealed class GrounderPatrol : AppalachiaBehaviour<GrounderPatrol>
    {
        #region Fields and Autoproperties

        public bool freeze;
        public bool pointsAreRelative = true;

        public float positionSpeed = .1f;
        public float rotationSpeed = .1f;
        public float yOffset = .5f;
        [ReadOnly] public int targetIndex;
        public List<Vector3> points = new();

        [ReadOnly] public Vector3 lastPosition;
        public Vector3 origin;
        [ReadOnly] public Vector3 targetForward;

        [ReadOnly] public Vector3 targetPosition;
        [ReadOnly] public Vector3 targetUp;

        private RaycastHit[] hits = new RaycastHit[16];

        #endregion

        #region Event Functions

        private void Update()
        {
            using (_PRF_Update.Auto())
            {
                if (!DependenciesAreReady)
                {
                    return;
                }

                try
                {
                    if (origin == Vector3.zero)
                    {
                        origin = transform.position;
                    }

                    if (freeze)
                    {
                        return;
                    }

                    targetIndex = Mathf.Clamp(targetIndex, 0, points.Count);

                    if (points.Count == 0)
                    {
                        return;
                    }

                    var t = transform;

                    var position = t.position;
                    var forward = t.forward;
                    var up = t.up;

                    if ((position == targetPosition) && (targetPosition == lastPosition))
                    {
                        targetIndex += 1;

                        if (targetIndex >= points.Count)
                        {
                            targetIndex = 0;
                        }
                    }

                    var newPoint = points[targetIndex];

                    if (pointsAreRelative)
                    {
                        targetPosition = origin + newPoint;
                    }
                    else
                    {
                        targetPosition = newPoint;
                    }

                    if (hits == null)
                    {
                        hits = new RaycastHit[16];
                    }

                    var terrain = Terrain.activeTerrain;

                    targetPosition.y = yOffset + terrain.SampleHeight(targetPosition);

                    var newPosition = Vector3.MoveTowards(
                        position,
                        targetPosition,
                        positionSpeed * Time.deltaTime
                    );

                    newPosition.y = yOffset + terrain.SampleHeight(newPosition);
                    t.position = newPosition;

                    targetForward = (targetPosition - position).normalized;

                    t.forward = Vector3.RotateTowards(
                        forward,
                        targetForward,
                        rotationSpeed * Time.deltaTime,
                        rotationSpeed * Time.deltaTime
                    );

                    var normal = terrain.terrainData.GetInterpolatedNormal(
                        targetPosition.x,
                        targetPosition.z
                    );

                    targetUp = (normal + Vector3.up + Vector3.up) / 3f;

                    t.up = Vector3.RotateTowards(
                        up,
                        targetUp,
                        rotationSpeed * Time.deltaTime,
                        rotationSpeed * Time.deltaTime
                    );

                    lastPosition = position;
                }
                catch (Exception ex)
                {
                    Context.Log.Error(ex);
                }
            }
        }

        #endregion

        [Button]
        private void ResetOrigin()
        {
            origin = transform.position;
        }

        #region Profiling

        private const string _PRF_PFX = nameof(GrounderPatrol) + ".";

        private static readonly ProfilerMarker _PRF_Update = new ProfilerMarker(_PRF_PFX + nameof(Update));

        #endregion
    }
}
