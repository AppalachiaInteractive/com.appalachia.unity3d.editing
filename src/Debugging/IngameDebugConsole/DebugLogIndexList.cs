﻿using System;

namespace Appalachia.Editing.Debugging.IngameDebugConsole
{
    public class DebugLogIndexList
    {
        public DebugLogIndexList()
        {
            indices = new int[64];
            size = 0;
        }

        private int size;
        private int[] indices;

        public int Count => size;

        public int this[int index] => indices[index];

        public void Add(int index)
        {
            if (size == indices.Length)
            {
                Array.Resize(ref indices, size * 2);
            }

            indices[size++] = index;
        }

        public void Clear()
        {
            size = 0;
        }

        public int IndexOf(int index)
        {
            return Array.IndexOf(indices, index);
        }
    }
}
