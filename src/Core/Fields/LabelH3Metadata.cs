using System;
using Appalachia.Editing.Core.Windows;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH3Metadata : LabelHeaderMetadata<LabelH3Metadata>
    {
    
        public override int FontSize => 12;

        public override int TopMargin => 1;

        public override bool TopDrawLine => true;

        public override float TopLineWidth => 1f;

        public override Color TopLineColor => AssetUIHelper.LineColorH3;

        public override int BottomMargin => 1;

        public override bool BottomDrawLine => true;

        public override float BottomLineWidth => 1f;

        public override Color BottomLineColor => AssetUIHelper.LineColorH3Soft;
    }
}
