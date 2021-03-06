#if UNITY_EDITOR
using System;
using System.Diagnostics;
using UnityEngine;

namespace Appalachia.Editing.Labels
{
    [Serializable]
    public struct LabelAssignmentCollection : IEquatable<LabelAssignmentCollection>
    {
        public LabelAssignmentCollection(
            string baseTerm,
            Vector3 multiplier,
            params LabelAssignmentTerm[] terms)
        {
            this.baseTerm = baseTerm;
            this.terms = terms;
            this.multiplier = multiplier;
        }

        #region Fields and Autoproperties

        public readonly LabelAssignmentTerm[] terms;
        public readonly string baseTerm;
        public readonly Vector3 multiplier;

        #endregion

        [DebuggerStepThrough]
        public static bool operator ==(LabelAssignmentCollection left, LabelAssignmentCollection right)
        {
            return left.Equals(right);
        }

        [DebuggerStepThrough]
        public static bool operator !=(LabelAssignmentCollection left, LabelAssignmentCollection right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        [DebuggerStepThrough]
        public override bool Equals(object obj)
        {
            return obj is LabelAssignmentCollection other && Equals(other);
        }

        /// <inheritdoc />
        [DebuggerStepThrough]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = baseTerm != null ? baseTerm.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ multiplier.GetHashCode();
                hashCode = (hashCode * 397) ^ (terms != null ? terms.GetHashCode() : 0);
                return hashCode;
            }
        }

        #region IEquatable<LabelAssignmentCollection> Members

        [DebuggerStepThrough]
        public bool Equals(LabelAssignmentCollection other)
        {
            return (baseTerm == other.baseTerm) &&
                   multiplier.Equals(other.multiplier) &&
                   Equals(terms, other.terms);
        }

        #endregion
    }
}

#endif
