using System;
using Appalachia.Utility.Colors;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Colors
{
    [Serializable]
    public static class ColorPalettes
    {
        private static ColorPalette _scratchPalette;

        private static ColorPalette _editing;

        public static ColorPalette Editing
        {
            get
            {
                if (_editing == null)
                {
                    _editing = new ColorPalette
                    {
                        error = new Color(1f,      0.37f, 0.34f, 1f),
                        warning = new Color(1f,    .9f,   0f,    1f),
                        good = new Color(0.4f,     1f,    0.4f,  1f),
                        selected = new Color(0.7f, 0.8f,  1f,    1f),
                        notable = new Color(0f,    .9f,   1f,    1f)
                    };

                    _editing.error2 = _editing.error.ScaleS(.8f).ScaleV(.8f);
                    _editing.warning2 = _editing.warning.ScaleS(.8f).ScaleV(.8f);
                    _editing.good2 = _editing.good.ScaleS(.8f).ScaleV(.8f);
                }

                return _editing;
            }
        }

        internal static void DrawScratchPalette(ColorPalette assignTo)
        {
            if (_scratchPalette == null)
            {
                _scratchPalette = assignTo?.Copy() ?? ColorPalette.Default();
            }

            var paletteChanged = _scratchPalette.Draw();

            if (GUILayout.Button("Generate Color Code to Log"))
            {
                _scratchPalette.Log();
            }

            EditorGUILayout.Space(6f, false);

            if (paletteChanged)
            {
                if (assignTo != null)
                {
                    assignTo.CopyFrom(_scratchPalette);
                }
            }
        }
    }
}
