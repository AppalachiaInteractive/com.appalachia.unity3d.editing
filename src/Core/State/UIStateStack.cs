using System.Collections.Generic;
using Unity.Profiling;

namespace Appalachia.Editing.Core.State
{
    public abstract class UIStateStack<T>
    {
        private const string _PRF_PFX = nameof(UIStateStack<T>) + ".";

        private static readonly ProfilerMarker _PRF_Push = new(_PRF_PFX + nameof(Push));
        private static readonly ProfilerMarker _PRF_Pop = new(_PRF_PFX + nameof(Pop));

        private Stack<T> _stack;

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

                SetNew(restoredValue, false);

                return restoredValue;
            }
        }

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

                SetNew(newValue, true);
            }
        }

        protected abstract T GetCurrent();
        protected abstract void SetNew(T value, bool pushing);
    }
}
