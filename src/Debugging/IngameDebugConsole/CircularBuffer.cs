// #define RESET_REMOVED_ELEMENTS

namespace Appalachia.Editing.Debugging.IngameDebugConsole
{
    public class CircularBuffer<T>
    {
        private readonly T[] arr;
        private int startIndex;

        public CircularBuffer(int capacity)
        {
            arr = new T[capacity];
        }

        public T this[int index] => arr[(startIndex + index) % arr.Length];

        public int Count { get; private set; }

        // Old elements are overwritten when capacity is reached
        public void Add(T value)
        {
            if (Count < arr.Length)
            {
                arr[Count++] = value;
            }
            else
            {
                arr[startIndex] = value;
                if (++startIndex >= arr.Length)
                {
                    startIndex = 0;
                }
            }
        }
    }
}
