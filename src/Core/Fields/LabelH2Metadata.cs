using System;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.Windows;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH2Metadata : LabelHeaderMetadata<LabelH2Metadata>
    {
        public override bool BottomDrawLine => true;

        public override Color BottomLineColor => AppalachiaEditorGUIHelper.LineColorH2Soft;

        public override float BottomLineWidth => 1f;

        public override int BottomMargin => 4;
        public override int FontSize => 13;

        public override bool TopDrawLine => true;

        public override Color TopLineColor => AppalachiaEditorGUIHelper.LineColorH2;

        public override float TopLineWidth => 1f;

        public override int TopMargin => 3;
    }
}
