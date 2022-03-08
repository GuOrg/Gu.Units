namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections.Generic;
    using System.Globalization;

    public static class SuccessCase
    {
        public static SuccessCase<T> Create<T>(string text, int start, T expected, int expectedEnd)
        {
            return new SuccessCase<T>(text, start, expected, expectedEnd);
        }

        public static SuccessCase<T> Create<T>(string text, T expected)
        {
            return new SuccessCase<T>(text, CultureInfo.InvariantCulture, 0, expected, text.Length);
        }

        public static SuccessCase<T> Create<T>(string text, CultureInfo cultureInfo, T expected)
        {
            return new SuccessCase<T>(text, cultureInfo, 0, expected, text.Length);
        }

        public static SuccessCase<T> Create<T>(string text, CultureInfo cultureInfo, int start, T expected, int expectedEnd)
        {
            return new SuccessCase<T>(text, cultureInfo, start, expected, expectedEnd);
        }

        internal static SuccessCase<IReadOnlyList<SymbolAndPower>> Create(string text, params SymbolAndPower[] expected)
        {
            return new SuccessCase<IReadOnlyList<SymbolAndPower>>(text, 0, expected, text.Length);
        }
    }
}
