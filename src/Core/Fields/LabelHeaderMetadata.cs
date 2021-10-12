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
        public abstract int FontSize { get; }
        public abstract int TopMargin { get; }
        public abstract bool TopDrawLine { get; }
        public abstract float TopLineWidth { get; }
        public abstract Color TopLineColor { get; }
        public abstract int BottomMargin { get; }
        public abstract bool BottomDrawLine { get; }
        public abstract float BottomLineWidth { get; }
        public abstract Color BottomLineColor { get; }
        
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
                        fontSize = FontSize
                    };
                }

                return _defaultStyle;
            }
        }

        private static readonly ProfilerMarker _PRF_OnBeforeDraw = new ProfilerMarker(_PRF_PFX + nameof(OnBeforeDraw));
        protected override void OnBeforeDraw()
        {
            using (_PRF_OnBeforeDraw.Auto())
            {
                if (TopDrawLine)
                {
                    AssetUIHelper.HorizontalLineSeparator(TopLineColor, TopLineWidth, TopLineWidth);
                }
            }
        }

        private static readonly ProfilerMarker _PRF_OnAfterDraw = new ProfilerMarker(_PRF_PFX + nameof(OnAfterDraw));
        protected override void OnAfterDraw()
        {
            using (_PRF_OnAfterDraw.Auto())
            {
                if (BottomDrawLine)
                {
                    AssetUIHelper.HorizontalLineSeparator(BottomLineColor, BottomLineWidth, BottomLineWidth);
                }
            }
        }
    }
}
