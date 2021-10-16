using System;
using System.Collections.Generic;
using System.Reflection;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Editing.Core.Fields;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace Appalachia.Editing.Drawers.Processors
{
    public class CheckboxEnabledDrawerAttributeProcessor<T> : OdinAttributeProcessor<CheckboxField<T>>
    {
        public override bool CanProcessChildMemberAttributes(
            InspectorProperty parentProperty,
            MemberInfo member)
        {
            return true;
        }

        public override bool CanProcessSelfAttributes(InspectorProperty property)
        {
            return true;
        }

        public override void ProcessChildMemberAttributes(
            InspectorProperty parentProperty,
            MemberInfo member,
            List<Attribute> attributes)
        {
            var checkboxAttribute = parentProperty.GetAttribute<CheckboxEnabledAttribute>();

            if (checkboxAttribute == null)
            {
                return;
            }

            if (member.Name == "value")
            {
                if (checkboxAttribute.EnableIf && !attributes.Exists(a => a is EnableIfAttribute))
                {
                    attributes.Add(new EnableIfAttribute("enabled"));
                }

                if (checkboxAttribute.ShowIf && !attributes.Exists(a => a is ShowIfAttribute))
                {
                    attributes.Add(new ShowIfAttribute("enabled"));
                }

                if (checkboxAttribute.PreviewField &&
                    !attributes.Exists(a => a.GetType() == typeof(PreviewFieldAttribute)))
                {
                    attributes.Add(new PreviewFieldAttribute(checkboxAttribute.PreviewHeight));
                }

                if (!string.IsNullOrEmpty(checkboxAttribute.MinMember) &&
                    !string.IsNullOrEmpty(checkboxAttribute.MaxMember))
                {
                    attributes.Add(
                        new PropertyRangeAttribute(checkboxAttribute.MinMember, checkboxAttribute.MaxMember)
                    );
                }
                else if (!string.IsNullOrEmpty(checkboxAttribute.MinMember))
                {
                    attributes.Add(
                        new PropertyRangeAttribute(checkboxAttribute.MinMember, checkboxAttribute.Max)
                    );
                }
                else if (!string.IsNullOrEmpty(checkboxAttribute.MaxMember))
                {
                    attributes.Add(
                        new PropertyRangeAttribute(checkboxAttribute.Min, checkboxAttribute.MaxMember)
                    );
                }
                else if (Math.Abs(checkboxAttribute.Min - checkboxAttribute.Max) > float.Epsilon)
                {
                    attributes.Add(new PropertyRangeAttribute(checkboxAttribute.Min, checkboxAttribute.Max));
                }
            }

            base.ProcessChildMemberAttributes(parentProperty, member, attributes);
        }

        public override void ProcessSelfAttributes(InspectorProperty property, List<Attribute> attributes)
        {
            var checkboxAttribute = property.GetAttribute<CheckboxEnabledAttribute>();

            if (checkboxAttribute == null)
            {
                return;
            }

            if (!checkboxAttribute.ShowReferencePicker &&
                !attributes.Exists(a => a.GetType() == typeof(HideReferenceObjectPickerAttribute)))
            {
                attributes.Add(new HideReferenceObjectPickerAttribute());
            }

            base.ProcessSelfAttributes(property, attributes);
        }
    }
}
