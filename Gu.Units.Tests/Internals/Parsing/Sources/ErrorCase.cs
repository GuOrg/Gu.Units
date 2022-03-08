namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections.Generic;
    using System.Globalization;

    public static class ErrorCase
    {
#pragma warning disable CA1825 // Avoid zero-length array allocations
        private static readonly SymbolAndPower[] Empty = new SymbolAndPower[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations

        public static ErrorCase<T> Create<T>(string text, int start, T expected, string expectedMessage)
        {
            return new ErrorCase<T>(text, start, expected, start, expectedMessage);
        }

        public static ErrorCase<T> Create<T>(string text, int start, string expectedMessage)
        {
            return new ErrorCase<T>(text, start, default, start, expectedMessage);
        }

        public static ErrorCase<T> Create<T>(string text, int start)
        {
            return new ErrorCase<T>(text, start, default, start, null);
        }

        public static ErrorCase<T> Create<T>(string text, CultureInfo cultureInfo)
        {
            return new ErrorCase<T>(text, cultureInfo, 0, default, 0, null);
        }

        public static ErrorCase<T> Create<T>(string text, CultureInfo cultureInfo, string expectedMessage)
        {
            return new ErrorCase<T>(text, cultureInfo, 0, default, 0, expectedMessage);
        }

        public static ErrorCase<T> Create<T>(string text, CultureInfo cultureInfo, int start)
        {
            return new ErrorCase<T>(text, cultureInfo, start, default, start, null);
        }

        internal static ErrorCase<IReadOnlyList<SymbolAndPower>> CreateForSymbol(string text)
        {
            return new ErrorCase<IReadOnlyList<SymbolAndPower>>(text, 0, Empty, 0, null);
        }
    }
}
