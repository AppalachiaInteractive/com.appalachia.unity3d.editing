using System;
using System.Diagnostics;
using Appalachia.Editing.Core.Operations;
using Sirenix.OdinInspector;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public struct CheckboxOperationField<T>
    {
        [HideLabel]
        [HorizontalGroup(.1f)]
        public bool enabled;

        [HideLabel]
        [HorizontalGroup(.25f)]
        public CheckboxOperationType operation;

        [HideLabel]
        [HorizontalGroup]
        [InlineProperty]
        public T value;

        [DebuggerStepThrough] public static implicit operator T(CheckboxOperationField<T> field)
        {
            return field.value;
        }
    }
}
