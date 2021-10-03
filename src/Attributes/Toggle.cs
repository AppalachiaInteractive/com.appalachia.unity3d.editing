/*
using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Core.Editing.Attributes
{
    [Serializable]
    public struct Toggle : IEquatable<Toggle>, IEquatable<bool>
    {
        public Toggle(bool value = false)
        {
            
        }
        
        [SerializeField, HideInInspector] public bool value;
        
        private void 
        
        #region IEquatable
        
        public static implicit operator Toggle(bool b) => new Toggle(b);
        public static implicit operator bool(Toggle t) => t.value;

        public bool Equals(Toggle other)
        {
            return value == other.value;
        }

        public bool Equals(bool other)
        {
            return value == other;
        }

        public override bool Equals(object obj)
        {
            return (obj is Toggle other && Equals(other)) || 
                (obj is bool bother && Equals(bother));
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(Toggle left, Toggle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Toggle left, Toggle right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Toggle left, bool right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Toggle left, bool right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
*/


