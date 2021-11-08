using System;
using System.Collections.Generic;
using Appalachia.Core.Aspects.Tracing;
using Appalachia.Core.Context.Interfaces;
using Appalachia.Core.Preferences;
using Appalachia.Editing.Core.Fields;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.State;
using Appalachia.Editing.Core.Windows;
using Appalachia.Utility.Colors;
using Unity.Profiling;
using UnityEngine;

namespace Appalachia.Editing.Core.Common
{
    public class PreferenceDrawer : IPreferencesDrawer
    {
        public delegate void PreferencesChangedHandler();

        #region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(PreferenceDrawer) + ".";
        private const string _TRACE_PFX = nameof(PreferenceDrawer) + ".";

        private static readonly ProfilerMarker _PRF_DrawPreferenceFields =
            new(_PRF_PFX + nameof(DrawPreferenceFields));

        private static readonly TraceMarker _TRACE_DrawPreferenceFields =
            new(_TRACE_PFX + nameof(DrawPreferenceFields));

        private static readonly ProfilerMarker _PRF_DrawPreferencesHorizontal =
            new(_PRF_PFX + nameof(DrawPreferencesHorizontal));

        private static readonly ProfilerMarker _PRF_DrawPreferencesVertical =
            new(_PRF_PFX + nameof(DrawPreferencesVertical));

        private static readonly ProfilerMarker _PRF_RegisterFilterPref =
            new(_PRF_PFX + nameof(RegisterFilterPref));

        private static readonly TraceMarker _TRACE_RegisterFilterPref =
            new(_TRACE_PFX + nameof(RegisterFilterPref));

        private static readonly ProfilerMarker _PRF_OnPreferenceAwake =
            new(_PRF_PFX + nameof(OnPreferenceAwake));

        private static readonly TraceMarker _TRACE_OnPreferenceAwake =
            new(_TRACE_PFX + nameof(OnPreferenceAwake));

        #endregion

        public PreferenceDrawer(UIFieldMetadataManager fieldMetadataManager)
        {
            _fieldMetadataManager = fieldMetadataManager;
        }
        
        public PreferenceDrawer(UIFieldMetadataManager fieldMetadataManager, IAppalachiaWindow window)
        {
            _fieldMetadataManager = fieldMetadataManager;
            _window = window;
        }

        private IAppalachiaWindow _window;

        private readonly UIFieldMetadataManager _fieldMetadataManager;

        public int[] preferenceTabLevels { get; set; }

        public List<Func<bool>> prefsEnabledIf { get; set; }

        public List<PREF_BASE> registeredPrefs { get; set; }

        public IAppalachiaWindow Window
        {
            get => _window;
            set => _window = value;
        }

        public event PreferencesChangedHandler OnPreferencesChanged;

        public void DrawPreferenceFields(bool horizontal)
        {
            using (_TRACE_DrawPreferenceFields.Auto())
            using (_PRF_DrawPreferenceFields.Auto())
            {
                if ((registeredPrefs == null) || (registeredPrefs.Count == 0))
                {
                    return;
                }

                APPAGUI.SPACE.SIZE.SectionStartVertical.MAKE();

                APPAGUI.DrawHorizontalLineSeperator();

                bool changed;

                if (horizontal)
                {
                    changed = DrawPreferencesHorizontal();
                }
                else
                {
                    APPAGUI.SPACE.SIZE.PreferencesStartVertical.MAKE();

                    changed = DrawPreferencesVertical();

                    APPAGUI.SPACE.SIZE.PreferencesEndVertical.MAKE();
                }

                if (changed)
                {
                    OnPreferencesChanged?.Invoke();
                }

                APPAGUI.DrawHorizontalLineSeperator();

                APPAGUI.SPACE.SIZE.SectionEndVertical.MAKE();
            }
        }

        // ReSharper disable once UnusedParameter.Global
        public void OnPreferenceAwake<TP>(PREF<TP> pref)
        {
            using (_TRACE_OnPreferenceAwake.Auto())
            using (_PRF_OnPreferenceAwake.Auto())
            {
                if (_window != null)
                {
                    _window.SafeRepaint();
                }
            }
        }

        public void RegisterFilterPref<T>(
            ref PREF<T> pref,
            string grouping,
            string settingName,
            T defaultValue,
            Func<bool> enableIf)
        {
            using (_TRACE_RegisterFilterPref.Auto())
            using (_PRF_RegisterFilterPref.Auto())
            {
                if (pref == null)
                {
                    pref = PREFS.REG(grouping, settingName, defaultValue);

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
                if (pref == null)
                {
                    throw new NotSupportedException();
                }
                
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
                    _fieldMetadataManager.Background(ColorPalette.Default.highlight.Middle.ScaleA(.25f));

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

                        using (APPAGUI.StateStacks.guiEnabled.Auto(enabled))
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
                    _fieldMetadataManager.Background(ColorPalette.Default.highlight.Middle.ScaleA(.25f));

                using (new GUILayout.VerticalScope(bgStyle))
                {
                    var changed = false;
                    APPAGUI.SPACE.SIZE.PreferencesLeftPaddingTop.MAKE();

                    for (var preferenceIndex = 0; preferenceIndex < registeredPrefs.Count; preferenceIndex++)
                    {
                        var preference = registeredPrefs[preferenceIndex];
                        var enableIf = prefsEnabledIf[preferenceIndex];
                        var enabled = (enableIf == null) || enableIf();

                        if (preference == null)
                        {
                            continue;
                        }

                        using (new GUILayout.HorizontalScope())
                        {
                            APPAGUI.SPACE.SIZE.PreferencesLeftPaddingInner.MAKE();

                            using (APPAGUI.StateStacks.guiEnabled.Auto(enabled))
                            {
                                if (preference.IsAwake && preference.Draw())
                                {
                                    changed = true;
                                }
                            }

                            APPAGUI.SPACE.SIZE.PreferencesLeftPaddingInner.MAKE();
                        }

                        APPAGUI.SPACE.SIZE.PreferencesLeftPaddingUnder.MAKE();
                    }

                    APPAGUI.SPACE.SIZE.PreferencesLeftPaddingBottom.MAKE();
                    return changed;
                }
            }
        }
    }
}
