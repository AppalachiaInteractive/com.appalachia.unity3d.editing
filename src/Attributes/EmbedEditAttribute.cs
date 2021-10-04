#region

using System;
using Sirenix.OdinInspector;

#endregion

namespace Appalachia.Editing.Attributes
{
    [IncludeMyAttributes]
    [InlineEditor(Expanded = true)]
    [HideLabel]
    [LabelWidth(0)]
    public class EmbedEditAttribute : Attribute
    {
    }
}
