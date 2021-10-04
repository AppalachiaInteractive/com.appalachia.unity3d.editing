#region

using Appalachia.Editing.Attributes.Drawers.Contexts;
using Sirenix.OdinInspector.Editor;
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
    public sealed class SmartInlineButtonAttributeDrawer<T> : ContextualPropertyDrawer<
        SmartInlineButtonAttribute, SmartInlineButtonContext<T>, T>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawPropertyLayout.Auto())
            {
                PrepareDisabledLayout(out var disabled);

                PrepareColorLayout(out var color);

                DrawLayout(label, disabled, color);
            }
        }

        private void PrepareDisabledLayout(out bool? disabled)
        {
            using (_PRF_PrepareDisabledLayout.Auto())
            {
                disabled = null;

                if (context.HasDisabledMember)
                {
                    if (context.DisabledHelper.ErrorMessage != null)
                    {
                        SirenixEditorGUI.ErrorMessageBox(context.DisabledHelper.ErrorMessage);
                    }
                    else
                    {
                        disabled = context.DisabledHelper.GetValue(false);
                    }
                }
            }
        }

        private void PrepareColorLayout(out Color? color)
        {
            using (_PRF_PrepareColorLayout.Auto())
            {
                color = null;

                if (context.HasColorMember)
                {
                    if (context.ColorHelper.ErrorMessage != null)
                    {
                        SirenixEditorGUI.ErrorMessageBox(context.ColorHelper.ErrorMessage);
                    }
                    else
                    {
                        color = context.ColorHelper.GetValue();
                    }
                }
            }
        }

        private void DrawLayout(GUIContent label, bool? disabled, Color? color)
        {
            using (_PRF_DrawLayout.Auto())
            {
                if (context.hasError)
                {
                    using (_PRF_DrawLayout_ErrorMessageBox.Auto())
                    {
                        context.DrawErrors();
                    }

                    CallNextDrawer(label);
                }
                else
                {
                    using (_PRF_DrawLayout_BeginHorizontal.Auto())
                    {
                        EditorGUILayout.BeginHorizontal();
                    }

                    if (Attribute.Before)
                    {
                        HandleDrawingInlineButton(color, disabled);
                    }

                    DrawMainField(label);

                    if (!Attribute.Before)
                    {
                        HandleDrawingInlineButton(color, disabled);
                    }

                    using (_PRF_DrawLayout_EndHorizontal.Auto())
                    {
                        EditorGUILayout.EndHorizontal();
                    }
                }
            }
        }

        private void HandleDrawingInlineButton(Color? color, bool? disabled)
        {
            using (_PRF_HandleDrawingInlineButton.Auto())
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

                GUIHelper.PushIsBoldLabel(Attribute.Bold);
            }
        }

        private void DrawInlineButton()
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
                    var labelText = context.LabelHelper.GetValue();

                    var labelWidth = labelText.Length * 8.0f;

                    GUIHelper.PushLabelWidth(labelWidth);
                    buttonResult = GUILayout.Button(labelText, _miniButtonStyle, _buttonOptions);
                    GUIHelper.PopLabelWidth();
                }

                if (buttonResult)
                {
                    ExecuteInlineButton();
                }
            }
        }

        private void ExecuteInlineButton()
        {
            using (_PRF_ExecuteInlineButton.Auto())
            {
                if (context.StaticMethodCaller != null)
                {
                    context.StaticMethodCaller();
                }
                else if (context.InstanceMethodCaller != null)
                {
                    context.InstanceMethodCaller(Property.ParentValues[0]);
                }
                else if (context.InstanceParameterMethodCaller != null)
                {
                    context.InstanceParameterMethodCaller(
                        Property.ParentValues[0],
                        ValueEntry.SmartValue
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

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout =
            new(_PRF_PFX + nameof(DrawPropertyLayout));

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
