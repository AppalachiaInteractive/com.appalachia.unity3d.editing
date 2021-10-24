using System;
using Appalachia.Editing.Core.Layout;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH2Metadata : LabelHeaderMetadata<LabelH2Metadata>
    {
        public override bool BottomDrawLine => true;

        public override bool TopDrawLine => true;

        public override Color BottomLineColor => APPAGUI.LineColorH2Soft;

        public override Color TopLineColor => APPAGUI.LineColorH2;

        public override float BottomLineWidth => 1f;

        public override float TopLineWidth => 1f;

        public override int BottomMargin => 4;
        public override int FontSize => 13;

        public override int TopMargin => 3;
    }
}
