namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    public static class DoubleReaderTests
    {
        private static readonly string[] PadFormats = { "abc{0}def", "abcd{0}ef", "{0}" };
        private static readonly CultureInfo En = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo Sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly TestCaseData[] HappyPaths =
        {
            new TestCaseData("0", NumberStyles.Float, En),
            new TestCaseData("0.", NumberStyles.Float, En),
            new TestCaseData(".0", NumberStyles.Float, En),
            new TestCaseData("0.0", NumberStyles.Float, En),
            new TestCaseData("1.2", NumberStyles.Float, En),
            new TestCaseData("0.012", NumberStyles.Float, En),
            new TestCaseData("0.0012", NumberStyles.Float, En),
            new TestCaseData("0.001", NumberStyles.Float, En),
            new TestCaseData("1", NumberStyles.Float, En),
            new TestCaseData(" 1", NumberStyles.Float, En),
            new TestCaseData("-1", NumberStyles.Float, En),
            new TestCaseData("+1", NumberStyles.Float, En),
            new TestCaseData(".1", NumberStyles.Float, En),
            new TestCaseData("-.1", NumberStyles.Float, En),
            new TestCaseData("1.", NumberStyles.Float, En),
            new TestCaseData("-1.", NumberStyles.Float, En),
            new TestCaseData("12,345.67", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("-12,345.67", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("+1.2", NumberStyles.Float, En),
            new TestCaseData("+1,2", NumberStyles.Float, Sv),
            new TestCaseData("+1.2e3", NumberStyles.Float, En),
            new TestCaseData("-1.2E3", NumberStyles.Float, En),
            new TestCaseData("+1.2e-3", NumberStyles.Float, En),
            new TestCaseData("+1.2E-3", NumberStyles.Float, En),
            new TestCaseData("-1.2e+3", NumberStyles.Float, En), //// 1,,2,3,4,5,,,.00
            new TestCaseData("1,,2,3,4,5,,,.00", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("12345678910123456789", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("1.2345678910123456789", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("1234567891012345678.9", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData(new string('1', 307), NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData(new string('1', 308), NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData(new string('1', 309), NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("0." + new string('0', 15) + "1", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("0." + new string('0', 16) + "1", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("0." + new string('0', 299) + "1", NumberStyles.Float | NumberStyles.AllowThousands, En),
            new TestCaseData("0." + new string('0', 300) + "1", NumberStyles.Float | NumberStyles.AllowThousands, En),
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
            new TestCaseData("3.141592653589793238", NumberStyles.Float, En),
            new TestCaseData("-3.141592653589793238", NumberStyles.Float, En),
            new TestCaseData("0.017453292519943295", NumberStyles.Float, En),
            CreateTestCase(-Math.PI, NumberStyles.Float, En, "r"),
            new TestCaseData(Sv.NumberFormat.NaNSymbol, NumberStyles.Float, Sv),
            new TestCaseData(Sv.NumberFormat.PositiveInfinitySymbol, NumberStyles.Float, Sv),
            new TestCaseData(Sv.NumberFormat.NegativeInfinitySymbol, NumberStyles.Float, Sv),
        };

        private static readonly TestCaseData[] Errors =
        {
            new TestCaseData("e1", NumberStyles.Float, En),
            new TestCaseData(" 1", NumberStyles.None, En),
            new TestCaseData("-1", NumberStyles.None, En),
            new TestCaseData(".1", NumberStyles.None, En),
            new TestCaseData(",.1", NumberStyles.Float, En),
            new TestCaseData(new string('1', 311), NumberStyles.Float, En),
            ////Add("1.", NumberStyles.Float | NumberStyles.AllowHexSpecifier, en),
            new TestCaseData(".", NumberStyles.Float, En),
            ////Add("+1,2", NumberStyles.Float, en),
            ////Add("+1.2", NumberStyles.Float, sv),
            new TestCaseData("+1.2e3", NumberStyles.None | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, En),
        };

        [TestCaseSource(nameof(HappyPaths))]
        public static void ReadSuccess(string text, NumberStyles styles, IFormatProvider culture)
        {
            foreach (var format in PadFormats)
            {
                var formatted = string.Format(format, text);
                var pos = format.IndexOf('{');
                var start = pos;
                double expected = double.Parse(text, styles, culture);
                var actual = DoubleReader.Read(formatted, ref pos, styles, culture);
                Assert.AreEqual(expected, actual);
                var expectedEnd = start + text.Length;
                Assert.AreEqual(expectedEnd, pos);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public static void ReadError(string text, NumberStyles styles, IFormatProvider culture)
        {
            foreach (var format in PadFormats)
            {
                var ns = string.Format(format, text);
                var pos = format.IndexOf('{');
                var start = pos;
                Exception parseException = null;
                try
                {
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    double.Parse(text, styles, culture);
                }
                catch (Exception e)
                {
                    parseException = e;
                }

                Exception readException = null;
                try
                {
                    DoubleReader.Read(ns, ref pos, styles, culture);
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
        public static void ReadException()
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
        public static void TryReadSuccess(string text, NumberStyles styles, IFormatProvider culture)
        {
            var pos = 0;
            Assert.IsTrue(double.TryParse(text, styles, culture, out double expected));
            Assert.IsTrue(DoubleReader.TryRead(text, ref pos, styles, culture, out double actual));
            Assert.AreEqual(expected, actual);
            var expectedEnd = text.Length;
            Assert.AreEqual(expectedEnd, pos);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public static void TryReadPaddedSuccess(string text, NumberStyles styles, IFormatProvider culture)
        {
            foreach (var format in PadFormats)
            {
                var formatted = string.Format(format, text);
                var pos = format.IndexOf('{');
                var start = pos;
                Assert.IsTrue(double.TryParse(text, styles, culture, out double expected));
                Assert.IsTrue(DoubleReader.TryRead(formatted, ref pos, styles, culture, out double actual));
                Assert.AreEqual(expected, actual);
                var expectedEnd = start + text.Length;
                Assert.AreEqual(expectedEnd, pos);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public static void TryReadErrorPadded(string text, NumberStyles styles, IFormatProvider culture)
        {
            foreach (var format in PadFormats)
            {
                var ns = string.Format(format, text);
                var pos = format.IndexOf('{');
                var start = pos;
                Assert.IsFalse(double.TryParse(text, styles, culture, out double expected));
                Assert.IsFalse(DoubleReader.TryRead(ns, ref pos, styles, culture, out double actual));
                Assert.AreEqual(expected, actual);
                Assert.AreEqual(start, pos);
            }
        }

        [TestCaseSource(nameof(Errors))]
        public static void TryReadError(string text, NumberStyles styles, IFormatProvider culture)
        {
            var pos = 0;
            Assert.IsFalse(double.TryParse(text, styles, culture, out double expected));
            Assert.IsFalse(DoubleReader.TryRead(text, ref pos, styles, culture, out double actual));
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(0, pos);
        }

        private static TestCaseData CreateTestCase(double value, NumberStyles styles, IFormatProvider culture, string format)
        {
            return new TestCaseData(value.ToString(format, culture), styles, culture);
        }
    }
}
