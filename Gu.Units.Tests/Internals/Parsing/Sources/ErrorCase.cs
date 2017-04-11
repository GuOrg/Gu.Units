namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections.Generic;
    using System.Globalization;

    public static class ErrorCase
    {
        public static ErrorCase<T> Create<T>(string text, int start, T expected, string expectedMessage)
        {
            return new ErrorCase<T>(text, start, expected, start, expectedMessage);
        }

        public static ErrorCase<T> Create<T>(string text, int start, string expectedMessage)
        {
            return new ErrorCase<T>(text, start, default(T), start, expectedMessage);
        }

        public static ErrorCase<T> Create<T>(string text, int start)
        {
            return new ErrorCase<T>(text, start, default(T), start, null);
        }

        public static ErrorCase<T> Create<T>(string text, CultureInfo cultureInfo)
        {
            return new ErrorCase<T>(text, cultureInfo, 0, default(T), 0, null);
        }

        public static ErrorCase<T> Create<T>(string text, CultureInfo cultureInfo, string expectedMessage)
        {
            return new ErrorCase<T>(text, cultureInfo, 0, default(T), 0, expectedMessage);
        }

        public static ErrorCase<T> Create<T>(string text, CultureInfo cultureInfo, int start)
        {
            return new ErrorCase<T>(text, cultureInfo, start, default(T), start, null);
        }

        internal static ErrorCase<IReadOnlyList<SymbolAndPower>> CreateForSymbol(string text)
        {
            IReadOnlyList<SymbolAndPower> expected = new SymbolAndPower[0];
            return new ErrorCase<IReadOnlyList<SymbolAndPower>>(text, 0, expected, 0, null);
        }
    }
}