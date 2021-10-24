﻿using System;

namespace Appalachia.Editing.Debugging.IngameDebugConsole
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ConsoleMethodAttribute : Attribute
    {
        public ConsoleMethodAttribute(string command, string description, params string[] parameterNames)
        {
            m_command = command;
            m_description = description;
            m_parameterNames = parameterNames;
        }

        private readonly string m_command;
        private readonly string m_description;
        private readonly string[] m_parameterNames;

        public string Command => m_command;
        public string Description => m_description;
        public string[] ParameterNames => m_parameterNames;
    }
}
