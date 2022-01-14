using System;
using System.Collections.Generic;
using Appalachia.CI.Integration.FileSystem;
using Appalachia.Utility.Extensions;
using Appalachia.Utility.Strings;

namespace Appalachia.Editing.Core.Operations
{
    [Serializable]
    public class StringOperationMetadata : OperationMetadata<StringOperation, string>
    {
        public StringOperationMetadata()
        {
        }

        public StringOperationMetadata(StringOperation operation) : base(operation)
        {
        }

        public override string ApplyOperation(string input)
        {
            switch (operation)
            {
                case StringOperation.PadLeft:
                    return input.PadLeft(Arguments[0].IntArgument, Arguments[1].CharArgument);

                case StringOperation.PadLeftSpaces:
                    return input.PadLeft(Arguments[0].IntArgument);

                case StringOperation.PadRight:
                    return input.PadRight(Arguments[0].IntArgument, Arguments[1].CharArgument);

                case StringOperation.PadRightSpaces:
                    return input.PadRight(Arguments[0].IntArgument);

                case StringOperation.RemoveAt:
                    return input.Remove(Arguments[0].IntArgument);

                case StringOperation.RemoveCharacters:
                    var removeCharactersResult = input;
                    foreach (var replacementCharacter in Arguments[0].CharArrayArgument)
                    {
                        removeCharactersResult =
                            removeCharactersResult.Replace(replacementCharacter, default);
                    }

                    return removeCharactersResult;

                case StringOperation.RemoveString:
                    if (string.IsNullOrEmpty(Arguments[0].StringArgument))
                    {
                        return input;
                    }

                    return input.Replace(Arguments[0].StringArgument, string.Empty);

                case StringOperation.ReplaceCharacters:
                    var replaceCharactersResult = input;
                    foreach (var replacementCharacter in Arguments[0].CharArrayArgument)
                    {
                        replaceCharactersResult = replaceCharactersResult.Replace(
                            replacementCharacter,
                            Arguments[1].CharArgument
                        );
                    }

                    return replaceCharactersResult;

                case StringOperation.ReplaceString:
                    if (string.IsNullOrEmpty(Arguments[0].StringArgument))
                    {
                        return input;
                    }

                    return input.Replace(Arguments[0].StringArgument, Arguments[1].StringArgument);

                case StringOperation.Split:
                case StringOperation.SplitAndTakeFirst:
                case StringOperation.SplitAndTakeLast:
                    var splits = input.Split(Arguments[0].CharArrayArgument);

                    if (operation == StringOperation.SplitAndTakeFirst)
                    {
                        return splits[0];
                    }

                    if (operation == StringOperation.SplitAndTakeLast)
                    {
                        return splits[splits.Length - 1];
                    }

                    return splits[Arguments[1].IntArgument];

                case StringOperation.Substring:
                    return input.Substring(Arguments[0].IntArgument, Arguments[1].IntArgument);

                case StringOperation.SubstringToEnd:
                    return input.Substring(Arguments[0].IntArgument);

                case StringOperation.ToLower:
                    return input.ToLowerInvariant();

                case StringOperation.ToUpper:
                    return input.ToUpperInvariant();

                case StringOperation.ToTitleCase:
                    return input.ToTitleCase();

                case StringOperation.Trim:
                    return input.Trim(Arguments[0].CharArrayArgument);

                case StringOperation.TrimStart:
                    return input.TrimStart(Arguments[0].CharArrayArgument);

                case StringOperation.TrimEnd:
                    return input.TrimEnd(Arguments[0].CharArrayArgument);

                case StringOperation.Append:
                    if (string.IsNullOrEmpty(Arguments[0].StringArgument))
                    {
                        return input;
                    }

                    return ZString.Format("{0}{1}", input, Arguments[0].StringArgument);

                case StringOperation.AppendFileName:
                    if (string.IsNullOrEmpty(Arguments[0].StringArgument))
                    {
                        return input;
                    }

                    var d = AppaPath.GetDirectoryName(input);
                    var n = AppaPath.GetFileNameWithoutExtension(input);
                    var e = AppaPath.GetExtension(input);

                    return ZString.Format("{0}{1}{2}{3}", d, n, Arguments[0].StringArgument, e);

                case StringOperation.Prepend:
                    if (string.IsNullOrEmpty(Arguments[0].StringArgument))
                    {
                        return input;
                    }

                    return ZString.Format("{0}{1}", Arguments[0].StringArgument, input);

                case StringOperation.Set:
                    if (string.IsNullOrEmpty(Arguments[0].StringArgument))
                    {
                        return input;
                    }

                    return ZString.Format("{0}", Arguments[0].StringArgument);
            }

            return input;
        }

