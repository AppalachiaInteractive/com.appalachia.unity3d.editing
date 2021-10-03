#region

using System;
using System.Diagnostics;
using Sirenix.OdinInspector;

#endregion

namespace Appalachia.Core.Editing.Attributes
{
    [DontApplyToListElements]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    [Conditional("UNITY_EDITOR")]
    public sealed class SmartInlineButtonAttribute : Attribute
    {
        public string MemberMethod;

        public string Label;

        public bool Bold;

        public bool Before;

        public string Color;

        public string DisableIf;

        public SmartInlineButtonAttribute(
            string memberMethod,
            string label = null,
            bool bold = true,
            bool before = false,
            string color = null,
            string disableIf = null)
        {
            Bold = bold;
            Before = before;
            Color = color;
            MemberMethod = memberMethod;
            Label = label;
            DisableIf = disableIf;
        }
    }
}
