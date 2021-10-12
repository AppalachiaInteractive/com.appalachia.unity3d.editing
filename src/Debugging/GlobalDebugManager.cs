using Appalachia.Editing.Core.Behaviours;
using Sirenix.OdinInspector;

namespace Appalachia.Editing.Debugging
{
    public class GlobalDebugManager : EditorOnlySingletonMonoBehaviour<GlobalDebugManager>
    {
        public override EditorOnlyExclusionStyle exclusionStyle =>
            EditorOnlyExclusionStyle.ObjectIfNoConflict;
#if UNITY_EDITOR
        [InlineProperty]
        [InlineEditor]
        [HideLabel]
        public GlobalDebug debug;

        private void Update()
        {
            debug.Update();
        }
#endif
    }
}
