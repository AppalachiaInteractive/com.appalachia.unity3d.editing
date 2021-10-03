#region

using System;
using Sirenix.OdinInspector;

#endregion

namespace Appalachia.Core.Editing.Attributes
{
    [IncludeMyAttributes]
    [InlineProperty]
    [HideLabel]
    [LabelWidth(0)]
    public class EmbedAttribute : Attribute
    {
    }
}
