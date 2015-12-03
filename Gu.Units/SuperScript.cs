namespace Gu.Units
{
    using System;

    public static class SuperScript
    {
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        internal const string SuperscriptDigits = "⁰¹²³⁴⁵⁶⁷⁸⁹";

        public static readonly char Plus = '⁺';
        public static readonly char Minus = '⁻';

        public static char GetChar(int i)
        {
            Ensure.GreaterThanOrEqual(i, 0, nameof(i));
            Ensure.LessThanOrEqual(i, 9, nameof(i));
            return GetCharUnchecked(i);
        }

        public static int GetDigit(char c)
        {
            try
            {
                return SuperscriptDigits.IndexOf(c);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"{c} is not a superscript digit", e);
            }
        }

        internal static char GetCharUnchecked(int i)
        {
            return SuperscriptDigits[i];
        }
    }
}
