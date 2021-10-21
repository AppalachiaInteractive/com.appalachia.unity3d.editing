using System;
using Appalachia.CI.Constants;
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

        private static readonly ProfilerMarker _PRF_GetInitializationAction =
            new(_PRF_PFX + nameof(GetInitializationAction));

        private static readonly ProfilerMarker _PRF_SetInitializationAction =
            new(_PRF_PFX + nameof(SetInitializationAction));

        protected Action<EditorUIFieldMetadata<T>> _initializeAction;

        public void SetInitializationAction(Action<EditorUIFieldMetadata<T>> action)
        {
            _initializeAction = action;
        }

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
    }

    [Serializable]
    public abstract class EditorUIFieldMetadata
    {
        private const string _PRF_PFX = nameof(EditorUIFieldMetadata) + ".";
        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));
        private static readonly ProfilerMarker _PRF_CloneStyle = new(_PRF_PFX + nameof(CloneStyle));
        private static readonly ProfilerMarker _PRF_CloneContent = new(_PRF_PFX + nameof(CloneContent));
        private static readonly ProfilerMarker _PRF_CloneLayout = new(_PRF_PFX + nameof(CloneLayout));
        private static readonly ProfilerMarker _PRF_AddLayoutOption = new(_PRF_PFX + nameof(AddLayoutOption));

        private static readonly ProfilerMarker _PRF_AlterContent = new(_PRF_PFX + nameof(AlterContent));

        private static readonly ProfilerMarker _PRF_AlterStyle = new(_PRF_PFX + nameof(AlterStyle));

        public bool hasBeenDrawn;

        public string identifier;

        protected GUIStyle _defaultStyle;
        private GUIContent _content;

        private GUILayoutOption[] _layout;
        private GUIStyle _style;
        private int __clonedContentHashcode;
        private int __clonedLayoutHashcode;
        private int __clonedStyleHashcode;
        private UIFieldMetadataManager _fieldManager;

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

        protected abstract GUIStyle DefaultStyle { get; }

        protected abstract Action GetInitializationAction();

        public virtual GUIContent InitializeContent()
        {
            return new(GUIContent.none);
        }

        public virtual GUILayoutOption[] InitializeLayout()
        {
            return new GUILayoutOption[0];
        }

        public virtual GUIStyle InitializeStyle()
        {
            var s = new GUIStyle(DefaultStyle);
            s.SupportRichText();

            return s;
        }

        public void AddLayoutOption(params GUILayoutOption[] newOptions)
        {
            using (_PRF_AddLayoutOption.Auto())
            {
                foreach (var newOption in newOptions)
                {
                    AddLayoutOption(newOption, ref _layout);                    
                }
            }
        }

        public void AlterContent(Action<GUIContent> updater)
        {
            using (_PRF_AlterContent.Auto())
            {
                updater(content);
            }
        }

        public void AlterStyle(Action<GUIStyle> updater)
        {
            using (_PRF_AlterStyle.Auto())
            {
                updater(style);
            }
        }

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

        public void Initialize(UIFieldMetadataManager manager)
        {
            using (_PRF_Initialize.Auto())
            {
                _fieldManager = manager;

                OnInitialize();

                var action = GetInitializationAction();

                if (action == null)
                {
                    return;
                }

                action();
            }
        }

        protected float GetSpace(SpaceSize spaceSize)
        {
            return _fieldManager.GetSpace(spaceSize);
        }

        protected virtual void OnInitialize()
        {
        }

        protected void Space(SpaceSize spaceSize)
        {
            _fieldManager.Space(spaceSize);
        }

        protected void Space(float size)
        {
            _fieldManager.Space(size);
        }

        internal static float indent => UnityEditor.EditorGUI.indentLevel * 15f;
        
        protected static bool LabelHasContent(GUIContent label)
        {
            return label is not {text: ""} || (label.image != null);
        }

        protected static void AddLayoutOption(GUILayoutOption newOption, ref GUILayoutOption[] options)
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
    }
}
