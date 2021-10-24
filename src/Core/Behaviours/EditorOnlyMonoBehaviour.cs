#if UNITY_EDITOR

#region

using System;
using Appalachia.Core.Behaviours;
using Appalachia.Core.Labels;
using Unity.Profiling;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Core.Behaviours
{
    [ExecuteAlways]
    public abstract class EditorOnlyMonoBehaviour : AppalachiaMonoBehaviour
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(EditorOnlyMonoBehaviour) + ".";

        private static readonly ProfilerMarker _PRF_Awake = new(_PRF_PFX + "Awake");

        private static readonly ProfilerMarker _PRF_OnEnable = new(_PRF_PFX + "OnEnable");
        private static readonly ProfilerMarker _PRF_Start = new(_PRF_PFX + nameof(Start));
        private static readonly ProfilerMarker _PRF_Reset = new(_PRF_PFX + "Reset");
        protected static bool VSP_ENABLING;

        private static readonly ProfilerMarker _PRF_Ensure_EditorTag =
            new(_PRF_PFX + nameof(EnsureCorrectEditorTag));

#endregion

        [HideInInspector] public abstract EditorOnlyExclusionStyle exclusionStyle { get; }

        protected virtual void Internal_Awake()
        {
        }

        protected virtual void Internal_OnEnable()
        {
        }

        protected virtual void Internal_Reset()
        {
        }

        protected virtual void Internal_Start()
        {
        }

        public void EnsureCorrectEditorTag()
        {
            using (_PRF_Ensure_EditorTag.Auto())
            {
                var isObjectExcluded = gameObject.CompareTag(TAGS.EditorOnly);

                switch (exclusionStyle)
                {
                    case EditorOnlyExclusionStyle.Component:
                        if (isObjectExcluded)
                        {
                            gameObject.tag = TAGS._untagged;
                        }

                        break;
                    case EditorOnlyExclusionStyle.ObjectIfNoConflict:
                    {
                        if (isObjectExcluded)
                        {
                            break;
                        }

                        var others = GetComponents<EditorOnlyMonoBehaviour>();

                        var hasOtherComponentThatDoesNotExcludeObject = false;
                        for (var i = 0; i < others.Length; i++)
                        {
                            var other = others[i];

                            if (other == this)
                            {
                                continue;
                            }

                            if (other.exclusionStyle == EditorOnlyExclusionStyle.Component)
                            {
                                hasOtherComponentThatDoesNotExcludeObject = true;
                                break;
                            }
                        }

                        if (!hasOtherComponentThatDoesNotExcludeObject)
                        {
                            gameObject.tag = TAGS.EditorOnly;
                            SetDirty();
                        }
                    }
                        break;
                    case EditorOnlyExclusionStyle.ObjectForceConflict:
                    {
                        if (isObjectExcluded)
                        {
                            break;
                        }

                        var others = GetComponents<EditorOnlyMonoBehaviour>();

                        var hasOtherComponentThatDoesNotExcludeObject = false;
                        for (var i = 0; i < others.Length; i++)
                        {
                            var other = others[i];

                            if (other == this)
                            {
                                continue;
                            }

                            if (other.exclusionStyle == EditorOnlyExclusionStyle.Component)
                            {
                                hasOtherComponentThatDoesNotExcludeObject = true;
                                break;
                            }
                        }

                        if (hasOtherComponentThatDoesNotExcludeObject)
                        {
                            Debug.LogError("EditorOnly Object CONFLICT!", this);
                        }
                        else
                        {
                            gameObject.tag = TAGS.EditorOnly;
                            SetDirty();
                        }
                    }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected void Awake()
        {
            using (_PRF_Awake.Auto())
            {
                VSP_ENABLING = false; //VegetationSystemPro.EXECUTING_ENABLE;
                if (VSP_ENABLING)
                {
                    return;
                }

                if (!VSP_ENABLING && !Application.isPlaying)
                {
                    EnsureCorrectEditorTag();
                }

                Internal_Awake();
            }
        }

        protected void OnEnable()
        {
            using (_PRF_OnEnable.Auto())
            {
                VSP_ENABLING = false; //VegetationSystemPro.EXECUTING_ENABLE;
                if (VSP_ENABLING)
                {
                    return;
                }

                if (!Application.isPlaying)
                {
                    EnsureCorrectEditorTag();
                }

                Internal_OnEnable();
            }
        }

        protected void Reset()
        {
            using (_PRF_Reset.Auto())
            {
                VSP_ENABLING = false; //VegetationSystemPro.EXECUTING_ENABLE;
                if (VSP_ENABLING)
                {
                    return;
                }

                if (!Application.isPlaying)
                {
                    EnsureCorrectEditorTag();
                }

                Internal_Reset();
            }
        }

        protected void Start()
        {
            using (_PRF_Start.Auto())
            {
                VSP_ENABLING = false; //VegetationSystemPro.EXECUTING_ENABLE;
                if (VSP_ENABLING)
                {
                    return;
                }

                if (!Application.isPlaying)
                {
                    EnsureCorrectEditorTag();
                }

                Internal_Start();
            }
        }
    }
}

#endif
