using System;
using Appalachia.Core.Objects.Root;
using UnityEngine;

namespace Appalachia.Editing.Debugging
{
    [ExecuteAlways]
    public sealed class Grounder : AppalachiaBehaviour<Grounder>
    {
        #region Fields and Autoproperties

        public bool freeze;
        public bool locked;

        public bool terrainOnly = true;

        public float positionLerpSpeed = .1f;
        public float rotationLerpSpeed = .1f;

        public LayerMask layers;
        public Quaternion _lastRotation;
        public Quaternion _targetRotation;
        public Transform reference;
        public Vector3 _lastPosition;

        public Vector3 _targetPosition;
        public Vector3 offset;
        private readonly RaycastHit[] _hits = new RaycastHit[12];

        private RaycastHit[] hits = new RaycastHit[16];

        #endregion

        #region Event Functions

        private void Update()
        {
            using (_PRF_Update.Auto())
            {
                if (ShouldSkipUpdate)
                {
                    return;
                }

                try
                {
                    if (freeze)
                    {
                        if (locked)
                        {
                            transform.position = _targetPosition;
                            transform.rotation = _targetRotation;

                            return;
                        }

                        if ((transform.position == _targetPosition) &&
                            (transform.rotation == _targetRotation))
                        {
                            locked = true;
                        }
                        else
                        {
                            locked = false;
                        }

                        if (locked)
                        {
                            transform.position = _targetPosition;
                            transform.rotation = _targetRotation;

                            return;
                        }

                        transform.position = Vector3.Lerp(
                            transform.position,
                            _targetPosition,
                            positionLerpSpeed
                        );

                        transform.rotation = Quaternion.Slerp(
                            transform.rotation,
                            _targetRotation,
                            rotationLerpSpeed
                        );

                        return;
                    }

                    if (reference == null)
                    {
                        reference = Camera.main?.transform;

                        if (reference == null)
                        {
                            return;
                        }
                    }

                    if (hits == null)
                    {
                        hits = new RaycastHit[16];
                    }

                    var t = transform;

                    var position = t.position;
                    var rotation = t.rotation;

                    var transformedOffset = reference.TransformPoint(offset);

                    var rayOrigin = transformedOffset;

                    var targetPosition = rayOrigin;
                    var targetNormal = Vector3.up;

                    if (terrainOnly)
                    {
                        var terrain = Terrain.activeTerrain;

                        targetPosition.y = terrain.SampleHeight(rayOrigin);

                        targetNormal = terrain.terrainData.GetInterpolatedNormal(
                            targetPosition.x,
                            targetPosition.z
                        );
                    }
                    else
                    {
                        var ray = new Ray(rayOrigin, Vector3.down);

                        var hitCount = Physics.RaycastNonAlloc(
                            ray,
                            _hits,
                            128f,
                            layers,
                            QueryTriggerInteraction.Ignore
                        );

                        if (hitCount > 0)
                        {
                            var hit = _hits[0];

                            targetPosition.y = hit.point.y;

                            targetNormal = hit.normal;
                        }
                    }

                    _targetPosition = targetPosition;

                    var targetUp = (targetNormal + Vector3.up + Vector3.up) / 3f;
                    var newForward = Vector3.Cross(reference.right, targetUp);
                    _targetRotation = Quaternion.LookRotation(newForward, targetUp);

                    if ((position == _lastPosition) &&
                        (rotation == _lastRotation) &&
                        (_targetPosition == _lastPosition) &&
                        (_targetRotation == _lastRotation))
                    {
                        return;
                    }

                    t.position = Vector3.Lerp(position, _targetPosition, positionLerpSpeed);
                    t.rotation = Quaternion.Slerp(rotation, _targetRotation, rotationLerpSpeed);

                    _lastPosition = position;
                    _lastRotation = rotation;
                }
                catch (Exception ex)
                {
                    Context.Log.Error(ex);
                }
            }
        }

        #endregion
    }
}
