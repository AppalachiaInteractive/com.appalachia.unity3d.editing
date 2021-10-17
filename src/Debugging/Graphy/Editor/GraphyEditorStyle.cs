﻿/* ---------------------------------------
 * Author:          Martin Pane (martintayx@gmail.com) (@tayx94)
 * Contributors:    https://github.com/Tayx94/graphy/graphs/contributors
 * Project:         Graphy - Ultimate Stats Monitor
 * Date:            02-Jan-18
 * Studio:          Tayx
 *
 * Git repo:        https://github.com/Tayx94/graphy
 *
 * This project is released under the MIT license.
 * Attribution is not required, but it is always welcomed!
 * -------------------------------------*/

using Appalachia.CI.Integration.Assets;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Debugging.Graphy
{
    internal static class GraphyEditorStyle
    {
#region Static Constructor

        static GraphyEditorStyle()
        {
            var managerLogoGuid = AssetDatabaseManager.FindAssets(
                $"Manager_Logo_{(EditorGUIUtility.isProSkin ? "White" : "Dark")}"
            )[0];
            var debuggerLogoGuid = AssetDatabaseManager.FindAssets(
                $"Debugger_Logo_{(EditorGUIUtility.isProSkin ? "White" : "Dark")}"
            )[0];
            var guiSkinGuid = AssetDatabaseManager.FindAssets("GraphyGUISkin")[0];

            _managerLogoTexture =
                AssetDatabaseManager.LoadAssetAtPath<Texture2D>(
                    AssetDatabaseManager.GUIDToAssetPath(managerLogoGuid)
                );

            _debuggerLogoTexture =
                AssetDatabaseManager.LoadAssetAtPath<Texture2D>(
                    AssetDatabaseManager.GUIDToAssetPath(debuggerLogoGuid)
                );

            m_skin = AssetDatabaseManager.LoadAssetAtPath<GUISkin>(
                AssetDatabaseManager.GUIDToAssetPath(guiSkinGuid)
            );

            if (m_skin != null)
            {
                m_headerStyle1 = m_skin.GetStyle("Header1");
                m_headerStyle2 = m_skin.GetStyle("Header2");

                SetGuiStyleFontColor(m_headerStyle2, EditorGUIUtility.isProSkin ? Color.white : Color.black);
            }
            else
            {
                m_headerStyle1 = EditorStyles.boldLabel;
                m_headerStyle2 = EditorStyles.boldLabel;
            }

            m_foldoutStyle = new GUIStyle(EditorStyles.foldout)
            {
                font = m_headerStyle2.font,
                fontStyle = m_headerStyle2.fontStyle,
                contentOffset = Vector2.down * 3f
            };

            SetGuiStyleFontColor(m_foldoutStyle, EditorGUIUtility.isProSkin ? Color.white : Color.black);
        }

#endregion

#region Methods -> Private

        private static void SetGuiStyleFontColor(GUIStyle guiStyle, Color color)
        {
            guiStyle.normal.textColor = color;
            guiStyle.hover.textColor = color;
            guiStyle.active.textColor = color;
            guiStyle.focused.textColor = color;
            guiStyle.onNormal.textColor = color;
            guiStyle.onHover.textColor = color;
            guiStyle.onActive.textColor = color;
            guiStyle.onFocused.textColor = color;
        }

#endregion

#region Variables -> Private

        private static readonly Texture2D _managerLogoTexture;
        private static readonly Texture2D _debuggerLogoTexture;
        private static readonly GUISkin m_skin;
        private static readonly GUIStyle m_headerStyle1;
        private static readonly GUIStyle m_headerStyle2;
        private static readonly GUIStyle m_foldoutStyle;
        private static string path;

#endregion

#region Properties -> Public

        public static Texture2D ManagerLogoTexture => _managerLogoTexture;
        public static Texture2D DebuggerLogoTexture => _debuggerLogoTexture;
        public static GUISkin Skin => m_skin;
        public static GUIStyle HeaderStyle1 => m_headerStyle1;
        public static GUIStyle HeaderStyle2 => m_headerStyle2;
        public static GUIStyle FoldoutStyle => m_foldoutStyle;

#endregion
    }
}