using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;

namespace Appalachia.Core.Editing.Attributes.Drawers.Contexts
{
    internal class ButtonContext<T>
    {
        public string ErrorMessage;
        public ValueResolver<string> LabelHelper;
        public Action StaticMethodCaller;
        public Action<object> InstanceMethodCaller;
        public Action<object, T> InstanceParameterMethodCaller;
    }
}
