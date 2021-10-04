#region

using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Preferences
{
    [ShowInInspector]
    [InlineProperty]
    [HideReferenceObjectPicker]
    public sealed class PREF<T>
    {
        private readonly T _defaultValue;
        private readonly string _grouping;
        private readonly T _high;

        private bool _isAwake;
        private readonly string _key;
        private readonly string _label;
        private readonly T _low;
        private string _niceLabel;
        private readonly int _order;

        private readonly PREF_STATE<T> _prefs;
        private bool _reset;

        [HideLabel]
        [InlineProperty]
        [OnValueChanged(nameof(UIApplyValue))]
        [SerializeField]
        [InlineButton(nameof(Reset), " Reset ")]
        private T _value;

        internal PREF(
            string key,
            string grouping,
            string label,
            T defaultValue,
            T low,
            T high,
            int order,
            bool reset)
        {
            _key = key;
            _grouping = grouping;
            _label = label;
            _defaultValue = defaultValue;
            _low = low;
            _high = high;
            _order = order;
            _prefs = PREF_STATES.Get<T>();
            _reset = reset;
        }

        public bool IsAwake => _isAwake;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                if (_isAwake)
                {
                    _prefs.API.Save(_key, _value, _low, _high);
                }
            }
        }

        public T v
        {
            get => Value;
            set => Value = value;
        }

        internal string Key => _key;
        internal string Grouping => _grouping;
        internal string Label => _label;

        internal string NiceLabel
        {
            get => _niceLabel;
            set => _niceLabel = value;
        }

        internal int Order => _order;

        internal T Low => _low;
        internal T High => _high;

        private void UIApplyValue()
        {
            if (_isAwake)
            {
                _prefs.API.Save(_key, _value, _low, _high);
            }
        }

        /*[HorizontalGroup("A", 52f)]
        [Button("Awake", ButtonSizes.Small)]
        [DisableIf(nameof(_isAwake))]*/
        public void WakeUp()
        {
            _value = _prefs.API.Get(_key, _defaultValue, _low, _high);

            ExecuteResetIfNecessary();
            _isAwake = true;
        }

        /*[HorizontalGroup("A", 58f)]
        [Button("Refresh", ButtonSizes.Small)]*/
        private void Refresh()
        {
            if (_isAwake)
            {
                _value = _prefs.API.Get(_key, _defaultValue, _low, _high);
            }
        }

        private void Reset()
        {
            _reset = true;
            ExecuteResetIfNecessary();
        }

        private void ExecuteResetIfNecessary()
        {
            if (_reset)
            {
                _value = _defaultValue;

                if (_isAwake)
                {
                    _prefs.API.Save(_key, _defaultValue, _low, _high);
                    _reset = false;
                }
            }
        }
    }
}
