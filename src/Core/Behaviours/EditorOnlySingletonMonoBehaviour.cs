using Appalachia.Core.Extensions;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Behaviours
{
    public abstract class EditorOnlySingletonMonoBehaviour<T> : EditorOnlyMonoBehaviour
        where T : EditorOnlySingletonMonoBehaviour<T>
    {
        private const string _PRF_PFX = nameof(EditorOnlySingletonMonoBehaviour<T>) + ".";

        private static T __instance;
        private static readonly ProfilerMarker _PRF_Awake = new(_PRF_PFX + nameof(Awake));

        public static T I => _instance;
        public static T instance => _instance;
        public static T Instance => _instance;

        private static T _instance
        {
            get
            {
                if (__instance == null)
                {
                    __instance = FindObjectOfType<T>();
                }

                if (__instance == null)
                {
                    var go = new GameObject(typeof(T).Name);
                    __instance = go.AddComponent<T>();
                }

                return __instance;
            }
        }

        protected override void Internal_Awake()
        {
            using (_PRF_Awake.Auto())
            {
                if ((_instance != null) && (_instance != this))
                {
#if UNITY_EDITOR
                    Selection.objects = new Object[] {_instance.gameObject};
#endif
                    this.DestroySafely();
                }
                else
                {
                    __instance = this as T;
                }

                OnAwake();
            }
        }

        protected virtual void OnAwake()
        {
        }
    }
}
