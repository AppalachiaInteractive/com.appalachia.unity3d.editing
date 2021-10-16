using System;
using UnityEngine;

namespace Appalachia.Editing.Debugging.IngameDebugConsole
{
    public struct QueuedDebugLogEntry
    {
        public readonly string logString;
        public readonly string stackTrace;
        public readonly LogType logType;

        public QueuedDebugLogEntry(string logString, string stackTrace, LogType logType)
        {
            this.logString = logString;
            this.stackTrace = stackTrace;
            this.logType = logType;
        }

        // Checks if logString or stackTrace contains the search term
        public bool MatchesSearchTerm(string searchTerm)
        {
            return ((logString != null) &&
                    (logString.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)) ||
                   ((stackTrace != null) &&
                    (stackTrace.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0));
        }
    }
}
