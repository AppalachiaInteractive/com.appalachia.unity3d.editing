#region

using Appalachia.Core.Attributes.Editing;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.State;
using Appalachia.Editing.Drawers.Contexts;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Drawers
{
    [DrawerPriority(DrawerPriorityLevel.WrapperPriority)]
    public sealed class
        SmartLabelAttributeDrawer : ContextualPropertyDrawer<SmartLabelAttribute, SmartLabelContext>
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(SmartLabelAttributeDrawer) + ".";

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout =
            new(_PRF_PFX + nameof(DrawPropertyLayout));

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout_CallNextDrawer =
            new(_PRF_PFX + nameof(DrawPropertyLayout) + ".CallNextDrawer");

        private static readonly ProfilerMarker _PRF_DrawInlineEditorPropertyLayout =
            new(_PRF_PFX + nameof(DrawInlineEditorPropertyLayout));

        private static readonly ProfilerMarker _PRF_DrawGeneralPropertyLayout =
            new(_PRF_PFX + nameof(DrawGeneralPropertyLayout));

        private static readonly ProfilerMarker _PRF_DrawTogglePropertyLayout =
            new(_PRF_PFX + nameof(DrawTogglePropertyLayout));

        private static readonly ProfilerMarker _PRF_UpdateLabel = new(_PRF_PFX + nameof(UpdateLabel));
        private static readonly ProfilerMarker _PRF_PushLabel = new(_PRF_PFX + nameof(PushLabel));
        private static readonly ProfilerMarker _PRF_PopLabel = new(_PRF_PFX + nameof(PopLabel));

        private static readonly ProfilerMarker _PRF_PushColor = new(_PRF_PFX + nameof(PushColor));

#endregion

        private IPropertyValueEntry<bool> boolValueEntry;

        /// <summary>
        ///     Gets the attribute that the OdinAttributeDrawer draws for.
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

        public void PushColor(out bool pushedColor)
        {
            using (_PRF_PushColor.Auto())
            {
                ExecuteColorPush(out pushedColor);
            }
        }

        public void PushLabel(out bool pushedColor)
        {
            using (_PRF_PushLabel.Auto())
            {
                if (context.Size < 0.0)
                {
                    APPAGUI.StateStacks.labelWidth.Push(GUIHelper.BetterLabelWidth + context.Size);
                }
                else
                {
                    APPAGUI.StateStacks.labelWidth.Push(context.Size);
                }

                GUIHelper.PushIsBoldLabel(Attribute.Bold);

                if (Attribute.ShallowColor)
                {
                    ExecuteColorPush(out pushedColor);
                }
                else
                {
                    pushedColor = false;
                }
            }
        }

        public void UpdateLabel(GUIContent label)
        {
            using (_PRF_UpdateLabel.Auto())
            {
                if (label.text != context.InputLabelText)
                {
                    context.InputLabelText = label.text;

                    if (Attribute.Text != null)
                    {
                        label.text = Attribute.Text;
                    }

                    var widthText = Attribute.AlignWith ?? label.text;

                    var chars = widthText.Length;
                    var size = Attribute.PixelsPerCharacter * chars;
                    size += Attribute.Padding;

                    context.Size = size;
                    context.OutputLabelText = label.text;
                }
                else
                {
                    label.text = context.OutputLabelText;
                }
            }
        }

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

        private void DrawGeneralPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawGeneralPropertyLayout.Auto())
            {
                var attribute = Attribute;

                UpdateLabel(label);

                GUILayout.BeginHorizontal();

                var labelText = context.OutputLabelText;

                if (!attribute.Postfix)
                {
                    PushLabel(out var pushedColor);
                    GUILayout.Label(labelText, GUILayoutOptions.ExpandWidth(false));
                    PopLabel(pushedColor);
                }

                var pushedColorDeep = false;

                if (!attribute.ShallowColor)
                {
                    PushColor(out pushedColorDeep);
                }

                using (_PRF_DrawPropertyLayout_CallNextDrawer.Auto())
                {
                    GUILayout.BeginVertical();
                    CallNextDrawer(null);
                    GUILayout.EndVertical();
                }

                if (pushedColorDeep)
                {
                    GUIHelper.PopLabelColor();
                }

                if (attribute.Postfix)
                {
                    PushLabel(out var pushedColor);
                    GUILayout.Label(labelText, GUILayoutOptions.ExpandWidth(false));
                    PopLabel(pushedColor);
                }

                GUILayout.EndHorizontal();
            }
        }

        private void DrawInlineEditorPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawInlineEditorPropertyLayout.Auto())
            {
                var attribute = Attribute;

                UpdateLabel(label);

                var labelText = context.OutputLabelText;

                TitleAttributeHelper.Title(
                    labelText,
                    null,
                    TextAlignment.Left,
                    false,
                    attribute.Bold,
                    attribute.HasPropertyColor && !context.ColorError && (attribute.Color != null)
                        ? context.ColorHelper.GetValue()
                        : default
                );

                var pushedColorDeep = false;

                if (!attribute.ShallowColor)
                {
                    PushColor(out pushedColorDeep);
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

        private void DrawTogglePropertyLayout(GUIContent label)
        {
            using (_PRF_DrawTogglePropertyLayout.Auto())
            {
                var attribute = Attribute;
                var valueEntry = BoolValueEntry;

                UpdateLabel(label);
                if (string.IsNullOrWhiteSpace(context.OutputLabelText))
                {
                    valueEntry.SmartValue = EditorGUILayout.ToggleLeft(
                        GUIContent.none,
                        valueEntry.SmartValue
                    );
                    return;
                }

                GUILayout.BeginHorizontal();

                var labelText = context.OutputLabelText;

                var pushedColor = false;

                if (attribute.Postfix)
                {
                    EditorGUIUtility.labelWidth = 1;
                }
                else
                {
                    PushLabel(out pushedColor);
                    GUILayout.Label(labelText, GUILayoutOptions.ExpandWidth(false));
                }

                valueEntry.SmartValue = EditorGUILayout.Toggle(
                    string.Empty,
                    valueEntry.SmartValue,
                    GUILayoutOptions.ExpandWidth(false)
                );

                /*
                valueEntry.SmartValue = attribute.Postfix
                    ? EditorGUILayout.ToggleLeft(label, valueEntry.SmartValue)
                    : EditorGUILayout.Toggle(label, valueEntry.SmartValue);*/

                if (attribute.Postfix)
                {
                    PushLabel(out pushedColor);
                    GUILayout.Label(labelText, GUILayoutOptions.ExpandWidth(false));
                }

                PopLabel(pushedColor);

                GUILayout.EndHorizontal();
            }
        }

        private void ExecuteColorPush(out bool pushedColor)
        {
            pushedColor = true;

            if (Attribute.HasPropertyColor && !context.ColorError)
            {
                var color = context.ColorHelper.GetValue();
                GUIHelper.PushLabelColor(color);
            }
            else if (Attribute.HasHue || Attribute.HasValue || Attribute.HasSaturation)
            {
                if (!context.HSVColor.HasValue)
                {
                    context.HSVColor = Color.HSVToRGB(
                        Attribute.HasHue ? Attribute.Hue / 255f : 0f,
                        Attribute.HasSaturation
                            ? Attribute.Saturation / 255f
                            : Attribute.HasHue
                                ? 1f
                                : Attribute.HasValue
                                    ? 0f
                                    : 1f,
                        Attribute.HasValue ? Attribute.Value / 255f : 1f
                    );
                }

                var color = context.HSVColor.Value;
                GUIHelper.PushLabelColor(color);
            }
            else
            {
                pushedColor = false;
            }
        }

        public static void PopLabel(bool pushedColor)
        {
            using (_PRF_PopLabel.Auto())
            {
                if (pushedColor)
                {
                    GUIHelper.PopLabelColor();
                }

                GUIHelper.PopIsBoldLabel();

                APPAGUI.StateStacks.labelWidth.Pop();
            }
        }
    }
}
