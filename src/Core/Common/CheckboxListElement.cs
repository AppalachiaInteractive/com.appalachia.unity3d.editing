using Appalachia.Core.Attributes;
using Appalachia.Core.Objects.Root;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Editing.Core.Common
{
    [HideReferenceObjectPicker]
    [NonSerializable]
    public sealed class CheckboxListElement<T> : AppalachiaBase
    {
        public CheckboxListElement(Object owner) : base(owner)
        {
            Name = GetType().Name;
        }

        #region Fields and Autoproperties

        [HideLabel] public bool include;
        public T element;

        /// <inheritdoc />
        public override string Name { get; }

        #endregion
    }
}
