using System;
using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    public class SmartInlineButtonContext<T>
    {
        public string ErrorMessage;
        public ValueResolver<string> LabelHelper;
        public bool HasColorMember;
        public ValueResolver<Color> ColorHelper;
        public bool HasDisabledMember;
        public IfAttributeHelper DisabledHelper;
        public Action StaticMethodCaller;
        public Action<object> InstanceMethodCaller;
        public Action<object, T> InstanceParameterMethodCaller;
    }
}
