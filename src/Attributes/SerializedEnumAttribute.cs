using System;
using UnityEngine;

namespace Appalachia.Core.Enums
{
    public class SerializedEnumAttribute : PropertyAttribute
    {
        public readonly Type type;

        public SerializedEnumAttribute(Type type)
        {
            this.type = type;
        }
    }
}