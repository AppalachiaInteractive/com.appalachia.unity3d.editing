using System;
using Appalachia.Core.Attributes.Editing;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace Appalachia.Editing.Drawers.Contexts
{
    [Serializable]
    public class SmartLabelContext : PropertyDrawerContextCollection<SmartLabelAttribute>
    {
        public bool ColorError;
        public Color? HSVColor;
        public float Size;
        public string InputLabelText;
        public string OutputLabelText;
        public ValueResolver<Color> ColorHelper;

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

        protected override ValueResolver[] GetValueResolvers()
        {
            return new ValueResolver[] {ColorHelper};
        }
    }
}
