namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections.Generic;
    using System.Globalization;

    public static class SuccessData
    {
        public static SuccessData<T> Create<T>(string text,
            int start,
            T expected,
            int expectedEnd)
        {
            return new SuccessData<T>(text, start, expected, expectedEnd);
        }

        public static SuccessData<T> Create<T>(string text, T expected)
        {
            return new SuccessData<T>(text, CultureInfo.InvariantCulture, 0, expected, text.Length);
        }

        public static SuccessData<T> Create<T>(string text, CultureInfo cultureInfo, T expected)
        {
            return new SuccessData<T>(text, cultureInfo, 0, expected, text.Length);
        }

        public static SuccessData<T> Create<T>(string text,
            CultureInfo cultureInfo,
            int start,
            T expected,
            int expectedEnd)
        {
            return new SuccessData<T>(text, cultureInfo, start, expected, expectedEnd);
        }

        internal static SuccessData<IReadOnlyList<SymbolAndPower>> Create(string text, params SymbolAndPower[] expected)
        {
            return new SuccessData<IReadOnlyList<SymbolAndPower>>(text, 0, expected, text.Length);
        }
    }
}