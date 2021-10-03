#region

using Appalachia.Core.Editing.Attributes.Drawers.Contexts;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Core.Editing.Attributes.Drawers
{
    public sealed class SmartTitleGroupAttributeDrawer : OdinGroupDrawer<SmartTitleGroupAttribute>
    {
        private const string _PRF_PFX = nameof(SmartTitleGroupAttributeDrawer) + ".";

        private static readonly ProfilerMarker _PRF_DrawPropertyLayout = new ProfilerMarker(_PRF_PFX + nameof(DrawPropertyLayout));
        
        private TitleContext _propertyContext;
        private ValueResolver<Color> _colorContext;
        
        protected override void DrawPropertyLayout(GUIContent label)
        {
            using (_PRF_DrawPropertyLayout.Auto())
            {
                var property = Property;
                var attribute = Attribute;

                if (_propertyContext == null)
                {
                    _propertyContext = new TitleContext();
                    _propertyContext.TitleHelper = ValueResolver.Get(property,    attribute.GroupName, _propertyContext.ErrorMessage);
                    _propertyContext.SubtitleHelper = ValueResolver.Get(property, attribute.Subtitle,  _propertyContext.ErrorMessage);
                }

                if (_colorContext == null)
                {
                    _colorContext = ValueResolver.Get<Color>(property, attribute.Color);
                }

                if (_propertyContext.ErrorMessage != null)
                {
                    SirenixEditorGUI.ErrorMessageBox(_propertyContext.ErrorMessage);
                }
                else if (_colorContext.ErrorMessage != null)
                {
                    SirenixEditorGUI.ErrorMessageBox(_colorContext.ErrorMessage);
                }
                else
                {
                    var title = _propertyContext.TitleHelper.GetValue();
                    var subtitle = _propertyContext.SubtitleHelper.GetValue();

                    TitleAttributeHelper.Title(
                        title,
                        subtitle,
                        (TextAlignment) attribute.Alignment,
                        attribute.HorizontalLine,
                        attribute.Bold,
                        attribute.Color != null ? _colorContext.GetValue() : default
                    );
                }

                GUIHelper.PushIndentLevel(EditorGUI.indentLevel + (attribute.Indent ? 1 : 0));

                for (var index = 0; index < property.Children.Count; ++index)
                {
                    var child = property.Children[index];
                    child.Draw(child.Label);
                }

                GUIHelper.PopIndentLevel();
            }
        }
    }
}
