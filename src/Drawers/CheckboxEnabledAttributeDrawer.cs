using Appalachia.Editing.Core.Fields;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace Appalachia.Editing.Drawers
{
    public class CheckboxEnabledAttributeDrawer<T> : OdinValueDrawer<CheckboxField<T>>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            CallNextDrawer(label);
        }
    }
}
