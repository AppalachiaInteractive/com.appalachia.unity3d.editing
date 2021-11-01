using System;
using Appalachia.Core.Context.Contexts;
using Appalachia.Core.Context.Elements.Progress;
using Appalachia.Editing.Core.Layout;
using Appalachia.Editing.Core.Windows;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Editing.Core.Fields
{
    [Serializable]
    public class ProgressBarMetadata : EditorUIFieldMetadata<ProgressBarMetadata>
    {
        private float _progressStartTime;
        private string _lastMessageContent;

        protected override GUIStyle DefaultStyle => EditorStyles.label;

        public void Draw(float value, string text, params GUILayoutOption[] options)
        {
            hasBeenDrawn = true;

            var p = GUILayoutUtility.GetRect(content, style, options);

            if (text == null)
            {
                text = value.ToString("N3");
            }

            EditorGUI.ProgressBar(p, value, text);
            APPAGUI.SPACE.SIZE.ProgressBarFooter.MAKE();
        }

        public void Draw(float value, string text = null)
        {
            hasBeenDrawn = true;
            Draw(value, text, GUILayout.ExpandWidth(true));
        }

        public void Draw(float width, float value, string text = null)
        {
            hasBeenDrawn = true;
            Draw(value, text, GUILayout.Width(width));
        }

        public void DrawInContext<TC>(TC context, IAppalachiaWindow window)
            where TC : AppaMenuContext
        {
            if (!context.NeedsProgressDraw)
            {
                Draw(0);
                return;
            }

            DrawDynamic(context.GetProgress, window);
        }

        public void DrawDynamic(
            Func<AppaProgress> progressGetter,
            IAppalachiaWindow window)
        {
            if (_progressStartTime == 0f)
            {
                _progressStartTime = Time.realtimeSinceStartup;
            }

            var elapsedTime = Time.realtimeSinceStartup - _progressStartTime;

            var loopTime = 2f;

            var progressPercentage = (elapsedTime % loopTime) / loopTime;

            progressPercentage = Math.Max(0f, Math.Min(.999f, progressPercentage));

            var defaultMessage = $"Initializing: {elapsedTime:N3}";
            string messageContent = null;

            var progressMessage = progressGetter();

            if (progressMessage != default)
            {
                messageContent = $"{progressMessage.message}...";

                if (progressMessage.progress > 0)
                {
                    if (progressMessage.progress > 1)
                    {
                        progressPercentage = progressMessage.progress * .01f;
                    }
                    else
                    {
                        progressPercentage = progressMessage.progress;
                    }
                }
            }

            var forceRepaint = false;

            if (_lastMessageContent != messageContent)
            {
                forceRepaint = true;
                _lastMessageContent = messageContent;
            }

            string message = null;

            if (messageContent != null)
            {
                message = $"{defaultMessage} | {messageContent}";
            }
            else
            {
                message = defaultMessage;
            }

            Draw(progressPercentage, message);

            window.SafeRepaint(forceRepaint);
        }

        public void Reset()
        {
            _progressStartTime = 0f;
            _lastMessageContent = null;
        }
    }
}
