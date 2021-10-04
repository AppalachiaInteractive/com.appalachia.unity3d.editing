using System;
using System.Reflection;
using Appalachia.Utility.Reflection;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    [Serializable]
    public class
        SmartInlineButtonContext<T> : PropertyDrawerContextCollection<SmartInlineButtonAttribute>
    {
        public bool HasColorMember;
        public bool HasDisabledMember;
        public ValueResolver<Color> ColorHelper;
        public IfAttributeHelper DisabledHelper;
        public Action<object> InstanceMethodCaller;
        public Action<object, T> InstanceParameterMethodCaller;

        public ValueResolver<string> LabelHelper;
        public Action StaticMethodCaller;

        protected override ValueResolver[] GetValueResolvers()
        {
            return new ValueResolver[] {LabelHelper, ColorHelper};
        }

        public override void Initialize(
            InspectorProperty property,
            SmartInlineButtonAttribute attribute,
            IPropertyValueEntry valueEntry)
        {
            LabelHelper = ValueResolver.Get(
                property,
                attribute.Label ?? attribute.MemberMethod.SplitPascalCase(),
                "Label Error"
            );

            HasDisabledMember = !string.IsNullOrWhiteSpace(attribute.DisableIf);
            if (HasDisabledMember)
            {
                DisabledHelper = new IfAttributeHelper(property, attribute.DisableIf);
            }

            HasColorMember = !string.IsNullOrWhiteSpace(attribute.Color);
            if (HasColorMember)
            {
                ColorHelper = ValueResolver.Get<Color>(property, attribute.Color);
            }

            string ErrorMessage = null;

            if (!LabelHelper.HasError)
            {
                MethodInfo memberInfo;
                if (AppaMemberFinder.Start(valueEntry.ParentType)
                                    .IsMethod()
                                    .IsNamed(attribute.MemberMethod)
                                    .HasNoParameters()
                                    .TryGetMember(out memberInfo, out ErrorMessage))
                {
                    if (memberInfo.IsStatic())
                    {
                        StaticMethodCaller = EmitUtilities.CreateStaticMethodCaller(memberInfo);
                    }
                    else
                    {
                        InstanceMethodCaller =
                            EmitUtilities.CreateWeakInstanceMethodCaller(memberInfo);
                    }
                }
                else if (AppaMemberFinder.Start(valueEntry.ParentType)
                                         .IsMethod()
                                         .IsNamed(attribute.MemberMethod)
                                         .HasParameters<T>()
                                         .TryGetMember(out memberInfo, out ErrorMessage))
                {
                    if (memberInfo.IsStatic())
                    {
                        ErrorMessage = "Static parameterized method is currently not supported.";
                    }
                    else
                    {
                        InstanceParameterMethodCaller =
                            EmitUtilities.CreateWeakInstanceMethodCaller<T>(memberInfo);
                    }
                }
            }

            if (ErrorMessage != null)
            {
                SirenixEditorGUI.ErrorMessageBox(ErrorMessage);
            }
        }
    }
}
