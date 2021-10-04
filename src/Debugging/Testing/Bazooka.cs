#region

using System.Collections.Generic;
using Appalachia.Base.Behaviours;
using Appalachia.Core.Extensions;
using Appalachia.Core.Layers;
using Appalachia.Core.Types.Enums;
using Appalachia.Simulation.Core;
using Appalachia.Utility.Colors;
using Appalachia.Utility.Constants;
using Sirenix.OdinInspector;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Testing
{

#endregion

    [ExecuteAlways]
    public class Bazooka : SingletonMonoBehaviour<Bazooka>
    {
        private const string _PRF_PFX = nameof(Bazooka) + ".";

        private static readonly ProfilerMarker _PRF_FindOrphanedMissiles =
            new(_PRF_PFX + nameof(FindOrphanedMissiles));

        private static readonly ProfilerMarker _PRF_CheckOutstandingMissiles =
            new(_PRF_PFX + nameof(CheckOutstandingMissiles));

        private static readonly ProfilerMarker _PRF_OnEnable = new(_PRF_PFX + nameof(OnEnable));

        private static readonly ProfilerMarker _PRF_Fire = new(_PRF_PFX + nameof(Fire));

        private static readonly ProfilerMarker _PRF_SoftFire = new(_PRF_PFX + nameof(SoftFire));

        private static readonly ProfilerMarker _PRF_Drop = new(_PRF_PFX + nameof(Drop));

        private static readonly ProfilerMarker _PRF_OnDrawGizmosSelected =
            new(_PRF_PFX + nameof(OnDrawGizmosSelected));

        private static readonly ProfilerMarker _PRF_Update = new(_PRF_PFX + nameof(Update));

        private static readonly ProfilerMarker _PRF_FindMissileRoot =
            new(_PRF_PFX + nameof(FindMissileRoot));

        [FoldoutGroup("Advanced")]
        public PrimitiveColliderType defaultPrimitive = PrimitiveColliderType.Sphere;

        [FoldoutGroup("Advanced")]
        public Vector2 allowedScaleRange = new(.05f, 3f);

        [FoldoutGroup("Advanced")]
        public Vector2 allowedMassRange = new(.1f, 10f);

        [FoldoutGroup("Advanced")]
        public Vector2 allowedForceRange = new(.5f, 25f);

        [FoldoutGroup("Advanced")]
        public Vector2Int allowedOutstanding = new(1, 100);

        [FoldoutGroup("Advanced")]
        [MinMaxSlider(-1, 1, true)]
        public Vector2 allowedLeftToRightRange = new(-.5f, .5f);

        [FoldoutGroup("Advanced")]
        public Vector2 allowedLifetimes = new(1.0f, 180f);

        [FoldoutGroup("General")]
        [ToggleLeft]
        public bool exact;

        [FoldoutGroup("General")]
        public LayerSelection layer;

        [FoldoutGroup("Missile")]
        public GameObject prefab;

        [FoldoutGroup("Missile")]
        public GameObject missileRoot;

        [FoldoutGroup("Missile")]
        [ToggleLeft]
        public bool uniformScale;

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showScalingUniform))]
        [PropertyRange(nameof(_scaleMin), nameof(_scaleMax))]
        public float scalingUniform = 1.0f;

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showScaling))]
        [PropertyRange(nameof(_scaleMin), nameof(_scaleMax))]
        public float scalingX = 1.0f;

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showScaling))]
        [PropertyRange(nameof(_scaleMin), nameof(_scaleMax))]
        public float scalingY = 1.0f;

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showScaling))]
        [PropertyRange(nameof(_scaleMin), nameof(_scaleMax))]
        public float scalingZ = 1.0f;

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showScalingRangeUniform))]
        [MinMaxSlider(nameof(_scaleMin), nameof(_scaleMax), true)]
        public Vector2 scalingRangeUniform = new(.8f, 1.2f);

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showScalingRange))]
        [MinMaxSlider(nameof(_scaleMin), nameof(_scaleMax), true)]
        public Vector2 scalingRangeX = new(.8f, 1.2f);

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showScalingRange))]
        [MinMaxSlider(nameof(_scaleMin), nameof(_scaleMax), true)]
        public Vector2 scalingRangeY = new(.8f, 1.2f);

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showScalingRange))]
        [MinMaxSlider(nameof(_scaleMin), nameof(_scaleMax), true)]
        public Vector2 scalingRangeZ = new(.8f, 1.2f);

        [FoldoutGroup("Missile")]
        [ToggleLeft]
        public bool updateMaterial = true;

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(updateMaterial))]
        public PhysicMaterial material;

        [FoldoutGroup("Missile")]
        [ToggleLeft]
        public bool updateMass = true;

        [FoldoutGroup("Missile")]
        [ToggleLeft]
        [ShowIf(nameof(_showMass))]
        public bool scaleMass = true;

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showMass))]
        [PropertyRange(nameof(_massMin), nameof(_massMax))]
        public float mass = 1.0f;

        [FoldoutGroup("Missile")]
        [ShowIf(nameof(_showMassRange))]
        [MinMaxSlider(nameof(_massMin), nameof(_massMax), true)]
        public Vector2 massRange = new(.8f, 1.2f);

        [FoldoutGroup("Force")] public ForceMode forceMode = ForceMode.VelocityChange;

        [FoldoutGroup("Force")]
        public CollisionDetectionMode collisionDetectionMode =
            CollisionDetectionMode.ContinuousDynamic;

        [FoldoutGroup("Force")]
        public RigidbodyInterpolation interpolation = RigidbodyInterpolation.Interpolate;

        [FoldoutGroup("Force")]
        [ShowIf(nameof(exact))]
        [PropertyRange(nameof(_allowedForceRangeMin), nameof(_allowedForceRangeMax))]
        public float force = 1.0f;

        [FoldoutGroup("Force")]
        [HideIf(nameof(exact))]
        [MinMaxSlider(nameof(_allowedForceRangeMin), nameof(_allowedForceRangeMax), true)]
        public Vector2 forceRange = new(1f, 2f);

        [FoldoutGroup("Force")]
        [PropertyRange(0.0f, 1f)]
        public float forceScalingPerMeter = 0.1f;

        [FoldoutGroup("Force")]
        [ShowIf(nameof(exact))]
        [PropertyRange(-1, 1)]
        public float forceForwardToVerticalRatio = 0.1f;

        [FoldoutGroup("Force")]
        [HideIf(nameof(exact))]
        [MinMaxSlider(-1.0f, 1.0f, true)]
        public Vector2 forceForwardToVerticalRatioRange = new(-.1f, .1f);

        [FoldoutGroup("Force")]
        [ShowIf(nameof(exact))]
        [PropertyRange(nameof(_allowedLeftToRightRatioMin), nameof(_allowedLeftToRightRatioMax))]
        public float forceLeftToRightRatio;

        [FoldoutGroup("Force")]
        [HideIf(nameof(exact))]
        [MinMaxSlider(
            nameof(_allowedLeftToRightRatioMin),
            nameof(_allowedLeftToRightRatioMax),
            true
        )]
        public Vector2 forceLeftToRightRatioRange = new(-.25f, .25f);

        [FoldoutGroup("Limits")] public bool limited = true;

        [FoldoutGroup("Limits")]
        [ShowIf(nameof(limited))]
        [PropertyRange(nameof(_allowedOutstandingMin), nameof(_allowedOutstandingMax))]
        public int outstandingFires = 15;

        [FoldoutGroup("Limits")]
        [ShowIf(nameof(limited))]
        [PropertyRange(nameof(_allowedLifetimesMin), nameof(_allowedLifetimesMax))]
        public float maxLife = 30;

        private Queue<Missile> _backupMissiles;

        private float _fireStrength = 1.0f;

        private bool _generationQueued;

        private readonly RaycastHit[] _hits = new RaycastHit[4];

        private Queue<Missile> _missiles;
        private Vector3 _scalingVector;

        private Transform _t;
        private Collider c;
        private float missile_force;

        private Vector3 missile_forceVector;
        private float missile_mass;
        private Rigidbody rb;

        private float _allowedForceRangeMin => allowedForceRange.x;
        private float _allowedForceRangeMax => allowedForceRange.y;
        private float _massMin => allowedMassRange.x;
        private float _massMax => allowedMassRange.y;
        private float _scaleMin => allowedScaleRange.x;
        private float _scaleMax => allowedScaleRange.y;
        private int _allowedOutstandingMin => allowedOutstanding.x;
        private int _allowedOutstandingMax => allowedOutstanding.y;
        private float _allowedLifetimesMin => allowedLifetimes.x;
        private float _allowedLifetimesMax => allowedLifetimes.y;
        private float _allowedLeftToRightRatioMin => allowedLeftToRightRange.x;
        private float _allowedLeftToRightRatioMax => allowedLeftToRightRange.y;

        private bool _showScalingUniform => exact && uniformScale;
        private bool _showScaling => exact && !uniformScale;

        private bool _showScalingRangeUniform => !exact && uniformScale;
        private bool _showScalingRange => !exact && !uniformScale;

        private bool _showMass => updateMass && exact;

        private bool _showMassRange => updateMass & !exact;

        private Color _fire => Colors.CadmiumOrange;
        private Color _softFire => Colors.CadmiumYellow;
        private Color _drop => Colors.DeepSkyBlue1;
