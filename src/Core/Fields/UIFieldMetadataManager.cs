using System;
using System.Collections.Generic;
using Appalachia.Editing.Core.Utilities;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public sealed class UIFieldMetadataManager
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(UIFieldMetadataManager) + ".";

        private static readonly ProfilerMarker _PRF_CheckInitialization =
            new(_PRF_PFX + nameof(CheckInitialization));

        private static readonly ProfilerMarker _PRF_Add = new(_PRF_PFX + nameof(Add));

        private static readonly ProfilerMarker _PRF_Get = new(_PRF_PFX + nameof(Get));

#endregion

        private Dictionary<Color, GUIStyle> _backgroundStyles;
        private Dictionary<Type, Dictionary<string, EditorUIFieldMetadata>> _lookup = new();

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
                    instance.Initialize(this);
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

        public GUIStyle Background(Color color)
        {
            if (_backgroundStyles == null)
            {
                _backgroundStyles = new Dictionary<Color, GUIStyle>();
            }

            GUIStyle bgStyle;

            if (!_backgroundStyles.ContainsKey(color))
            {
                bgStyle = new GUIStyle();
                bgStyle.normal.background = TextureHelper.GetBackground(color);
                bgStyle.active.background = TextureHelper.GetBackground(color);

                _backgroundStyles.Add(color, bgStyle);
            }
            else
            {
                bgStyle = _backgroundStyles[color];
            }

            return bgStyle;
        }

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
    }
}
