using Appalachia.Core.Objects.Root;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Editing.Core.Common
{
    [HideReferenceObjectPicker]
    public sealed class CheckboxListElement<T> : AppalachiaBase
    {
        public CheckboxListElement(Object owner) : base(owner)
        {
            Name = GetType().Name;
        }

        #region Fields and Autoproperties

        [HideLabel] public bool include;
        public T element;

        public override string Name { get; }

        #endregion
    }
}
