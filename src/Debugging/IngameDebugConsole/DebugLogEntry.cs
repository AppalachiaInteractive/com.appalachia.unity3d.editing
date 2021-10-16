﻿using System;
using UnityEngine;

// Container for a simple debug entry
namespace Appalachia.Editing.Debugging.IngameDebugConsole
{
    public class DebugLogEntry : IEquatable<DebugLogEntry>
    {
        private const int HASH_NOT_CALCULATED = -623218;

        // Collapsed count
        public int count;

        public string logString;

        public Sprite logTypeSpriteRepresentation;
        public string stackTrace;

        private string completeLog;

        private int hashValue;

        public override int GetHashCode()
        {
            if (hashValue == HASH_NOT_CALCULATED)
            {
                unchecked
                {
                    hashValue = 17;
                    hashValue = (hashValue * 23) + (logString == null ? 0 : logString.GetHashCode());
                    hashValue = (hashValue * 23) + (stackTrace == null ? 0 : stackTrace.GetHashCode());
                }
            }

            return hashValue;
        }

        public override string ToString()
        {
            if (completeLog == null)
            {
                completeLog = string.Concat(logString, "\n", stackTrace);
            }

            return completeLog;
        }

        public void Initialize(string logString, string st)
        {
            this.logString = logString;
            this.stackTrace = st;

            completeLog = null;
            count = 1;
            hashValue = HASH_NOT_CALCULATED;
        }

        // Checks if logString or stackTrace contains the search term
        public bool MatchesSearchTerm(string searchTerm)
        {
            return ((logString != null) &&
                    (logString.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)) ||
                   ((stackTrace != null) &&
                    (stackTrace.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        // Check if two entries have the same origin
        public bool Equals(DebugLogEntry other)
        {
            return (other != null) && (logString == other.logString) && (stackTrace == other.stackTrace);
        }
    }
}
