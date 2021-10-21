using System;
using System.Collections;
using System.Collections.Generic;
using Appalachia.Core.Aspects;
using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.State;
using Appalachia.Editing.Core.Windows.PaneBased.Panes.Interfaces;
using Appalachia.Utility.Colors;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    [Serializable]
    public abstract class AppalachiaWindowPane : IAppalachiaWindowPane
    {
        private const string _PRF_PFX = nameof(AppalachiaWindowPane) + ".";
        private const string _TRACE_PFX = nameof(AppalachiaWindowPane) + ".";

        private const string G_ = "Appalachia/Editor Windows";

        private static readonly ProfilerMarker _PRF_OnDrawGUI = new(_PRF_PFX + nameof(OnDrawGUI));
        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));

        private static readonly ProfilerMarker _PRF_OnInitializationGUI =
            new(_PRF_PFX + nameof(OnInitializationGUI));

        private static readonly ProfilerMarker _PRF_RegisterFilterPref =
            new(_PRF_PFX + nameof(RegisterFilterPref));

        private static readonly ProfilerMarker _PRF_DrawPreferenceFields =
            new(_PRF_PFX + nameof(DrawPreferenceFields));

        private static readonly ProfilerMarker _PRF_DrawPaneContent = new(_PRF_PFX + nameof(DrawPaneContent));

        private static readonly ProfilerMarker _PRF_OnPreferenceAwake =
            new(_PRF_PFX + nameof(OnPreferenceAwake));

        private static readonly ProfilerMarker _PRF_ProcessCollection =
            new(_PRF_PFX + nameof(ProcessCollection));

        private static readonly ProfilerMarker _PRF_ExecuteDrawPaneContent =
            new(_PRF_PFX + nameof(ExecuteDrawPaneContent));

        private static Dictionary<string, IList<IAppalachiaTabbedWindowPane>> _tabPaneSetCache;
        private static Dictionary<string, IReadOnlyList<IAppalachiaWindowPane>> _childPaneSetCache;
        private static readonly TraceMarker _TRACE_GetChildPanes = new(_TRACE_PFX + nameof(GetChildPanes));
        private static readonly ProfilerMarker _PRF_GetChildPanes = new(_PRF_PFX + nameof(GetChildPanes));
        private static readonly TraceMarker _TRACE_GetTabPanes = new(_TRACE_PFX + nameof(GetTabPanes));
        private static readonly ProfilerMarker _PRF_GetTabPanes = new(_PRF_PFX + nameof(GetTabPanes));
        private static readonly TraceMarker _TRACE_Initialize = new(_TRACE_PFX + nameof(Initialize));
        private static readonly TraceMarker _TRACE_OnDrawGUI = new(_TRACE_PFX + nameof(OnDrawGUI));

        private static readonly TraceMarker _TRACE_DrawPreferenceToggles =
            new(_TRACE_PFX + nameof(DrawPreferenceFields));

        private static readonly ProfilerMarker _PRF_ExecuteCoroutine =
            new(_PRF_PFX + nameof(ExecuteCoroutine));

        private static readonly TraceMarker _TRACE_ExecuteCoroutine =
            new(_TRACE_PFX + nameof(ExecuteCoroutine));

        private static readonly TraceMarker _TRACE_OnPreferenceAwake =
            new(_TRACE_PFX + nameof(OnPreferenceAwake));

        private static readonly TraceMarker _TRACE_ProcessCollection =
            new(_TRACE_PFX + nameof(ProcessCollection));

        private static readonly TraceMarker _TRACE_RegisterFilterPref =
            new(_TRACE_PFX + nameof(RegisterFilterPref));

        private static readonly TraceMarker
            _TRACE_DrawPaneContent = new(_TRACE_PFX + nameof(DrawPaneContent));

        private static readonly TraceMarker _TRACE_ExecuteDrawPaneContent =
            new(_TRACE_PFX + nameof(ExecuteDrawPaneContent));

        private static readonly TraceMarker _TRACE_OnInitializationGUI =
            new(_TRACE_PFX + nameof(OnInitializationGUI));

        private static readonly TraceMarker _TRACE_HorizontalLineSeparator =
            new(_TRACE_PFX + nameof(HorizontalLineSeparator));

        private static readonly ProfilerMarker _PRF_HorizontalLineSeparator =
            new(_PRF_PFX + nameof(HorizontalLineSeparator));

        private static readonly TraceMarker _TRACE_GetPanes = new(_TRACE_PFX + nameof(GetPanes));
        private static readonly ProfilerMarker _PRF_GetPanes = new(_PRF_PFX + nameof(GetPanes));

        private static readonly TraceMarker _TRACE_Initialize_OnBeforeInitialize =
            new(_TRACE_PFX + nameof(Initialize) + ".OnBeforeInitialize");

        private static readonly TraceMarker _TRACE_Initialize_OnInitialize =
            new(_TRACE_PFX + nameof(Initialize) + ".OnInitialize");

        private static readonly TraceMarker _TRACE_OnBeforeDraw = new(_TRACE_PFX + nameof(OnBeforeDraw));

        private static readonly TraceMarker _TRACE_OnBeforeDrawPaneContent =
            new(_TRACE_PFX + nameof(OnBeforeDrawPaneContent));

        private static readonly TraceMarker _TRACE_OnBeforeInitialize =
            new(_TRACE_PFX + nameof(OnBeforeInitialize));

        private static readonly ProfilerMarker _PRF_DrawPreferencesHorizontal =
            new(_PRF_PFX + nameof(DrawPreferencesHorizontal));

        private static readonly ProfilerMarker _PRF_DrawPreferencesVertical =
            new(_PRF_PFX + nameof(DrawPreferencesVertical));

        public static Dictionary<string, IList<IAppalachiaTabbedWindowPane>> tabPaneSetCache { get; set; }

        public static Dictionary<string, IReadOnlyList<IAppalachiaWindowPane>> childPaneSetCache { get; set; }

        private UIFieldMetadataManager _fieldMetadataManager;

        public List<Func<bool>> prefsEnabledIf { get; set; }

        public AppalachiaPaneBasedWindowBase window { get; set; }

        public bool Initialized { get; set; }

        public bool Initializing { get; set; }

        public float InitializationStart { get; set; }

        public int[] preferenceTabLevels { get; set; }

        public List<PREF_BASE> registeredPrefs { get; set; }

        public Rect container { get; set; }

        public abstract bool ContentInScrollView { get; }
        public abstract string PaneName { get; }

        public virtual bool DrawHeader => false;

        public UIFieldMetadataManager fieldMetadataManager
        {
            get
            {
                if (_fieldMetadataManager == null)
                {
                    _fieldMetadataManager = new UIFieldMetadataManager();
                }

                return _fieldMetadataManager;
            }
        }

        protected virtual bool AlwaysShowHorizontalScrollbar => false;

        protected virtual bool AlwaysShowVerticalScrollbar => false;

        protected virtual bool DrawPreferences => true;

        public abstract void OnDrawPaneContent();

        public abstract void OnInitialize();

        public virtual void DrawPaneHeader()
        {
        }

        public virtual void OnPreferencesChanged()
        {
        }

        public IEnumerator Initialize()
        {
            using (_TRACE_Initialize.Auto())
            using (_PRF_Initialize.Auto())
            {
                if (Initialized)
                {
                    yield break;
                }

                Initializing = true;
                InitializationStart = Time.realtimeSinceStartup;

                try
                {
                    using (_TRACE_Initialize_OnBeforeInitialize.Auto())
                    {
                        OnBeforeInitialize();
                    }

                    using (_TRACE_Initialize_OnInitialize.Auto())
                    {
                        OnInitialize();
                    }

                    Initialized = true;
                    Initializing = false;

                    window.SafeRepaint();
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }
        }

        public IList<IAppalachiaTabbedWindowPane> GetTabPanes(
            string paneSetIdentifier,
            Func<IList<IAppalachiaTabbedWindowPane>> initializationFunction)
        {
            using (_TRACE_GetTabPanes.Auto())
            using (_PRF_GetTabPanes.Auto())
            {
                return GetPanes(ref _tabPaneSetCache, paneSetIdentifier, initializationFunction);
            }
        }

        public IReadOnlyList<IAppalachiaWindowPane> GetChildPanes(
            string paneSetIdentifier,
            Func<IReadOnlyList<IAppalachiaWindowPane>> initializationFunction)
        {
            using (_TRACE_GetChildPanes.Auto())
            using (_PRF_GetChildPanes.Auto())
            {
                return GetPanes(ref _childPaneSetCache, paneSetIdentifier, initializationFunction);
            }
        }

        public void DrawPaneContent()
        {
            using (_TRACE_DrawPaneContent.Auto())
            using (_PRF_DrawPaneContent.Auto())
            {
                using (new EditorGUILayout.VerticalScope())
                {
                    if (DrawHeader)
                    {
                        var headerLabel = fieldMetadataManager.Get<LabelH2Metadata>(PaneName);
                        headerLabel.Draw();
                    }

                    if (DrawPreferences)
                    {
                        DrawPreferenceFields(true);
                    }

                    fieldMetadataManager.Space(SpaceSize.PreferencesPaddingVertical);

                    OnBeforeDrawPaneContentStart(out var shouldDraw);

                    if (!shouldDraw)
                    {
                        return;
                    }

                    if (ContentInScrollView)
                    {
                        var scrollView =
                            fieldMetadataManager.Get<ScrollViewUIMetadata>($"SV_CONTENT_{PaneName}");

                        using (scrollView.GetScope(
                            AlwaysShowHorizontalScrollbar,
                            AlwaysShowVerticalScrollbar
                        ))
                        {
                            ExecuteDrawPaneContent();
                        }

                        container = GUILayoutUtility.GetLastRect();
                    }
                    else
                    {
                        ExecuteDrawPaneContent();
                    }
                }
            }
        }

        public void DrawPreferenceFields(bool horizontal)
        {
            using (_TRACE_DrawPreferenceToggles.Auto())
            using (_PRF_DrawPreferenceFields.Auto())
            {
                if ((preferenceTabLevels == null) || (preferenceTabLevels.Length == 0))
                {
                    return;
                }

                fieldMetadataManager.Space(SpaceSize.SectionStartVertical);

                AppalachiaEditorGUIHelper.HorizontalLineSeparator();

                bool changed;

                if (horizontal)
                {
                    changed = DrawPreferencesHorizontal();
                }
                else
                {
                    fieldMetadataManager.Space(SpaceSize.PreferencesStartVertical);

                    changed = DrawPreferencesVertical();

                    fieldMetadataManager.Space(SpaceSize.PreferencesEndVertical);
                }

                if (changed)
                {
                    OnPreferencesChanged();
                }

                AppalachiaEditorGUIHelper.HorizontalLineSeparator();

                fieldMetadataManager.Space(SpaceSize.SectionEndVertical);
            }
        }

        public void ExecuteCoroutine(Func<IEnumerator> coroutine)
        {
            using (_TRACE_ExecuteCoroutine.Auto())
            using (_PRF_ExecuteCoroutine.Auto())
            {
                window.ExecuteCoroutine(coroutine);
            }
        }

        public void ExecuteDrawPaneContent()
        {
            using (_TRACE_ExecuteDrawPaneContent.Auto())
            using (_PRF_ExecuteDrawPaneContent.Auto())
            {
                OnDrawPaneContentStart();

                HorizontalLineSeparator();

                if (this is IAppalachiaTabbedWindowPaneParent p1 && p1.DrawTabsBeforeContent)
                {
                    p1.DrawAppalachiaTabbedWindowPane();
                }

                OnDrawPaneContent();

                if (this is IAppalachiaTabbedWindowPaneParent p2 && !p2.DrawTabsBeforeContent)
                {
                    p2.DrawAppalachiaTabbedWindowPane();
                }

                HorizontalLineSeparator();

                OnDrawPaneContentEnd();
            }
        }

        public virtual void OnBeforeDraw()
        {
        }

        public virtual void OnBeforeDrawPaneContent()
        {
        }

        public virtual void OnBeforeDrawPaneContentStart(out bool shouldDraw)
        {
            shouldDraw = true;
        }

        public virtual void OnBeforeInitialize()
        {
        }

        public void OnDrawGUI()
        {
            using (_TRACE_OnDrawGUI.Auto())
            using (_PRF_OnDrawGUI.Auto())
            {
                if (!Initialized)
                {
                    OnInitializationGUI();
                    return;
                }

                OnBeforeDraw();

                DrawPaneHeader();

                using (new EditorGUILayout.HorizontalScope())
                {
                    OnBeforeDrawPaneContent();

                    DrawPaneContent();
                }
            }
        }

        public virtual void OnDrawPaneContentEnd()
        {
        }

        public virtual void OnDrawPaneContentStart()
        {
        }

        public void OnInitializationGUI()
        {
            using (_TRACE_OnInitializationGUI.Auto())
            using (_PRF_OnInitializationGUI.Auto())
            {
                var progressBar = fieldMetadataManager.Get<ProgressBarMetadata>("Initializing...");

                if (InitializationStart == 0f)
                {
                    InitializationStart = Time.realtimeSinceStartup;
                }

                var initializationTime = Time.realtimeSinceStartup - InitializationStart;

                var loopTime = 2f;

                var totals = (initializationTime % loopTime) / loopTime;

                totals = Math.Max(0f, Math.Min(.999f, totals));

                var text = $"Initializing: {initializationTime:N3}";

                progressBar.Draw(totals, text);

                window.SafeRepaint();
            }
        }

        // ReSharper disable once UnusedParameter.Global
        public void OnPreferenceAwake<TP>(PREF<TP> pref)
        {
            using (_TRACE_OnPreferenceAwake.Auto())
            using (_PRF_OnPreferenceAwake.Auto())
            {
                if (window != null)
                {
                    window.SafeRepaint();
                }
            }
        }

        public void ProcessCollection<TL>(
            IList<TL> collection,
            Action<TL> elementAction,
            Func<TL, bool>[] skipElement)
        {
            using (_TRACE_ProcessCollection.Auto())
            using (_PRF_ProcessCollection.Auto())
            {
                ProcessCollection(DummyDisposable.provider, collection, elementAction, skipElement);
            }
        }

        public void ProcessCollection<TL>(
            Func<IDisposable> wrapper,
            IList<TL> collection,
            Action<TL> elementAction,
            Func<TL, bool>[] skipElement)
        {
            using (_TRACE_ProcessCollection.Auto())
            using (_PRF_ProcessCollection.Auto())
            {
                using (wrapper())
                {
                    for (var index = 0; index < collection.Count; index++)
                    {
                        var element = collection[index];

                        var skip = false;
                        if (skipElement != null)
                        {
                            for (var i = 0; i < skipElement.Length; i++)
                            {
                                var elementSkipCheck = skipElement[i];

                                if (elementSkipCheck == null)
                                {
                                    continue;
                                }

                                if (elementSkipCheck(element))
                                {
                                    skip = true;
                                    break;
                                }
                            }
                        }

                        if (skip)
                        {
                            continue;
                        }

                        elementAction(element);
                    }
                }
            }
        }

        public void RegisterFilterPref<T>(
            ref PREF<T> pref,
            string prefix,
            string settingName,
            T defaultValue,
            Func<bool> enableIf)
        {
            using (_TRACE_RegisterFilterPref.Auto())
            using (_PRF_RegisterFilterPref.Auto())
            {
                if (pref == null)
                {
                    pref = PREFS.REG($"{G_}/{prefix}", settingName, defaultValue);

                    pref.OnAwake -= OnPreferenceAwake;
                    pref.OnAwake += OnPreferenceAwake;
                }

                RegisterFilterPref(pref, enableIf);
            }
        }

        public void RegisterFilterPref<T>(PREF<T> pref, Func<bool> enableIf = null)
        {
            using (_TRACE_RegisterFilterPref.Auto())
            using (_PRF_RegisterFilterPref.Auto())
            {
                if (registeredPrefs == null)
                {
                    registeredPrefs = new List<PREF_BASE>();
                }

                if (prefsEnabledIf == null)
                {
                    prefsEnabledIf = new List<Func<bool>>();
                }

                if (!registeredPrefs.Contains(pref))
                {
                    registeredPrefs.Add(pref);
                    prefsEnabledIf.Add(enableIf);

                    var tabLevels = registeredPrefs.Count / 4;

                    var extraTabCount = registeredPrefs.Count % 4;

                    var hasExtraLevel = false;

                    if (extraTabCount > 2)
                    {
                        tabLevels += 1;
                        hasExtraLevel = true;
                    }

                    preferenceTabLevels = new int[tabLevels];

                    for (var i = 0; i < preferenceTabLevels.Length; i++)
                    {
                        if (i == (preferenceTabLevels.Length - 1))
                        {
                            if (hasExtraLevel)
                            {
                                preferenceTabLevels[^1] = extraTabCount;
                            }
                            else
                            {
                                preferenceTabLevels[^1] = 4 + extraTabCount;
                            }
                        }
                        else
                        {
                            preferenceTabLevels[i] = 4;
                        }
                    }
                }
            }
        }

        private bool DrawPreferencesHorizontal()
        {
            using (_PRF_DrawPreferencesHorizontal.Auto())
            {
                var bgStyle =
                    fieldMetadataManager.Background(ColorPalette.Default.highlight.Middle.ScaleA(.25f));

                GUILayout.HorizontalScope scope;

                var changed = false;

                using (scope = new GUILayout.HorizontalScope(bgStyle))
                {
                    var drawCount = 0;
                    var levelCount = 0;
                    var turnoverCount = preferenceTabLevels[levelCount];

                    for (var preferenceIndex = 0; preferenceIndex < registeredPrefs.Count; preferenceIndex++)
                    {
                        var preference = registeredPrefs[preferenceIndex];

                        var enableIf = prefsEnabledIf[preferenceIndex];
                        var enabled = (enableIf == null) || enableIf();

                        using (UIStateStacks.guiEnabled.Auto(enabled))
                        {
                            if (preference.Draw())
                            {
                                changed = true;
                            }
                        }

                        drawCount += 1;

                        if (drawCount >= turnoverCount)
                        {
                            scope.Dispose();
                            scope = new GUILayout.HorizontalScope(bgStyle);

                            drawCount = 0;
                            levelCount += 1;
                            if (levelCount < preferenceTabLevels.Length)
                            {
                                turnoverCount = preferenceTabLevels[levelCount];
                            }
                        }
                    }
                }

                scope.Dispose();

                return changed;
            }
        }

        private bool DrawPreferencesVertical()
        {
            using (_PRF_DrawPreferencesVertical.Auto())
            {
                var bgStyle =
                    fieldMetadataManager.Background(ColorPalette.Default.highlight.Middle.ScaleA(.25f));

                using (new GUILayout.VerticalScope(bgStyle))
                {
                    var changed = false;
                    fieldMetadataManager.Space(SpaceSize.PreferencesLeftPaddingTop);

                    for (var preferenceIndex = 0; preferenceIndex < registeredPrefs.Count; preferenceIndex++)
                    {
                        var preference = registeredPrefs[preferenceIndex];
                        var enableIf = prefsEnabledIf[preferenceIndex];
                        var enabled = (enableIf == null) || enableIf();

                        using (new GUILayout.HorizontalScope())
                        {
                            fieldMetadataManager.Space(SpaceSize.PreferencesLeftPaddingInner);

                            using (UIStateStacks.guiEnabled.Auto(enabled))
                            {
                                if (preference.Draw())
                                {
                                    changed = true;
                                }
                            }

                            fieldMetadataManager.Space(SpaceSize.PreferencesLeftPaddingInner);
                        }

                        fieldMetadataManager.Space(SpaceSize.PreferencesLeftPaddingUnder);
                    }

                    fieldMetadataManager.Space(SpaceSize.PreferencesLeftPaddingBottom);
                    return changed;
                }
            }
        }

        public static void HorizontalLineSeparator(
            Color color = default,
            float lineWidth = 1f,
            float bufferSize = 1f)
        {
            using (_TRACE_HorizontalLineSeparator.Auto())
            using (_PRF_HorizontalLineSeparator.Auto())
            {
                AppalachiaEditorGUIHelper.HorizontalLineSeparator(color, lineWidth, bufferSize);
            }
        }

        private static TC GetPanes<TC>(
            ref Dictionary<string, TC> cache,
            string paneSetIdentifier,
            Func<TC> initializationFunction)
        {
            using (_TRACE_GetPanes.Auto())
            using (_PRF_GetPanes.Auto())
            {
                cache ??= new Dictionary<string, TC>();

                if (!cache.ContainsKey(paneSetIdentifier))
                {
                    var newPaneSet = initializationFunction();
                    cache.Add(paneSetIdentifier, newPaneSet);
                    return newPaneSet;
                }

                var preExistingPaneSet = cache[paneSetIdentifier];

                if (preExistingPaneSet != null)
                {
                    return preExistingPaneSet;
                }

                {
                    var newPaneSet = initializationFunction();
                    cache.Add(paneSetIdentifier, newPaneSet);
                    return newPaneSet;
                }
            }
        }
    }
}
