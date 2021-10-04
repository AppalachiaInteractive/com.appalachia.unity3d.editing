using System;
using Sirenix.OdinInspector.Editor;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    [Serializable]
    public abstract class
        PropertyDrawerContextCollection<TAttribute> : BaseDrawerContextCollection<TAttribute>
        where TAttribute : Attribute
    {
        public void Construct(
            InspectorProperty property,
            TAttribute attribute,
            IPropertyValueEntry valueEntry)
        {
            _property = property;
            _attribute = attribute;

            Initialize(property, attribute, valueEntry);
            hasError = HasError();
        }

        public abstract void Initialize(
            InspectorProperty property,
            TAttribute attribute,
            IPropertyValueEntry valueEntry);
    }
}
