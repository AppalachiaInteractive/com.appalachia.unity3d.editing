#region

using System;
using System.Diagnostics;
using Appalachia.Utility.Colors;
using Sirenix.OdinInspector;

#endregion

namespace Appalachia.Core.Editing.Attributes
{
    [DontApplyToListElements]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    [Conditional("UNITY_EDITOR")]
    public sealed class ToggleButtonAttribute : Attribute
    {
        public string MemberMethod;

        public string Label;

        public bool Bold;

        public Colors.Enum False;

        public Colors.Enum True;

        public ToggleButtonAttribute(
            string memberMethod,
            string label = null,
            bool bold = true,
            Colors.Enum falseColor = Colors.Enum.IndianRed1,
            Colors.Enum trueColor = Colors.Enum.ForestGreen)
        {
            Bold = bold;
            False = falseColor;
            True = trueColor;
            MemberMethod = memberMethod;
            Label = label;
        }
    }
}
