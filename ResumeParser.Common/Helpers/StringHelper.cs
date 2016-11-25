using System;
using System.Text.RegularExpressions;

namespace ResumeParser.Common.Helpers
{
    public static class StringHelper
    {
        public static string RemoveLastSymbol(this string value)
        {
            return value.Remove(value.Length - 1);
        }

        public static string RemoveTags(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static string ReplaceHtmlQuotes(this string input)
        {
            return input.Replace("&quot;", "'");
        }
    }
}