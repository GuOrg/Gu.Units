namespace Gu.Units.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using NUnit.Framework;

    public class DoubleParserTests
    {
        private static readonly string[] Formats = { "abc{0}def", "abcd{0}ef" };

        [TestCaseSource(typeof(DoubleParseHappyPathSource))]
        public void Parse(DoubleParseData data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            var s = data.Text;
            foreach (var format in Formats)
            {
                var ns = string.Format(format, s);
                var start = format.IndexOf('{');
                int end;
                double expected = double.Parse(s, style, culture);
                var actual = DoubleParser.Parse(ns, start, style, culture, out end);
                Assert.AreEqual(expected, actual);
                var expectedEnd = start + s.Length;
                Assert.AreEqual(expectedEnd, end);
            }
        }

        [TestCaseSource(typeof(DoubleParseErrorSource))]
        public void ParseError(DoubleParseData data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            var s = data.Text;
            foreach (var format in Formats)
            {
                var ns = string.Format(format, s);
                var start = format.IndexOf('{');
                int end = -1;
                Assert.Throws<FormatException>(() => double.Parse(s, style, culture));
                Assert.Throws<FormatException>(() => DoubleParser.Parse(ns, start, style, culture, out end));
                //Assert.AreEqual(start, end);
            }
        }

        [TestCaseSource(typeof(DoubleParseHappyPathSource))]
        public void TryParse(DoubleParseData data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            var s = data.Text;
            foreach (var format in Formats)
            {
                var ns = string.Format(format, s);
                var start = format.IndexOf('{');
                int end;
                double expected;
                Assert.IsTrue(double.TryParse(s, style, culture, out expected));
                double actual;
                Assert.IsTrue(DoubleParser.TryParse(ns, start, style, culture, out actual, out end));
                Assert.AreEqual(expected, actual);
                var expectedEnd = start + s.Length;
                Assert.AreEqual(expectedEnd, end);
            }
        }

        [TestCaseSource(typeof(DoubleParseErrorSource))]
        public void TryParseError(DoubleParseData data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            var s = data.Text;
            foreach (var format in Formats)
            {
                var ns = string.Format(format, s);
                var start = format.IndexOf('{');
                int end;
                double expected;
                Assert.IsFalse(double.TryParse(s, style, culture, out expected));
                double actual;
                Assert.IsFalse(DoubleParser.TryParse(ns, start, style, culture, out actual, out end));
                Assert.AreEqual(expected, actual);
                //Assert.AreEqual(start, end);
            }
        }

        public class DoubleParseHappyPathSource : List<DoubleParseData>
        {
            public DoubleParseHappyPathSource()
            {
                var en = CultureInfo.GetCultureInfo("en-US");
                var sv = CultureInfo.GetCultureInfo("sv-SE");
                Add("1", NumberStyles.Float, en);
                Add(" 1", NumberStyles.Float, en);
                Add("-1", NumberStyles.Float, en);
                Add("+1", NumberStyles.Float, en);
                Add(".1", NumberStyles.Float, en);
                Add("1.", NumberStyles.Float, en);
                Add("+1.2", NumberStyles.Float, en);
                Add("+1,2", NumberStyles.Float, sv);
                Add("+1.2e3", NumberStyles.Float, en);
                Add("+1.2E3", NumberStyles.Float, en);
                Add("+1.2e-3", NumberStyles.Float, en);           
                Add("+1.2E-3", NumberStyles.Float, en);
                Add("+1.2e+3", NumberStyles.Float, en);
                Add(sv.NumberFormat.NaNSymbol, NumberStyles.Float, sv);
                Add(sv.NumberFormat.PositiveInfinitySymbol, NumberStyles.Float, sv);
                Add(sv.NumberFormat.NegativeInfinitySymbol, NumberStyles.Float, sv);
            }

            public void Add(string text, NumberStyles styles, CultureInfo culture)
            {
                Add(new DoubleParseData(text, styles, culture));
            }
        }

        public class DoubleParseErrorSource : List<DoubleParseData>
        {
            public DoubleParseErrorSource()
            {
                var en = CultureInfo.GetCultureInfo("en-US");
                var sv = CultureInfo.GetCultureInfo("sv-SE");
                Add("e1", NumberStyles.Float, en);
                Add(" 1", NumberStyles.None, en);
                Add("-1", NumberStyles.None, en);
                Add(".1", NumberStyles.None, en);
                //Add("1.", NumberStyles.Float | NumberStyles.AllowHexSpecifier, en);
                Add(".", NumberStyles.Float, en);
                //Add("+1,2", NumberStyles.Float, en);
                //Add("+1.2", NumberStyles.Float, sv);
                Add("+1.2e3", NumberStyles.None|NumberStyles.AllowDecimalPoint|NumberStyles.AllowLeadingSign, en);
            }

            public void Add(string text, NumberStyles styles, CultureInfo culture)
            {
                Add(new DoubleParseData(text, styles, culture));
            }
        }

        public class DoubleParseData
        {
            public readonly string Text;
            public readonly NumberStyles Styles;
            public readonly CultureInfo Culture;

            public DoubleParseData(string text, NumberStyles styles, CultureInfo culture)
            {
                Text = text;
                Styles = styles;
                Culture = culture;
            }

            public override string ToString()
            {
                return string.Format("Text: {0}, Styles: {1}, Culture: {2}", Text, Styles, Culture);
            }
        }
    }
}
