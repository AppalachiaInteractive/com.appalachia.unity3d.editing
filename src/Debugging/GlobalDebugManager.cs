using Appalachia.Editing.Behaviours;
using Sirenix.OdinInspector;

namespace Appalachia.Editing.Debugging
{
    public class GlobalDebugManager : EditorOnlySingletonMonoBehaviour<GlobalDebugManager>
    {
#if UNITY_EDITOR
        [InlineProperty, InlineEditor, HideLabel]
        public GlobalDebug debug;

        void Update()
        {
            debug.Update();
        }
#endif
        public override EditorOnlyExclusionStyle exclusionStyle => EditorOnlyExclusionStyle.ObjectIfNoConflict;
    }
}
