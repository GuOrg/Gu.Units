namespace Gu.Units.Tests.Internals.Parsing
{
    using System.Collections.Generic;
    using System.Globalization;

    public static class ErrorData
    {
        public static ErrorData<T> Create<T>(string text,
            int start,
            T expected,
            string expectedMessage)
        {
            return new ErrorData<T>(text, start, expected, start, expectedMessage);
        }

        public static ErrorData<T> Create<T>(string text,
            int start,
            string expectedMessage)
        {
            return new ErrorData<T>(text, start, default(T), start, expectedMessage);
        }

        public static ErrorData<T> Create<T>(string text, int start)
        {
            return new ErrorData<T>(text, start, default(T), start, null);
        }

        public static ErrorData<T> Create<T>(string text, CultureInfo cultureInfo)
        {
            return new ErrorData<T>(text, cultureInfo, 0, default(T), 0, null);
        }

        public static ErrorData<T> Create<T>(string text, CultureInfo cultureInfo, string expectedMessage)
        {
            return new ErrorData<T>(text, cultureInfo, 0, default(T), 0, expectedMessage);
        }

        public static ErrorData<T> Create<T>(string text, CultureInfo cultureInfo, int start)
        {
            return new ErrorData<T>(text, cultureInfo, start, default(T), start, null);
        }

        internal static ErrorData<IReadOnlyList<SymbolAndPower>> CreateForSymbol(string text)
        {
            IReadOnlyList<SymbolAndPower> expected = new SymbolAndPower[0];
            return new ErrorData<IReadOnlyList<SymbolAndPower>>(text, 0, expected, 0, null);
        }
    }
}