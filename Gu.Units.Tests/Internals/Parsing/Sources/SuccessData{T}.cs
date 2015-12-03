namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class SuccessData<T> : ISuccessData
    {
        public SuccessData(string text, int start, T expected, int expectedEnd)
            : this(text, CultureInfo.InvariantCulture, start, expected, expectedEnd)
        {
        }

        public SuccessData(string text,
            CultureInfo cultureInfo,
            int start,
            T expected,
            int expectedEnd)
        {
            Text = text;
            CultureInfo = cultureInfo;
            Start = start;
            Expected = expected;
            ExpectedEnd = expectedEnd;
        }

        public string Text { get; }

        public CultureInfo CultureInfo { get; }

        public int Start { get; }

        public T Expected { get; }

        public Type Type => typeof (T);

        object ISuccessData.Expected => Expected;

        public int ExpectedEnd { get; }

        public override string ToString()
        {
            if (CultureInfo == null)
            {
                return $"Text: {Text}, Start: {Start}, Expected {ToString(typeof(T))}: {ToString(Expected)}, ExpectedEnd: {ExpectedEnd}";
            }

            return $"Text: {Text}, Culture: {CultureInfo.Name} Start: {Start}, Expected {ToString(typeof(T))}: {ToString(Expected)}, ExpectedEnd: {ExpectedEnd}";
        }

        private static string ToString(Type type)
        {
            if (type == typeof(IReadOnlyList<SymbolAndPower>))
            {
                return string.Empty;
            }

            return $"({type.Name})";
        }

        private static string ToString(T expected)
        {
            if (expected == null)
            {
                return "null";
            }

            var saps = expected as IEnumerable<SymbolAndPower>;
            if (saps != null)
            {
                return $"{{{string.Join(", ", saps)}}}";
            }

            return expected.ToString();
        }
    }
}