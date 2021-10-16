﻿using UnityEngine;
using UnityEngine.Scripting;

namespace Appalachia.Editing.Debugging.IngameDebugConsole.Commands
{
    public class TimeCommands
    {
        [ConsoleMethod("time.scale", "Returns the current Time.timeScale value")]
        [Preserve]
        public static float GetTimeScale()
        {
            return Time.timeScale;
        }

        [ConsoleMethod("time.scale", "Sets the Time.timeScale value")]
        [Preserve]
        public static void SetTimeScale(float value)
        {
            Time.timeScale = Mathf.Max(value, 0f);
        }
    }
}
