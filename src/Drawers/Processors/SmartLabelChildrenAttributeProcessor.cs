using System;
using System.Collections.Generic;
using System.Reflection;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Core.Extensions;
using Sirenix.OdinInspector.Editor;

namespace Appalachia.Editing.Drawers.Processors
{
    public class SmartLabelChildrenAttributeProcessor : OdinAttributeProcessor
    {
        public override void ProcessChildMemberAttributes(
            InspectorProperty parentProperty,
            MemberInfo member,
            List<Attribute> attributes)
        {
            if (attributes.Count == 0)
            {
                return;
            }

            switch (member.MemberType)
            {
                case MemberTypes.All:
                case MemberTypes.Constructor:
                case MemberTypes.Custom:
                case MemberTypes.Event:
                case MemberTypes.Method:
                case MemberTypes.NestedType:
                case MemberTypes.TypeInfo:
                    return;
            }

            var slcAttribute =
                parentProperty.Attributes.FirstOrDefault_NoAlloc(
                    a => a is SmartLabelChildrenAttribute
                ) as SmartLabelChildrenAttribute;

            if (slcAttribute == null)
            {
                slcAttribute =
                    parentProperty.Parent?.Parent?.Attributes.FirstOrDefault_NoAlloc(
                        a => a is SmartLabelChildrenAttribute
                    ) as SmartLabelChildrenAttribute;

                if (slcAttribute == null)
                {
                    return;
                }
            }

            var attribute = new SmartLabelAttribute(slcAttribute);

            attributes.Add(attribute);
        }
    }
}
