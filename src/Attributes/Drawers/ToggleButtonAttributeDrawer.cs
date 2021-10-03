using System.Reflection;
using Appalachia.Core.Editing.Attributes.Drawers.Contexts;
using Appalachia.Utility.Reflection;
using Appalachia.Utility.Colors;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Core.Editing.Attributes.Drawers
{
    /// <summary>
    ///     Draws properties marked with <see cref="T:Sirenix.OdinInspector.ToggleButtonAttribute" />
    /// </summary>
    [DrawerPriority(DrawerPriorityLevel.WrapperPriority)]
    public sealed class ToggleButtonAttributeDrawer<T> : OdinAttributeDrawer<ToggleButtonAttribute, T>
    {

        private ButtonContext<T> _buttonContext;
        
        /// <summary>Draws the property.</summary>
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var valueEntry = ValueEntry;
            var attribute = Attribute;
            var property = Property;

            if (_buttonContext == null)
            {
                _buttonContext = new ButtonContext<T>();
                _buttonContext.LabelHelper = ValueResolver.Get(
                    Property,
                    attribute.Label ?? attribute.MemberMethod.SplitPascalCase(),
                    _buttonContext.ErrorMessage
                );

                if (_buttonContext.ErrorMessage == null)
                {
                    MethodInfo memberInfo;
                    if (AppaMemberFinder.Start(valueEntry.ParentType)
                                    .IsMethod()
                                    .IsNamed(attribute.MemberMethod)
                                    .HasNoParameters()
                                    .TryGetMember(out memberInfo, out _buttonContext.ErrorMessage))
                    {
                        if (memberInfo.IsStatic())
                        {
                            _buttonContext.StaticMethodCaller = EmitUtilities.CreateStaticMethodCaller(memberInfo);
                        }
                        else
                        {
                            _buttonContext.InstanceMethodCaller = EmitUtilities.CreateWeakInstanceMethodCaller(memberInfo);
                        }
                    }
                    else if (AppaMemberFinder.Start(valueEntry.ParentType)
                                         .IsMethod()
                                         .IsNamed(attribute.MemberMethod)
                                         .HasParameters<T>()
                                         .TryGetMember(out memberInfo, out _buttonContext.ErrorMessage))
                    {
                        if (memberInfo.IsStatic())
                        {
                            _buttonContext.ErrorMessage = "Static parameterized method is currently not supported.";
                        }
                        else
                        {
                            _buttonContext.InstanceParameterMethodCaller = EmitUtilities.CreateWeakInstanceMethodCaller<T>(memberInfo);
                        }
                    }
                }
            }

            var value = property.ValueEntry.WeakSmartValue as bool? ?? false;
            var color = Colors.FromEnum(value ? attribute.True : attribute.False);

            if (_buttonContext.ErrorMessage != null)
            {
                SirenixEditorGUI.ErrorMessageBox(_buttonContext.ErrorMessage);
                GUIHelper.PushLabelColor(color);
                GUIHelper.PushIsBoldLabel(attribute.Bold);
                CallNextDrawer(label);
                GUIHelper.PopLabelColor();
            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.BeginVertical();
                GUIHelper.PushLabelColor(color);
                GUIHelper.PushIsBoldLabel(attribute.Bold);
                CallNextDrawer(label);
                GUIHelper.PopIsBoldLabel();
                GUIHelper.PopLabelColor();
                EditorGUILayout.EndVertical();

                GUIHelper.PushColor(color);

                if (GUILayout.Button(
                    _buttonContext.LabelHelper.GetValue(),
                    EditorStyles.miniButton,
                    GUILayoutOptions.ExpandWidth(false).MinWidth(20f)
                ))
                {
                    if (_buttonContext.StaticMethodCaller != null)
                    {
                        _buttonContext.StaticMethodCaller();
                    }
                    else if (_buttonContext.InstanceMethodCaller != null)
                    {
                        _buttonContext.InstanceMethodCaller(valueEntry.Property.ParentValues[0]);
                    }
                    else if (_buttonContext.InstanceParameterMethodCaller != null)
                    {
                        _buttonContext.InstanceParameterMethodCaller(valueEntry.Property.ParentValues[0], valueEntry.SmartValue);
                    }
                    else
                    {
                        Debug.LogError("No method found.");
                    }
                }

                GUIHelper.PopColor();

                EditorGUILayout.EndHorizontal();
            }
        }
    }
}