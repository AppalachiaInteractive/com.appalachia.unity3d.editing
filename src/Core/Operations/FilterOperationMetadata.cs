using System;
using System.Collections.Generic;

namespace Appalachia.Editing.Core.Operations
{
    [Serializable]
    public class FilterOperationMetadata : OperationMetadata<FilterOperation, bool>
    {
        public FilterOperationMetadata()
        {
        }

        public FilterOperationMetadata(FilterOperation operation) : base(operation)
        {
        }

        /// <inheritdoc />
        public override bool ApplyOperation(string input)
        {
            switch (operation)
            {
                case FilterOperation.Contains:
                    return input.Contains(
                        Arguments[0].StringArgument,
                        Arguments[1].BooleanArgument
                            ? StringComparison.InvariantCulture
                            : StringComparison.InvariantCultureIgnoreCase
                    );

                case FilterOperation.StartsWith:
                    return input.StartsWith(
                        Arguments[0].StringArgument,
                        Arguments[1].BooleanArgument
                            ? StringComparison.InvariantCulture
                            : StringComparison.InvariantCultureIgnoreCase
                    );

                case FilterOperation.EndsWith:
                    return input.EndsWith(
                        Arguments[0].StringArgument,
                        Arguments[1].BooleanArgument
                            ? StringComparison.InvariantCulture
                            : StringComparison.InvariantCultureIgnoreCase
                    );
            }

            return false;
        }

        /// <inheritdoc />
        protected override IEnumerable<OperationArgument> SetupOperation()
        {
            switch (operation)
            {
                case FilterOperation.Contains:
                    return new[]
                    {
                        new OperationArgument("Value",          ".png"),
                        new OperationArgument("Case Sensitive", true)
                    };

                case FilterOperation.StartsWith:
                    return new[]
                    {
                        new OperationArgument("Value",          ".png"),
                        new OperationArgument("Case Sensitive", true)
                    };

                case FilterOperation.EndsWith:
                    return new[]
                    {
                        new OperationArgument("Value",          ".png"),
                        new OperationArgument("Case Sensitive", true)
                    };
            }

            return null;
        }
    }
}
