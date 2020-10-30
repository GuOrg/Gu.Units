namespace Gu.Units
{
    using System;

    /// <summary>
    /// Helper class for working with superscript numbers.
    /// </summary>
    public static class SuperScript
    {
        /// <summary>
        /// The superscript plus.
        /// </summary>
        public static readonly char Plus = '⁺';

        /// <summary>
        /// The superscript minus.
        /// </summary>
        public static readonly char Minus = '⁻';

        //// ReSharper disable UnusedMember.Local
        internal const string SuperscriptDigits = "⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        //// ReSharper restore UnusedMember.Local

        /// <summary>
        /// Gest the superscript for a number.
        /// </summary>
        /// <param name="i">A value between -9 and +9.</param>
        /// <returns>The superscript char for <paramref name="i"/>.</returns>
        public static char GetChar(int i)
        {
            Ensure.GreaterThanOrEqual(i, 0, nameof(i));
            Ensure.LessThanOrEqual(i, 9, nameof(i));
            return GetCharUnchecked(i);
        }

        /// <summary>
        /// Gest the superscript for a number.
        /// </summary>
        /// <param name="i">A value between -9 and +9.</param>
        /// <returns>The superscript for <paramref name="i"/>.</returns>
        public static string GetString(int i)
        {
            Ensure.GreaterThanOrEqual(i, -9, nameof(i));
            Ensure.LessThanOrEqual(i, 9, nameof(i));
            if (i < 0)
            {
                return $"{Minus}{GetCharUnchecked(i)}";
            }

            return $"{GetCharUnchecked(i)}";
        }

        /// <summary>
        /// Gets the integer value for a superscript char.
        /// </summary>
        /// <param name="c">A value in the range {⁰¹²³⁴⁵⁶⁷⁸⁹}.</param>
        /// <returns>The integer value for <paramref name="c"/>.</returns>
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
