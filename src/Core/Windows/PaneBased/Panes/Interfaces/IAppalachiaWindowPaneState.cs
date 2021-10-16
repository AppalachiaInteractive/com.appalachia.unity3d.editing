using System.Collections.Generic;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Fields;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    public interface IAppalachiaWindowPaneState
    {
        bool ContentInScrollView { get; }
        bool DrawHeader { get; }
        string PaneName { get; }
        UIFieldMetadataManager fieldMetadataManager { get; }
        AppalachiaPaneBasedWindowBase window { get; set; }
        bool Initialized { get; set; }
        bool Initializing { get; set; }
        float InitializationStart { get; set; }
        int[] preferenceTabLevels { get; set; }
        List<PREF<bool>> registeredPrefs { get; set; }
        Rect container { get; set; }
    }
}
