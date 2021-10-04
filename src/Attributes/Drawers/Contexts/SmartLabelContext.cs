using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    public class SmartLabelContext
    {
        public bool ColorError;
        public ValueResolver<Color> ColorHelper;
        public Color? HSVColor;
        public string InputLabelText;
        public string OutputLabelText;
        public float Size;
    }
}
