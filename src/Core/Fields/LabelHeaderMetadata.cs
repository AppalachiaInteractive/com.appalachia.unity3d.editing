using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.Windows;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    public abstract class LabelHeaderMetadata<T> : LabelMetadataBase<T>
        where T : LabelHeaderMetadata<T>
    {
        private const string _PRF_PFX = nameof(LabelHeaderMetadata<T>) + ".";

        private static readonly ProfilerMarker _PRF_OnBeforeDraw = new(_PRF_PFX + nameof(OnBeforeDraw));
        private static readonly ProfilerMarker _PRF_OnAfterDraw = new(_PRF_PFX + nameof(OnAfterDraw));

        public abstract bool BottomDrawLine { get; }
        public abstract Color BottomLineColor { get; }
        public abstract float BottomLineWidth { get; }
        public abstract int BottomMargin { get; }
        public abstract int FontSize { get; }
        public abstract bool TopDrawLine { get; }
        public abstract Color TopLineColor { get; }
        public abstract float TopLineWidth { get; }
        public abstract int TopMargin { get; }

        protected override GUIStyle DefaultStyle
        {
            get
            {
                if (_defaultStyle == null)
                {
                    _defaultStyle = new GUIStyle(EditorStyles.whiteLargeLabel)
                    {
                        border = new RectOffset(0, 0, 0,         0),
                        margin = new RectOffset(0, 0, TopMargin, BottomMargin),
                        fontSize = FontSize,
                        alignment = TextAnchor.MiddleLeft
                    };
                }

                return _defaultStyle;
            }
        }

        protected override void OnAfterDraw()
        {
            using (_PRF_OnAfterDraw.Auto())
            {
                if (BottomDrawLine)
                {
                    AppalachiaEditorGUIHelper.HorizontalLineSeparator(BottomLineColor, BottomLineWidth, BottomLineWidth);
                }
            }
        }

        protected override void OnBeforeDraw()
        {
            using (_PRF_OnBeforeDraw.Auto())
            {
                if (labelHeight == 0)
                {
                    SetLabelHeight(DefaultLabelHeight + TopMargin + BottomMargin);
                }
                
                if (TopDrawLine)
                {
                    AppalachiaEditorGUIHelper.HorizontalLineSeparator(TopLineColor, TopLineWidth, TopLineWidth);
                }
            }
        }

        public override GUILayoutOption[] InitializeLayout()
        {
            return new[] {GUILayout.ExpandWidth(true), GUILayout.MinWidth(1)};
        }
    }
}
