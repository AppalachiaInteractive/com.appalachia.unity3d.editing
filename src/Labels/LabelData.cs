#if UNITY_EDITOR

#region

using System;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Utility.Strings;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Labels
{
    [Serializable]
    [InlineProperty]
    [HideLabel]
    [LabelWidth(0)]
    [HideDuplicateReferenceBox]
    [HideReferenceObjectPicker]
    public sealed class LabelData
    {
        #region Fields and Autoproperties

        [HorizontalGroup("B", .25f)]
        [LabelText("Apply")]
        [SmartLabel(Postfix = true)]
        [OnValueChanged(nameof(OnApplyChanged))]
        [DisableIf(nameof(_disableApply))]
        public bool applyLabel;

        [HorizontalGroup("B", .25f)]
        [LabelText("Delete")]
        [SmartLabel(Postfix = true)]
        [OnValueChanged(nameof(OnDeleteChanged))]
        [DisableIf(nameof(_disableDelete))]
        public bool deleteLabel;

        [HideInInspector] public int count;

        [ReadOnly]
        [SmartLabel]
        [SuffixLabel("$" + nameof(suffixLabel))]
        public string label;

        [HorizontalGroup("B", .5f)]
        [LabelText("Swap")]
        [SmartLabel]
        [OnValueChanged(nameof(OnSwitchToChanged))]
        [DisableIf(nameof(_disableSwitchTo))]
        public string switchTo;

        #endregion

        private bool _disableApply => deleteLabel || (switchTo != null);

        private bool _disableDelete => applyLabel || (switchTo != null);

        private bool _disableSwitchTo => deleteLabel || applyLabel;

        private string suffixLabel => ZString.Format("  {0} items", count);

        private void OnApplyChanged()
        {
            if (applyLabel)
            {
                deleteLabel = false;
                switchTo = null;
            }
        }

        private void OnDeleteChanged()
        {
            if (deleteLabel)
            {
                applyLabel = false;
                switchTo = null;
            }
        }

        private void OnSwitchToChanged()
        {
            if (switchTo != null)
            {
                deleteLabel = false;
                applyLabel = false;
            }
        }
    }
}

#endif
