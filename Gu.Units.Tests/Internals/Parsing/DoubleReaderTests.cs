namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using NUnit.Framework;

    public class DoubleReaderTests
    {
        private static readonly string[] PadFormats = { "abc{0}def", "abcd{0}ef", "{0}" };

        [Explicit("Runs forever unless")]
        [Test]
        public void Fuzzer()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            long count = 0;
            var builder = new StringBuilder();
            string text;

            double parsed;
            double read;

            bool parseSuccess;
            bool readSuccess;
            bool success;
            do
            {
                var pos = 0;
                var length = rnd.Next(2, 15);
                var decimalPlace = rnd.Next(length);
                builder.Clear();
                for (int i = 0; i < length; i++)
                {
                    if (i == decimalPlace)
                    {
                        builder.Append('.');
                        continue;
                    }
                    builder.Append((char)rnd.Next('0', '9'));
                }

                text = builder.ToString();
                parseSuccess = double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out parsed);
                readSuccess = DoubleReader.TryRead(text, ref pos, NumberStyles.Float, CultureInfo.InvariantCulture, out read);
                success = parseSuccess && readSuccess && parsed == read;
                count++;
            } while (success);

            Console.WriteLine($"Count: {count}");
            Console.WriteLine(text);
            Console.WriteLine($"success: {parseSuccess} double.TryParse(text, out {parsed.ToString("R", CultureInfo.InvariantCulture)})");
            Console.WriteLine($"success: {readSuccess} double.TryParse(text, out {read.ToString("R", CultureInfo.InvariantCulture)})");
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void ReadSuccess(DoubleData data)
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
        public void ReadError(DoubleData data)
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
            int endPos;
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
        public void TryReadSuccess(DoubleData data)
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
        public void TryReadPaddedSuccess(DoubleData data)
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
        public void TryReadErrorPadded(DoubleData data)
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
        public void TryReadError(DoubleData data)
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

        #region TestData

        private static readonly CultureInfo en = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly IReadOnlyList<DoubleData> HappyPaths = new[]
        {
            CreateParseData("0", NumberStyles.Float, en),
            CreateParseData("0.", NumberStyles.Float, en),
            CreateParseData(".0", NumberStyles.Float, en),
            CreateParseData("0.0", NumberStyles.Float, en),
            CreateParseData("1.2", NumberStyles.Float, en),
            CreateParseData("0.012", NumberStyles.Float, en),
            CreateParseData("0.0012", NumberStyles.Float, en),
            CreateParseData("0.001", NumberStyles.Float, en),
            CreateParseData("1", NumberStyles.Float, en),
            CreateParseData(" 1", NumberStyles.Float, en),
            CreateParseData("-1", NumberStyles.Float, en),
            CreateParseData("+1", NumberStyles.Float, en),
            CreateParseData(".1", NumberStyles.Float, en),
            CreateParseData("-.1", NumberStyles.Float, en),
            CreateParseData("1.", NumberStyles.Float, en),
            CreateParseData("-1.", NumberStyles.Float, en),
            CreateParseData("12,345.67", NumberStyles.Float | NumberStyles.AllowThousands, en),
            CreateParseData("-12,345.67", NumberStyles.Float | NumberStyles.AllowThousands, en),
            CreateParseData("+1.2", NumberStyles.Float, en),
            CreateParseData("+1,2", NumberStyles.Float, sv),
            CreateParseData("+1.2e3", NumberStyles.Float, en),
            CreateParseData("-1.2E3", NumberStyles.Float, en),
            CreateParseData("+1.2e-3", NumberStyles.Float, en),
            CreateParseData("+1.2E-3", NumberStyles.Float, en),
            CreateParseData("-1.2e+3", NumberStyles.Float, en),//1,,2,3,4,5,,,.00
            CreateParseData("1,,2,3,4,5,,,.00", NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData("12345678910123456789", NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData("1.2345678910123456789", NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData("1234567891012345678.9", NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData(new string('1', 307), NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData(new string('1', 308), NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData(new string('1', 309), NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData("0." + new string('0', 15)+"1", NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData("0." + new string('0', 16)+"1", NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData("0." + new string('0', 299)+"1", NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData("0." + new string('0', 300)+"1", NumberStyles.Float|NumberStyles.AllowThousands, en),
            CreateParseData(-12345.678910, NumberStyles.Float, en, "e"),
            CreateParseData(12345.678910, NumberStyles.Float, en, "E"),
            CreateParseData(12345.678910, NumberStyles.Float, en, "E5"),
            CreateParseData(-12345.678910, NumberStyles.Float, en, "f"),
            CreateParseData(12345.678910, NumberStyles.Float, en, "F"),
            CreateParseData(12345.678912, NumberStyles.Float, en, "F20"),
            CreateParseData(12345.678910, NumberStyles.Float, en, "G"),
            CreateParseData(-12345.678910, NumberStyles.Float, en, "g"),
            CreateParseData(12345.678910, NumberStyles.Float, en, "g5"),
            CreateParseData(12345.678910, NumberStyles.Float |NumberStyles.AllowThousands, en, "n"),
            CreateParseData(12345.678910, NumberStyles.Float |NumberStyles.AllowThousands, en, "N"),
            CreateParseData(12345.678910, NumberStyles.Float |NumberStyles.AllowThousands, en, "N5"),
            CreateParseData(12345.678910, NumberStyles.Float, en, "R"),
            CreateParseData(-12345.678910, NumberStyles.Float, en, "r"),
            CreateParseData(-Math.PI, NumberStyles.Float, en, "f15"),
            CreateParseData(-Math.PI, NumberStyles.Float, en, "f16"),
            CreateParseData(-Math.PI, NumberStyles.Float, en, "f17"),
            CreateParseData(Math.PI, NumberStyles.Float, en, "f25"),
            CreateParseData("3.141592653589793238", NumberStyles.Float, en),
            CreateParseData("-3.141592653589793238", NumberStyles.Float, en),
            CreateParseData("0.017453292519943295", NumberStyles.Float, en),
            CreateParseData(-Math.PI, NumberStyles.Float, en, "r"),
            CreateParseData(sv.NumberFormat.NaNSymbol, NumberStyles.Float, sv),
            CreateParseData(sv.NumberFormat.PositiveInfinitySymbol, NumberStyles.Float, sv),
            CreateParseData(sv.NumberFormat.NegativeInfinitySymbol, NumberStyles.Float, sv),
        };

        private static DoubleData CreateParseData(double value,
            NumberStyles styles,
            IFormatProvider culture,
            string format)
        {
            return new DoubleData(value.ToString(format, culture), styles, culture);
        }

        private static readonly IReadOnlyList<DoubleData> Errors = new[]
        {
            CreateParseData("e1", NumberStyles.Float, en),
            CreateParseData(" 1", NumberStyles.None, en),
            CreateParseData("-1", NumberStyles.None, en),
            CreateParseData(".1", NumberStyles.None, en),
            CreateParseData(",.1", NumberStyles.Float, en),
            CreateParseData(new string('1', 311), NumberStyles.Float, en),
            //Add("1.", NumberStyles.Float | NumberStyles.AllowHexSpecifier, en),
            CreateParseData(".", NumberStyles.Float, en),
            //Add("+1,2", NumberStyles.Float, en),
            //Add("+1.2", NumberStyles.Float, sv),
            CreateParseData("+1.2e3", NumberStyles.None | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, en),
        };

        private static DoubleData CreateParseData(string text,
            NumberStyles styles,
            CultureInfo culture)
        {
            return new DoubleData(text, styles, culture);
        }

        public class DoubleData
        {
            public readonly string Text;
            public readonly NumberStyles Styles;
            public readonly IFormatProvider Culture;

            public DoubleData(string text,
                NumberStyles styles,
                IFormatProvider culture)
            {
                this.Text = text;
                this.Styles = styles;
                this.Culture = culture;
            }

            public override string ToString()
            {
                return $"Text: {this.Text}, Styles: {this.Styles}, Culture: {this.Culture}";
            }
        }

        #endregion  TestData
    }
}
