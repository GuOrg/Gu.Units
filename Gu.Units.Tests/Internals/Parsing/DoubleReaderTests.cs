namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using NUnit.Framework;

    public class DoubleReaderTests
    {
        private static readonly string[] PadFormats = { "abc{0}def", "abcd{0}ef", "{0}" };
        private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo Sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly IReadOnlyList<TestCase> HappyPaths = new[]
        {
            CreateTestCase("0", NumberStyles.Float, En),
            CreateTestCase("0.", NumberStyles.Float, En),
            CreateTestCase(".0", NumberStyles.Float, En),
            CreateTestCase("0.0", NumberStyles.Float, En),
            CreateTestCase("1.2", NumberStyles.Float, En),
            CreateTestCase("0.012", NumberStyles.Float, En),
            CreateTestCase("0.0012", NumberStyles.Float, En),
            CreateTestCase("0.001", NumberStyles.Float, En),
            CreateTestCase("1", NumberStyles.Float, En),
            CreateTestCase(" 1", NumberStyles.Float, En),
            CreateTestCase("-1", NumberStyles.Float, En),
            CreateTestCase("+1", NumberStyles.Float, En),
            CreateTestCase(".1", NumberStyles.Float, En),
            CreateTestCase("-.1", NumberStyles.Float, En),
            CreateTestCase("1.", NumberStyles.Float, En),
            CreateTestCase("-1.", NumberStyles.Float, En),
            CreateTestCase("12,345.67", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("-12,345.67", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("+1.2", NumberStyles.Float, En),
            CreateTestCase("+1,2", NumberStyles.Float, Sv),
            CreateTestCase("+1.2e3", NumberStyles.Float, En),
            CreateTestCase("-1.2E3", NumberStyles.Float, En),
            CreateTestCase("+1.2e-3", NumberStyles.Float, En),
            CreateTestCase("+1.2E-3", NumberStyles.Float, En),
            CreateTestCase("-1.2e+3", NumberStyles.Float, En), //1,,2,3,4,5,,,.00
            CreateTestCase("1,,2,3,4,5,,,.00", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("12345678910123456789", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("1.2345678910123456789", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("1234567891012345678.9", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase(new string('1', 307), NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase(new string('1', 308), NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase(new string('1', 309), NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("0." + new string('0', 15) + "1", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("0." + new string('0', 16) + "1", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("0." + new string('0', 299) + "1", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase("0." + new string('0', 300) + "1", NumberStyles.Float | NumberStyles.AllowThousands, En),
            CreateTestCase(-12345.678910, NumberStyles.Float, En, "e"),
            CreateTestCase(12345.678910, NumberStyles.Float, En, "E"),
            CreateTestCase(12345.678910, NumberStyles.Float, En, "E5"),
            CreateTestCase(-12345.678910, NumberStyles.Float, En, "f"),
            CreateTestCase(12345.678910, NumberStyles.Float, En, "F"),
            CreateTestCase(12345.678912, NumberStyles.Float, En, "F20"),
            CreateTestCase(12345.678910, NumberStyles.Float, En, "G"),
            CreateTestCase(-12345.678910, NumberStyles.Float, En, "g"),
            CreateTestCase(12345.678910, NumberStyles.Float, En, "g5"),
            CreateTestCase(12345.678910, NumberStyles.Float | NumberStyles.AllowThousands, En, "n"),
            CreateTestCase(12345.678910, NumberStyles.Float | NumberStyles.AllowThousands, En, "N"),
            CreateTestCase(12345.678910, NumberStyles.Float | NumberStyles.AllowThousands, En, "N5"),
            CreateTestCase(12345.678910, NumberStyles.Float, En, "R"),
            CreateTestCase(-12345.678910, NumberStyles.Float, En, "r"),
            CreateTestCase(-Math.PI, NumberStyles.Float, En, "f15"),
            CreateTestCase(-Math.PI, NumberStyles.Float, En, "f16"),
            CreateTestCase(-Math.PI, NumberStyles.Float, En, "f17"),
            CreateTestCase(Math.PI, NumberStyles.Float, En, "f25"),
            CreateTestCase("3.141592653589793238", NumberStyles.Float, En),
            CreateTestCase("-3.141592653589793238", NumberStyles.Float, En),
            CreateTestCase("0.017453292519943295", NumberStyles.Float, En),
            CreateTestCase(-Math.PI, NumberStyles.Float, En, "r"),
            CreateTestCase(Sv.NumberFormat.NaNSymbol, NumberStyles.Float, Sv),
            CreateTestCase(Sv.NumberFormat.PositiveInfinitySymbol, NumberStyles.Float, Sv),
            CreateTestCase(Sv.NumberFormat.NegativeInfinitySymbol, NumberStyles.Float, Sv),
        };

        private static readonly IReadOnlyList<TestCase> Errors = new[]
        {
            CreateTestCase("e1", NumberStyles.Float, En),
            CreateTestCase(" 1", NumberStyles.None, En),
            CreateTestCase("-1", NumberStyles.None, En),
            CreateTestCase(".1", NumberStyles.None, En),
            CreateTestCase(",.1", NumberStyles.Float, En),
            CreateTestCase(new string('1', 311), NumberStyles.Float, En),
            ////Add("1.", NumberStyles.Float | NumberStyles.AllowHexSpecifier, en),
            CreateTestCase(".", NumberStyles.Float, En),
            ////Add("+1,2", NumberStyles.Float, en),
            ////Add("+1.2", NumberStyles.Float, sv),
            CreateTestCase("+1.2e3", NumberStyles.None | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, En),
        };

        [TestCaseSource(nameof(HappyPaths))]
        public void ReadSuccess(TestCase data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            foreach (var format in PadFormats)
            {
                var text = string.Format(format, data.Text);
                var pos = format.IndexOf('{');
                var start = pos;
                double expected = double.Parse(data.Text, style, culture);
                var actual = DoubleReader.Read(text, ref pos, style, culture);
                Assert.AreEqual(expected, actual);
                var expectedEnd = start + data.Text.Length;
                Assert.AreEqual(expectedEnd, pos);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public void ReadError(TestCase data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            var text = data.Text;
            foreach (var format in PadFormats)
            {
                var ns = string.Format(format, text);
                var pos = format.IndexOf('{');
                var start = pos;
                Exception parseException = null;
                try
                {
                    double.Parse(text, style, culture);
                }
                catch (Exception e)
                {
                    parseException = e;
                }

                Exception readException = null;
                try
                {
                    DoubleReader.Read(ns, ref pos, style, culture);
                }
                catch (Exception e)
                {
                    readException = e;
                }

                Assert.AreEqual(start, pos);
                Assert.NotNull(parseException);
                Assert.NotNull(readException);
            }
        }

        [Test]
        public void ReadException()
        {
            var text = "abcdef";
            var culture = CultureInfo.InvariantCulture;
            var pos = 3;
            var e = Assert.Throws<FormatException>(() => DoubleReader.Read(text, ref pos, NumberStyles.Float, culture));
            var expected = "Expected to find a double starting at index 3\r\n" +
                           "String: abcdef\r\n" +
                           "           ^";
            Assert.AreEqual(expected, e.Message);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryReadSuccess(TestCase data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            var pos = 0;
            double expected;
            Assert.IsTrue(double.TryParse(data.Text, style, culture, out expected));
            double actual;
            Assert.IsTrue(DoubleReader.TryRead(data.Text, ref pos, style, culture, out actual));
            Assert.AreEqual(expected, actual);
            var expectedEnd = data.Text.Length;
            Assert.AreEqual(expectedEnd, pos);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryReadPaddedSuccess(TestCase data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            foreach (var format in PadFormats)
            {
                var text = string.Format(format, data.Text);
                var pos = format.IndexOf('{');
                var start = pos;
                double expected;
                Assert.IsTrue(double.TryParse(data.Text, style, culture, out expected));
                double actual;
                Assert.IsTrue(DoubleReader.TryRead(text, ref pos, style, culture, out actual));
                Assert.AreEqual(expected, actual);
                var expectedEnd = start + data.Text.Length;
                Assert.AreEqual(expectedEnd, pos);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public void TryReadErrorPadded(TestCase data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            var s = data.Text;
            foreach (var format in PadFormats)
            {
                var ns = string.Format(format, s);
                var pos = format.IndexOf('{');
                var start = pos;
                double expected;
                Assert.IsFalse(double.TryParse(s, style, culture, out expected));
                double actual;
                Assert.IsFalse(DoubleReader.TryRead(ns, ref pos, style, culture, out actual));
                Assert.AreEqual(expected, actual);
                Assert.AreEqual(start, pos);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public void TryReadError(TestCase data)
        {
            var culture = data.Culture;
            var style = data.Styles;
            var pos = 0;
            double expected;
            Assert.IsFalse(double.TryParse(data.Text, style, culture, out expected));
            double actual;
            Assert.IsFalse(DoubleReader.TryRead(data.Text, ref pos, style, culture, out actual));
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(0, pos);
        }

        private static TestCase CreateTestCase(double value, NumberStyles styles, IFormatProvider culture, string format)
        {
            return new TestCase(value.ToString(format, culture), styles, culture);
        }

        private static TestCase CreateTestCase(string text, NumberStyles styles, CultureInfo culture)
        {
            return new TestCase(text, styles, culture);
        }

        public class TestCase
        {
            public TestCase(string text, NumberStyles styles, IFormatProvider culture)
            {
                this.Text = text;
                this.Styles = styles;
                this.Culture = culture;
            }

            public string Text { get; }

            public NumberStyles Styles { get; }

            public IFormatProvider Culture { get; }

            public override string ToString()
            {
                return $"Text: {this.Text}, Styles: {this.Styles}, Culture: {this.Culture}";
            }
        }
    }
}
