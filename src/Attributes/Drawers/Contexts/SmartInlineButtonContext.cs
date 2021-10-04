using System;
using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    public class SmartInlineButtonContext<T>
    {
        public ValueResolver<Color> ColorHelper;
        public IfAttributeHelper DisabledHelper;
        public string ErrorMessage;
        public bool HasColorMember;
        public bool HasDisabledMember;
        public Action<object> InstanceMethodCaller;
        public Action<object, T> InstanceParameterMethodCaller;
        public ValueResolver<string> LabelHelper;
        public Action StaticMethodCaller;
    }
}
