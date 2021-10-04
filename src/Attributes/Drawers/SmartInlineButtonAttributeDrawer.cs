#region

using System.Reflection;
using Appalachia.Editing.Attributes.Drawers.Contexts;
using Appalachia.Utility.Reflection;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Attributes.Drawers
{
    /// <summary>
    ///     Draws properties marked with <see cref="T:Sirenix.OdinInspector.SmartInlineButtonAttribute" />
    /// </summary>
    [DrawerPriority(DrawerPriorityLevel.WrapperPriority)]
    public sealed class
        SmartInlineButtonAttributeDrawer<T> : OdinAttributeDrawer<SmartInlineButtonAttribute, T>
    {
        private SmartInlineButtonContext<T> _propertyContext;

        protected override void DrawPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawPropertyLayout.Auto())
            {
                var attribute = Attribute;

                var propertyContext = PreparePropertyContext(attribute);

                PrepareDisabledLayout(propertyContext, out var disabled);

                PrepareColorLayout(propertyContext, out var color);

                DrawLayout(propertyContext, attribute, label, disabled, color);
            }
        }

        private SmartInlineButtonContext<T> PreparePropertyContext(
            SmartInlineButtonAttribute attribute)
        {
            using (_PRF_PreparePropertyContext.Auto())
            {
                if (_propertyContext == null)
                {
                    _propertyContext = new SmartInlineButtonContext<T>();

                    _propertyContext.LabelHelper = ValueResolver.Get(
                        Property,
                        attribute.Label ?? attribute.MemberMethod.SplitPascalCase(),
                        _propertyContext.ErrorMessage
                    );

                    _propertyContext.HasDisabledMember =
                        !string.IsNullOrWhiteSpace(attribute.DisableIf);
                    if (_propertyContext.HasDisabledMember)
                    {
                        _propertyContext.DisabledHelper = new IfAttributeHelper(
                            Property,
                            attribute.DisableIf
                        );
                    }

                    _propertyContext.HasColorMember = !string.IsNullOrWhiteSpace(attribute.Color);
                    if (_propertyContext.HasColorMember)
                    {
                        _propertyContext.ColorHelper =
                            ValueResolver.Get<Color>(Property, attribute.Color);
                    }

                    if (_propertyContext.ErrorMessage == null)
                    {
                        MethodInfo memberInfo;
                        if (AppaMemberFinder.Start(ValueEntry.ParentType)
                                            .IsMethod()
                                            .IsNamed(attribute.MemberMethod)
                                            .HasNoParameters()
                                            .TryGetMember(
                                                 out memberInfo,
                                                 out _propertyContext.ErrorMessage
                                             ))
                        {
                            if (memberInfo.IsStatic())
                            {
                                _propertyContext.StaticMethodCaller =
                                    EmitUtilities.CreateStaticMethodCaller(memberInfo);
                            }
                            else
                            {
                                _propertyContext.InstanceMethodCaller =
                                    EmitUtilities.CreateWeakInstanceMethodCaller(memberInfo);
                            }
                        }
                        else if (AppaMemberFinder.Start(ValueEntry.ParentType)
                                                 .IsMethod()
                                                 .IsNamed(attribute.MemberMethod)
                                                 .HasParameters<T>()
                                                 .TryGetMember(
                                                      out memberInfo,
                                                      out _propertyContext.ErrorMessage
                                                  ))
                        {
                            if (memberInfo.IsStatic())
                            {
                                _propertyContext.ErrorMessage =
                                    "Static parameterized method is currently not supported.";
                            }
                            else
                            {
                                _propertyContext.InstanceParameterMethodCaller =
                                    EmitUtilities.CreateWeakInstanceMethodCaller<T>(memberInfo);
                            }
                        }
                    }
                }

                return _propertyContext;
            }
        }

        private void PrepareDisabledLayout(
            SmartInlineButtonContext<T> propertyContext,
            out bool? disabled)
        {
            using (_PRF_PrepareDisabledLayout.Auto())
            {
                disabled = null;

                if (_propertyContext.HasDisabledMember)
                {
                    if (_propertyContext.DisabledHelper.ErrorMessage != null)
                    {
                        SirenixEditorGUI.ErrorMessageBox(
                            _propertyContext.DisabledHelper.ErrorMessage
                        );
                    }
                    else
                    {
                        disabled = _propertyContext.DisabledHelper.GetValue(false);
                    }
                }
            }
        }

        private void PrepareColorLayout(
            SmartInlineButtonContext<T> propertyContext,
            out Color? color)
        {
            using (_PRF_PrepareColorLayout.Auto())
            {
                color = null;

                if (_propertyContext.HasColorMember)
                {
                    if (_propertyContext.ColorHelper.ErrorMessage != null)
                    {
                        SirenixEditorGUI.ErrorMessageBox(_propertyContext.ColorHelper.ErrorMessage);
                    }
                    else
                    {
                        color = _propertyContext.ColorHelper.GetValue();
                    }
                }
            }
        }

        private void DrawLayout(
            SmartInlineButtonContext<T> propertyContext,
            SmartInlineButtonAttribute attribute,
            GUIContent label,
            bool? disabled,
            Color? color)
        {
            using (_PRF_DrawLayout.Auto())
            {
                if (_propertyContext.ErrorMessage != null)
                {
                    using (_PRF_DrawLayout_ErrorMessageBox.Auto())
                    {
                        SirenixEditorGUI.ErrorMessageBox(_propertyContext.ErrorMessage);
                    }

                    CallNextDrawer(label);
                }
                else if (_propertyContext.HasColorMember &&
                         (_propertyContext.ColorHelper?.ErrorMessage != null))
                {
                    using (_PRF_DrawLayout_ErrorMessageBox.Auto())
                    {
                        SirenixEditorGUI.ErrorMessageBox(_propertyContext.ErrorMessage);
                    }

                    CallNextDrawer(label);
                }
                else if (_propertyContext.HasColorMember &&
                         (_propertyContext.DisabledHelper?.ErrorMessage != null))
                {
                    using (_PRF_DrawLayout_ErrorMessageBox.Auto())
                    {
                        SirenixEditorGUI.ErrorMessageBox(_propertyContext.ErrorMessage);
                    }

                    CallNextDrawer(label);
                }
                else
                {
                    using (_PRF_DrawLayout_BeginHorizontal.Auto())
                    {
                        EditorGUILayout.BeginHorizontal();
                    }

                    if (attribute.Before)
                    {
                        HandleDrawingInlineButton(propertyContext, attribute, color, disabled);
                    }

                    DrawMainField(label);

                    if (!attribute.Before)
                    {
                        HandleDrawingInlineButton(propertyContext, attribute, color, disabled);
                    }

                    using (_PRF_DrawLayout_EndHorizontal.Auto())
                    {
                        EditorGUILayout.EndHorizontal();
                    }
                }
            }
        }

        private void HandleDrawingInlineButton(
            SmartInlineButtonContext<T> propertyContext,
            SmartInlineButtonAttribute attribute,
            Color? color,
            bool? disabled)
        {
            using (_PRF_HandleDrawingInlineButton.Auto())
            {
                PushInlineButton(attribute, color, disabled);
                DrawInlineButton(propertyContext);
                PopInlineButton(color, disabled);
            }
        }

        private void PushInlineButton(
            SmartInlineButtonAttribute attribute,
            Color? color,
            bool? disabled)
        {
            using (_PRF_PushInlineButton.Auto())
            {
                if (color.HasValue)
                {
                    //GUIHelper.PushColor(Color.white);
                    GUIHelper.PushColor(color.Value);
                }

                if (disabled.HasValue)
                {
                    GUIHelper.PushGUIEnabled(!disabled.Value);

                    //GUIHelper.PushGUIEnabled(true);
                }

                GUIHelper.PushIsBoldLabel(attribute.Bold);
            }
        }

        private void DrawInlineButton(SmartInlineButtonContext<T> propertyContext)
        {
            using (_PRF_DrawInlineButton.Auto())
            {
                bool buttonResult;

                if (_buttonOptions == null)
                {
                    _buttonOptions = GUILayoutOptions.ExpandWidth(false).MinWidth(20f);
                }

                if (_miniButtonStyle == null)
                {
                    _miniButtonStyle = EditorStyles.miniButton;
                }

                using (_PRF_DrawInlineButton_DrawButton.Auto())
                {
                    var labelText = _propertyContext.LabelHelper.GetValue();

                    var labelWidth = labelText.Length * 8.0f;

                    GUIHelper.PushLabelWidth(labelWidth);
                    buttonResult = GUILayout.Button(labelText, _miniButtonStyle, _buttonOptions);
                    GUIHelper.PopLabelWidth();
                }

                if (buttonResult)
                {
                    ExecuteInlineButton(propertyContext);
                }
            }
        }

        private void ExecuteInlineButton(SmartInlineButtonContext<T> propertyContext)
        {
            using (_PRF_ExecuteInlineButton.Auto())
            {
                if (propertyContext.StaticMethodCaller != null)
                {
                    propertyContext.StaticMethodCaller();
                }
                else if (propertyContext.InstanceMethodCaller != null)
                {
                    propertyContext.InstanceMethodCaller(Property.ParentValues[0]);
                }
                else if (propertyContext.InstanceParameterMethodCaller != null)
                {
                    var valueEntry = ValueEntry;
                    propertyContext.InstanceParameterMethodCaller(
                        Property.ParentValues[0],
                        valueEntry.SmartValue
                    );
                }
                else
                {
                    Debug.LogError(logErrorString);
                }
            }
        }

        private void PopInlineButton(Color? color, bool? disabled)
        {
            using (_PRF_PopInlineButton.Auto())
            {
                GUIHelper.PopIsBoldLabel();

                if (disabled.HasValue)
                {
                    GUIHelper.PopGUIEnabled();
                }

                if (color.HasValue)
                {
                    GUIHelper.PopColor();
                }
            }
        }

        private void DrawMainField(GUIContent label)
        {
            using (_PRF_DrawMainField.Auto())
            {
                using (_PRF_DrawMainField_BeginVertical.Auto())
                {
                    EditorGUILayout.BeginVertical();
                }

                using (_PRF_DrawMainField_CallNextDrawer.Auto())
                {
                    CallNextDrawer(label);
                }

                using (_PRF_DrawMainField_EndVertical.Auto())
                {
                    EditorGUILayout.EndVertical();
                }
            }
        }

