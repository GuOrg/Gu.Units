namespace Gu.Units.Tests
{
    using System;
    using NUnit.Framework;

    public class LengthUnitTests
    {
        private static TestCase[] HappyPathSource { get; } =
        {
            new TestCase("m"),
            new TestCase("m "),
            new TestCase(" m"),
            new TestCase(" m "),
            new TestCase(" cm"),
            new TestCase("mm"),
            new TestCase("μm", "\u00B5m"),
            new TestCase("\u00B5m", "\u00B5m"),
            new TestCase("\u03BCm", "\u00B5m"),
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
            LengthUnit temp;
            Assert.AreEqual(false, LengthUnit.TryParse(text, out temp));
        }

        [TestCaseSource(nameof(HappyPathSource))]
        public void TryParseSuccess(TestCase testCase)
        {
            LengthUnit result;
            Assert.AreEqual(true, LengthUnit.TryParse(testCase.Text, out result));
            Assert.AreEqual(testCase.Expected, result.ToString());
        }

        [TestCaseSource(nameof(ErrorSource))]
        public void TryParseError(string text)
        {
            LengthUnit temp;
            Assert.AreEqual(false, LengthUnit.TryParse(text, out temp));
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