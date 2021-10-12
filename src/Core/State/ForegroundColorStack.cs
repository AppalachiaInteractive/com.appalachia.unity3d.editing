using UnityEngine;

namespace Appalachia.Editing.Core.State
{
    public sealed class ForegroundColorStack : UIStateStack<Color>
    {
        protected override Color GetCurrent()
        {
            return GUI.color;
        }

        protected override void SetNew(Color value)
        {
            GUI.color = value;
        }
    }
}
