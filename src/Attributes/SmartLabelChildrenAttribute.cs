using System;
using System.Diagnostics;
using Unity.Mathematics;

namespace Appalachia.Editing.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    [Conditional("UNITY_EDITOR")]
    public class SmartLabelChildrenAttribute : Attribute
    {
        internal string _propertyColor;
        internal bool _bold;
        internal bool _suffix;
        internal int _hue;
        internal int _saturation;
        internal int _value;
        public string AlignWith { get; set; }

        public float Padding { get; set; } = 4f;

        public float PixelsPerCharacter { get; set; } = 8.25f;

        public bool Bold
        {
            get => _bold;
            set
            {
                _bold = value;
            }
        }
        
        public bool Suffix
        {
            get => _suffix;
            set
            {
                _suffix = value;
            }
        }

        public int Hue
        {
            get => _hue;
            set
            {
                _hue = math.clamp(value, 0, 359);
                HasHue = true;
            }
        }

        public int Saturation
        {
            get => _saturation;
            set
            {
                _saturation = math.clamp(value, 0, 100);
                HasSaturation = true;
            }
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = math.clamp(value, 0, 100);
                HasValue = true;
            }
        }

        public string Color
        {
            get => _propertyColor;
            set
            {
                _propertyColor = value;
                HasPropertyColor = true;
            }
        }

        public bool HasPropertyColor { get; private set; }
        public bool HasHue { get; private set; }

        public bool HasSaturation { get; private set; }

        public bool HasValue { get; private set; }
    }
}
