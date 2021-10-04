using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    public class TitleContext
    {
        public string ErrorMessage;
        public ValueResolver<string> TitleHelper;
        public ValueResolver<string> SubtitleHelper;
        public ValueResolver<Color> ColorHelper;
        public IfAttributeHelper HideHelper;
    }
}
