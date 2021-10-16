using System;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace Appalachia.Editing.Drawers.Contexts
{
    [Serializable]
    public abstract class GroupDrawerContextCollection<TAttribute> : BaseDrawerContextCollection<TAttribute>
        where TAttribute : PropertyGroupAttribute
    {
        public abstract void Initialize(InspectorProperty property, TAttribute attribute);

        public void Construct(InspectorProperty property, TAttribute attribute)
        {
            _property = property;
            _attribute = attribute;

            Initialize(property, attribute);
            hasError = HasError();
        }
    }
}