#if UNITY_EDITOR
        private void Update()
#else
        private void FixedUpdate()
#endif
        {
            using (_PRF_Update.Auto())
            {
                if (rb != null)
                {
                    rb.AddForce(missile_forceVector, forceMode);

                    OnPostFire?.Invoke(this, rb.gameObject);
                    rb = null;
                }

                if (!_generationQueued)
                {
                    CheckOutstandingMissiles();
                    return;
                }

                if (!PhysicsSimulator.IsSimulationActive)
                {
                    PhysicsSimulator.SetEnabled(true);
                }

                _generationQueued = false;

                if (prefab == null)
                {
                    prefab = GameObject.CreatePrimitive(
                        defaultPrimitive == PrimitiveColliderType.Capsule
                            ? PrimitiveType.Capsule
                            : defaultPrimitive == PrimitiveColliderType.Cube
                                ? PrimitiveType.Cube
                                : PrimitiveType.Sphere
                    );

                    c = prefab.GetComponent<Collider>();
                    rb = prefab.GetComponent<Rigidbody>();

                    if (c == null)
                    {
                        c = defaultPrimitive == PrimitiveColliderType.Capsule
                            ? prefab.AddComponent<CapsuleCollider>()
                            : defaultPrimitive == PrimitiveColliderType.Cube
                                ? prefab.AddComponent<CapsuleCollider>()
                                : prefab.AddComponent<SphereCollider>();
                    }

                    if (rb == null)
                    {
                        rb = prefab.AddComponent<Rigidbody>();
                    }

                    rb.isKinematic = true;
                }

                OnPreFire?.Invoke(this);

                FindMissileRoot();

                var missile = Instantiate(prefab, missileRoot.transform, true);
                missile.name += $"_{Time.time}";
                missile.layer = layer.layer;

                c = missile.GetComponentsInChildren<Collider>()
                           .FirstOrDefault_NoAlloc(cl => !cl.isTrigger && cl.enabled);
                rb = missile.GetComponentsInChildren<Rigidbody>().FirstOrDefault_NoAlloc();

                if ((c == null) || (rb == null))
                {
                    Debug.LogWarning("No collider or rigidbody!");
                    return;
                }

                if (_missiles == null)
                {
                    _missiles = new Queue<Missile>();
                }

                var missileComponent = missile.AddComponent<Missile>();
                missileComponent.Initialize(missile, rb, c);

                _missiles.Enqueue(missileComponent);

                var mt = missile.transform;

                mt.position = _t.position;
                mt.rotation = _t.rotation;

                missile_forceVector = Vector3.forward;

                if (exact)
                {
                    _scalingVector.x = uniformScale ? scalingUniform : scalingX;
                    _scalingVector.y = uniformScale ? scalingUniform : scalingY;
                    _scalingVector.z = uniformScale ? scalingUniform : scalingZ;

                    var scaleNormalized = uniformScale
                        ? _scalingVector.x.normalize(scalingRangeUniform)
                        : _scalingVector.normalize(scalingRangeX, scalingRangeY, scalingRangeZ)
                                        .average();

                    missile_force = force * scaleNormalized;
                    missile_mass = mass * scaleNormalized;

                    var verticalVector = Vector3.forward;
                    if (forceForwardToVerticalRatio > 0)
                    {
                        verticalVector = Vector3.Lerp(
                            verticalVector,
                            Vector3.up,
                            forceForwardToVerticalRatio
                        );
                    }
                    else if (forceForwardToVerticalRatio < 0)
                    {
                        verticalVector = Vector3.Lerp(
                            verticalVector,
                            Vector3.down,
                            -forceForwardToVerticalRatio
                        );
                    }

                    var horizontalVector = Vector3.forward;

                    if (forceLeftToRightRatio > 0)
                    {
                        horizontalVector = Vector3.Lerp(
                            horizontalVector,
                            Vector3.right,
                            forceLeftToRightRatio
                        );
                    }
                    else if (forceLeftToRightRatio < 0)
                    {
                        horizontalVector = Vector3.Lerp(
                            horizontalVector,
                            Vector3.left,
                            -forceLeftToRightRatio
                        );
                    }

                    missile_forceVector = verticalVector + horizontalVector;
                }
                else
                {
                    _scalingVector.x = uniformScale
                        ? Random.Range(scalingRangeUniform.x, scalingRangeUniform.y)
                        : Random.Range(scalingRangeX.x,       scalingRangeX.y);
                    _scalingVector.y = uniformScale
                        ? _scalingVector.x
                        : Random.Range(scalingRangeY.x, scalingRangeY.y);
                    _scalingVector.z = uniformScale
                        ? _scalingVector.x
                        : Random.Range(scalingRangeZ.x, scalingRangeZ.y);

                    var scaleNormalized = uniformScale
                        ? _scalingVector.x.normalize(scalingRangeUniform)
                        : _scalingVector.normalize(scalingRangeX, scalingRangeY, scalingRangeZ)
                                        .average();

                    missile_force = scaleNormalized * Random.Range(forceRange.x, forceRange.y);
                    missile_mass = scaleNormalized * Random.Range(massRange.x,   massRange.y);

                    var verticalRatio = Random.Range(
                        forceForwardToVerticalRatioRange.x,
                        forceForwardToVerticalRatioRange.y
                    );
                    var verticalVector = Vector3.forward;
                    if (verticalRatio > 0)
                    {
                        verticalVector = Vector3.Lerp(verticalVector, Vector3.up, verticalRatio);
                    }
                    else if (verticalRatio < 0)
                    {
                        verticalVector = Vector3.Lerp(verticalVector, Vector3.down, -verticalRatio);
                    }

                    var horizontalRatio = Random.Range(
                        forceLeftToRightRatioRange.x,
                        forceLeftToRightRatioRange.y
                    );
                    var horizontalVector = Vector3.forward;

                    if (horizontalRatio > 0)
                    {
                        horizontalVector = Vector3.Lerp(
                            horizontalVector,
                            Vector3.right,
                            horizontalRatio
                        );
                    }
                    else if (horizontalRatio < 0)
                    {
                        horizontalVector = Vector3.Lerp(
                            horizontalVector,
                            Vector3.left,
                            -horizontalRatio
                        );
                    }

                    missile_forceVector = verticalVector + horizontalVector;
                }

                mt.localScale = Vector3.Scale(mt.localScale, _scalingVector);

                if (updateMass)
                {
                    if (scaleMass)
                    {
                        missile_mass *= mt.localScale.magnitude;
                    }

                    rb.mass = missile_mass;
                }

                if (updateMaterial)
                {
                    c.sharedMaterial = material;
                }

                rb.interpolation = interpolation;
                /*rb.detectCollisions = true;
            rb.useGravity = true;
            rb.isKinematic = false;*/
                rb.collisionDetectionMode = collisionDetectionMode;

                var missileVector = mt.TransformVector(missile_forceVector.normalized).normalized;

                var hitCount = Physics.RaycastNonAlloc(_transform.position, missileVector, _hits);

                if (hitCount > 0)
                {
                    var hit = _hits[0];

                    missile_force += forceScalingPerMeter * hit.distance;
                }

                missile_forceVector = missile_force * _fireStrength * missileVector;

                CheckOutstandingMissiles();
            }
        }

        public void OnEnable()
        {
            using (_PRF_OnEnable.Auto())
            {
                _t = transform;

                FindOrphanedMissiles();
            }
        }

        private void OnDrawGizmosSelected()
        {
            using (_PRF_OnDrawGizmosSelected.Auto())
            {
                if (!GizmoCameraChecker.ShouldRenderGizmos())
                {
                    return;
                }

                Gizmos.DrawRay(_t.position, missile_forceVector);
            }
        }

        public event OnPreFire OnPreFire;
        public event OnPostFire OnPostFire;

        [Button(ButtonSizes.Large)]
        [LabelText("Fire!!!")]
        [GUIColor(nameof(_fire))]
        public void Fire()
        {
            using (_PRF_Fire.Auto())
            {
                _generationQueued = true;
                _fireStrength = 1.0f;
            }
        }

        [Button(ButtonSizes.Large)]
        [LabelText("Fire")]
        [GUIColor(nameof(_softFire))]
        public void SoftFire()
        {
            using (_PRF_SoftFire.Auto())
            {
                _generationQueued = true;
                _fireStrength = 0.25f;
            }
        }

        [Button(ButtonSizes.Large)]
        [LabelText("Drop")]
        [GUIColor(nameof(_drop))]
        public void Drop()
        {
            using (_PRF_Drop.Auto())
            {
                _generationQueued = true;
                _fireStrength = 0.05f;
            }
        }

        private void FindMissileRoot()
        {
            using (_PRF_FindMissileRoot.Auto())
            {
                if (missileRoot == null)
                {
                    missileRoot = GameObject.Find("_missiles");

                    if (missileRoot == null)
                    {
                        missileRoot = new GameObject("_missiles");
                        var mrt = missileRoot.transform;
                        mrt.position = Vector3.zero;
                        mrt.rotation = Quaternion.identity;
                        mrt.localScale = Vector3.one;
                    }
                }

                missileRoot.hideFlags = HideFlags.DontSave;
            }
        }

        [ButtonGroup]
        private void FindOrphanedMissiles()
        {
            using (_PRF_FindOrphanedMissiles.Auto())
            {
                if (_missiles == null)
                {
                    _missiles = new Queue<Missile>();
                }

                FindMissileRoot();

                if (_missiles.Count != missileRoot.transform.childCount)
                {
                    _missiles.Clear();

                    for (var i = 0; i < missileRoot.transform.childCount; i++)
                    {
                        var child = missileRoot.transform.GetChild(i);
                        var childObject = child.gameObject;
                        var missile = childObject.GetComponent<Missile>();

                        if (missile == null)
                        {
                            missile = childObject.AddComponent<Missile>();
                            missile.Initialize(
                                childObject,
                                child.GetComponent<Rigidbody>(),
                                child.GetComponent<Collider>()
                            );
                        }

                        _missiles.Enqueue(missile);
                    }
                }
            }
        }

        [ButtonGroup]
        private void CheckOutstandingMissiles()
        {
            using (_PRF_CheckOutstandingMissiles.Auto())
            {
                if (!limited)
                {
                    return;
                }

                if (_backupMissiles == null)
                {
                    _backupMissiles = new Queue<Missile>();
                }

                if (_missiles == null)
                {
                    _missiles = new Queue<Missile>();
                }

                FindOrphanedMissiles();

                while (_missiles.Count > 0)
                {
                    var missile = _missiles.Dequeue();

                    if (missile.go == null)
                    {
                        continue;
                    }

                    if ((missile.age > maxLife) ||
                        ((_missiles.Count + _backupMissiles.Count) > outstandingFires))
                    {
                        missile.Destroy();
                    }
                    else if ((missile.go.transform.position.y < -1000) ||
                             (missile.rb.velocity.magnitude > 250f))
                    {
                        missile.Destroy();
                    }
                    else
                    {
                        _backupMissiles.Enqueue(missile);
                    }
                }

                var t = _missiles;
                _missiles = _backupMissiles;
                _backupMissiles = t;
            }
        }

        [ButtonGroup]
        private void DestroyAllMissiles()
        {
            using (_PRF_CheckOutstandingMissiles.Auto())
            {
                FindOrphanedMissiles();

                while (_missiles.Count > 0)
                {
                    var missile = _missiles.Dequeue();

                    missile.Destroy();
                }
            }
        }

