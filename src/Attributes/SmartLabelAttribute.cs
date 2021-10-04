#region

using System;
using System.Diagnostics;
using Sirenix.OdinInspector;
using Unity.Mathematics;

#endregion

namespace Appalachia.Editing.Attributes
{
    [DontApplyToListElements]
    [AttributeUsage(AttributeTargets.All)]
    [Conditional("UNITY_EDITOR")]
    public class SmartLabelAttribute : Attribute
    {
        public SmartLabelAttribute()
        {
            
        }
        public SmartLabelAttribute(string text)
        {
            Text = text;
        }

        public SmartLabelAttribute(SmartLabelAttribute sla)
        {
            _propertyColor = sla._propertyColor;
            _text = sla._text;
            _bold = sla._bold;
            _postfix = sla._postfix;
            _hue = sla._hue;
            _saturation = sla._saturation;
            _value = sla._value;
            AlignWith = sla.AlignWith;
            Padding = sla.Padding;

        }

        public SmartLabelAttribute(SmartLabelChildrenAttribute sla)
        {
           _propertyColor = sla._propertyColor;
           _bold = sla._bold;
           _postfix = sla._suffix;
           _hue = sla._hue;
           _saturation = sla._saturation;
           _value = sla._value;
           AlignWith = sla.AlignWith;
           Padding = sla.Padding;

        }

        private string _propertyColor;
        private string _text;
        private bool _bold;
        private bool _postfix;
        private int _hue;
        private int _saturation;
        private int _value;
        private bool _shallowColor;
        
        public string AlignWith { get; set; }

        public string Text { get; set; }
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
        
        public bool Postfix
        {
            get => _postfix;
            set
            {
                _postfix = value;
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

        public bool ShallowColor
        {
            get => _shallowColor;
            set
            {
                _shallowColor = value;
            }
        }

        public bool HasPropertyColor { get; private set; }
        public bool HasHue { get; private set; }

        public bool HasSaturation { get; private set; }

        public bool HasValue { get; private set; }
    }
}
