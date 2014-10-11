namespace Gu.Units.Tests
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    public class ParserTests
    {
        [TestCase("1m", new[] { "sv-se", "en-us" }, 1)]
        [TestCase("-1m", new[] { "sv-se", "en-us" }, -1)]
        [TestCase("1.2m", new[] { "en-us" }, 1.2)]
        [TestCase("1.2m", new[] { "en-us" }, 1.2)]
        [TestCase("1,2m", new[] { "sv-se" }, 1.2)]
        [TestCase("-1m", new[] { "sv-se", "en-us" }, -1)]
        [TestCase("1e3m", new[] { "sv-se", "en-us" }, 1e3)]
        [TestCase("1E3m", new[] { "sv-se", "en-us" }, 1e3)]
        [TestCase("1e+3m", new[] { "sv-se", "en-us" }, 1e+3)]
        [TestCase("1E+3m", new[] { "sv-se", "en-us" }, 1E+3)]
        [TestCase("1.2e-3m", new[] { "en-us" }, 1.2e-3)]
        [TestCase("1.2E-3m", new[] { "en-us" }, 1.2e-3)]
        [TestCase(" 1m", new[] { "sv-se", "en-us" }, 1)]
        [TestCase("1 m", new[] { "sv-se", "en-us" }, 1)]
        [TestCase("1m ", new[] { "sv-se", "en-us" }, 1)]
        [TestCase("1mm", new[] { "sv-se", "en-us" }, 1e-3)]
        [TestCase("1cm", new[] { "sv-se", "en-us" }, 1e-2)]
        public void ParseLength(string s, string[] cultures, double expected)
        {
            foreach (var culture in cultures)
            {
                var cultureInfo = CultureInfo.GetCultureInfo(culture);
                var length = Parser.Parse<ILengthUnit, Length>(s, Length.From, cultureInfo);
                Assert.AreEqual(expected, length.Metres);
            }
        }

        [TestCase("1s", 1)]
        [TestCase("1h", 3600)]
        [TestCase("1ms", 1e-3)]
        public void ParseTime(string s, double expected)
        {
            var time = Parser.Parse<ITimeUnit, Time>(s, Time.From);
            Assert.AreEqual(expected, time.Seconds);
        }

        [TestCase("1kg", 1)]
        [TestCase("1g", 1e-3)]
        public void ParseForce(string s, double expected)
        {
            var value = Parser.Parse<IMassUnit, Mass>(s, Mass.From);
            Assert.AreEqual(expected, value.Kilograms);
        }

        [TestCase("1", 1)]
        [TestCase(".1", .1)]
        [TestCase("-.1", -.1)]
        [TestCase("1.2", 1.2)]
        [TestCase("-1.2", -1.2)]
        [TestCase("1.2E+3", 1.2E+3)]
        [TestCase("1.2e+3", 1.2E+3)]
        [TestCase("1.2E3", 1.2E3)]
        [TestCase("1.2e3", 1.2E3)]
        [TestCase("1.2E-3", 1.2E-3)]
        [TestCase("1.2e-3", 1.2E-3)]
        public void DoublePattern(string s, double expected)
        {
            Assert.IsTrue(Regex.IsMatch(s, Parser.DoublePointPattern));
            Assert.AreEqual(expected, double.Parse(s, CultureInfo.InvariantCulture));
        }

        [TestCase("1.0cm", "sv-se")]
        [TestCase("1,0cm", "en-us")]
        public void Exceptions(string s, string culture)
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            Assert.Throws<FormatException>(() => Parser.Parse<ILengthUnit, Length>(s, Length.From, cultureInfo));
        }
    }
}
