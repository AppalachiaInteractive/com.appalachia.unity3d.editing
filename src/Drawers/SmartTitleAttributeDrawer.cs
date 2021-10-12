#region

using Appalachia.Core.Attributes.Editing;
using Appalachia.Editing.Drawers.Contexts;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using Unity.Profiling;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Drawers
{
    [DrawerPriority(1.0)]
    public sealed class
        SmartTitleAttributeDrawer : ContextualPropertyDrawer<SmartTitleAttribute, SmartTitleContext>
    {
        private const string _PRF_PFX = nameof(SmartTitleAttributeDrawer) + ".";

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout =
            new(_PRF_PFX + nameof(DrawPropertyLayout));

        protected override void DrawPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawPropertyLayout.Auto())
            {
                if (Attribute.Below)
                {
                    CallNextDrawer(label);
                }

                var isHidden = false;

                if (context.HideHelper != null)
                {
                    if (context.HideHelper.ErrorMessage != null)
                    {
                        SirenixEditorGUI.ErrorMessageBox(context.HideHelper.ErrorMessage);
                    }
                    else
                    {
                        isHidden = context.HideHelper.GetValue(true);
                    }
                }

                if (context.hasError)
                {
                    context.DrawErrors();
                }
                else if (!isHidden)
                {
                    TitleAttributeHelper.Title(
                        context.TitleHelper.GetValue(),
                        context.SubtitleHelper.GetValue(),
                        (TextAlignment) Attribute.Alignment,
                        Attribute.HorizontalLine,
                        Attribute.Bold,
                        Attribute.Color != null ? context.ColorHelper.GetValue() : default
                    );
                }

                if (!Attribute.Below)
                {
                    CallNextDrawer(label);
                }
            }
        }
    }
}
