namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public static class ResistanceUnitTests
    {
        private static readonly TestCaseData[] HappyPathSource =
        {
            new TestCaseData("Ω", "\u03A9"),
            new TestCaseData("\u2126", "\u03A9"),
            new TestCaseData("\u03A9", "\u03A9"),
        };

        [TestCaseSource(nameof(HappyPathSource))]
        public static void ParseSuccess(string text, string expected)
        {
            var unit = ResistanceUnit.Parse(text);
            Assert.AreEqual(expected, unit.ToString());
        }

        [TestCaseSource(nameof(HappyPathSource))]
        public static void TryParseSuccess(string text, string expected)
        {
            Assert.AreEqual(true, ResistanceUnit.TryParse(text, out var result));
            Assert.AreEqual(expected, result.ToString());
        }
    }
}
