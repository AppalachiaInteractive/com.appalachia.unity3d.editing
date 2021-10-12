using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace Appalachia.Editing.Core.Fields
{
    public sealed class UIFieldMetadataManager
    {
        private const string _PRF_PFX = nameof(UIFieldMetadataManager) + ".";
        private Dictionary<Type, Dictionary<string, EditorUIFieldMetadata>> _lookup = new();

        private static readonly ProfilerMarker _PRF_CheckInitialization = new ProfilerMarker(_PRF_PFX + nameof(CheckInitialization));
        private void CheckInitialization()
        {
            using (_PRF_CheckInitialization.Auto())
            {
                if ((_lookup == null) || (_lookup.Count == 0))
                {
                    _lookup = new Dictionary<Type, Dictionary<string, EditorUIFieldMetadata>>();
                }
            }
        }


        private static readonly ProfilerMarker _PRF_Add = new ProfilerMarker(_PRF_PFX + nameof(Add));
        public T Add<T>(
            string identifier = null,
            T instance = null,
            Action<EditorUIFieldMetadata<T>> onInitialize = null)
            where T : EditorUIFieldMetadata<T>, new()
        {
            using (_PRF_Add.Auto())
            {
                CheckInitialization();

                var searchType = typeof(T);

                if (!_lookup.ContainsKey(searchType))
                {
                    _lookup.Add(searchType, new Dictionary<string, EditorUIFieldMetadata>());
                }

                var typeLookup = _lookup[searchType];

                if (identifier == null)
                {
                    identifier = string.Empty;
                }

                if (typeLookup.ContainsKey(identifier))
                {
                    instance = typeLookup[identifier] as T;
                }

                if (instance == default)
                {
                    instance = new T();
                    instance.SetInitializationAction(onInitialize);
                    instance.Initialize();
                    instance.identifier = identifier;
                }

                if (!typeLookup.ContainsKey(identifier))
                {
                    typeLookup.Add(identifier, instance);
                }
                else
                {
                    typeLookup[identifier] = instance;
                }

                return instance;
            }
        }

        private static readonly ProfilerMarker _PRF_Get = new ProfilerMarker(_PRF_PFX + nameof(Get));
        public T Get<T>()
            where T : EditorUIFieldMetadata<T>, new()
        {
            using (_PRF_Get.Auto())
            {
                return Get<T>(string.Empty);
            }
        }

        public T Get<T>(string identifier, Action<T> onCreate = null)
            where T : EditorUIFieldMetadata<T>, new()
        {
            using (_PRF_Get.Auto())
            {
                CheckInitialization();

                var searchType = typeof(T);
                T instance;

                if (!_lookup.ContainsKey(searchType))
                {
                    instance = Add<T>(identifier);
                
                    onCreate?.Invoke(instance);
                
                    return instance;
                }

                if (_lookup[searchType] == null)
                {
                    _lookup[searchType] = new Dictionary<string, EditorUIFieldMetadata>();
                }

                var typeLookup = _lookup[searchType];

                if (typeLookup.ContainsKey(identifier) && (typeLookup[identifier] != null))
                {
                    var hit = typeLookup[identifier];

                    instance = hit as T;

                    if (instance != null)
                    {
                        instance.identifier = identifier;
                    }

                    return instance;
                }

                instance = Add<T>(identifier);
                onCreate?.Invoke(instance);

                return instance;
            }
        }
    }
}
