#region

using Appalachia.Core.Editing.Attributes.Drawers.Contexts;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Core.Editing.Attributes.Drawers
{
    [DrawerPriority(DrawerPriorityLevel.WrapperPriority)]
    public sealed class SmartLabelAttributeDrawer : OdinAttributeDrawer<SmartLabelAttribute>
    {
        private const string _PRF_PFX = nameof(SmartLabelAttributeDrawer) + ".";

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout = new ProfilerMarker(_PRF_PFX + nameof(DrawPropertyLayout));

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout_CallNextDrawer =
            new ProfilerMarker(_PRF_PFX + nameof(DrawPropertyLayout) + ".CallNextDrawer");

        protected override void DrawPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawPropertyLayout.Auto())
            {
                if (label?.text == null)
                {
                    using (_PRF_DrawPropertyLayout_CallNextDrawer.Auto())
                    {
                        CallNextDrawer(label);
                    }

                    return;
                }

                
                var inlineEditor = false;

                for (var i = 0; i < Property.Attributes.Count; i++)
                {
                    var attribute = Property.Attributes[i];

                    if (attribute is InlineEditorAttribute)
                    {
                        inlineEditor = true;
                        break;
                    }
                }

                if (inlineEditor)
                {
                    DrawInlineEditorPropertyLayout(label);
                }
                else if (Property.ValueEntry.TypeOfValue == typeof(bool))
                {
                    DrawTogglePropertyLayout(label);
                }
                else
                {
                    DrawGeneralPropertyLayout(label);                
                }
            }
        }

        private SmartLabelContext _propertyContext;
        
        private static readonly ProfilerMarker _PRF_DrawInlineEditorPropertyLayout = new ProfilerMarker(_PRF_PFX + nameof(DrawInlineEditorPropertyLayout));
        private void DrawInlineEditorPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawInlineEditorPropertyLayout.Auto())
            {
                var attribute = Attribute;
                if (_propertyContext == null)
                {
                    _propertyContext =
                        SmartLabelAttributeHelper.GetPropertyContext(this, Property, attribute);
                }

                SmartLabelAttributeHelper.UpdateLabel(_propertyContext, attribute, label);
                
                var labelText = _propertyContext.OutputLabelText;
                
                TitleAttributeHelper.Title(
                    labelText,
                    null,
                    TextAlignment.Left,
                    false,
                    attribute.Bold,
                    attribute.HasPropertyColor && !_propertyContext.ColorError && attribute.Color != null ? _propertyContext.ColorHelper.GetValue() : default
                );

                bool pushedColorDeep = false;
                
                if (!attribute.ShallowColor)
                {
                    SmartLabelAttributeHelper.PushColor(_propertyContext, attribute, out pushedColorDeep);
                }

                using (_PRF_DrawPropertyLayout_CallNextDrawer.Auto())
                {
                    CallNextDrawer(null);
                }
                
                if (pushedColorDeep)
                {
                    GUIHelper.PopLabelColor();
                }
            }
        }

        private static readonly ProfilerMarker _PRF_DrawGeneralPropertyLayout = new ProfilerMarker(_PRF_PFX + nameof(DrawGeneralPropertyLayout));

        private void DrawGeneralPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawGeneralPropertyLayout.Auto())
            {
                var attribute = Attribute;
                var propertyContext = SmartLabelAttributeHelper.GetPropertyContext(this, Property, attribute);

                SmartLabelAttributeHelper.UpdateLabel(propertyContext, attribute, label);

                GUILayout.BeginHorizontal();
                
                var labelText = propertyContext.OutputLabelText;

                if (!attribute.Postfix)
                {
                    SmartLabelAttributeHelper.PushLabel(propertyContext, attribute, out var pushedColor);
                    GUILayout.Label(labelText, GUILayoutOptions.ExpandWidth(false));
                    SmartLabelAttributeHelper.PopLabel(pushedColor);
                }

                bool pushedColorDeep = false;
                
                if (!attribute.ShallowColor)
                {
                    SmartLabelAttributeHelper.PushColor(propertyContext, attribute, out pushedColorDeep);
                }
                
                using (_PRF_DrawPropertyLayout_CallNextDrawer.Auto())
                {
                    GUILayout.BeginVertical();
                    CallNextDrawer((GUIContent) null);
                    GUILayout.EndVertical();
                }
                
                if (pushedColorDeep)
                {
                    GUIHelper.PopLabelColor();
                }
                
                if (attribute.Postfix)
                {
                    SmartLabelAttributeHelper.PushLabel(propertyContext, attribute, out var pushedColor);
                    GUILayout.Label(labelText, GUILayoutOptions.ExpandWidth(false));
                    SmartLabelAttributeHelper.PopLabel(pushedColor);
                }

                GUILayout.EndHorizontal();
            }
        }

        private IPropertyValueEntry<bool> boolValueEntry;

        /// <summary>
        /// Gets the attribute that the OdinAttributeDrawer draws for.
        /// </summary>
        public IPropertyValueEntry<bool> BoolValueEntry
        {
            get
            {
                if (boolValueEntry == null)
                {
                    boolValueEntry = Property.ValueEntry as IPropertyValueEntry<bool>;
                    if (boolValueEntry == null)
                    {
                        Property.Update(true);
                        boolValueEntry = Property.ValueEntry as IPropertyValueEntry<bool>;
                    }
                }
                return boolValueEntry;
            }
        }
        
        private static readonly ProfilerMarker _PRF_DrawTogglePropertyLayout = new ProfilerMarker(_PRF_PFX + nameof(DrawTogglePropertyLayout));

        private void DrawTogglePropertyLayout(GUIContent label)
        {
            using (_PRF_DrawTogglePropertyLayout.Auto())
            {
                var attribute = Attribute;
                var propertyContext = SmartLabelAttributeHelper.GetPropertyContext(this, Property, attribute);
                var valueEntry = BoolValueEntry;
                
                SmartLabelAttributeHelper.UpdateLabel(propertyContext, attribute, label);
                
                if (string.IsNullOrWhiteSpace(_propertyContext.OutputLabelText))
                {
                    valueEntry.SmartValue = EditorGUILayout.ToggleLeft(GUIContent.none, valueEntry.SmartValue);
                    return;
                }

                GUILayout.BeginHorizontal();

                var labelText = _propertyContext.OutputLabelText;

                var pushedColor = false;
                
                if (attribute.Postfix)
                {
                    EditorGUIUtility.labelWidth = 1;
                }
                else
                {
                    SmartLabelAttributeHelper.PushLabel(propertyContext, attribute, out pushedColor);
                    GUILayout.Label(labelText, GUILayoutOptions.ExpandWidth(false));
                }
                
                valueEntry.SmartValue = EditorGUILayout.Toggle(string.Empty, valueEntry.SmartValue, GUILayoutOptions.ExpandWidth(false));
                
                /*
                valueEntry.SmartValue = attribute.Postfix
                    ? EditorGUILayout.ToggleLeft(label, valueEntry.SmartValue)
                    : EditorGUILayout.Toggle(label, valueEntry.SmartValue);*/
                    
                if (attribute.Postfix)
                {
                    SmartLabelAttributeHelper.PushLabel(propertyContext, attribute, out pushedColor);
                    GUILayout.Label(labelText, GUILayoutOptions.ExpandWidth(false));
                }
                
                SmartLabelAttributeHelper.PopLabel(pushedColor);

                GUILayout.EndHorizontal();
            }
        }

    }
}
