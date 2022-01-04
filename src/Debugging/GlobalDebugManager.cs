#if UNITY_EDITOR
using Appalachia.Editing.Core.Behaviours;
using Sirenix.OdinInspector;

namespace Appalachia.Editing.Debugging
{
    public class GlobalDebugManager : SingletonEditorOnlyAppalachiaBehaviour<GlobalDebugManager>
    {
        [InlineProperty]
        [InlineEditor]
        [HideLabel]
        public GlobalDebug debug;

        private void Update()
        {
            if (!DependenciesAreReady || !FullyInitialized)
            {
                return;
            }
            
            debug.Update();
        }
    }
}

#endif