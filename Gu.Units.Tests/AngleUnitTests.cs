namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class AngleUnitTests
    {
        private static readonly TestCaseData[] HappyPathSource =
        {
            new TestCaseData("°", "\u00B0"),
            new TestCaseData("\u00B0", "\u00B0"),
        };

        [TestCaseSource(nameof(HappyPathSource))]
        public void ParseSuccess(string text, string expected)
        {
            var unit = AngleUnit.Parse(text);
            Assert.AreEqual(expected, unit.ToString());
        }

        [TestCaseSource(nameof(HappyPathSource))]
        public void TryParseSuccess(string text, string expected)
        {
            Assert.AreEqual(true, AngleUnit.TryParse(text, out AngleUnit result));
            Assert.AreEqual(expected, result.ToString());
        }
    }
}