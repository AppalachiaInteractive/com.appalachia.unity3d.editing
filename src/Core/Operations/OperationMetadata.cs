using System;
using System.Collections.Generic;
using Appalachia.Core.Attributes.Editing;
using Sirenix.OdinInspector;

namespace Appalachia.Editing.Core.Operations
{
    [HideReferenceObjectPicker]
    [Serializable]
    public abstract class OperationMetadata<TI, TO>
        where TI : struct
    {
        protected OperationMetadata()
        {
            operation = default;
            Arguments = new List<OperationArgument>();
            SetupOperationBase();
        }

        protected OperationMetadata(TI operation)
        {
            this.operation = operation;
            Arguments = new List<OperationArgument>();
            SetupOperationBase();
        }

        #region Fields and Autoproperties

        [SmartLabel]
        [InlineProperty]
        [ListDrawerSettings(
            HideAddButton = true,
            HideRemoveButton = true,
            DraggableItems = false,
            Expanded = true
        )]
        public List<OperationArgument> Arguments;

        [OnValueChanged(nameof(SetupOperationBase))]
        [SmartLabel]
        [PropertyOrder(-1)]
        public TI operation;

        #endregion

        public abstract TO ApplyOperation(string input);

        protected abstract IEnumerable<OperationArgument> SetupOperation();

        private void SetupOperationBase()
        {
            if (Arguments == null)
            {
                Arguments = new List<OperationArgument>();
            }

            Arguments.Clear();

            var arguments = SetupOperation();

            if ((arguments == null) || arguments.Equals(default))
            {
                return;
            }

            foreach (var arg in arguments)
            {
                Arguments.Add(arg);
            }
        }
    }
}