#region Profiling

        private const string logErrorString = "No method found.";
        private const string _PRF_PFX = nameof(SmartInlineButtonAttributeDrawer<T>) + ".";

        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout =
            new(_PRF_PFX + nameof(DrawPropertyLayout));

        private static readonly ProfilerMarker _PRF_PreparePropertyContext =
            new(_PRF_PFX + nameof(PreparePropertyContext));

        private static readonly ProfilerMarker _PRF_PrepareDisabledLayout =
            new(_PRF_PFX + nameof(PrepareDisabledLayout));

        private static readonly ProfilerMarker _PRF_PrepareColorLayout =
            new(_PRF_PFX + nameof(PrepareColorLayout));

        private static readonly ProfilerMarker _PRF_DrawLayout = new(_PRF_PFX + nameof(DrawLayout));

        private static readonly ProfilerMarker _PRF_DrawLayout_ErrorMessageBox =
            new(_PRF_PFX + nameof(DrawLayout) + ".ErrorMessageBox");

        private static readonly ProfilerMarker _PRF_DrawLayout_BeginHorizontal =
            new(_PRF_PFX + nameof(DrawLayout) + ".BeginHorizontal");

        private static readonly ProfilerMarker _PRF_DrawLayout_EndHorizontal =
            new(_PRF_PFX + nameof(DrawLayout) + ".EndHorizontal");

        private static readonly ProfilerMarker _PRF_DrawMainField =
            new(_PRF_PFX + nameof(DrawMainField));

        private static readonly ProfilerMarker _PRF_DrawMainField_BeginVertical =
            new(_PRF_PFX + nameof(DrawMainField) + ".BeginVertical");

        private static readonly ProfilerMarker _PRF_DrawMainField_CallNextDrawer =
            new(_PRF_PFX + nameof(DrawMainField) + ".CallNextDrawer");

        private static readonly ProfilerMarker _PRF_DrawMainField_EndVertical =
            new(_PRF_PFX + nameof(DrawMainField) + ".EndVertical");

        private static readonly ProfilerMarker _PRF_HandleDrawingInlineButton =
            new(_PRF_PFX + nameof(HandleDrawingInlineButton));

        private static readonly ProfilerMarker _PRF_PushInlineButton =
            new(_PRF_PFX + nameof(PushInlineButton));

        private static GUILayoutOptions.GUILayoutOptionsInstance _buttonOptions;
        private static GUIStyle _miniButtonStyle;

        private static readonly ProfilerMarker _PRF_DrawInlineButton =
            new(_PRF_PFX + nameof(DrawInlineButton));

        private static readonly ProfilerMarker _PRF_DrawInlineButton_DrawButton =
            new(_PRF_PFX + nameof(DrawInlineButton) + ".DrawButton");

        private static readonly ProfilerMarker _PRF_ExecuteInlineButton =
            new(_PRF_PFX + nameof(ExecuteInlineButton));

        private static readonly ProfilerMarker _PRF_PopInlineButton =
            new(_PRF_PFX + nameof(PopInlineButton));

#endregion
    }
}
