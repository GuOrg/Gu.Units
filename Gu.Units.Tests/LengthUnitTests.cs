namespace Gu.Units.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class LengthUnitTests
    {
        private static readonly IReadOnlyList<TestCase> HappyPathSource = new[]
        {
            new TestCase("m"),
            new TestCase("m "),
            new TestCase(" m"),
            new TestCase(" m "),
            new TestCase(" cm"),
            new TestCase("mm"),
            new TestCase("μm", "\u03BCm"),
            new TestCase("\u00B5m", "\u03BCm"),
            new TestCase("\u03BCm", "\u03BCm"),
            new TestCase("ft"),
            new TestCase("yd"),
        };

        private static string[] ErrorSource { get; } = { "ssg", "mms" };

        [TestCaseSource(nameof(HappyPathSource))]
        public void ParseSuccess(TestCase testCase)
        {
            var lengthUnit = LengthUnit.Parse(testCase.Text);
            Assert.AreEqual(testCase.Expected, lengthUnit.ToString());
        }

        [TestCaseSource(nameof(ErrorSource))]
        public void ParseError(string text)
        {
            Assert.Throws<FormatException>(() => LengthUnit.Parse(text));
            Assert.AreEqual(false, LengthUnit.TryParse(text, out LengthUnit _));
        }

        [TestCaseSource(nameof(HappyPathSource))]
        public void TryParseSuccess(TestCase testCase)
        {
            Assert.AreEqual(true, LengthUnit.TryParse(testCase.Text, out LengthUnit result));
            Assert.AreEqual(testCase.Expected, result.ToString());
        }

        [TestCaseSource(nameof(ErrorSource))]
        public void TryParseError(string text)
        {
            Assert.AreEqual(false, LengthUnit.TryParse(text, out LengthUnit _));
        }

        public class TestCase
        {
            public TestCase(string text)
                : this(text, text.Trim())
            {
            }

            public TestCase(string text, string expected)
            {
                this.Text = text;
                this.Expected = expected;
            }

            public string Text { get; }

            public string Expected { get; }

            public override string ToString()
            {
                return $"{nameof(this.Text)}: {this.Text}, {nameof(this.Expected)}: {this.Expected}";
            }
        }
    }
}