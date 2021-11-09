﻿using System;
using System.Diagnostics;
using UnityEngine;

// Container for a simple debug entry
namespace Appalachia.Editing.Debugging.IngameDebugConsole
{
    public class DebugLogEntry : IEquatable<DebugLogEntry>
    {
        private const int HASH_NOT_CALCULATED = -623218;

        // Collapsed count
        public int count;

        public Sprite logTypeSpriteRepresentation;

        public string logString;
        public string stackTrace;

        private int hashValue;

        private string completeLog;

        public void Initialize(string logString, string st)
        {
            this.logString = logString;
            stackTrace = st;

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
        [DebuggerStepThrough] public bool Equals(DebugLogEntry other)
        {
            return (other != null) && (logString == other.logString) && (stackTrace == other.stackTrace);
        }

        [DebuggerStepThrough] public override int GetHashCode()
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

        [DebuggerStepThrough] public override string ToString()
        {
            if (completeLog == null)
            {
                completeLog = string.Concat(logString, "\n", stackTrace);
            }

            return completeLog;
        }
    }
}
