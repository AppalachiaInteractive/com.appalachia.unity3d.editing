using Appalachia.Core.Attributes.Editing;
using Appalachia.Editing.Drawers.Contexts;
using Appalachia.Utility.Colors;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Drawers
{
    /// <summary>
    ///     Draws properties marked with <see cref="T:Sirenix.OdinInspector.ToggleButtonAttribute" />
    /// </summary>
    [DrawerPriority(DrawerPriorityLevel.WrapperPriority)]
    public sealed class ToggleButtonAttributeDrawer<T> : ContextualPropertyDrawer<
        ToggleButtonAttribute, ToggleButtonContext<T>, T>
    {
        /// <summary>Draws the Property.</summary>
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var value = Property.ValueEntry.WeakSmartValue as bool? ?? false;
            var color = Colors.FromEnum(value ? Attribute.True : Attribute.False);

            if (context.hasError)
            {
                context.DrawErrors();
                GUIHelper.PushLabelColor(color);
                GUIHelper.PushIsBoldLabel(Attribute.Bold);
                CallNextDrawer(label);
                GUIHelper.PopLabelColor();
            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.BeginVertical();
                GUIHelper.PushLabelColor(color);
                GUIHelper.PushIsBoldLabel(Attribute.Bold);
                CallNextDrawer(label);
                GUIHelper.PopIsBoldLabel();
                GUIHelper.PopLabelColor();
                EditorGUILayout.EndVertical();

                GUIHelper.PushColor(color);

                if (GUILayout.Button(
                    context.LabelHelper.GetValue(),
                    EditorStyles.miniButton,
                    GUILayoutOptions.ExpandWidth(false).MinWidth(20f)
                ))
                {
                    if (context.StaticMethodCaller != null)
                    {
                        context.StaticMethodCaller();
                    }
                    else if (context.InstanceMethodCaller != null)
                    {
                        context.InstanceMethodCaller(ValueEntry.Property.ParentValues[0]);
                    }
                    else if (context.InstanceParameterMethodCaller != null)
                    {
                        context.InstanceParameterMethodCaller(
                            ValueEntry.Property.ParentValues[0],
                            ValueEntry.SmartValue
                        );
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
