using System;

namespace Appalachia.Editing.Debugging.IngameDebugConsole
{
    [Flags]
    public enum DebugLogFilter
    {
        None = 0,
        Info = 1,
        Warning = 2,
        Error = 4,
        All = 7
    }
}