        protected override IEnumerable<OperationArgument> SetupOperation()
        {
            switch (operation)
            {
                case StringOperation.PadLeft:
                    return new[]
                    {
                        new OperationArgument("Padding Amount",    4),
                        new OperationArgument("Padding Character", ' ')
                    };

                case StringOperation.PadLeftSpaces:
                    return new[] { new OperationArgument("Padding Amount", 4) };

                case StringOperation.PadRight:
                    return new[]
                    {
                        new OperationArgument("Padding Amount",    4),
                        new OperationArgument("Padding Character", ' ')
                    };

                case StringOperation.PadRightSpaces:
                    return new[] { new OperationArgument("Padding Amount", 4) };

                case StringOperation.RemoveAt:
                    return new[]
                    {
                        new OperationArgument("Start Index", 0), new OperationArgument("Count", 1)
                    };

                case StringOperation.RemoveCharacters:
                    return new[] { new OperationArgument("Remove Values", new[] { '-', '|' }) };

                case StringOperation.RemoveString:
                    return new[] { new OperationArgument("Remove Value", "abc") };

                case StringOperation.ReplaceCharacters:
                    return new[]
                    {
                        new OperationArgument("Old Values", new[] { '-', '|' }),
                        new OperationArgument("New Value",  '_')
                    };

                case StringOperation.ReplaceString:
                    return new[]
                    {
                        new OperationArgument("Old Value", "abc"),
                        new OperationArgument("New Value", "xyz")
                    };

                case StringOperation.Split:
                    return new[]
                    {
                        new OperationArgument("Split Characters",        new[] { '_' }),
                        new OperationArgument("Take Index (Zero Based)", 1)
                    };

                case StringOperation.SplitAndTakeFirst:
                    return new[] { new OperationArgument("Split Characters", new[] { '_' }) };

                case StringOperation.SplitAndTakeLast:
                    return new[] { new OperationArgument("Split Characters", new[] { '_' }) };

                case StringOperation.Substring:
                    return new[]
                    {
                        new OperationArgument("Start Index", 5), new OperationArgument("Length", 5)
                    };

                case StringOperation.SubstringToEnd:
                    return new[] { new OperationArgument("Start Index", 5) };

                case StringOperation.ToLower:
                    return null;

                case StringOperation.ToUpper:
                    return null;

                case StringOperation.ToTitleCase:
                    return null;

                case StringOperation.Trim:
                    return new[] { new OperationArgument("Trim Characters", new[] { ' ', '-', '_', '.' }) };

                case StringOperation.TrimStart:
                    return new[] { new OperationArgument("Trim Characters", new[] { ' ', '-', '_', '.' }) };

                case StringOperation.TrimEnd:
                    return new[] { new OperationArgument("Trim Characters", new[] { ' ', '-', '_', '.' }) };

                case StringOperation.Append:
                    return new[] { new OperationArgument("Append Value", "Value") };

                case StringOperation.AppendFileName:
                    return new[] { new OperationArgument("Append Value", "Value") };

                case StringOperation.Prepend:
                    return new[] { new OperationArgument("Prepend Value", "Value") };

                case StringOperation.Set:
                    return new[] { new OperationArgument("Set Value", "Value") };
            }

            return null;
        }
    }
}
