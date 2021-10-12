using System;
using Appalachia.Utility.Reflection.Extensions;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public abstract class EditorUIFieldMetadata<T> : EditorUIFieldMetadata
        where T : EditorUIFieldMetadata<T>
    {
        private const string _PRF_PFX = nameof(EditorUIFieldMetadata<T>) + ".";
        protected Action<EditorUIFieldMetadata<T>> _initializeAction;

        private static readonly ProfilerMarker _PRF_GetInitializationAction = new ProfilerMarker(_PRF_PFX + nameof(GetInitializationAction));
        protected override Action GetInitializationAction()
        {
            using (_PRF_GetInitializationAction.Auto())
            {
                if (_initializeAction == null)
                {
                    return null;
                }

                return () => _initializeAction(this);
            }
        }

        private static readonly ProfilerMarker _PRF_SetInitializationAction = new ProfilerMarker(_PRF_PFX + nameof(SetInitializationAction));
        public void SetInitializationAction(Action<EditorUIFieldMetadata<T>> action)
        {
            _initializeAction = action;
        }
    }

    [Serializable]
    public abstract class EditorUIFieldMetadata
    {
        private const string _PRF_PFX = nameof(EditorUIFieldMetadata) + ".";
        
        public string identifier;
        private int __clonedContentHashcode;
        private int __clonedLayoutHashcode;
        private int __clonedStyleHashcode;
        private GUIContent _content;
        protected GUIStyle _defaultStyle;

        private GUILayoutOption[] _layout;
        private GUIStyle _style;

        protected EditorUIFieldMetadata()
        {
            Initialize();
        }

        public GUIContent content
        {
            get
            {
                if (_content == null)
                {
                    _content = InitializeContent();
                }

                return _content;
            }
        }

        public GUIStyle style
        {
            get
            {
                if (_style == null)
                {
                    _style = InitializeStyle();
                }

                return _style;
            }
        }

        public GUILayoutOption[] layout
        {
            get
            {
                if (_layout == null)
                {
                    _layout = InitializeLayout();
                }

                return _layout;
            }
        }

        protected abstract GUIStyle DefaultStyle { get; }

        public virtual GUIContent InitializeContent()
        {
            return GUIContent.none;
        }

        public virtual GUIStyle InitializeStyle()
        {
            return new(DefaultStyle);
        }

        public virtual GUILayoutOption[] InitializeLayout()
        {
            return new GUILayoutOption[0];
        }

        private static readonly ProfilerMarker _PRF_Initialize = new ProfilerMarker(_PRF_PFX + nameof(Initialize));
        public void Initialize()
        {
            using (_PRF_Initialize.Auto())
            {
                OnInitialize();

                var action = GetInitializationAction();

                if (action == null)
                {
                    return;
                }

                action();
            }
        }

        protected virtual void OnInitialize()
        {
        }

        private static readonly ProfilerMarker _PRF_Refresh = new ProfilerMarker(_PRF_PFX + nameof(Refresh));
        public void Refresh(bool doInitialize = true)
        {
            using (_PRF_Refresh.Auto())
            {
                _content = null;
                _style = null;
                _layout = null;

                if (doInitialize)
                {
                    Initialize();
                }
            }
        }

        private static readonly ProfilerMarker _PRF_CloneStyle = new ProfilerMarker(_PRF_PFX + nameof(CloneStyle));
        public void CloneStyle(GUIStyle i)
        {
            using (_PRF_CloneStyle.Auto())
            {
                if (i == null)
                {
                    return;
                }

                var hash = i.GetHashCode();
                if (hash == __clonedStyleHashcode)
                {
                    return;
                }

                __clonedStyleHashcode = hash;
                _style = new GUIStyle(i);
            }
        }

        private static readonly ProfilerMarker _PRF_CloneContent = new ProfilerMarker(_PRF_PFX + nameof(CloneContent));
        public void CloneContent(GUIContent i)
        {
            using (_PRF_CloneContent.Auto())
            {
                if (i == null)
                {
                    return;
                }

                var hash = i.GetHashCode();
                if (hash == __clonedContentHashcode)
                {
                    return;
                }

                __clonedContentHashcode = hash;
                _content = new GUIContent(i);
            }
        }

        private static readonly ProfilerMarker _PRF_CloneLayout = new ProfilerMarker(_PRF_PFX + nameof(CloneLayout));
        public void CloneLayout(GUILayoutOption[] i)
        {
            using (_PRF_CloneLayout.Auto())
            {
                if (i == null)
                {
                    return;
                }

                var hash = i.GetHashCode();
                if (hash == __clonedLayoutHashcode)
                {
                    return;
                }

                __clonedLayoutHashcode = hash;
                _layout = new GUILayoutOption[i.Length];
                Array.Copy(i, _layout, i.Length);
            }
        }

        private static readonly ProfilerMarker _PRF_AddLayoutOption = new ProfilerMarker(_PRF_PFX + nameof(AddLayoutOption));
        protected static void AddLayoutOption(
            GUILayoutOption newOption,
            ref GUILayoutOption[] options)
        {
            using (_PRF_AddLayoutOption.Auto())
            {
                if (options == null)
                {
                    options = new[] {newOption};
                    return;
                }

                for (var layoutIndex = 0; layoutIndex < options.Length; layoutIndex++)
                {
                    var existingLayoutOption = options[layoutIndex];

                    var newOptionType = newOption.GetFieldValue("type");
                    var checkingOptionType = existingLayoutOption.GetFieldValue("type");

                    if (newOptionType.Equals(checkingOptionType))
                    {
                        var newOptionValue = newOption.GetFieldValue("value");

                        existingLayoutOption.SetFieldValue("value", newOptionValue);

                        options[layoutIndex] = existingLayoutOption;
                        return;
                    }
                }

                var newArray = new GUILayoutOption[options.Length + 1];

                Array.Copy(options, newArray, options.Length);

                newArray[newArray.Length - 1] = newOption;

                options = newArray;
            }
        }

        public void AddLayoutOption(GUILayoutOption newOption)
        {
            using (_PRF_AddLayoutOption.Auto())
            {

                AddLayoutOption(newOption, ref _layout);
            }
        }

        private static readonly ProfilerMarker _PRF_AlterContent = new ProfilerMarker(_PRF_PFX + nameof(AlterContent));
        public void AlterContent(Action<GUIContent> updater)
        {
            using (_PRF_AlterContent.Auto())
            {
                updater(content);
            }
        }

        private static readonly ProfilerMarker _PRF_AlterStyle = new ProfilerMarker(_PRF_PFX + nameof(AlterStyle));
        public void AlterStyle(Action<GUIStyle> updater)
        {
            using (_PRF_AlterStyle.Auto())
            {
                updater(style);
            }
        }

        protected abstract Action GetInitializationAction();
    }
}
