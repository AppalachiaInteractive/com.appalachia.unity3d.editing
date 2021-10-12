using UnityEditor;

namespace Appalachia.Editing.Core.State
{
    public sealed class LabelWidthStack : UIStateStack<float>
    {
        protected override float GetCurrent()
        {
            return EditorGUIUtility.labelWidth;
        }

        protected override void SetNew(float value)
        {
            EditorGUIUtility.labelWidth = value;
        }
    }
}
