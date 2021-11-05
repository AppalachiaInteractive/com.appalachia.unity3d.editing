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
        private double _lastRepaintTime;
        private double _progressStartTime;
        private string _lastMessageContent;

        protected override GUIStyle DefaultStyle => EditorStyles.label;

        public void Draw(double value, string text, params GUILayoutOption[] options)
        {
            hasBeenDrawn = true;

            var p = GUILayoutUtility.GetRect(content, style, options);

            if (text == null)
            {
                text = value.ToString("N3");
            }

            EditorGUI.ProgressBar(p, (float) value, text);
            APPAGUI.SPACE.SIZE.ProgressBarFooter.MAKE();
        }

        public void Draw(double value, string text = null)
        {
            hasBeenDrawn = true;
            Draw(value, text, GUILayout.ExpandWidth(true));
        }

        public void Draw(float width, double value, string text = null)
        {
            hasBeenDrawn = true;
            Draw(value, text, GUILayout.Width(width));
        }

        public void DrawDynamic(string verb, Func<AppaProgress> progressGetter, IAppalachiaWindow window)
        {
            if (_progressStartTime == 0f)
            {
                _progressStartTime = Time.realtimeSinceStartupAsDouble;
            }

            var elapsedTime = Time.realtimeSinceStartup - _progressStartTime;

            var loopTime = 4f;

            var progressPercentage = (elapsedTime % loopTime) / (.5f * loopTime);

            if (progressPercentage > 1f)
            {
                var part = progressPercentage % 1f;

                progressPercentage = 1f - part;
            }

            progressPercentage = Math.Max(0f, Math.Min(.999f, progressPercentage));

            var defaultMessage = $"{verb}: {elapsedTime:N3}";
            string messageContent = null;

            var progressMessage = progressGetter();

            if (progressMessage != default)
            {
                messageContent = progressMessage.message;

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
                else
                {
                    progressMessage.progress = 0f;
                }
            }

            if (string.IsNullOrWhiteSpace(messageContent))
            {
                messageContent = _lastMessageContent;
            }

            var forceRepaint = ShouldForceRepaint(messageContent);

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

        public void DrawInContext<TC>(TC context, IAppalachiaWindow window)
            where TC : AppaMenuContext
        {
            if (!context.NeedsProgressDraw)
            {
                Draw(0);
                return;
            }

            DrawDynamic(context.ProgressVerb, context.GetProgress, window);
        }

        public void Reset()
        {
            _progressStartTime = 0f;
            _lastMessageContent = null;
        }

        public void ResetTime()
        {
            _progressStartTime = 0f;
        }

        private bool ShouldForceRepaint(string messageContent)
        {
            var elapsedSinceRepaint = Time.realtimeSinceStartup - _lastRepaintTime;

            var forceRepaint = _lastMessageContent != messageContent;

            forceRepaint |= elapsedSinceRepaint > 1f;

            _lastMessageContent = messageContent;

            if (forceRepaint)
            {
                _lastRepaintTime = Time.realtimeSinceStartupAsDouble;
            }

            return forceRepaint;
        }
    }
}
