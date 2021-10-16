using System;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class HelpBoxMetadata : LabelledFieldMetadataBase<HelpBoxMetadata>
    {
        private static GUIContent s_ErrorIcon;
        private static GUIContent s_InfoIcon;
        private static GUIContent s_WarningIcon;

        internal static Texture2D errorIcon
        {
            get
            {
                if (s_ErrorIcon == null)
                {
                    s_ErrorIcon = EditorGUIUtility.IconContent("console.erroricon");
                }

                return s_ErrorIcon.image as Texture2D;
            }
        }

        internal static Texture2D infoIcon
        {
            get
            {
                if (s_InfoIcon == null)
                {
                    s_InfoIcon = EditorGUIUtility.IconContent("console.infoicon");
                }

                return s_InfoIcon.image as Texture2D;
            }
        }

        internal static Texture2D warningIcon
        {
            get
            {
                if (s_WarningIcon == null)
                {
                    s_WarningIcon = EditorGUIUtility.IconContent("console.warnicon");
                }

                return s_WarningIcon.image as Texture2D;
            }
        }

        protected override GUIStyle DefaultStyle => EditorStyles.helpBox;

        public void Draw(MessageType messageType)
        {
            hasBeenDrawn = true;
            var c = content;
            c.image = GetHelpIcon(messageType);

            EditorGUILayout.HelpBox(c);
        }

        internal static Texture2D GetHelpIcon(MessageType type)
        {
            switch (type)
            {
                case MessageType.Info:
                    return infoIcon;
                case MessageType.Warning:
                    return warningIcon;
                case MessageType.Error:
                    return errorIcon;
                default:
                    return null;
            }
        }
    }
}
