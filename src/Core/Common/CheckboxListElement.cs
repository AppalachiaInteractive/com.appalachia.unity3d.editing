using Sirenix.OdinInspector;

namespace Appalachia.Editing.Core.Common
{
    [HideReferenceObjectPicker]
    public class CheckboxListElement<T>
    {
        public T element;

        [HideLabel] public bool include;
    }
}
