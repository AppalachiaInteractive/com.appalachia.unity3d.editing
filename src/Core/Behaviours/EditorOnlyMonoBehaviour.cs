#region

using System;
using Appalachia.Core.Behaviours;
using Appalachia.Core.Labels;
using Appalachia.Utility.Extensions;
using Appalachia.Utility.Logging;
using Unity.Profiling;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Core.Behaviours
{
    [ExecuteAlways]
    public abstract class EditorOnlyBehaviour : AppalachiaBehaviour
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(EditorOnlyBehaviour) + ".";

        private static readonly ProfilerMarker _PRF_Awake = new(_PRF_PFX + "Awake");

        private static readonly ProfilerMarker _PRF_OnEnable = new(_PRF_PFX + "OnEnable");
        private static readonly ProfilerMarker _PRF_Start = new(_PRF_PFX + nameof(Start));
        private static readonly ProfilerMarker _PRF_Reset = new(_PRF_PFX + "Reset");
        protected static bool VSP_ENABLING;
#if UNITY_EDITOR

        private static readonly ProfilerMarker _PRF_Ensure_EditorTag =
            new(_PRF_PFX + nameof(EnsureCorrectEditorTag));
#endif

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
#if UNITY_EDITOR

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

                        var others = GetComponents<EditorOnlyBehaviour>();

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
                           this.MarkAsModified();
                        }
                    }
                        break;
                    case EditorOnlyExclusionStyle.ObjectForceConflict:
                    {
                        if (isObjectExcluded)
                        {
                            break;
                        }

                        var others = GetComponents<EditorOnlyBehaviour>();

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
                            AppaLog.Error("EditorOnly Object CONFLICT!", this);
                        }
                        else
                        {
                            gameObject.tag = TAGS.EditorOnly;
                           this.MarkAsModified();
                        }
                    }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
#endif

        protected override void Awake()
        {
            using (_PRF_Awake.Auto())
            {
                base.Awake();
                
                VSP_ENABLING = false; //VegetationSystemPro.EXECUTING_ENABLE;
                if (VSP_ENABLING)
                {
                    return;
                }

#if UNITY_EDITOR
                if (!VSP_ENABLING && !Application.isPlaying)
                {
                    EnsureCorrectEditorTag();
                }
#endif

                Internal_Awake();
            }
        }

        protected override void OnEnable()
        {
            using (_PRF_OnEnable.Auto())
            {
                base.OnEnable();
                
                VSP_ENABLING = false; //VegetationSystemPro.EXECUTING_ENABLE;
                if (VSP_ENABLING)
                {
                    return;
                }

#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    EnsureCorrectEditorTag();
                }
#endif

                Internal_OnEnable();
            }
        }

        protected override void Reset()
        {
            using (_PRF_Reset.Auto())
            {
                base.Reset();
                
                VSP_ENABLING = false; //VegetationSystemPro.EXECUTING_ENABLE;
                if (VSP_ENABLING)
                {
                    return;
                }

#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    EnsureCorrectEditorTag();
                }
#endif

                Internal_Reset();
            }
        }

        protected override void Start()
        {
            using (_PRF_Start.Auto())
            {
                base.Start();
                
                VSP_ENABLING = false; //VegetationSystemPro.EXECUTING_ENABLE;
                if (VSP_ENABLING)
                {
                    return;
                }

#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    EnsureCorrectEditorTag();
                }
#endif

                Internal_Start();
            }
        }
    }
}
