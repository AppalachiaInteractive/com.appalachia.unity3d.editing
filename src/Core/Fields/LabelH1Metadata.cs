using System;
using Appalachia.Editing.Core.Layout;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH1Metadata : LabelHeaderMetadata<LabelH1Metadata>
    {
        public override bool BottomDrawLine => true;

        public override bool TopDrawLine => true;

        public override Color BottomLineColor => APPAGUI.LineColorH1Soft;

        public override Color TopLineColor => APPAGUI.LineColorH1;

        public override float BottomLineWidth => 2f;

        public override float TopLineWidth => 1f;

        public override int BottomMargin => 5;
        public override int FontSize => 14;

        public override int TopMargin => 4;
    }
}
