#if UNITY_EDITOR

#region

using Appalachia.CI.Integration.Attributes;
using Appalachia.Core.Objects.Root;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Core.Behaviours
{
    [ExecuteAlways]
    [InspectorIcon(Brand.EditorOnlyAppalachiaBehaviour.Icon)]
    public abstract class EditorOnlyAppalachiaBehaviour<T> : AppalachiaBehaviour<T>
        where T : EditorOnlyAppalachiaBehaviour<T>
    {
        /// <inheritdoc />
        protected override string GetBackgroundColor()
        {
            return Brand.EditorOnlyAppalachiaBehaviour.Banner;
        }

        /// <inheritdoc />
        protected override string GetFallbackTitle()
        {
            return Brand.EditorOnlyAppalachiaBehaviour.Fallback;
        }

        /// <inheritdoc />
        protected override string GetTitle()
        {
            return Brand.EditorOnlyAppalachiaBehaviour.Text;
        }

        /// <inheritdoc />
        protected override string GetTitleColor()
        {
            return Brand.EditorOnlyAppalachiaBehaviour.Color;
        }
    }
}

#endif
