using System;
using Sirenix.OdinInspector.Editor.ValueResolvers;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    internal class ButtonContext<T>
    {
        public string ErrorMessage;
        public Action<object> InstanceMethodCaller;
        public Action<object, T> InstanceParameterMethodCaller;
        public ValueResolver<string> LabelHelper;
        public Action StaticMethodCaller;
    }
}
