using System;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.Windows;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH3Metadata : LabelHeaderMetadata<LabelH3Metadata>
    {
        public override bool BottomDrawLine => true;

        public override Color BottomLineColor => AppalachiaEditorGUIHelper.LineColorH3Soft;

        public override float BottomLineWidth => 1f;

        public override int BottomMargin => 1;

        public override int FontSize => 12;

        public override bool TopDrawLine => true;

        public override Color TopLineColor => AppalachiaEditorGUIHelper.LineColorH3;

        public override float TopLineWidth => 1f;

        public override int TopMargin => 1;
    }
}
