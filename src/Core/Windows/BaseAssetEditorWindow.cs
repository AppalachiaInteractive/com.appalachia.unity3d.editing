using System;
using System.Collections.Generic;
using Appalachia.Core.Preferences;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Windows
{
    public abstract class BaseAssetEditorWindow : EditorWindow
    {

        protected void OnPreferenceAwake<T>(PREF<T> pref)
        {
            Repaint();
        }

        protected void CloseWindow()
        {
            Close();
            GUIUtility.ExitGUI();
        }

        protected static void SetToggleCollection(
            ref Dictionary<Type, bool> toggles,
            IEnumerable<Type> types)
        {
            if (toggles == null)
            {
                toggles = new Dictionary<Type, bool>();
            }

            foreach (var type in types)
            {
                if (!toggles.ContainsKey(type))
                {
                    toggles.Add(type, false);
                }
            }
        }

        protected static void SetToggleCollection(ref bool[] toggles, int size)
        {
            if (toggles == null)
            {
                toggles = new bool[size];
            }
            else if (size != toggles.Length)
            {
                Array.Resize(ref toggles, size);
            }
        }
    }
}
