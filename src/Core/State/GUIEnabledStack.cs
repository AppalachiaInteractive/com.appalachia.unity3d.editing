using UnityEngine;

namespace Appalachia.Editing.Core.State
{
    public sealed class GUIEnabledStack : UIStateStack<bool>
    {
        protected override bool GetCurrent()
        {
            return GUI.enabled;
        }

        protected override void SetNew(bool value, bool pushing)
        {
            GUI.enabled = value;
        }
    }
}
