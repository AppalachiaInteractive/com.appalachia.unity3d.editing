using System;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    [Serializable]
    public abstract class
        GroupDrawerContextCollection<TAttribute> : BaseDrawerContextCollection<TAttribute>
        where TAttribute : PropertyGroupAttribute
    {
        public void Construct(InspectorProperty property, TAttribute attribute)
        {
            _property = property;
            _attribute = attribute;

            Initialize(property, attribute);
            hasError = HasError();
        }

        public abstract void Initialize(InspectorProperty property, TAttribute attribute);
    }
}
