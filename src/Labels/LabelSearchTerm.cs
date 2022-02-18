#if UNITY_EDITOR

#region

using System;
using Appalachia.Core.Attributes.Editing;
using Appalachia.Core.Objects.Root;
using Appalachia.Core.Preferences.Globals;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace Appalachia.Editing.Labels
{
    [Serializable]
    public class LabelSearchTerm : AppalachiaBase
    {
        public LabelSearchTerm(Object owner) : base(owner)
        {
        }

        #region Fields and Autoproperties

        [ToggleLeft]
        [LabelText("Use")]
        [SmartLabel]
        [HorizontalGroup("A", 20f /*, .1f*/)]
        [SerializeField]
        public bool enabled;

        [HideInInspector]
        [NonSerialized]
        public bool found;

        [GUIColor(nameof(_labelColor))]
        [ValueDropdown(nameof(labelList))]
        [InlineProperty]
        [HideLabel]
        [LabelWidth(0)]
        [HorizontalGroup("A" /*, .1f*/)]
        [SerializeField]
        public string label;

        #endregion

        /// <inheritdoc />
        public override string Name => label;

        private Color _labelColor =>
            enabled ? ColorPrefs.Instance.EnabledSubdued.v : ColorPrefs.Instance.DisabledImportantSubdued.v;

        private ValueDropdownList<string> labelList => LabelManager.labelDropdownList;

        public void Reset()
        {
            found = false;
        }
    }
}

#endif
