#if UNITY_EDITOR
using Appalachia.Editing.Core.Behaviours;
using Sirenix.OdinInspector;

namespace Appalachia.Editing.Debugging
{
    public class RendererDebuggingManager : SingletonEditorOnlyAppalachiaBehaviour<RendererDebuggingManager>
    {
        #region Fields and Autoproperties

        [InlineProperty]
        [InlineEditor]
        [HideLabel]
        public RendererDebuggingSettings debug;

        #endregion

        #region Event Functions

        private void Update()
        {
            if (ShouldSkipUpdate)
            {
                return;
            }

            debug.Update();
        }

        #endregion
    }
}

#endif
