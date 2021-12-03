using Appalachia.Core.Behaviours;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Graphy.Graph
{
    public abstract class G_Graph: AppalachiaBehaviour
    {
        #region Methods -> Protected

        /// <summary>
        ///     Updates the graph/s.
        /// </summary>
        protected abstract void UpdateGraph();

        /// <summary>
        ///     Creates the points for the graph/s.
        /// </summary>
        protected abstract void CreatePoints();

        #endregion
    }
}
