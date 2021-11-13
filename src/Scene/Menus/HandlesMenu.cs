#if UNITY_EDITOR

#region

using Appalachia.Core.Attributes;
using Appalachia.Core.Preferences;
using UnityEngine.Rendering;

#endregion

namespace Appalachia.Editing.Scene.Menus
{
    [UnityEditor.InitializeOnLoad]
    
    public static class HandlesMenu
    {
        static HandlesMenu()
        {
        }

        [ExecuteOnEnable]
        private static void OnEnable()
        {
            _Z_PREF = PREFS.REG(PKG.Prefs.Group, "Default UnityEditor.Handles ZTest", CompareFunction.Always);

            UnityEditor.Handles.zTest = _Z_PREF.v;
        }

#region Default UnityEditor.Handles ZTest

        public static PREF<CompareFunction> _Z_PREF = PREFS.REG(
            PKG.Prefs.Group,
            "Default UnityEditor.Handles ZTest",
            CompareFunction.Always
        );

        private const string Z_TEST = PKG.Menu.Appalachia.Tools.Base + "ZTest";

        private static readonly CompareFunction _ZT_DIS_v = CompareFunction.Disabled;
        private static readonly CompareFunction _ZT_NEV_v = CompareFunction.Never;
        private static readonly CompareFunction _ZT_LES_v = CompareFunction.Less;
        private static readonly CompareFunction _ZT_EQU_v = CompareFunction.Equal;
        private static readonly CompareFunction _ZT_LEQ_v = CompareFunction.LessEqual;
        private static readonly CompareFunction _ZT_GRT_v = CompareFunction.Greater;
        private static readonly CompareFunction _ZT_NEQ_v = CompareFunction.NotEqual;
        private static readonly CompareFunction _ZT_GRE_v = CompareFunction.GreaterEqual;
        private static readonly CompareFunction _ZT_ALW_v = CompareFunction.Always;

        private const string _ZT_DIS_s = "/Disabled";
        private const string _ZT_NEV_s = "/Never";
        private const string _ZT_LES_s = "/Less";
        private const string _ZT_EQU_s = "/Equal";
        private const string _ZT_LEQ_s = "/LessEqual";
        private const string _ZT_GRT_s = "/Greater";
        private const string _ZT_NEQ_s = "/NotEqual";
        private const string _ZT_GRE_s = "/GreaterEqual";
        private const string _ZT_ALW_s = "/Always";

        private static bool _ZT_DIS_chk => _Z_PREF.Value.Equals(_ZT_DIS_v);
        private static bool _ZT_NEV_chk => _Z_PREF.Value.Equals(_ZT_NEV_v);
        private static bool _ZT_LES_chk => _Z_PREF.Value.Equals(_ZT_LES_v);
        private static bool _ZT_EQU_chk => _Z_PREF.Value.Equals(_ZT_EQU_v);
        private static bool _ZT_LEQ_chk => _Z_PREF.Value.Equals(_ZT_LEQ_v);
        private static bool _ZT_GRT_chk => _Z_PREF.Value.Equals(_ZT_GRT_v);
        private static bool _ZT_NEQ_chk => _Z_PREF.Value.Equals(_ZT_NEQ_v);
        private static bool _ZT_GRE_chk => _Z_PREF.Value.Equals(_ZT_GRE_v);
        private static bool _ZT_ALW_chk => _Z_PREF.Value.Equals(_ZT_ALW_v);

        private const string _ZT_DIS_m = Z_TEST + _ZT_DIS_s;
        private const string _ZT_NEV_m = Z_TEST + _ZT_NEV_s;
        private const string _ZT_LES_m = Z_TEST + _ZT_LES_s;
        private const string _ZT_EQU_m = Z_TEST + _ZT_EQU_s;
        private const string _ZT_LEQ_m = Z_TEST + _ZT_LEQ_s;
        private const string _ZT_GRT_m = Z_TEST + _ZT_GRT_s;
        private const string _ZT_NEQ_m = Z_TEST + _ZT_NEQ_s;
        private const string _ZT_GRE_m = Z_TEST + _ZT_GRE_s;
        private const string _ZT_ALW_m = Z_TEST + _ZT_ALW_s;

        [UnityEditor.MenuItem(_ZT_DIS_m, true)]
        private static bool _ZT_DIS_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_DIS_m, _ZT_DIS_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_NEV_m, true)]
        private static bool _ZT_NEV_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_NEV_m, _ZT_NEV_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_LES_m, true)]
        private static bool _ZT_LES_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_LES_m, _ZT_LES_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_EQU_m, true)]
        private static bool _ZT_EQU_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_EQU_m, _ZT_EQU_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_LEQ_m, true)]
        private static bool _ZT_LEQ_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_LEQ_m, _ZT_LEQ_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_GRT_m, true)]
        private static bool _ZT_GRT_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_GRT_m, _ZT_GRT_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_NEQ_m, true)]
        private static bool _ZT_NEQ_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_NEQ_m, _ZT_NEQ_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_GRE_m, true)]
        private static bool _ZT_GRE_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_GRE_m, _ZT_GRE_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_ALW_m, true)]
        private static bool _ZT_ALW_V()
        {
            UnityEditor.Menu.SetChecked(_ZT_ALW_m, _ZT_ALW_chk);
            return true;
        }

        [UnityEditor.MenuItem(_ZT_DIS_m)]
        private static void _ZT_DIS_()
        {
            _Z_PREF.v = _ZT_DIS_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

        [UnityEditor.MenuItem(_ZT_NEV_m)]
        private static void _ZT_NEV_()
        {
            _Z_PREF.v = _ZT_NEV_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

        [UnityEditor.MenuItem(_ZT_LES_m)]
        private static void _ZT_LES_()
        {
            _Z_PREF.v = _ZT_LES_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

        [UnityEditor.MenuItem(_ZT_EQU_m)]
        private static void _ZT_EQU_()
        {
            _Z_PREF.v = _ZT_EQU_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

        [UnityEditor.MenuItem(_ZT_LEQ_m)]
        private static void _ZT_LEQ_()
        {
            _Z_PREF.v = _ZT_LEQ_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

        [UnityEditor.MenuItem(_ZT_GRT_m)]
        private static void _ZT_GRT_()
        {
            _Z_PREF.v = _ZT_GRT_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

        [UnityEditor.MenuItem(_ZT_NEQ_m)]
        private static void _ZT_NEQ_()
        {
            _Z_PREF.v = _ZT_NEQ_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

        [UnityEditor.MenuItem(_ZT_GRE_m)]
        private static void _ZT_GRE_()
        {
            _Z_PREF.v = _ZT_GRE_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

        [UnityEditor.MenuItem(_ZT_ALW_m)]
        private static void _ZT_ALW_()
        {
            _Z_PREF.v = _ZT_ALW_v;
           UnityEditor.Handles.zTest = _Z_PREF.v;
        }

#endregion
    }
}

#endif
