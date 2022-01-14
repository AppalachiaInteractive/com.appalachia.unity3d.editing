#if UNITY_EDITOR
using System.Diagnostics;
using Appalachia.Utility.Strings;

namespace Appalachia.Editing.Labels
{
    public struct LabelAssignmentTerm
    {
        public LabelAssignmentTerm(string term, float allowedMagnitude)
        {
            this.term = term;
            this.allowedMagnitude = allowedMagnitude;
        }

        #region Fields and Autoproperties

        public readonly float allowedMagnitude;

        public readonly string term;

        #endregion

        [DebuggerStepThrough]
        public override string ToString()
        {
            return ZString.Format("{0} ({1:F1}m)", term, allowedMagnitude);
        }
    }
}

#endif
