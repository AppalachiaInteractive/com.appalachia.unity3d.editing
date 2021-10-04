#region

using System;
using System.Collections.Generic;
using System.Linq;
using Appalachia.Core.Attributes;
using Appalachia.Core.Constants;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Preferences
{
    public static class PREF_STATES
    {
        private const string _PRF_PFX = nameof(PREF_STATES) + ".";
        
        public static readonly HashSet<string> _keys = new HashSet<string>();
        public static readonly List<string> _groupings = new List<string>(128);
        public static readonly HashSet<string> _groupingsParts = new HashSet<string>();
        private static readonly Group _group = new Group(string.Empty);

        public static readonly PREF_STATE<bool> _bools = new PREF_STATE<bool>();
        public static readonly PREF_STATE<Bounds> _bounds = new PREF_STATE<Bounds>();
        public static readonly PREF_STATE<Color> _colors = new PREF_STATE<Color>();
        public static readonly PREF_STATE<Gradient> _gradients = new PREF_STATE<Gradient>();
        public static readonly PREF_STATE<double> _doubles = new PREF_STATE<double>();
        public static readonly PREF_STATE<float> _floats = new PREF_STATE<float>();
        public static readonly PREF_STATE<float2> _float2s = new PREF_STATE<float2>();
        public static readonly PREF_STATE<float3> _float3s = new PREF_STATE<float3>();
        public static readonly PREF_STATE<float4> _float4s = new PREF_STATE<float4>();
        public static readonly PREF_STATE<int> _ints = new PREF_STATE<int>();
        public static readonly PREF_STATE<quaternion> _quaternions = new PREF_STATE<quaternion>();
        public static readonly PREF_STATE<string> _strings = new PREF_STATE<string>();
        public static bool _safeToAwaken;

        public static readonly Dictionary<Type, object> _enums = new Dictionary<Type, object>();

        private static readonly ProfilerMarker _PRF_CustomUserPreferences = new ProfilerMarker(_PRF_PFX + nameof(CustomUserPreferences));
        [SettingsProvider]
        public static SettingsProvider CustomUserPreferences()
        {
            using (_PRF_CustomUserPreferences.Auto())
            {
                var provider = new SettingsProvider("Preferences/User Created", SettingsScope.User);
                provider.guiHandler = searchContext => DrawUI();
                provider.label = "User Created";
                return provider;
            }
        }

        private static readonly ProfilerMarker _PRF_GetSortedCount = new ProfilerMarker(_PRF_PFX + nameof(GetSortedCount));
        private static int GetSortedCount<T>(PREF_STATE<T> prefState)
        {
            using (_PRF_GetSortedCount.Auto())
            {
                if (prefState.SortedValues.Count != prefState.Values.Count)
                {
                    prefState.Sort();
                }

                return prefState.SortedValues.Count;
            }
        }

        private static readonly ProfilerMarker _PRF_AddToGrouping = new ProfilerMarker(_PRF_PFX + nameof(AddToGrouping));
        private static void AddToGrouping<T>(PREF_STATE<T> prefState)
        {
            using (_PRF_AddToGrouping.Auto())
            {
                for (var index = 0; index < prefState.SortedValues.Count; index++)
                {
                    var pref = prefState.SortedValues[index];
                    _groupings.Add(pref.Grouping);
                }
            }
        }

        private static void DrawUI()
        {
            using (_PRF_DrawUI.Auto())
            {
                var groupingCount = GetSortedCount(_bools) +
                                    GetSortedCount(_colors) +
                                    GetSortedCount(_gradients) +
                                    GetSortedCount(_doubles) +
                                    GetSortedCount(_floats) +
                                    GetSortedCount(_float2s) +
                                    GetSortedCount(_float3s) +
                                    GetSortedCount(_float4s) +
                                    GetSortedCount(_ints) +
                                    GetSortedCount(_quaternions) +
                                    GetSortedCount(_strings);

                if (_groupings.Count != groupingCount)
                {
                    _groupings.Clear();

                    AddToGrouping(_bools);
                    AddToGrouping(_colors);
                    AddToGrouping(_gradients);
                    AddToGrouping(_doubles);
                    AddToGrouping(_floats);
                    AddToGrouping(_float2s);
                    AddToGrouping(_float3s);
                    AddToGrouping(_float4s);
                    AddToGrouping(_ints);
                    AddToGrouping(_quaternions);
                    AddToGrouping(_strings);

                    for (var index = 0; index < _groupings.Count; index++)
                    {
                        var grouping = _groupings[index];
                        var splits = grouping.Split('/');
                        var subs = string.Empty;

                        for (var i = 0; i < splits.Length; i++)
                        {
                            subs += splits[i];

                            _groupingsParts.Add(subs);

                            subs += "/";
                        }
                    }
                }

                if (_group.NestedCount != _groupingsParts.Count)
                {
                    var ordered = _groupingsParts.OrderBy(g => g.Length).ToArray();

                    _group.Add(ordered);
                }

                for (var i = 0; i < _group.subgroups.Count; i++)
                {
                    DrawUIGroup(_group.subgroups[i]);
                }
            }
        }

        private static readonly ProfilerMarker _PRF_DrawUIGroup = new ProfilerMarker(_PRF_PFX + nameof(DrawUIGroup));
        private static void DrawUIGroup(Group group)
        {
            using (_PRF_DrawUIGroup.Auto())
            {
                group.foldout = EditorGUILayout.Foldout(group.foldout, group.groupShortName);

                EditorGUI.indentLevel++;

                if (group.foldout)
                {
                    group.CollapseCousinGroups();

                    DrawUI(group.groupFullName, _bools);
                    DrawUI(group.groupFullName, _bounds);
                    DrawUI(group.groupFullName, _colors);
                    DrawUI(group.groupFullName, _gradients);
                    DrawUI(group.groupFullName, _floats);
                    DrawUI(group.groupFullName, _doubles);
                    DrawUI(group.groupFullName, _float2s);
                    DrawUI(group.groupFullName, _float3s);
                    DrawUI(group.groupFullName, _float4s);
                    DrawUI(group.groupFullName, _ints);
                    DrawUI(group.groupFullName, _quaternions);
                    DrawUI(group.groupFullName, _strings);

                    for (var i = 0; i < group.subgroups.Count; i++)
                    {
                        DrawUIGroup(group.subgroups[i]);
                    }
                }
                else
                {
                    group.CollapseChildGroups();
                }

                EditorGUI.indentLevel--;
            }
        }

        public static float indentSize = 25f;
        public static float characterSize = 7f;
        private static readonly ProfilerMarker _PRF_DrawUI = new ProfilerMarker(_PRF_PFX + nameof(DrawUI));
        private static void DrawUI<TR>(string groupFullName, PREF_STATE<TR> prefs)
        {
            using (_PRF_DrawUI.Auto())
            {
                EditorGUI.indentLevel++;

                var indent = EditorGUI.indentLevel * indentSize;

                for (var index = 0; index < prefs.SortedValues.Count; index++)
                {
                    var preference = prefs.SortedValues[index];
                    if (preference.Grouping == groupFullName)
                    {
                        EditorGUI.BeginChangeCheck();

                        if (preference.NiceLabel == null)
                        {
                            preference.NiceLabel = ObjectNames.NicifyVariableName(preference.Label);
                        }
                        
                        var labelWidth = indent + (preference.NiceLabel.Length * characterSize);
                        var currentLabelWidth = EditorGUIUtility.labelWidth;

                        EditorGUIUtility.labelWidth = labelWidth;
                        preference.Value = prefs.API.Draw(preference.NiceLabel, preference.Value, preference.Low, preference.High);

                        if (EditorGUI.EndChangeCheck())
                        {
                            prefs.API.Save(preference.Key, preference.Value, preference.Low, preference.High);
                        }

                        EditorGUIUtility.labelWidth = currentLabelWidth;
                    }
                }

                EditorGUI.indentLevel--;
            }
        }

        private static readonly ProfilerMarker _PRF_Awake = new ProfilerMarker(_PRF_PFX + nameof(Awake));
        [MenuItem("Tools/Preferences/Awaken", false, MENU_P.TOOLS.GENERAL.PRIORITY)]
        [ExecuteOnEnable]
        internal static void Awake()
        {
            using (_PRF_Awake.Auto())
            {
                _safeToAwaken = true;

                _bools.Awake();
                _bounds.Awake();
                _colors.Awake();
                _gradients.Awake();
                _doubles.Awake();
                _floats.Awake();
                _float2s.Awake();
                _float3s.Awake();
                _float4s.Awake();
                _ints.Awake();
                _quaternions.Awake();
                _strings.Awake();

                foreach (var x in _enums)
                {
                    if (x.Value is PREF_STATE_BASE xb)
                    {
                        xb.Awake();
                    }
                }
            }
        }

        private static readonly ProfilerMarker _PRF_Get = new ProfilerMarker(_PRF_PFX + nameof(Get));
        public static PREF_STATE<TR> Get<TR>()
        {
            using (_PRF_Get.Auto())
            {
                var typeTR = typeof(TR);

                if (typeTR == typeof(bool))
                {
                    return _bools as PREF_STATE<TR>;
                }

                if (typeTR == typeof(Bounds))
                {
                    return _bounds as PREF_STATE<TR>;
                }

                if (typeTR == typeof(Color))
                {
                    return _colors as PREF_STATE<TR>;
                }

                if (typeTR == typeof(Gradient))
                {
                    return _gradients as PREF_STATE<TR>;
                }

                if (typeTR == typeof(double))
                {
                    return _doubles as PREF_STATE<TR>;
                }

                if (typeTR == typeof(float))
                {
                    return _floats as PREF_STATE<TR>;
                }

                if (typeTR == typeof(float2))
                {
                    return _float2s as PREF_STATE<TR>;
                }

                if (typeTR == typeof(float3))
                {
                    return _float3s as PREF_STATE<TR>;
                }

                if (typeTR == typeof(float4))
                {
                    return _float4s as PREF_STATE<TR>;
                }

                if (typeTR == typeof(int))
                {
                    return _ints as PREF_STATE<TR>;
                }

                if (typeTR == typeof(quaternion))
                {
                    return _quaternions as PREF_STATE<TR>;
                }

                if (typeTR == typeof(string))
                {
                    return _strings as PREF_STATE<TR>;
                }

                if (typeTR.IsEnum || (typeof(TR) == typeof(Enum)))
                {
                    return GetEnumState<TR>();
                }

                throw new NotSupportedException(typeTR.Name);
            }
        }

        private static readonly ProfilerMarker _PRF_GetEnumState = new ProfilerMarker(_PRF_PFX + nameof(GetEnumState));
        public static PREF_STATE<TR> GetEnumState<TR>()
        {
            using (_PRF_GetEnumState.Auto())
            {
                var type = typeof(TR);

                if (!_enums.ContainsKey(type))
                {
                    var p = new PREF_STATE<TR>();

                    _enums.Add(type, p);
                    return p;
                }

                var existing = _enums[type];

                return (PREF_STATE<TR>) existing;
            }
        }

        public class Group
        {
            private const string _PRF_PFX = nameof(PREF_STATES) + "." + nameof(Group) + ".";
            
            public string groupShortName;
            public string groupFullName;
            public Group parent;
            public List<Group> subgroups;
            public bool foldout;

            public Group(string groupFullName, Group parent = null)
            {
                this.groupFullName = groupFullName;
                var splits = groupFullName.Split('/');
                groupShortName = splits[splits.Length - 1];
                subgroups = new List<Group>();
                this.parent = null;
                foldout = parent == null;
            }

            private static readonly ProfilerMarker _PRF_NestedCount = new ProfilerMarker(_PRF_PFX + nameof(NestedCount));
            public int NestedCount
            {
                get
                {
                    using (_PRF_NestedCount.Auto())
                    {
                        var sum = 0;

                        for (var i = 0; i < subgroups.Count; i++)
                        {
                            sum += subgroups[i].NestedCount;
                        }

                        sum += subgroups.Count;

                        return sum;
                    }
                }
            }

            private static readonly ProfilerMarker _PRF_Add = new ProfilerMarker(_PRF_PFX + nameof(Add));
            public void Add(string[] groupings)
            {
                using (_PRF_Add.Auto())
                {
                    subgroups.Clear();

                    for (var i = 0; i < groupings.Length; i++)
                    {
                        Add(groupings[i]);
                    }
                }
            }

            public bool Add(string other)
            {
                using (_PRF_Add.Auto())
                {
                    var found = false;

                    if ((other.Length > groupFullName.Length) && (other.StartsWith(groupFullName) || string.IsNullOrEmpty(groupFullName)))
                    {
                        for (var i = 0; i < subgroups.Count; i++)
                        {
                            var subg = subgroups[i];

                            found = subg.Add(other);

                            if (found)
                            {
                                break;
                            }
                        }

                        if (!found)
                        {
                            subgroups.Add(new Group(other));
                            return true;
                        }
                    }

                    return found;
                }
            }

            private static readonly ProfilerMarker _PRF_CollapseChildGroups = new ProfilerMarker(_PRF_PFX + nameof(CollapseChildGroups));
            public void CollapseChildGroups()
            {
                using (_PRF_CollapseChildGroups.Auto())
                {
                    for (var i = 0; i < subgroups.Count; i++)
                    {
                        var subgroup = subgroups[i];

                        subgroup.foldout = false;
                    }
                }
            }

            private static readonly ProfilerMarker _PRF_CollapseCousinGroups = new ProfilerMarker(_PRF_PFX + nameof(CollapseCousinGroups));
            public void CollapseCousinGroups()
            {
                using (_PRF_CollapseCousinGroups.Auto())
                {
                    if (parent == null)
                    {
                        return;
                    }

                    for (var i = 0; i < parent.subgroups.Count; i++)
                    {
                        var subgroup = subgroups[i];

                        if (subgroup.groupFullName == groupFullName)
                        {
                            continue;
                        }

                        subgroup.foldout = false;
                    }
                }
            }
        }

/*
_bools
_bounds
_colors
_gradients
_doubles
_floats
_float2s
_float3s
_float4s
_ints
_quaternions
_strings

bool
Bounds
Color
Gradient
double
float
float2
float3
float4
int
quaternion
string
*/
    }
}
