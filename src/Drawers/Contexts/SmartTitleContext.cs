using System;
using Appalachia.Core.Attributes.Editing;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Drawers.Contexts
{
    [Serializable]
    public class SmartTitleContext : PropertyDrawerContextCollection<SmartTitleAttribute>
    {
        public ValueResolver<Color> ColorHelper;
        public IfAttributeHelper HideHelper;
        public ValueResolver<string> SubtitleHelper;
        public ValueResolver<string> TitleHelper;

        protected override ValueResolver[] GetValueResolvers()
        {
            return new ValueResolver[] {TitleHelper, SubtitleHelper, ColorHelper};
        }

        public override void Initialize(
            InspectorProperty property,
            SmartTitleAttribute attribute,
            IPropertyValueEntry valueEntry)
        {
            TitleHelper = ValueResolver.Get<string>(property,    attribute.Title);
            SubtitleHelper = ValueResolver.Get<string>(property, attribute.Subtitle);
            ColorHelper = ValueResolver.Get<Color>(property, attribute.Color);

            var canHide = !string.IsNullOrWhiteSpace(attribute.HideIfMemberName);
            if (canHide)
            {
                HideHelper = new IfAttributeHelper(property, attribute.HideIfMemberName);
            }
        }
    }
}
