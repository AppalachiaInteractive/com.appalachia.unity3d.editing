#if UNITY_EDITOR
using Appalachia.CI.Integration.Attributes;
using Appalachia.Core.Objects.Root;
using UnityEngine;

namespace Appalachia.Editing.Core.Behaviours
{
    [ExecuteAlways]
    [InspectorIcon(Brand.SingletonEditorOnlyAppalachiaBehaviour.Icon)]
    public abstract class SingletonEditorOnlyAppalachiaBehaviour<T> : SingletonAppalachiaBehaviour<T>
        where T : SingletonEditorOnlyAppalachiaBehaviour<T>
    {
        protected override string GetBackgroundColor()
        {
            return Brand.SingletonEditorOnlyAppalachiaBehaviour.Banner;
        }

        protected override string GetFallbackTitle()
        {
            return Brand.SingletonEditorOnlyAppalachiaBehaviour.Fallback;
        }

        protected override string GetTitle()
        {
            return Brand.SingletonEditorOnlyAppalachiaBehaviour.Text;
        }

        protected override string GetTitleColor()
        {
            return Brand.SingletonEditorOnlyAppalachiaBehaviour.Color;
        }
    }
}

#endif
