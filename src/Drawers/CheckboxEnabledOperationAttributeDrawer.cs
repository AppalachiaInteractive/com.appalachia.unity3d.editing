using Appalachia.Editing.Core.Fields;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace Appalachia.Editing.Drawers
{
    public class CheckboxEnabledOperationAttributeDrawer<T> : OdinValueDrawer<CheckboxOperationField<T>>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            CallNextDrawer(label);
        }
    }
}
