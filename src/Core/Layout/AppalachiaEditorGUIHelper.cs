using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Layout
{
    /// <summary>
    ///     <para>
    ///         GUILayoutHelper is a handy utility that provides cached GUILayoutOpion arrays based on the wanted parameters.
    ///     </para>
    /// </summary>
    /// <example>
    ///     <para>
    ///         Most GUILayout and EditorGUILayout methods takes an optional "params GUILayoutOption[]" parameter.
    ///         Each time you call this, an array is allocated generating garbage.
    ///     </para>
    ///     <code>
    /// // Generates garbage:
    /// GUILayout.Label(label, GUILayout.Label(label, GUILayout.Width(20), GUILayout.ExpandHeight(), GUILayout.MaxWidth(300)));
    /// 
    /// // Does not generate garbage:
    /// GUILayout.Label(label, GUILayout.Label(label, GUILayoutOptions.Width(20).ExpandHeight().MaxWidth(300)));
    /// </code>
    /// </example>
    public static class AppalachiaEditorGUIHelper
    {
        
            
        private const float _H1 = 1f;
        private const float _H1T = .3f;
        private const float _H1TSoft = _H1T * .5f;
        private const float _H2 = 1f;
        private const float _H2T = .2f;
        private const float _H2TSoft = _H2T * .5f;
        private const float _H3 = 1f;
        private const float _H3T = .1f;
        private const float _H3TSoft = _H3T * .5f;
        private const float _H4 = 0f;
        private const float _H4T = .1f;
        private const float _H4TSoft = _H4T * .5f;
        public static GUILayoutOption[] _expandWidth;

        private static Color _lineColorH1;
        private static Color _lineColorH1Soft;
        private static Color _lineColorH2;
        private static Color _lineColorH2Soft;
        private static Color _lineColorH3;
        private static Color _lineColorH3Soft;
        private static Color _lineColorH4;
        private static Color _lineColorH4Soft;

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

        public static void DrawUIBox(Rect rect, Color borderColor, float size = 1.5f)
        {
            var left = new Rect(rect.xMin - size,   rect.yMin - size, size, rect.height + (2 * size));
            var right = new Rect(rect.xMax,         rect.yMin - size, size, rect.height + (2 * size));
            var top = new Rect(rect.xMin - size,    rect.yMin - size, rect.width + (2 * size), size);
            var bottom = new Rect(rect.xMin - size, rect.yMax,        rect.width + (2 * size), size);

            EditorGUI.DrawRect(left,   borderColor);
            EditorGUI.DrawRect(right,  borderColor);
            EditorGUI.DrawRect(top,    borderColor);
            EditorGUI.DrawRect(bottom, borderColor);
        }

        public static Rect GetExpandableRect(float thickness = 1f)
        {
            return GUILayoutUtility.GetRect(thickness, thickness, expandWidth);
        }
        
        public static void HorizontalLineSeparator(
            Color color = default,
            float lineThickness = 1f,
            float bufferSize = 1f)
        {
            ReinitializeState();

            if (color == default)
            {
                color = LineColorH3;
            }

            EditorGUILayout.Space(bufferSize, false);
            var expandableRect = GetExpandableRect(lineThickness);
            DrawSolidRect(expandableRect, color);
            EditorGUILayout.Space(bufferSize, false);
        }

        public static void ReinitializeState()
        {
        }
        
        /// <summary>An EmptyGUIOption[] array with a length of 0.</summary>
        public static readonly GUILayoutOption[] EmptyGUIOptions = new GUILayoutOption[0];

        private static readonly Dictionary<GUILayoutOptionsInstance, GUILayoutOption[]>
            GUILayoutOptionsCache = new();

        private static readonly GUILayoutOptionsInstance[] GUILayoutOptionsInstanceCache =
            new GUILayoutOptionsInstance[30];

        private static int CurrentCacheIndex;

        static AppalachiaEditorGUIHelper()
        {
            GUILayoutOptionsInstanceCache[0] = new GUILayoutOptionsInstance();
            for (var index = 1; index < 30; ++index)
            {
                GUILayoutOptionsInstanceCache[index] = new GUILayoutOptionsInstance();
                GUILayoutOptionsInstanceCache[index].Parent = GUILayoutOptionsInstanceCache[index - 1];
            }
        }

        /// <summary>
        ///     Option passed to a control to allow or disallow vertical expansion.
        /// </summary>
        public static GUILayoutOptionsInstance ExpandHeight(bool expand = true)
        {
            CurrentCacheIndex = 0;
            var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
            layoutOptionsInstance.SetValue(GUILayoutOptionType.ExpandHeight, expand);
            return layoutOptionsInstance;
        }

        /// <summary>
        ///     Option passed to a control to allow or disallow horizontal expansion.
        /// </summary>
        public static GUILayoutOptionsInstance ExpandWidth(bool expand = true)
        {
            CurrentCacheIndex = 0;
            var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
            layoutOptionsInstance.SetValue(GUILayoutOptionType.ExpandWidth, expand);
            return layoutOptionsInstance;
        }

        /// <summary>
        ///     Option passed to a control to give it an absolute height.
        /// </summary>
        public static GUILayoutOptionsInstance Height(float height)
        {
            CurrentCacheIndex = 0;
            var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
            layoutOptionsInstance.SetValue(GUILayoutOptionType.Height, height);
            return layoutOptionsInstance;
        }

        /// <summary>
        ///     Option passed to a control to specify a maximum height.
        /// </summary>
        public static GUILayoutOptionsInstance MaxHeight(float height)
        {
            CurrentCacheIndex = 0;
            var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
            layoutOptionsInstance.SetValue(GUILayoutOptionType.MaxHeight, height);
            return layoutOptionsInstance;
        }

        /// <summary>
        ///     Option passed to a control to specify a maximum width.
        /// </summary>
        public static GUILayoutOptionsInstance MaxWidth(float width)
        {
            CurrentCacheIndex = 0;
            var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
            layoutOptionsInstance.SetValue(GUILayoutOptionType.MaxWidth, width);
            return layoutOptionsInstance;
        }

        /// <summary>
        ///     Option passed to a control to specify a minimum height.
        /// </summary>
        public static GUILayoutOptionsInstance MinHeight(float height)
        {
            CurrentCacheIndex = 0;
            var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
            layoutOptionsInstance.SetValue(GUILayoutOptionType.MinHeight, height);
            return layoutOptionsInstance;
        }

        /// <summary>
        ///     Option passed to a control to specify a minimum width.
        /// </summary>
        public static GUILayoutOptionsInstance MinWidth(float width)
        {
            CurrentCacheIndex = 0;
            var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
            layoutOptionsInstance.SetValue(GUILayoutOptionType.MinWidth, width);
            return layoutOptionsInstance;
        }

        /// <summary>
        ///     Option passed to a control to give it an absolute width.
        /// </summary>
        public static GUILayoutOptionsInstance Width(float width)
        {
            CurrentCacheIndex = 0;
            var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
            layoutOptionsInstance.SetValue(GUILayoutOptionType.Width, width);
            return layoutOptionsInstance;
        }

        public enum GUILayoutOptionType
        {
            Width,
            Height,
            MinWidth,
            MaxHeight,
            MaxWidth,
            MinHeight,
            ExpandHeight,
            ExpandWidth
        }

        /// <summary>
        ///     A GUILayoutOptions instance with an implicit operator to be converted to a GUILayoutOption[] array.
        /// </summary>
        /// <seealso cref="T:Sirenix.Utilities.GUILayoutOptions" />
        public sealed class GUILayoutOptionsInstance : IEquatable<GUILayoutOptionsInstance>
        {
            public GUILayoutOptionType GUILayoutOptionType;
            public GUILayoutOptionsInstance Parent;
            private float value;

            public GUILayoutOptionsInstance()
            {
            }

            /// <summary>Returns a hash code for this instance.</summary>
            public override int GetHashCode()
            {
                var num1 = 0;
                var num2 = 17;
                for (var layoutOptionsInstance = this;
                    layoutOptionsInstance != null;
                    layoutOptionsInstance = layoutOptionsInstance.Parent)
                {
                    num2 = (num2 * 29) +
                           GUILayoutOptionType.GetHashCode() +
                           (value.GetHashCode() * 17) +
                           num1++;
                }

                return num2;
            }

            /// <summary>
            ///     Option passed to a control to allow or disallow vertical expansion.
            /// </summary>
            public GUILayoutOptionsInstance ExpandHeight(bool expand = true)
            {
                var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
                layoutOptionsInstance.SetValue(GUILayoutOptionType.ExpandHeight, expand);
                return layoutOptionsInstance;
            }

            /// <summary>
            ///     Option passed to a control to allow or disallow horizontal expansion.
            /// </summary>
            public GUILayoutOptionsInstance ExpandWidth(bool expand = true)
            {
                var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
                layoutOptionsInstance.SetValue(GUILayoutOptionType.ExpandWidth, expand);
                return layoutOptionsInstance;
            }

            /// <summary>
            ///     Option passed to a control to give it an absolute height.
            /// </summary>
            public GUILayoutOptionsInstance Height(float height)
            {
                var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
                layoutOptionsInstance.SetValue(GUILayoutOptionType.Height, height);
                return layoutOptionsInstance;
            }

            /// <summary>
            ///     Option passed to a control to specify a maximum height.
            /// </summary>
            public GUILayoutOptionsInstance MaxHeight(float height)
            {
                var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
                layoutOptionsInstance.SetValue(GUILayoutOptionType.MaxHeight, height);
                return layoutOptionsInstance;
            }

            /// <summary>
            ///     Option passed to a control to specify a maximum width.
            /// </summary>
            public GUILayoutOptionsInstance MaxWidth(float width)
            {
                var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
                layoutOptionsInstance.SetValue(GUILayoutOptionType.MaxWidth, width);
                return layoutOptionsInstance;
            }

            /// <summary>
            ///     Option passed to a control to specify a minimum height.
            /// </summary>
            public GUILayoutOptionsInstance MinHeight(float height)
            {
                var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
                layoutOptionsInstance.SetValue(GUILayoutOptionType.MinHeight, height);
                return layoutOptionsInstance;
            }

            /// <summary>
            ///     Option passed to a control to specify a minimum width.
            /// </summary>
            public GUILayoutOptionsInstance MinWidth(float width)
            {
                var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
                layoutOptionsInstance.SetValue(GUILayoutOptionType.MinWidth, width);
                return layoutOptionsInstance;
            }

            /// <summary>
            ///     Option passed to a control to give it an absolute width.
            /// </summary>
            public GUILayoutOptionsInstance Width(float width)
            {
                var layoutOptionsInstance = GUILayoutOptionsInstanceCache[CurrentCacheIndex++];
                layoutOptionsInstance.SetValue(GUILayoutOptionType.Width, width);
                return layoutOptionsInstance;
            }

            /// <summary>
            ///     Determines whether the instance is equals another instance.
            /// </summary>
            public bool Equals(GUILayoutOptionsInstance other)
            {
                var layoutOptionsInstance1 = this;
                GUILayoutOptionsInstance layoutOptionsInstance2;
                for (layoutOptionsInstance2 = other;
                    (layoutOptionsInstance1 != null) && (layoutOptionsInstance2 != null);
                    layoutOptionsInstance2 = layoutOptionsInstance2.Parent)
                {
                    if ((layoutOptionsInstance1.GUILayoutOptionType !=
                         layoutOptionsInstance2.GUILayoutOptionType) ||
                        (Math.Abs(layoutOptionsInstance1.value - (double) layoutOptionsInstance2.value) > float.Epsilon))
                    {
                        return false;
                    }

                    layoutOptionsInstance1 = layoutOptionsInstance1.Parent;
                }

                return (layoutOptionsInstance2 == null) && (layoutOptionsInstance1 == null);
            }

            public void SetValue(GUILayoutOptionType type, float value)
            {
                GUILayoutOptionType = type;
                this.value = value;
            }

            public void SetValue(GUILayoutOptionType type, bool value)
            {
                GUILayoutOptionType = type;
                this.value = value ? 1f : 0.0f;
            }

            private GUILayoutOptionsInstance Clone()
            {
                var layoutOptionsInstance1 = new GUILayoutOptionsInstance
                {
                    value = value, GUILayoutOptionType = GUILayoutOptionType
                };
                var layoutOptionsInstance2 = layoutOptionsInstance1;
                var parent = Parent;
                while (parent != null)
                {
                    layoutOptionsInstance2.Parent = new GUILayoutOptionsInstance
                    {
                        value = parent.value, GUILayoutOptionType = parent.GUILayoutOptionType
                    };
                    parent = parent.Parent;
                    layoutOptionsInstance2 = layoutOptionsInstance2.Parent;
                }

                return layoutOptionsInstance1;
            }

            private GUILayoutOption[] CreateOptionsArary()
            {
                var guiLayoutOptionList = new List<GUILayoutOption>();
                for (var layoutOptionsInstance = this;
                    layoutOptionsInstance != null;
                    layoutOptionsInstance = layoutOptionsInstance.Parent)
                {
                    switch (layoutOptionsInstance.GUILayoutOptionType)
                    {
                        case GUILayoutOptionType.Width:
                            guiLayoutOptionList.Add(GUILayout.Width(layoutOptionsInstance.value));
                            break;
                        case GUILayoutOptionType.Height:
                            guiLayoutOptionList.Add(GUILayout.Height(layoutOptionsInstance.value));
                            break;
                        case GUILayoutOptionType.MinWidth:
                            guiLayoutOptionList.Add(GUILayout.MinWidth(layoutOptionsInstance.value));
                            break;
                        case GUILayoutOptionType.MaxHeight:
                            guiLayoutOptionList.Add(GUILayout.MaxHeight(layoutOptionsInstance.value));
                            break;
                        case GUILayoutOptionType.MaxWidth:
                            guiLayoutOptionList.Add(GUILayout.MaxWidth(layoutOptionsInstance.value));
                            break;
                        case GUILayoutOptionType.MinHeight:
                            guiLayoutOptionList.Add(GUILayout.MinHeight(layoutOptionsInstance.value));
                            break;
                        case GUILayoutOptionType.ExpandHeight:
                            guiLayoutOptionList.Add(
                                GUILayout.ExpandHeight(layoutOptionsInstance.value > 0.200000002980232)
                            );
                            break;
                        case GUILayoutOptionType.ExpandWidth:
                            guiLayoutOptionList.Add(
                                GUILayout.ExpandWidth(layoutOptionsInstance.value > 0.200000002980232)
                            );
                            break;
                    }
                }

                return guiLayoutOptionList.ToArray();
            }

            private GUILayoutOption[] GetCachedOptions()
            {
                GUILayoutOption[] guiLayoutOptionArray;
                if (!GUILayoutOptionsCache.TryGetValue(this, out guiLayoutOptionArray))
                {
                    guiLayoutOptionArray = GUILayoutOptionsCache[Clone()] = CreateOptionsArary();
                }

                return guiLayoutOptionArray;
            }

            /// <summary>
            ///     Gets or creates the cached GUILayoutOption array based on the layout options specified.
            /// </summary>
            public static implicit operator GUILayoutOption[](GUILayoutOptionsInstance options)
            {
                return options.GetCachedOptions();
            }
            
        }
    }
}
