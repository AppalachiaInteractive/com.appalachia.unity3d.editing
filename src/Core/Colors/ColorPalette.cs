using System;
using System.Text;
using Appalachia.Utility.Colors;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Colors
{
    [Serializable]
    public class ColorPalette
    {
        private const string _prefixSpace = "                        ";
        public Color error;
        public Color error2;
        public Color good;
        public Color good2;
        public Color notable;
        public Color selected;
        public Color warning;
        public Color warning2;

        private static StringBuilder _logBuilder;

        public ColorPalette()
        {
            SetDefaults(this);
        }

        public void Configure()
        {
            ColorPalettes.DrawScratchPalette(this);
        }

        public ColorPalette Copy()
        {
            var newPalette = new ColorPalette();

            foreach (var label in labels)
            {
                newPalette[label] = this[label];
            }

            return newPalette;
        }

        public void CopyFrom(ColorPalette other)
        {
            foreach (var label in labels)
            {
                this[label] = other[label];
            }
        }

        public void CopyTo(ColorPalette other)
        {
            foreach (var label in labels)
            {
                other[label] = this[label];
            }
        }

        public bool Draw()
        {
            var changed = false;

            for (var index = 0; index < labels.Length; index++)
            {
                var label = labels[index];
                var getter = getters[index];

                var initialValue = getter();
                var temp = EditorGUILayout.ColorField(label, initialValue);

                var thisChanged = temp != initialValue;

                changed = changed || thisChanged;

                if (thisChanged)
                {
                    var setter = setters[index];
                    setter(temp);
                }
            }

            return changed;
        }

        public void Log()
        {
            if (_logBuilder == null)
            {
                _logBuilder = new StringBuilder();
            }

            _logBuilder.Clear();

            foreach (var label in labels)
            {
                var color = this[label];

                var formatted =
                    $"{_prefixSpace}{label} = new Color({color.r}f, {color.g}f, {color.b}f, {color.a}f),";

                _logBuilder.AppendLine(formatted);
            }

            var logMessage = _logBuilder.ToString();

            Debug.Log(logMessage);
        }

        private Func<Color>[] GetGettersInternal()
        {
            return new Func<Color>[]
            {
                () => error,
                () => error2,
                () => warning,
                () => warning2,
                () => good,
                () => good2,
                () => selected,
                () => notable
            };
        }

        private string[] GetLabelsInternal()
        {
            return new[]
            {
                nameof(error),
                nameof(error2),
                nameof(warning),
                nameof(warning2),
                nameof(good),
                nameof(good2),
                nameof(selected),
                nameof(notable)
            };
        }

        private Action<Color>[] GetSettersInternal()
        {
            return new Action<Color>[]
            {
                c => error = c,
                c => error2 = c,
                c => warning = c,
                c => warning2 = c,
                c => good = c,
                c => good2 = c,
                c => selected = c,
                c => notable = c
            };
        }

        public static ColorPalette Default()
        {
            var newPalette = new ColorPalette();

            SetDefaults(newPalette);

            return newPalette;
        }

        private static void SetDefaults(ColorPalette p)
        {
            p.error = Color.red;
            p.error2 = Color.red.ScaleSaturation(.8f).ScaleValue(.8f);
            p.warning = Color.yellow;
            p.warning2 = Color.yellow.ScaleSaturation(.8f).ScaleValue(.8f);
            p.good = Color.green;
            p.good2 = Color.green.ScaleSaturation(.8f).ScaleValue(.8f);
            p.selected = Color.blue;
            p.notable = Color.cyan;
        }

#region Plumbing

        private string[] _labels;
        private Func<Color>[] _getters;
        private Action<Color>[] _setters;

        private Func<Color>[] getters
        {
            get
            {
                if (_getters == null)
                {
                    _getters = GetGettersInternal();
                }

                return _getters;
            }
        }

        private Action<Color>[] setters
        {
            get
            {
                if (_setters == null)
                {
                    _setters = GetSettersInternal();
                }

                return _setters;
            }
        }

        private string[] labels
        {
            get
            {
                if (_labels == null)
                {
                    _labels = GetLabelsInternal();

                    for (var index = 0; index < _labels.Length; index++)
                    {
                        var label = _labels[index];
                        _labels[index] = char.ToUpper(label[0]) + label.Substring(1);
                    }
                }

                return _labels;
            }
        }

        private Color this[string key]
        {
            get
            {
                for (var index = 0; index < labels.Length; index++)
                {
                    var label = labels[index];

                    if (label != key)
                    {
                        continue;
                    }

                    var getter = getters[index];
                    return getter();
                }

                return default;
            }
            set
            {
                for (var index = 0; index < labels.Length; index++)
                {
                    var label = labels[index];
                    if (label != key)
                    {
                        continue;
                    }

                    var setter = setters[index];
                    setter(value);
                    return;
                }
            }
        }

#endregion
    }
}
