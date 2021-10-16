using System;
using System.Reflection;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Utility.Reflection;
using Appalachia.Utility.Reflection.Extensions;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities;

namespace Appalachia.Editing.Drawers.Contexts
{
    [Serializable]
    public class ToggleButtonContext<T> : PropertyDrawerContextCollection<ToggleButtonAttribute>
    {
        public string ErrorMessage;
        public Action<object> InstanceMethodCaller;
        public Action<object, T> InstanceParameterMethodCaller;
        public ValueResolver<string> LabelHelper;
        public Action StaticMethodCaller;

        public override void Initialize(
            InspectorProperty property,
            ToggleButtonAttribute attribute,
            IPropertyValueEntry valueEntry)
        {
            LabelHelper = ValueResolver.Get(
                property,
                attribute.Label ?? attribute.MemberMethod.SplitPascalCase(),
                ErrorMessage
            );

            if (!LabelHelper.HasError)
            {
                MethodInfo memberInfo;
                if (AppaMemberFinder.Start(valueEntry.ParentType)
                                    .IsMethod()
                                    .IsNamed(attribute.MemberMethod)
                                    .HasNoParameters()
                                    .TryGetMember(out memberInfo, out ErrorMessage))
                {
                    if (memberInfo.IsStatic_CACHE())
                    {
                        StaticMethodCaller = EmitUtilities.CreateStaticMethodCaller(memberInfo);
                    }
                    else
                    {
                        InstanceMethodCaller = EmitUtilities.CreateWeakInstanceMethodCaller(memberInfo);
                    }
                }
                else if (AppaMemberFinder.Start(valueEntry.ParentType)
                                         .IsMethod()
                                         .IsNamed(attribute.MemberMethod)
                                         .HasParameters<T>()
                                         .TryGetMember(out memberInfo, out ErrorMessage))
                {
                    if (memberInfo.IsStatic_CACHE())
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
        }

        protected override ValueResolver[] GetValueResolvers()
        {
            return new ValueResolver[] {LabelHelper};
        }
    }
}
