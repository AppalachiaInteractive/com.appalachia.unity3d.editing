using System;
using Appalachia.Editing.Core.Layout;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH4Metadata : LabelHeaderMetadata<LabelH4Metadata>
    {
        public override bool BottomDrawLine => true;

        public override bool TopDrawLine => false;

        public override Color BottomLineColor => APPAGUI.LineColorH4;

        public override Color TopLineColor => APPAGUI.LineColorH4;

        public override float BottomLineWidth => 1f;

        public override float TopLineWidth => 1f;

        public override int BottomMargin => 0;
        public override int FontSize => 11;

        public override int TopMargin => 0;
    }
}
