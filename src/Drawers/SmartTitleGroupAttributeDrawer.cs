#region

using Appalachia.Core.Attributes.Editing;
using Appalachia.Editing.Core.State;
using Appalachia.Editing.Drawers.Contexts;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Drawers
{
    public sealed class
        SmartTitleGroupAttributeDrawer : ContextualGroupDrawer<SmartTitleGroupAttribute,
            SmartTitleGroupContext>
    {
        private const string _PRF_PFX = nameof(SmartTitleGroupAttributeDrawer) + ".";

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout =
            new(_PRF_PFX + nameof(DrawPropertyLayout));

        protected override void DrawPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawPropertyLayout.Auto())
            {
                if (context.hasError)
                {
                    context.DrawErrors();
                }
                else
                {
                    var title = context.TitleHelper.GetValue();
                    var subtitle = context.SubtitleHelper.GetValue();

                    TitleAttributeHelper.Title(
                        title,
                        subtitle,
                        (TextAlignment) Attribute.Alignment,
                        Attribute.HorizontalLine,
                        Attribute.Bold,
                        Attribute.Color != null ? context.ColorHelper.GetValue() : default
                    );
                }

                UIStateStacks.indentLevel.Push(EditorGUI.indentLevel + (Attribute.Indent ? 1 : 0));

                for (var index = 0; index < Property.Children.Count; ++index)
                {
                    var child = Property.Children[index];
                    child.Draw(child.Label);
                }

                UIStateStacks.indentLevel.Pop();
            }
        }
    }
}
