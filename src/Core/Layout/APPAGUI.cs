using System;
using System.Collections.Generic;
using Appalachia.Editing.Core.Fields;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Layout
{
    public static class APPAGUI
    {
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

#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(APPAGUI) + ".";

        /// <summary>An EmptyGUIOption[] array with a length of 0.</summary>
        public static readonly GUILayoutOption[] EmptyGUIOptions = new GUILayoutOption[0];

        private static readonly Dictionary<GUILayoutOptionsInstance, GUILayoutOption[]>
            GUILayoutOptionsCache = new();

        private static readonly GUILayoutOptionsInstance[] GUILayoutOptionsInstanceCache =
            new GUILayoutOptionsInstance[30];

        private static Color _lineColorH1;
        private static Color _lineColorH1Soft;
        private static Color _lineColorH2;
        private static Color _lineColorH2Soft;
        private static Color _lineColorH3;
        private static Color _lineColorH3Soft;
        private static Color _lineColorH4;
        private static Color _lineColorH4Soft;
        private static int CurrentCacheIndex;
        private static readonly ProfilerMarker _PRF_DrawButtonRow = new(_PRF_PFX + nameof(DrawButtonRow));

#endregion

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

        public static string CurrentEditor // works fast, doesn't validate if executable really exists
            =>
                EditorPrefs.GetString("kScriptsDefaultApp");

        static APPAGUI()
        {
            GUILayoutOptionsInstanceCache[0] = new GUILayoutOptionsInstance();
            for (var index = 1; index < 30; ++index)
            {
                GUILayoutOptionsInstanceCache[index] = new GUILayoutOptionsInstance();
                GUILayoutOptionsInstanceCache[index].Parent = GUILayoutOptionsInstanceCache[index - 1];
            }
        }

        public static void DrawButtonRow<T>(
            UIFieldMetadataManager fieldMetadataManager,
            string identifierPrefix,
            T instance,
            params RowButton<T>[] buttonDatas)
        {
            using (_PRF_DrawButtonRow.Auto())
            {
                void OnCreateButton(RowButton<T> buttonData, EditorUIFieldMetadata f)
                {
                    f.AlterContent(c => c.text = buttonData.label);
                }

                using var outerScope = new GUILayout.HorizontalScope();

                SPACE.MAKE(SPACE.SIZE.ButtonPaddingLeft);

                using var verticalScope = new GUILayout.VerticalScope();

                using var horizontalScope = new GUILayout.HorizontalScope(GUILayout.ExpandWidth(true));

                for (var index = 0; index < buttonDatas.Length; index++)
                {
                    var buttonData = buttonDatas[index];

                    IButtonMetadata button;

                    var identifier = $"{identifierPrefix}.{buttonData.label}";

                    if (buttonDatas.Length == 1)
                    {
                        button = fieldMetadataManager.Get<MiniButtonLeftMetadata>(
                            identifier,
                            f => OnCreateButton(buttonData, f)
                        );
                    }
                    else if (index == 0)
                    {
                        button = fieldMetadataManager.Get<MiniButtonLeftMetadata>(
                            identifier,
                            f => OnCreateButton(buttonData, f)
                        );
                    }
                    else if (index == (buttonDatas.Length - 1))
                    {
                        button = fieldMetadataManager.Get<MiniButtonLeftMetadata>(
                            identifier,
                            f => OnCreateButton(buttonData, f)
                        );
                    }
                    else
                    {
                        button = fieldMetadataManager.Get<MiniButtonLeftMetadata>(
                            identifier,
                            f => OnCreateButton(buttonData, f)
                        );
                    }

                    var isEnabled = (buttonData.enabled == null) || buttonData.enabled(instance);
                    var color = buttonData.backgroundColor?.Invoke(instance) ?? Color.clear;

                    if (button.Button(isEnabled, backgroundColor: color))
                    {
                        buttonData.action(instance);
                    }
                }

                SPACE.MAKE(SPACE.SIZE.ButtonPaddingRight);
            }
        }

        public static void DrawHorizontalLineSeperator(
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
            var expandableRect = GetExpandableWidthRect(lineThickness);
            DrawSolidRect(expandableRect, color);
            EditorGUILayout.Space(bufferSize, false);
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

        public static void DrawVerticalLineSeperator(
            Color color = default,
            float lineThickness = 1f,
            float bufferSize = 1f)
        {
            ReinitializeState();

            if (color == default)
            {
                color = LineColorH3;
            }

            using (new GUILayout.VerticalScope())
            using (new GUILayout.HorizontalScope())
            {
                EditorGUILayout.Space(bufferSize, false);
                var expandableRect = GetExpandableHeightRect(lineThickness);
                DrawSolidRect(expandableRect, color);
                EditorGUILayout.Space(bufferSize, false);
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

        public static Rect GetExpandableHeightRect(float thickness = 1f)
        {
            return GUILayoutUtility.GetRect(thickness, thickness, ExpandWidth());
        }

        public static Rect GetExpandableWidthRect(float thickness = 1f)
        {
            return GUILayoutUtility.GetRect(thickness, thickness, ExpandWidth());
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

        public static void ReinitializeState()
        {
        }

        public static void SplitByColumns(int columns, int items, Action<List<int>> columnDrawer)
        {
            SplitByAxis(columns, items, columnDrawer, true);
        }

        public static void SplitByRows(int rows, int items, Action<List<int>> rowDrawer)
        {
            SplitByAxis(rows, items, rowDrawer, false);
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

        private static void SplitByAxis(
            int majorAxisDivisions,
            int items,
            Action<List<int>> drawer,
            bool verticalFirst)
        {
            var minorAxisDivisions = 0;

            var itemIndicesByMajorIndex = new List<int>[majorAxisDivisions];

            for (var majorIndex = 0; majorIndex < majorAxisDivisions; majorIndex++)
            {
                itemIndicesByMajorIndex[majorIndex] = new List<int>();

                for (var itemIndex = 0; itemIndex < items; itemIndex++)
                {
                    if ((itemIndex % majorAxisDivisions) == majorIndex)
                    {
                        itemIndicesByMajorIndex[majorIndex].Add(itemIndex);
                    }
                }

                minorAxisDivisions = Mathf.Max(minorAxisDivisions, itemIndicesByMajorIndex[majorIndex].Count);
            }

            using GUI.Scope outerScope =
                verticalFirst ? new GUILayout.VerticalScope() : new GUILayout.HorizontalScope();
            using GUI.Scope innerScope =
                verticalFirst ? new GUILayout.HorizontalScope() : new GUILayout.VerticalScope();

            for (var majorIndex = 0; majorIndex < majorAxisDivisions; majorIndex++)
            {
                var itemIndices = itemIndicesByMajorIndex[majorIndex];

                drawer(itemIndices);
            }
        }

        public static class SPACE
        {
            public enum SIZE
            {
                Default = 4,
                OverviewPrefixLabelWidth = 180,
                ButtonGroupBreak = 2,
                ButtonPaddingLeft = 4,
                ButtonPaddingRight = 4,
                ButtonSeperatorLarge = 5,
                ButtonSeperatorMedium = 3,
                ButtonSeperatorSmall = 1,
                FieldPaddingMid = 4,
                FieldPaddingRight = 4,
                HeaderPaddingLeft = 4,
                MenuItemPaddingLeft = 8,
                MenuItemSelectionStrip = 3,
                PreferencesEndVertical = 4,
                PreferencesLeftPaddingBottom = 6,
                PreferencesLeftPaddingInner = 6,
                PreferencesLeftPaddingTop = 6,
                PreferencesLeftPaddingUnder = 2,
                PreferencesPaddingVertical = 4,
                PreferencesStartVertical = 4,
                ProgressBarFooter = 4,
                SectionDividerVertical = 6,
                SectionEndVertical = 6,
                SectionStartVertical = 6,
                TabStartVertical = 4,
                DETAIL_LABEL_HEIGHT = 20,
                HeaderLabelHeight = 30,
                HeaderPrefixWidth = 120,
                HighlightFieldsLabelHeight = 22,
                NF_LABEL_WIDTH = 80,
                PREFIX_LABEL_WIDTH = 125,
                REFERENCE_PREFIX_WIDTH = 300
            }

            public static void Default()
            {
                MAKE(SIZE.Default);
            }

            public static float GET(SIZE spaceSize)
            {
                return (int) spaceSize;
            }

            public static void MAKE(SIZE spaceSize)
            {
                EditorGUILayout.Space((int) spaceSize, false);
            }
        }

        /// <summary>
        ///     A GUILayoutOptions instance with an implicit operator to be converted to a GUILayoutOption[] array.
        /// </summary>
        /// <seealso cref="T:Sirenix.Utilities.GUILayoutOptions" />
        public sealed class GUILayoutOptionsInstance : IEquatable<GUILayoutOptionsInstance>
        {
            public GUILayoutOptionsInstance Parent;
            public GUILayoutOptionType GUILayoutOptionType;
            private float value;

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
                        (Math.Abs(layoutOptionsInstance1.value - (double) layoutOptionsInstance2.value) >
                         float.Epsilon))
                    {
                        return false;
                    }

                    layoutOptionsInstance1 = layoutOptionsInstance1.Parent;
                }

                return (layoutOptionsInstance2 == null) && (layoutOptionsInstance1 == null);
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
