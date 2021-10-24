using System;

namespace Appalachia.Editing.Core.State
{
    public class UIStackScope<T> : IDisposable
    {
        public UIStackScope(UIStateStack<T> stack)
        {
            _stack = stack;
        }

        private readonly UIStateStack<T> _stack;

        public void Dispose()
        {
            _stack.Pop();
        }
    }
}
