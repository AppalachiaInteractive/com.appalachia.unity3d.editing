using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;

namespace Appalachia.Editing.Attributes.Drawers.Contexts
{
    public class SmartLabelContext
    {
        public ValueResolver<Color> ColorHelper;
        public string InputLabelText;
        public string OutputLabelText;
        public float Size;
        public Color? HSVColor;
        public bool ColorError;
    }
}