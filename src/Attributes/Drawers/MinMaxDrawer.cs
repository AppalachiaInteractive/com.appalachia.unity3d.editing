#region

using Unity.Profiling;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Attributes.Drawers
{
    [CustomPropertyDrawer(typeof(MinMaxAttribute))]
    public class MinMaxDrawer : PropertyDrawer
    {
        private const string _PRF_PFX = nameof(MinMaxDrawer) + ".";
        private static readonly ProfilerMarker _PRF_OnGUI = new ProfilerMarker(_PRF_PFX + nameof(OnGUI));
        public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
        {
            using (_PRF_OnGUI.Auto())
            {
                var mp = prop.FindPropertyRelative("min");
                var np = prop.FindPropertyRelative("max");
                var mm = attribute as MinMaxAttribute;

                if ((mp != null) && (np != null) && (mm != null))
                {
                    var i = EditorGUI.indentLevel;

                    var mv = mp.floatValue;
                    var nv = np.floatValue;

                    var dx1 = (EditorGUIUtility.fieldWidth * 2) + (Mathf.Clamp01(i) * 9);
                    var dx2 = (EditorGUIUtility.fieldWidth * 2) + ((i - 1) * 9);

                    var r = pos;
                    r.width = r.width - dx1;
                    EditorGUI.MinMaxSlider(r, new GUIContent(ObjectNames.NicifyVariableName(prop.name)), ref mv, ref nv, mm.min, mm.max);

                    EditorGUI.indentLevel = 0;

                    r.x = (pos.width - dx2) + (i * 9) + 3;
                    r.width = EditorGUIUtility.fieldWidth;
                    var s = new GUIStyle(EditorStyles.numberField);
                    s.fixedWidth = EditorGUIUtility.fieldWidth;
                    mv = EditorGUI.DelayedFloatField(r, mv, s);
                    r.x += EditorGUIUtility.fieldWidth + 2;
                    nv = EditorGUI.DelayedFloatField(r, nv, s);

                    mp.floatValue = Mathf.Min(Mathf.Max(mv, mm.min), Mathf.Min(nv, mm.max));
                    np.floatValue = Mathf.Max(Mathf.Max(mv, mm.min), Mathf.Min(nv, mm.max));

                    EditorGUI.indentLevel = i;
                }
            }
        }
    }
} // Hapki.Editor
