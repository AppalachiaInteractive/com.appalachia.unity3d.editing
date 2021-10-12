using Appalachia.Core.Attributes.Editing;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Drawers.Contexts
{
    public class SmartTitleGroupContext : GroupDrawerContextCollection<SmartTitleGroupAttribute>
    {
        public ValueResolver<Color> ColorHelper;
        public ValueResolver<string> SubtitleHelper;
        public ValueResolver<string> TitleHelper;

        protected override ValueResolver[] GetValueResolvers()
        {
            return new ValueResolver[] {TitleHelper, SubtitleHelper, ColorHelper};
        }

        public override void Initialize(
            InspectorProperty property,
            SmartTitleGroupAttribute attribute)
        {
            TitleHelper = ValueResolver.Get<string>(property,    attribute.GroupName);
            SubtitleHelper = ValueResolver.Get<string>(property, attribute.Subtitle);
            ColorHelper = ValueResolver.Get<Color>(property, attribute.Color);
        }
    }
}
