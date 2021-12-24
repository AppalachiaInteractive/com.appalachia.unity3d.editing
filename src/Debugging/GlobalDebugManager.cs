using Appalachia.Editing.Core.Behaviours;
using Sirenix.OdinInspector;

namespace Appalachia.Editing.Debugging
{
#if UNITY_EDITOR
    public class GlobalDebugManager : SingletonEditorOnlyAppalachiaBehaviour<GlobalDebugManager>
    {
        [InlineProperty]
        [InlineEditor]
        [HideLabel]
        public GlobalDebug debug;

        private void Update()
        {
            debug.Update();
        }
    }
#endif
}
