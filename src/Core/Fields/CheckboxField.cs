using System;
using System.Diagnostics;
using Sirenix.OdinInspector;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public struct CheckboxField<T> // : SerializedScriptableObject
    {
        [HideLabel]
        [HorizontalGroup(.1f)]
        public bool enabled;

        [HideLabel]
        [HorizontalGroup]
        [InlineProperty]
        public T value;

        [DebuggerStepThrough] public static implicit operator T(CheckboxField<T> field)
        {
            return field.value;
        }
    }
}
