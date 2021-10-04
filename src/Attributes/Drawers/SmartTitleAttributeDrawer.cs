#region

using Appalachia.Editing.Attributes.Drawers.Contexts;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using Unity.Profiling;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Attributes.Drawers
{
    [DrawerPriority(1.0)]
    public sealed class SmartTitleAttributeDrawer : OdinAttributeDrawer<SmartTitleAttribute>
    {
        private const string _PRF_PFX = nameof(SmartTitleAttributeDrawer) + ".";

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout = new ProfilerMarker(_PRF_PFX + nameof(DrawPropertyLayout));

        private TitleContext _propertyContext;
        
        protected override void DrawPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawPropertyLayout.Auto())
            {
                var property = Property;
                var attribute = Attribute;

                if (_propertyContext == null)
                {
                    _propertyContext = new TitleContext();
                    _propertyContext.TitleHelper = ValueResolver.Get<string>(property, attribute.Title, _propertyContext.ErrorMessage);
                    _propertyContext.SubtitleHelper = ValueResolver.Get<string>(
                        property,
                        attribute.Subtitle,
                        
                        _propertyContext.ErrorMessage
                    );
                    _propertyContext.ColorHelper = ValueResolver.Get<Color>(property, attribute.Color);

                    var canHide = !string.IsNullOrWhiteSpace(Attribute.HideIfMemberName);
                    if (canHide)
                    {
                        _propertyContext.HideHelper = new IfAttributeHelper(Property, Attribute.HideIfMemberName);
                    }
                }

                if (attribute.Below)
                {
                    CallNextDrawer(label);
                }

                var isHidden = false;

                if (_propertyContext.HideHelper != null)
                {
                    if (_propertyContext.HideHelper.ErrorMessage != null)
                    {
                        SirenixEditorGUI.ErrorMessageBox(_propertyContext.HideHelper.ErrorMessage);
                    }
                    else
                    {
                        isHidden = _propertyContext.HideHelper.GetValue(true);
                    }
                }

                if (_propertyContext.ErrorMessage != null)
                {
                    SirenixEditorGUI.ErrorMessageBox(_propertyContext.ErrorMessage);
                }
                else if (!isHidden)
                {
                    TitleAttributeHelper.Title(
                        _propertyContext.TitleHelper.GetValue(),
                        _propertyContext.SubtitleHelper.GetValue(),
                        (TextAlignment) attribute.Alignment,
                        attribute.HorizontalLine,
                        attribute.Bold,
                        attribute.Color != null ? _propertyContext.ColorHelper.GetValue() : default
                    );
                }

                if (!attribute.Below)
                {
                    CallNextDrawer(label);
                }
            }
        }
    }
}