#if UNITY_EDITOR
        [MenuItem("Tools/Bazooka!/Fire!!!!" + SHC.CTRL_ALT_SHFT_F)]
        private static void MenuFire()
        {
            instance._generationQueued = true;
            instance._fireStrength = 1.0f;
        }

        [MenuItem("Tools/Bazooka!/Fire" + SHC.CTRL_ALT_SHFT_R)]
        private static void MenuSoftFire()
        {
            instance._generationQueued = true;
            instance._fireStrength = 0.25f;
        }

        [MenuItem("Tools/Bazooka!/Drop Bomb!" + SHC.CTRL_ALT_SHFT_D)]
        private static void MenuDrop()
        {
            instance._generationQueued = true;
            instance._fireStrength = 0.05f;
        }

        [MenuItem("Tools/Bazooka!/Destroy Missiles!" + SHC.CTRL_ALT_SHFT_C)]
        private static void MenuClear()
        {
            instance.DestroyAllMissiles();
        }

        [MenuItem("Tools/Bazooka!/Load Missile!" + SHC.CTRL_ALT_SHFT_M)]
        private static void MenuSetMissile()
        {
            if ((Selection.gameObjects != null) && (Selection.gameObjects.Length == 1))
            {
                instance.prefab = Selection.gameObjects[0];
            }
        }
#endif
    }
}
