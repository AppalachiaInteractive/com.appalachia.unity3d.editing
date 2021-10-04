using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    [Serializable]
    public class SmartLabelContext : PropertyDrawerContextCollection<SmartLabelAttribute>
    {
        public bool ColorError;
        public Color? HSVColor;
        public string InputLabelText;
        public string OutputLabelText;
        public float Size;
        public ValueResolver<Color> ColorHelper;

        protected override ValueResolver[] GetValueResolvers()
        {
            return new ValueResolver[] {ColorHelper};
        }

        public override void Initialize(
            InspectorProperty property,
            SmartLabelAttribute attribute,
            IPropertyValueEntry valueEntry)
        {
            if (attribute.HasPropertyColor)
            {
                ColorHelper = ValueResolver.Get<Color>(property, attribute.Color);
            }

            ColorError = false;
            if (attribute.HasPropertyColor && (ColorHelper.ErrorMessage != null))
            {
                ColorError = true;
                SirenixEditorGUI.ErrorMessageBox(ColorHelper.ErrorMessage);
            }
        }
    }
}
