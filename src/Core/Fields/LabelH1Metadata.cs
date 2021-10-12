using System;
using Appalachia.Editing.Core.Windows;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH1Metadata : LabelHeaderMetadata<LabelH1Metadata>
    {
        public override int FontSize => 14;

        public override int TopMargin => 4;

        public override bool TopDrawLine => true;

        public override float TopLineWidth => 1f;

        public override Color TopLineColor => AssetUIHelper.LineColorH1;

        public override int BottomMargin => 5;

        public override bool BottomDrawLine => true;

        public override float BottomLineWidth => 2f;

        public override Color BottomLineColor => AssetUIHelper.LineColorH1Soft;    
    }
}
