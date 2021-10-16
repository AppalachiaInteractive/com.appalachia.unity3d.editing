using System;
using System.Collections;
using System.Collections.Generic;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Fields;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    
    public interface IAppalachiaWindowPane
    {
        bool ContentInScrollView { get; }
        string PaneName { get; }
        bool DrawHeader { get; }
        UIFieldMetadataManager fieldMetadataManager { get; }
        Rect container { get; set; }
        float InitializationStart { get; set; }
        bool Initialized { get; set; }
        bool Initializing { get; set; }
        int[] preferenceTabLevels { get; set; }
        List<PREF<bool>> registeredPrefs { get; set; }
        AppalachiaPaneBasedWindowBase window { get; set; }
        void DrawPaneContent();
        void DrawPreferenceToggles();
        void ExecuteCoroutine(Func<IEnumerator> coroutine);
        void ExecuteDrawPaneContent();

        IReadOnlyList<IAppalachiaWindowPane> GetChildPanes(
            string paneSetIdentifier,
            Func<IReadOnlyList<IAppalachiaWindowPane>> initializationFunction);

        IList<IAppalachiaTabbedWindowPane> GetTabPanes(
            string paneSetIdentifier,
            Func<IList<IAppalachiaTabbedWindowPane>> initializationFunction);

        IEnumerator Initialize();
        void OnBeforeDraw();
        void OnBeforeDrawPaneContent();
        void OnBeforeDrawPaneContentStart(out bool shouldDraw);
        void OnBeforeInitialize();
        void OnDrawGUI();
        void OnDrawPaneContent();
        void OnDrawPaneContentEnd();
        void OnDrawPaneContentStart();
        void OnInitializationGUI();
        void OnInitialize();
        void OnPreferenceAwake<TP>(PREF<TP> pref);

        void ProcessCollection<TL>(
            IList<TL> collection,
            Action<TL> elementAction,
            Func<TL, bool>[] skipElement);

        void ProcessCollection<TL>(
            Func<IDisposable> wrapper,
            IList<TL> collection,
            Action<TL> elementAction,
            Func<TL, bool>[] skipElement);

        void RegisterFilterPref(
            ref PREF<bool> pref,
            string prefix,
            string settingName,
            bool defaultValue);
    }
}
