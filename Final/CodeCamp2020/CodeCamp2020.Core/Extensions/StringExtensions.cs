using System;

namespace CodeCamp2020.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
}
