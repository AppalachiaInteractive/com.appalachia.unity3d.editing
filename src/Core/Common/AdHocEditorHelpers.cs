using System.Text;

namespace Appalachia.Editing.Core.Common
{
    public static class AdHocEditorHelpers
    {
        public static int LongestCommonSubstring(string str1, string str2, out string sequence)
        {
            sequence = string.Empty;
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return 0;
            }

            var num = new int[str1.Length, str2.Length];
            var maxlen = 0;
            var lastSubsBegin = 0;
            var sequenceBuilder = new StringBuilder();

            for (var i = 0; i < str1.Length; i++)
            {
                for (var j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                    {
                        num[i, j] = 0;
                    }
                    else
                    {
                        if ((i == 0) || (j == 0))
                        {
                            num[i, j] = 1;
                        }
                        else
                        {
                            num[i, j] = 1 + num[i - 1, j - 1];
                        }

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                            var thisSubsBegin = (i - num[i, j]) + 1;
                            if (lastSubsBegin == thisSubsBegin)
                            {
                                //if the current LCS is the same as the last time this block ran
                                sequenceBuilder.Append(str1[i]);
                            }
                            else //this block resets the string builder if a different LCS is found
                            {
                                lastSubsBegin = thisSubsBegin;
                                sequenceBuilder.Length = 0; //clear it
                                sequenceBuilder.Append(
                                    str1.Substring(lastSubsBegin, (i + 1) - lastSubsBegin)
                                );
                            }
                        }
                    }
                }
            }

            sequence = sequenceBuilder.ToString();
            return maxlen;
        }

        public static string TrimUnderscores(string value)
        {
            if ((value == null) || (value.Length == 0))
            {
                return string.Empty;
            }

            return value.Trim('_').TrimEnd('_');
        }
    }
}
