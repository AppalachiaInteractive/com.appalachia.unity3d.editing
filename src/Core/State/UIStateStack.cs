using System.Collections.Generic;
using Unity.Profiling;

namespace Appalachia.Editing.Core.State
{
    public abstract class UIStateStack<T>
    {
        private const string _PRF_PFX = nameof(UIStateStack<T>) + ".";
        
        private Stack<T> _stack;

        protected abstract T GetCurrent();
        protected abstract void SetNew(T value);

        private static readonly ProfilerMarker _PRF_Push = new ProfilerMarker(_PRF_PFX + nameof(Push));
        public void Push(T newValue)
        {
            using (_PRF_Push.Auto())
            {
                if (_stack == null)
                {
                    _stack = new Stack<T>();
                }

                var currentValue = GetCurrent();
                _stack.Push(currentValue);

                SetNew(newValue);
            }
        }

        private static readonly ProfilerMarker _PRF_Pop = new ProfilerMarker(_PRF_PFX + nameof(Pop));
        public T Pop()
        {
            using (_PRF_Pop.Auto())
            {
                if (_stack == null)
                {
                    _stack = new Stack<T>();
                }

                if (_stack.Count == 0)
                {
                    return default;
                }

                var restoredValue = _stack.Pop();

                SetNew(restoredValue);

                return restoredValue;
            }
        }
    }
}
