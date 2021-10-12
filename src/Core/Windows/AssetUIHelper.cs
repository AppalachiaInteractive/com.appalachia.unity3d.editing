using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows
{
    public static class AssetUIHelper
    {
        private const float _H1 = 1f;
        private const float _H2 = 1f;
        private const float _H3 = 1f;
        private const float _H4 = 0f;
        private const float _H1T = .3f;
        private const float _H2T = .2f;
        private const float _H3T = .1f;
        private const float _H4T = .1f;
        private const float _H1TSoft = _H1T*.5f;
        private const float _H2TSoft = _H2T*.5f;
        private const float _H3TSoft = _H3T*.5f;
        private const float _H4TSoft = _H4T*.5f;
       
        private static Color _lineColorH1;
        private static Color _lineColorH2;
        private static Color _lineColorH3;
        private static Color _lineColorH4;
        private static Color _lineColorH1Soft;
        private static Color _lineColorH2Soft;
        private static Color _lineColorH3Soft;
        private static Color _lineColorH4Soft;
        public static GUILayoutOption[] _expandWidth;

        public static Color LineColorH1Soft
        {
            get
            {
                if (_lineColorH1Soft == default)
                {
                    _lineColorH1Soft = new Color(_H1, _H1, _H1, _H1TSoft);
                }

                return _lineColorH1Soft;
            }
        }

        public static Color LineColorH2Soft
        {
            get
            {
                if (_lineColorH2Soft == default)
                {
                    _lineColorH2Soft = new Color(_H2, _H2, _H2, _H2TSoft);
                }

                return _lineColorH2Soft;
            }
        }

        public static Color LineColorH3Soft
        {
            get
            {
                if (_lineColorH3Soft == default)
                {
                    _lineColorH3Soft = new Color(_H3, _H3, _H3, _H3TSoft);
                }

                return _lineColorH3Soft;
            }
        }

        public static Color LineColorH4Soft
        {
            get
            {
                if (_lineColorH4Soft == default)
                {
                    _lineColorH4Soft = new Color(_H4, _H4, _H4, _H4TSoft);
                }

                return _lineColorH4Soft;
            }
        }

        public static Color LineColorH1
        {
            get
            {
                if (_lineColorH1 == default)
                {
                    _lineColorH1 = new Color(_H1, _H1, _H1, _H1T);
                }

                return _lineColorH1;
            }
        }

        public static Color LineColorH2
        {
            get
            {
                if (_lineColorH2 == default)
                {
                    _lineColorH2 = new Color(_H2, _H2, _H2, _H2T);
                }

                return _lineColorH2;
            }
        }

        public static Color LineColorH3
        {
            get
            {
                if (_lineColorH3 == default)
                {
                    _lineColorH3 = new Color(_H3, _H3, _H3, _H3T);
                }

                return _lineColorH3;
            }
        }

        public static Color LineColorH4
        {
            get
            {
                if (_lineColorH4 == default)
                {
                    _lineColorH4 = new Color(_H4, _H4, _H4, _H4T);
                }

                return _lineColorH4;
            }
        }

        public static GUILayoutOption[] expandWidth
        {
            get
            {
                if (_expandWidth == default)
                {
                    _expandWidth = new[] {GUILayout.ExpandWidth(true)};
                }

                return _expandWidth;
            }
        }

        public static void ReinitializeState()
        {
        }

        public static void HorizontalLineSeparator(
            Color color = default,
            float lineWidth = 1f,
            float bufferSize = 1f)
        {
            ReinitializeState();

            if (color == default)
            {
                color = LineColorH3;
            }

            EditorGUILayout.Space(bufferSize, false);
            DrawSolidRect(GUILayoutUtility.GetRect(lineWidth, lineWidth, expandWidth), color);
            EditorGUILayout.Space(bufferSize, false);
        }

        public static void DrawUIBox(Rect rect, Color borderColor, float size = 1.5f)
        {
            var left = new Rect(rect.xMin - size, rect.yMin - size, size, rect.height + (2 * size));
            var right = new Rect(rect.xMax, rect.yMin - size, size, rect.height + (2 * size));
            var top = new Rect(rect.xMin - size, rect.yMin - size, rect.width + (2 * size), size);
            var bottom = new Rect(rect.xMin - size, rect.yMax, rect.width + (2 * size), size);

            EditorGUI.DrawRect(left,   borderColor);
            EditorGUI.DrawRect(right,  borderColor);
            EditorGUI.DrawRect(top,    borderColor);
            EditorGUI.DrawRect(bottom, borderColor);
        }

        public static void DrawSolidRect(Rect rect, Color color, bool usePlaymodeTint = true)
        {
            if (Event.current.type != EventType.Repaint)
            {
                return;
            }

            if (usePlaymodeTint)
            {
                EditorGUI.DrawRect(rect, color);
            }
            else
            {
                var oldColor = GUI.color;
                GUI.color = color;
                GUI.DrawTexture(rect, EditorGUIUtility.whiteTexture);
                GUI.color = oldColor;
            }
        }
    }
}
