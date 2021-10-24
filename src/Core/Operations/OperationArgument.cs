using Sirenix.OdinInspector;

namespace Appalachia.Editing.Core.Operations
{
    [HideReferenceObjectPicker]
    public sealed class OperationArgument
    {
        public OperationArgument(string description, char argument)
        {
            Description = description;
            showCharArgument = true;
            CharArgument = argument;
        }

        public OperationArgument(string description, char[] argument)
        {
            Description = description;
            showCharArrayArgument = true;
            CharArrayArgument = argument;
        }

        public OperationArgument(string description, string argument)
        {
            Description = description;
            showStringArgument = true;
            StringArgument = argument;
        }

        public OperationArgument(string description, bool argument)
        {
            Description = description;
            showBooleanArgument = true;
            BooleanArgument = argument;
        }

        public OperationArgument(string description, int argument)
        {
            Description = description;
            showIntArgument = true;
            IntArgument = argument;
        }

        [ShowIf(nameof(showBooleanArgument))]
        [HideLabel]
        [HorizontalGroup]
        public bool BooleanArgument;

        [ShowIf(nameof(showCharArgument))]
        [HideLabel]
        [HorizontalGroup]
        public char CharArgument;

        [ShowIf(nameof(showCharArrayArgument))]
        [InlineProperty]
        [HideLabel]
        [HorizontalGroup]
        public char[] CharArrayArgument;

        [ShowIf(nameof(showIntArgument))]
        [HideLabel]
        [HorizontalGroup]
        public int IntArgument;

        [ReadOnly]
        [HideLabel]
        [HorizontalGroup]
        public string Description;

        [ShowIf(nameof(showStringArgument))]
        [HideLabel]
        [HorizontalGroup]
        public string StringArgument;

#pragma warning disable CS0414

        private bool showCharArgument;
        private bool showCharArrayArgument;
        private bool showStringArgument;
        private bool showBooleanArgument;
        private bool showIntArgument;

#pragma warning restore CS0414
    }
}
