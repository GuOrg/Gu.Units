namespace Gu.Units.Tests
{
    using System;
    using NUnit.Framework;

    public class LengthUnitTests
    {
        public static string[] HappyPathSource { get; } = { "m", "m ", " m", " m ", " cm", "mm", "μm", "ft", "yd" };

        public static string[] ErrorSource { get; } = { "ssg", "mms" };

        [TestCaseSource(nameof(HappyPathSource))]
        public void ParseSuccess(string text)
        {
            var lengthUnit = LengthUnit.Parse(text);
            Assert.AreEqual(text.Trim(), lengthUnit.ToString());
        }

        [TestCaseSource(nameof(ErrorSource))]
        public void ParseError(string text)
        {
            Assert.Throws<FormatException>(() => LengthUnit.Parse(text));
            LengthUnit temp;
            Assert.AreEqual(false, LengthUnit.TryParse(text, out temp));
        }

        [TestCaseSource(nameof(HappyPathSource))]
        public void TryParseSuccess(string text)
        {
            LengthUnit result;
            Assert.AreEqual(true, LengthUnit.TryParse(text, out result));
            Assert.AreEqual(text.Trim(), result.ToString());
        }

        [TestCaseSource(nameof(ErrorSource))]
        public void TryParseError(string text)
        {
            LengthUnit temp;
            Assert.AreEqual(false, LengthUnit.TryParse(text, out temp));
        }
    }
}