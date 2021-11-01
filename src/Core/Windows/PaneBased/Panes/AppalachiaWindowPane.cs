using System;
using System.Collections;
using System.Collections.Generic;
using Appalachia.Core.Aspects;
using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Context.Elements.Progress;
using Appalachia.Editing.Core.Common;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows.PaneBased.Panes
{
    [Serializable]
    public abstract class AppalachiaWindowPane : IComparable<AppalachiaWindowPane>, IComparable
    {
        #region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(AppalachiaWindowPane) + ".";

        private const string _TRACE_PFX = nameof(AppalachiaWindowPane) + ".";

        private static readonly ProfilerMarker _PRF_OnDrawGUI = new(_PRF_PFX + nameof(OnDrawGUI));
        private static readonly ProfilerMarker _PRF_Initialize = new(_PRF_PFX + nameof(Initialize));
        private static readonly ProfilerMarker _PRF_DrawPaneContent = new(_PRF_PFX + nameof(DrawPaneContent));

        private static readonly ProfilerMarker _PRF_ProcessCollection =
            new(_PRF_PFX + nameof(ProcessCollection));

        private static readonly ProfilerMarker _PRF_ExecuteDrawPaneContent =
            new(_PRF_PFX + nameof(ExecuteDrawPaneContent));

        private static readonly TraceMarker _TRACE_GetChildPanes = new(_TRACE_PFX + nameof(GetChildPanes));
        private static readonly ProfilerMarker _PRF_GetChildPanes = new(_PRF_PFX + nameof(GetChildPanes));
        private static readonly TraceMarker _TRACE_GetTabPanes = new(_TRACE_PFX + nameof(GetTabPanes));
        private static readonly ProfilerMarker _PRF_GetTabPanes = new(_PRF_PFX + nameof(GetTabPanes));
        private static readonly TraceMarker _TRACE_Initialize = new(_TRACE_PFX + nameof(Initialize));
        private static readonly TraceMarker _TRACE_OnDrawGUI = new(_TRACE_PFX + nameof(OnDrawGUI));

        private static readonly ProfilerMarker _PRF_ExecuteCoroutine =
            new(_PRF_PFX + nameof(ExecuteCoroutine));

        private static readonly TraceMarker _TRACE_ExecuteCoroutine =
            new(_TRACE_PFX + nameof(ExecuteCoroutine));

        private static readonly TraceMarker _TRACE_ProcessCollection =
            new(_TRACE_PFX + nameof(ProcessCollection));

        private static readonly TraceMarker
            _TRACE_DrawPaneContent = new(_TRACE_PFX + nameof(DrawPaneContent));

        private static readonly TraceMarker _TRACE_ExecuteDrawPaneContent =
            new(_TRACE_PFX + nameof(ExecuteDrawPaneContent));

        private static readonly TraceMarker _TRACE_HorizontalLineSeparator =
            new(_TRACE_PFX + nameof(HorizontalLineSeparator));

        private static readonly ProfilerMarker _PRF_HorizontalLineSeparator =
            new(_PRF_PFX + nameof(HorizontalLineSeparator));

        private static readonly TraceMarker _TRACE_GetPanes = new(_TRACE_PFX + nameof(GetPanes));
        private static readonly ProfilerMarker _PRF_GetPanes = new(_PRF_PFX + nameof(GetPanes));

        private static readonly TraceMarker _TRACE_Initialize_OnBeforeInitialize =
            new(_TRACE_PFX + nameof(Initialize) + ".OnBeforeInitialize");

        private static readonly TraceMarker _TRACE_Initialize_OnAfterInitialize =
            new(_TRACE_PFX + nameof(Initialize) + ".OnAfterInitialize");

        private static readonly TraceMarker _TRACE_Initialize_OnInitialize =
            new(_TRACE_PFX + nameof(Initialize) + ".OnInitialize");

        private static readonly TraceMarker _TRACE_OnBeforeDraw = new(_TRACE_PFX + nameof(OnBeforeDraw));

        private static readonly TraceMarker _TRACE_OnBeforeDrawPaneContent =
            new(_TRACE_PFX + nameof(OnBeforeDrawPaneContent));

        private static readonly TraceMarker _TRACE_OnBeforeInitialize =
            new(_TRACE_PFX + nameof(OnBeforeInitialize));

        #endregion

        protected AppalachiaWindowPane()
        {
            _fieldMetadataManager = new UIFieldMetadataManager();
            _preferencesDrawer = new PreferenceDrawer(_fieldMetadataManager);

            _preferencesDrawer.OnPreferencesChanged += OnPreferencesChanged;
        }

        private Dictionary<string, IList<AppalachiaWindowPane>> _tabPaneSetCache;
        private Dictionary<string, IReadOnlyList<AppalachiaWindowPane>> _childPaneSetCache;

        private PreferenceDrawer _preferencesDrawer;

        private ProgressBarMetadata _progressBar;

        private UIFieldMetadataManager _fieldMetadataManager;

        public bool PaneIsInitializing { get; set; }

        /*public Dictionary<string, IList<AppalachiaWindowPane>> tabPaneSetCache { get; set; }

        public Dictionary<string, IReadOnlyList<AppalachiaWindowPane>> childPaneSetCache { get; set; }*/

        public IAppalachiaWindow window { get; set; }

        public Rect container { get; set; }

        protected bool PaneIsInitialized { get; set; }

        public abstract bool ContentInScrollView { get; }

        public abstract int DesiredTabIndex { get; }

        public abstract string PaneName { get; }
        public abstract string TabName { get; }

        public virtual bool DrawHeader => false;

        public virtual bool IsInitialized => true;

        protected virtual bool AlwaysShowHorizontalScrollbar => false;

        protected virtual bool AlwaysShowVerticalScrollbar => false;

        protected virtual bool DrawPreferences => true;

        public bool FullyInitialized => IsInitialized && PaneIsInitialized;

        public PreferenceDrawer PreferencesDrawer => _preferencesDrawer;

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

        public abstract IEnumerator OnInitialize();

        public abstract void OnDrawPaneContent();

        public virtual IEnumerator OnAfterInitialize()
        {
            yield break;
        }

        public virtual IEnumerator OnBeforeInitialize()
        {
            yield break;
        }

        public virtual void DrawPaneHeader()
        {
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

        public virtual void OnDrawPaneContentEnd()
        {
        }

        public virtual void OnDrawPaneContentStart()
        {
        }

        public virtual void OnPreferencesChanged()
        {
        }

        protected virtual AppaProgress GetInitializationProgress()
        {
            return default;
        }

        public static bool operator >(AppalachiaWindowPane left, AppalachiaWindowPane right)
        {
            return Comparer<AppalachiaWindowPane>.Default.Compare(left, right) > 0;
        }

        public static bool operator >=(AppalachiaWindowPane left, AppalachiaWindowPane right)
        {
            return Comparer<AppalachiaWindowPane>.Default.Compare(left, right) >= 0;
        }

        public static bool operator <(AppalachiaWindowPane left, AppalachiaWindowPane right)
        {
            return Comparer<AppalachiaWindowPane>.Default.Compare(left, right) < 0;
        }

        public static bool operator <=(AppalachiaWindowPane left, AppalachiaWindowPane right)
        {
            return Comparer<AppalachiaWindowPane>.Default.Compare(left, right) <= 0;
        }

        public static void HorizontalLineSeparator(
            Color color = default,
            float lineWidth = 1f,
            float bufferSize = 1f)
        {
            using (_TRACE_HorizontalLineSeparator.Auto())
            using (_PRF_HorizontalLineSeparator.Auto())
            {
                APPAGUI.DrawHorizontalLineSeperator(color, lineWidth, bufferSize);
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

        public IEnumerator Initialize()
        {
            using (_TRACE_Initialize.Auto())
            using (_PRF_Initialize.Auto())
            {
                if (FullyInitialized || PaneIsInitializing)
                {
                    yield break;
                }

                PaneIsInitialized = false;
                PaneIsInitializing = true;

                using (_TRACE_Initialize_OnBeforeInitialize.Auto())
                {
                    var subenum = OnBeforeInitialize();

                    while (subenum.MoveNext())
                    {
                        yield return subenum.Current;
                    }
                }

                using (_TRACE_Initialize_OnInitialize.Auto())
                {
                    var subenum = OnInitialize();

                    while (subenum.MoveNext())
                    {
                        yield return subenum.Current;
                    }
                }

                using (_TRACE_Initialize_OnAfterInitialize.Auto())
                {
                    var subenum = OnAfterInitialize();

                    while (subenum.MoveNext())
                    {
                        yield return subenum.Current;
                    }
                }

                PaneIsInitialized = true;
                PaneIsInitializing = false;
                _progressBar?.Reset();

                window.SafeRepaint();
            }
        }

        public IList<AppalachiaWindowPane> GetTabPanes(
            string paneSetIdentifier,
            Func<IList<AppalachiaWindowPane>> initializationFunction)
        {
            using (_TRACE_GetTabPanes.Auto())
            using (_PRF_GetTabPanes.Auto())
            {
                return GetPanes(ref _tabPaneSetCache, paneSetIdentifier, initializationFunction);
            }
        }

        public IReadOnlyList<AppalachiaWindowPane> GetChildPanes(
            string paneSetIdentifier,
            Func<IReadOnlyList<AppalachiaWindowPane>> initializationFunction)
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
                        PreferencesDrawer.DrawPreferenceFields(true);
                    }

                    APPAGUI.SPACE.SIZE.PreferencesPaddingVertical.MAKE();

                    OnBeforeDrawPaneContentStart(out var shouldDraw);

                    if (!shouldDraw)
                    {
                        return;
                    }

                    if (ContentInScrollView)
                    {
                        var scrollView = fieldMetadataManager.Get<ScrollViewUIMetadata>(
                            $"SV_CONTENT_{PaneName}",
                            f =>
                            {
                                f.AlwaysShowHorizontal = AlwaysShowHorizontalScrollbar;
                                f.AlwaysShowVertical = AlwaysShowVerticalScrollbar;
                            }
                        );

                        using (scrollView.GetScope())
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

        public void DrawTabPaneChild(AppalachiaWindowPane tp, string tabName)
        {
            if (!tp.FullyInitialized && !tp.PaneIsInitializing)
            {
                ExecuteCoroutine(tp.Initialize);
            }

            if (tp.window == null)
            {
                tp.window = window;
            }

            using (fieldMetadataManager.Get<ScrollViewUIMetadata>($"TAB_{tabName}").GetScope())
            {
                tp.OnDrawGUI();
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

                if (this is AppalachiaTabPaneParent p1 && p1.DrawTabsBeforeContent)
                {
                    p1.DrawAppalachiaTabbedWindowPane();
                }

                OnDrawPaneContent();

                if (this is AppalachiaTabPaneParent p2 && !p2.DrawTabsBeforeContent)
                {
                    p2.DrawAppalachiaTabbedWindowPane();
                }

                HorizontalLineSeparator();

                OnDrawPaneContentEnd();
            }
        }

        public void OnDrawGUI()
        {
            using (_TRACE_OnDrawGUI.Auto())
            using (_PRF_OnDrawGUI.Auto())
            {
                if (!FullyInitialized)
                {
                    _progressBar ??= fieldMetadataManager.Get<ProgressBarMetadata>(PaneName + "Initializing...");

                    _progressBar.DrawDynamic(GetInitializationProgress, window);

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

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            return obj is AppalachiaWindowPane other
                ? CompareTo(other)
                : throw new ArgumentException($"Object must be of type {nameof(AppalachiaWindowPane)}");
        }

        public int CompareTo(AppalachiaWindowPane other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return DesiredTabIndex.CompareTo(other.DesiredTabIndex);
        }

        internal void SetWindowInternal(IAppalachiaWindow w)
        {
            window = w;
            _preferencesDrawer.Window = w;
        }
    }
}
