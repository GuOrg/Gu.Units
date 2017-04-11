namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class TestCase<T>
    {
        protected TestCase(string text, int start, T expected, int expectedEnd)
            : this(text, CultureInfo.InvariantCulture, start, expected, expectedEnd)
        {
        }

        protected TestCase(string text, CultureInfo cultureInfo, int start, T expected, int expectedEnd)
        {
            this.Text = text;
            this.CultureInfo = cultureInfo;
            this.Start = start;
            this.Expected = expected;
            this.ExpectedEnd = expectedEnd;
        }

        public string Text { get; }

        public CultureInfo CultureInfo { get; }

        public int Start { get; }

        public T Expected { get; }

        public Type Type => typeof(T);

        public int ExpectedEnd { get; }

        public override string ToString()
        {
            if (this.CultureInfo == null)
            {
                return $"Text: {this.Text}, Start: {this.Start}, Expected {ToString(typeof(T))}: {ToString(this.Expected)}, ExpectedEnd: {this.ExpectedEnd}";
            }

            return $"Text: {this.Text}, Culture: {this.CultureInfo.Name} Start: {this.Start}, Expected {ToString(typeof(T))}: {ToString(this.Expected)}, ExpectedEnd: {this.ExpectedEnd}";
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