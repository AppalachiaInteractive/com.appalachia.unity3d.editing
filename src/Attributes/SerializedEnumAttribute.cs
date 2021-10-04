using System;
using UnityEngine;

namespace Appalachia.Editing.Attributes
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