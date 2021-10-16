using System;
using System.Reflection;

namespace Appalachia.Editing.Debugging.IngameDebugConsole
{
    public class ConsoleMethodInfo
    {
        public readonly string command;
        public readonly object instance;
        public readonly MethodInfo method;
        public readonly string[] parameters;
        public readonly Type[] parameterTypes;
        public readonly string signature;

        public ConsoleMethodInfo(
            MethodInfo method,
            Type[] parameterTypes,
            object instance,
            string command,
            string signature,
            string[] parameters)
        {
            this.method = method;
            this.parameterTypes = parameterTypes;
            this.instance = instance;
            this.command = command;
            this.signature = signature;
            this.parameters = parameters;
        }

        public bool IsValid()
        {
            if (!method.IsStatic && ((instance == null) || instance.Equals(null)))
            {
                return false;
            }

            return true;
        }
    }
}
