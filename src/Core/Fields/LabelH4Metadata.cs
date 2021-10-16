using System;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.Windows;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class LabelH4Metadata : LabelHeaderMetadata<LabelH4Metadata>
    {
        public override bool BottomDrawLine => true;

        public override Color BottomLineColor => AppalachiaEditorGUIHelper.LineColorH4;

        public override float BottomLineWidth => 1f;

        public override int BottomMargin => 0;
        public override int FontSize => 11;

        public override bool TopDrawLine => false;

        public override Color TopLineColor => AppalachiaEditorGUIHelper.LineColorH4;

        public override float TopLineWidth => 1f;

        public override int TopMargin => 0;
    }
}
