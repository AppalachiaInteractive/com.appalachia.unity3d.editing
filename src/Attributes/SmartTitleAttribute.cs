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
    public class SmartTitleAttribute : Attribute
    {
        public string Title;

        public string Subtitle;

        public bool Bold;

        public bool HorizontalLine;

        public TitleAlignments Alignment;

        public string Color;

        public string HideIfMemberName;

        public bool Below;

        public SmartTitleAttribute(
            string title,
            string subtitle = null,
            TitleAlignments alignment = TitleAlignments.Left,
            bool horizontalLine = true,
            bool bold = true,
            string color = null,
            string hideIfMemberName = null,
            bool below = false)
        {
            Title = title ?? "null";
            Subtitle = subtitle;
            Bold = bold;
            Alignment = alignment;
            HorizontalLine = horizontalLine;
            Color = color;
            HideIfMemberName = hideIfMemberName;
            Below = below;
        }
    }
}
