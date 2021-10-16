using UnityEngine;

namespace Appalachia.Editing.Core.State
{
    public sealed class BackgroundColorStack : UIStateStack<Color>
    {
        protected override Color GetCurrent()
        {
            return GUI.backgroundColor;
        }

        protected override void SetNew(Color value, bool pushing)
        {
            GUI.backgroundColor = value;
        }
    }
}
