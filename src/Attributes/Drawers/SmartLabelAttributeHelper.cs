using Appalachia.Editing.Attributes.Drawers.Contexts;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers
{
    public static class SmartLabelAttributeHelper
    {
        private const string _PRF_PFX = nameof(SmartLabelAttributeHelper) + ".";

        private static readonly ProfilerMarker _PRF_GetPropertyContext =
            new(_PRF_PFX + nameof(GetPropertyContext));

        private static readonly ProfilerMarker _PRF_UpdateLabel =
            new(_PRF_PFX + nameof(UpdateLabel));

        private static readonly ProfilerMarker _PRF_PushLabel = new(_PRF_PFX + nameof(PushLabel));

        private static readonly ProfilerMarker _PRF_PopLabel = new(_PRF_PFX + nameof(PopLabel));

        private static readonly ProfilerMarker _PRF_PushColor = new(_PRF_PFX + nameof(PushColor));

        // ReSharper disable once UnusedParameter.Global
        public static SmartLabelContext GetPropertyContext(
            OdinDrawer drawer,
            InspectorProperty property,
            SmartLabelAttribute attribute)
        {
            using (_PRF_GetPropertyContext.Auto())
            {
                var propertyContext = new SmartLabelContext();

                if (attribute.HasPropertyColor)
                {
                    propertyContext.ColorHelper =
                        ValueResolver.Get<Color>(property, attribute.Color);
                }

                propertyContext.ColorError = false;
                if (attribute.HasPropertyColor &&
                    (propertyContext.ColorHelper.ErrorMessage != null))
                {
                    propertyContext.ColorError = true;
                    SirenixEditorGUI.ErrorMessageBox(propertyContext.ColorHelper.ErrorMessage);
                }

                return propertyContext;
            }
        }

        public static void UpdateLabel(
            SmartLabelContext propertyContext,
            SmartLabelAttribute attribute,
            GUIContent label)
        {
            using (_PRF_UpdateLabel.Auto())
            {
                if (label.text != propertyContext.InputLabelText)
                {
                    propertyContext.InputLabelText = label.text;

                    if (attribute.Text != null)
                    {
                        label.text = attribute.Text;
                    }

                    var widthText = attribute.AlignWith ?? label.text;

                    var chars = widthText.Length;
                    var size = attribute.PixelsPerCharacter * chars;
                    size += attribute.Padding;

                    propertyContext.Size = size;
                    propertyContext.OutputLabelText = label.text;
                }
                else
                {
                    label.text = propertyContext.OutputLabelText;
                }
            }
        }

        public static void PushLabel(
            SmartLabelContext propertyContext,
            SmartLabelAttribute attribute,
            out bool pushedColor)
        {
            using (_PRF_PushLabel.Auto())
            {
                if (propertyContext.Size < 0.0)
                {
                    GUIHelper.PushLabelWidth(GUIHelper.BetterLabelWidth + propertyContext.Size);
                }
                else
                {
                    GUIHelper.PushLabelWidth(propertyContext.Size);
                }

                GUIHelper.PushIsBoldLabel(attribute.Bold);

                if (attribute.ShallowColor)
                {
                    ExecuteColorPush(propertyContext, attribute, out pushedColor);
                }
                else
                {
                    pushedColor = false;
                }
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

                GUIHelper.PopLabelWidth();
            }
        }

        private static void ExecuteColorPush(
            SmartLabelContext propertyContext,
            SmartLabelAttribute attribute,
            out bool pushedColor)
        {
            pushedColor = true;

            if (attribute.HasPropertyColor && !propertyContext.ColorError)
            {
                var color = propertyContext.ColorHelper.GetValue();
                GUIHelper.PushLabelColor(color);
            }
            else if (attribute.HasHue || attribute.HasValue || attribute.HasSaturation)
            {
                if (!propertyContext.HSVColor.HasValue)
                {
                    propertyContext.HSVColor = Color.HSVToRGB(
                        attribute.HasHue ? attribute.Hue / 255f : 0f,
                        attribute.HasSaturation
                            ? attribute.Saturation / 255f
                            : attribute.HasHue
                                ? 1f
                                : attribute.HasValue
                                    ? 0f
                                    : 1f,
                        attribute.HasValue ? attribute.Value / 255f : 1f
                    );
                }

                var color = propertyContext.HSVColor.Value;
                GUIHelper.PushLabelColor(color);
            }
            else
            {
                pushedColor = false;
            }
        }

        public static void PushColor(
            SmartLabelContext propertyContext,
            SmartLabelAttribute attribute,
            out bool pushedColor)
        {
            using (_PRF_PushColor.Auto())
            {
                ExecuteColorPush(propertyContext, attribute, out pushedColor);
            }
        }
    }
}
