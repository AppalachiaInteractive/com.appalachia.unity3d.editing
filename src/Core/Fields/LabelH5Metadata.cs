using System;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH5Metadata : LabelHeaderMetadata<LabelH5Metadata>
    {
        public override bool BottomDrawLine => false;

        public override bool TopDrawLine => false;

        public override Color BottomLineColor => throw new NotImplementedException();

        public override Color TopLineColor => throw new NotImplementedException();

        public override float BottomLineWidth => throw new NotImplementedException();

        public override float TopLineWidth => throw new NotImplementedException();

        public override int BottomMargin => 0;
        public override int FontSize => 11;

        public override int TopMargin => 0;
    }
}
