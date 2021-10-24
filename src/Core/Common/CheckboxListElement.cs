using Sirenix.OdinInspector;

namespace Appalachia.Editing.Core.Common
{
    [HideReferenceObjectPicker]
    public class CheckboxListElement<T>
    {
        [HideLabel] public bool include;
        public T element;
    }
}
