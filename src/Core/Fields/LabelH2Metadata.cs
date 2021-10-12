using System;
using Appalachia.Editing.Core.Windows;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH2Metadata : LabelHeaderMetadata<LabelH2Metadata>
    {
        public override int FontSize => 13;

        public override int TopMargin => 3;

        public override bool TopDrawLine => true;

        public override float TopLineWidth => 1f;

        public override Color TopLineColor => AssetUIHelper.LineColorH2;

        public override int BottomMargin => 4;

        public override bool BottomDrawLine => true;

        public override float BottomLineWidth => 1f;

        public override Color BottomLineColor => AssetUIHelper.LineColorH2Soft;
    }
}
