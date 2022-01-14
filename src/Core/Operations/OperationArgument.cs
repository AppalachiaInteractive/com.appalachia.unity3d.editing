using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Appalachia.Editing.Core.Operations
{
    [HideReferenceObjectPicker]
    [Serializable]
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

        #region Fields and Autoproperties

        [ShowIf(nameof(showBooleanArgument))]
        [HorizontalGroup]
        [LabelText("$Description")]
        public bool BooleanArgument;

        [ShowIf(nameof(showCharArgument))]
        [HorizontalGroup]
        [LabelText("$Description")]
        public char CharArgument;

        [ShowIf(nameof(showCharArrayArgument))]
        [InlineProperty]
        [HorizontalGroup]
        [LabelText("$Description")]
        public char[] CharArrayArgument;

        [ShowIf(nameof(showIntArgument))]
        [HorizontalGroup]
        [LabelText("$Description")]
        public int IntArgument;

        [HideInInspector] public string Description;

        [ShowIf(nameof(showStringArgument))]
        [HideLabel]
        [HorizontalGroup]
        [LabelText("$Description")]
        public string StringArgument;

        #endregion

#pragma warning disable CS0414

        [SerializeField, HideInInspector]
        private bool showCharArgument;

        [SerializeField, HideInInspector]
        private bool showCharArrayArgument;

        [SerializeField, HideInInspector]
        private bool showStringArgument;

        [SerializeField, HideInInspector]
        private bool showBooleanArgument;

        [SerializeField, HideInInspector]
        private bool showIntArgument;

#pragma warning restore CS0414
    }
}
