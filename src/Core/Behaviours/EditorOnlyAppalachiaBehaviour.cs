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
        protected override string GetBackgroundColor()
        {
            return Brand.EditorOnlyAppalachiaBehaviour.Banner;
        }

        protected override string GetFallbackTitle()
        {
            return Brand.EditorOnlyAppalachiaBehaviour.Fallback;
        }

        protected override string GetTitle()
        {
            return Brand.EditorOnlyAppalachiaBehaviour.Text;
        }

        protected override string GetTitleColor()
        {
            return Brand.EditorOnlyAppalachiaBehaviour.Color;
        }
    }
}

#endif
