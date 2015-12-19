namespace Gu.Units.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class LengthUnitTests
    {
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

        private IReadOnlyList<string> HappyPathSource = new[] { "m", "mm", " cm", " m " };
        private IReadOnlyList<string> ErrorSource = new[] { "ssg", "mms" };
    }
}