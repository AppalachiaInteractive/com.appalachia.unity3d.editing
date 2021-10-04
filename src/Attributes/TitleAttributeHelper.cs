#region

using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

#endregion

namespace Appalachia.Editing.Attributes
{
    public static class TitleAttributeHelper
    {
        public static void Title(
            string title,
            string subtitle,
            TextAlignment textAlignment,
            bool horizontalLine,
            bool boldLabel = true,
            Color color = default)
        {
            GUIStyle guiStyle1;
            GUIStyle guiStyle2;
            switch (textAlignment)
            {
                case TextAlignment.Left:
                    guiStyle1 = boldLabel ? SirenixGUIStyles.BoldTitle : SirenixGUIStyles.Title;
                    guiStyle2 = SirenixGUIStyles.Subtitle;
                    break;
                case TextAlignment.Center:
                    guiStyle1 = boldLabel ? SirenixGUIStyles.BoldTitleCentered : SirenixGUIStyles.TitleCentered;
                    guiStyle2 = SirenixGUIStyles.SubtitleCentered;
                    break;
                case TextAlignment.Right:
                    guiStyle1 = boldLabel ? SirenixGUIStyles.BoldTitleRight : SirenixGUIStyles.TitleRight;
                    guiStyle2 = SirenixGUIStyles.SubtitleRight;
                    break;
                default:
                    guiStyle1 = boldLabel ? SirenixGUIStyles.BoldTitle : SirenixGUIStyles.Title;
                    guiStyle2 = SirenixGUIStyles.SubtitleRight;
                    break;
            }

            var style3 = new GUIStyle(guiStyle1);
            var style4 = new GUIStyle(guiStyle2);

            if (color != default)
            {
                style3.normal.textColor = color;
                style4.normal.textColor = color;
            }

            if ((int) textAlignment > 2)
            {
                var rect = GUILayoutUtility.GetRect(0.0f, 18f, style3, GUILayoutOptions.ExpandWidth());

                GUI.Label(rect, title, style3);

                rect.y += 3;

                GUI.Label(rect, subtitle, style4);

                if (!horizontalLine)
                {
                    return;
                }

                SirenixEditorGUI.HorizontalLineSeparator(SirenixGUIStyles.LightBorderColor);

                GUILayout.Space(1f);
            }
            else
            {
                var rect = EditorGUI.IndentedRect(EditorGUILayout.GetControlRect(false));
                GUI.Label(rect, title, style3);
                if ((subtitle != null) && !subtitle.IsNullOrWhitespace())
                {
                    rect = EditorGUI.IndentedRect(GUILayoutUtility.GetRect(GUIHelper.TempContent(subtitle), style4));
                    GUI.Label(rect, subtitle, style4);
                }

                if (!horizontalLine)
                {
                    return;
                }

                SirenixEditorGUI.DrawSolidRect(rect.AlignBottom(1f), SirenixGUIStyles.LightBorderColor);
                GUILayout.Space(1f);
            }
        }
    }
}
