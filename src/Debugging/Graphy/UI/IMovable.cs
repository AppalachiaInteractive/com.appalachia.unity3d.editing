namespace Appalachia.Editing.Debugging.Graphy.UI
{
    public interface IMovable
    {
        /// <summary>
        ///     Sets the position of the module.
        /// </summary>
        /// <param name="newModulePosition">
        ///     The new position of the module.
        /// </param>
        void SetPosition(GraphyManager.ModulePosition newModulePosition);
    }
}
