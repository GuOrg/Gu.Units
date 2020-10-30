namespace Gu.Units.Tests
{
    using System;
    using NUnit.Framework;

    public static class LengthUnitTests
    {
        private static readonly TestCaseData[] HappyPathSource =
        {
            Create("m"),
            Create("m "),
            Create(" m"),
            Create(" m "),
            Create(" cm"),
            Create("mm"),
            new TestCaseData("μm", "\u03BCm"),
            new TestCaseData("\u00B5m", "\u03BCm"),
            new TestCaseData("\u03BCm", "\u03BCm"),
            Create("ft"),
            Create("yd"),
        };

        private static string[] ErrorSource { get; } = { "ssg", "mms" };

        [TestCaseSource(nameof(HappyPathSource))]
        public static void ParseSuccess(string text, string expected)
        {
            var lengthUnit = LengthUnit.Parse(text);
            Assert.AreEqual(expected, lengthUnit.ToString());
        }

        [TestCaseSource(nameof(ErrorSource))]
        public static void ParseError(string text)
        {
            Assert.Throws<FormatException>(() => LengthUnit.Parse(text));
            Assert.AreEqual(false, LengthUnit.TryParse(text, out var _));
        }

        [TestCaseSource(nameof(HappyPathSource))]
        public static void TryParseSuccess(string text, string expected)
        {
            Assert.AreEqual(true, LengthUnit.TryParse(text, out var result));
            Assert.AreEqual(expected, result.ToString());
        }

        [TestCaseSource(nameof(ErrorSource))]
        public static void TryParseError(string text)
        {
            Assert.AreEqual(false, LengthUnit.TryParse(text, out var _));
        }

        private static TestCaseData Create(string text) => new TestCaseData(text, text.Trim());
    }
}