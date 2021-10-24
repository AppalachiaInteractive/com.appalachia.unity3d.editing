using System;
using System.Collections.Generic;
using Appalachia.CI.Integration.Assets;
using Appalachia.Editing.Core.Windows.ProjectWindow.Details;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Appalachia.Editing.Core.Windows.ProjectWindow
{
    /// <summary>
    ///     This class draws additional columns into the project window.
    /// </summary>
    [InitializeOnLoad]
    public static class ProjectWindowDetails
    {
#region Profiling And Tracing Markers

        private const string _PRF_PFX = nameof(ProjectWindowDetails) + ".";

        private static GUIStyle _rightAlignedStyle;
        private static List<ProjectWindowDetailBase> _details = new();
        private static readonly ProfilerMarker _PRF_RegisterDetail = new(_PRF_PFX + nameof(RegisterDetail));

        private static readonly ProfilerMarker _PRF_DrawAssetDetails =
            new(_PRF_PFX + nameof(DrawAssetDetails));

        private static readonly ProfilerMarker _PRF_DrawMenuIcon = new(_PRF_PFX + nameof(DrawMenuIcon));

#endregion

        private const int MenuIconWidth = 20;
        private const int SpaceBetweenColumns = 10;

        private static GUIStyle RightAlignedStyle
        {
            get
            {
                if (_rightAlignedStyle == null)
                {
                    _rightAlignedStyle = new GUIStyle(EditorStyles.label);
                    _rightAlignedStyle.alignment = TextAnchor.MiddleRight;
                }

                return _rightAlignedStyle;
            }
        }

        [MenuItem("Appalachia/Tools/Appalachia.Editing.Core/Project Window Details")]
        public static void Menu()
        {
            //Event.current.Use();
            ShowContextMenu();
        }

        public static void RegisterDetail<T>(T instance)
            where T : ProjectWindowDetailBase
        {
            using (_PRF_RegisterDetail.Auto())
            {
                if (_details == null)
                {
                    _details = new List<ProjectWindowDetailBase>();
                }

                _details.Add(instance);
            }
        }

        public static void ToggleMenu(object data)
        {
            var detail = (ProjectWindowDetailBase) data;
            detail.Visible = !detail.Visible;
        }

        private static void DrawAssetDetails(string guid, Rect rect)
        {
            using (_PRF_DrawAssetDetails.Auto())
            {
                if (Application.isPlaying)
                {
                    return;
                }

                if (!IsMainListAsset(rect))
                {
                    return;
                }

                if ((Event.current.type == EventType.MouseDown) &&
                    (Event.current.button == 0) &&
                    (Event.current.mousePosition.x > (rect.xMax - MenuIconWidth)))
                {
                    Event.current.Use();
                    ShowContextMenu();
                }

                if (Event.current.type != EventType.Repaint)
                {
                    return;
                }

                var isSelected = Array.IndexOf(Selection.assetGUIDs, guid) >= 0;

                // Right align label and leave some space for the menu icon:
                rect.x += rect.width;
                rect.x -= MenuIconWidth;
                rect.width = MenuIconWidth;

                if (isSelected)
                {
                    DrawMenuIcon(rect);
                }

                var assetPath = AssetDatabaseManager.GUIDToAssetPath(guid);
                if (AssetDatabaseManager.IsValidFolder(assetPath))
                {
                    return;
                }

                var asset = AssetDatabaseManager.LoadAssetAtPath<Object>(assetPath);
                if (asset == null)
                {
                    // this entry could be Favourites or Packages. Ignore it.
                    return;
                }

                for (var i = _details.Count - 1; i >= 0; i--)
                {
                    var detail = _details[i];
                    if (!detail.Visible)
                    {
                        continue;
                    }

                    rect.width = detail.ColumnWidth;
                    rect.x -= detail.ColumnWidth + SpaceBetweenColumns;
                    GUI.Label(
                        rect,
                        new GUIContent(detail.GetLabel(guid, assetPath, asset), detail.Name),
                        GetStyle(detail.Alignment)
                    );
                }
            }
        }

        private static void DrawMenuIcon(Rect rect)
        {
            using (_PRF_DrawMenuIcon.Auto())
            {
                rect.y += 4;
                var icon = EditorGUIUtility.IconContent("_menu");
                EditorGUI.LabelField(rect, icon);
            }
        }

        private static GUIStyle GetStyle(TextAlignment alignment)
        {
            return alignment == TextAlignment.Left ? EditorStyles.label : RightAlignedStyle;
        }

        private static void HideAllDetails()
        {
            foreach (var detail in _details)
            {
                detail.Visible = false;
            }
        }

        private static bool IsMainListAsset(Rect rect)
        {
            // Don't draw details if project view shows large preview icons:
            if (rect.height > 20)
            {
                return false;
            }

            // Don't draw details if this asset is a sub asset:
            if (rect.x > 16)
            {
                return false;
            }

            return true;
        }

        private static void ShowContextMenu()
        {
            var menu = new GenericMenu();
            foreach (var detail in _details)
            {
                menu.AddItem(new GUIContent(detail.Name), detail.Visible, ToggleMenu, detail);
            }

            menu.AddSeparator("");
            menu.AddItem(new GUIContent("None"), false, HideAllDetails);
            menu.DropDown(new Rect(Vector2.zero, Vector2.zero));
        }
    }
}
