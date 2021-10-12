using UnityEngine;

namespace Appalachia.Editing.Core.State
{
    public sealed class ContentColorStack : UIStateStack<Color>
    {
        protected override Color GetCurrent()
        {
            return GUI.contentColor;
        }

        protected override void SetNew(Color value)
        {
            GUI.contentColor = value;
        }
    }
}
