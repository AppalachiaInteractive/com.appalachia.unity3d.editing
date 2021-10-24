using System;
using UnityEngine;

namespace Appalachia.Editing.Core.Layout
{
    public class RowButton<T>
    {
        public Action<T> action;
        public Func<T, bool> enabled;
        public Func<T, Color> backgroundColor;
        public string label;
    }
}
