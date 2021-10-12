using System;
using Appalachia.Editing.Core.Windows;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH4Metadata : LabelHeaderMetadata<LabelH4Metadata>
    {
        public override int FontSize => 11;

        public override int TopMargin => 0;

        public override bool TopDrawLine => false;

        public override float TopLineWidth => 1f;

        public override Color TopLineColor => AssetUIHelper.LineColorH4;

        public override int BottomMargin => 0;

        public override bool BottomDrawLine => true;

        public override float BottomLineWidth => 1f;

        public override Color BottomLineColor => AssetUIHelper.LineColorH4;
    }
}
