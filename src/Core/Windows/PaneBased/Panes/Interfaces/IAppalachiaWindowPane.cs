using System;
using System.Collections;
using System.Collections.Generic;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Fields;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces
{
    public interface IAppalachiaWindowPane
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
        List<PREF_BASE> registeredPrefs { get; set; }
        Rect container { get; set; }

        IEnumerator Initialize();

        IList<IAppalachiaTabbedWindowPane> GetTabPanes(
            string paneSetIdentifier,
            Func<IList<IAppalachiaTabbedWindowPane>> initializationFunction);

        IReadOnlyList<IAppalachiaWindowPane> GetChildPanes(
            string paneSetIdentifier,
            Func<IReadOnlyList<IAppalachiaWindowPane>> initializationFunction);

        void DrawPaneContent();
        void DrawPreferenceFields(bool horizontal);
        void ExecuteCoroutine(Func<IEnumerator> coroutine);
        void ExecuteDrawPaneContent();
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

        void RegisterFilterPref<T>(PREF<T> pref, Func<bool> enableIf = null);

        void RegisterFilterPref<T>(ref PREF<T> pref, string prefix, string settingName, T defaultValue, Func<bool> enableIf = null);
    }
}
