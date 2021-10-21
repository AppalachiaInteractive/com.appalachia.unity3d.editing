using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public interface IButtonMetadata
    {
        public bool Button(
            bool enabled = true,
            Color contentColor = default,
            Color backgroundColor = default);
    }
}
