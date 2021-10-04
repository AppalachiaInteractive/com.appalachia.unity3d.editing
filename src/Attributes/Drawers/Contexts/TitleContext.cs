using Sirenix.OdinInspector.Editor.Drawers;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    public class TitleContext
    {
        public ValueResolver<Color> ColorHelper;
        public string ErrorMessage;
        public IfAttributeHelper HideHelper;
        public ValueResolver<string> SubtitleHelper;
        public ValueResolver<string> TitleHelper;
    }
}
