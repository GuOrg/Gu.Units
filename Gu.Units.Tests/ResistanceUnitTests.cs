namespace Gu.Units.Tests
{
    using NUnit.Framework;

    public class ResistanceUnitTests
    {
        private static readonly TestCase[] HappyPathSource =
        {
            new TestCase("Ω", "\u03A9"),
            new TestCase("\u2126", "\u03A9"),
            new TestCase("\u03A9", "\u03A9"),
        };

        [TestCaseSource(nameof(HappyPathSource))]
        public void ParseSuccess(TestCase testCase)
        {
            var unit = ResistanceUnit.Parse(testCase.Text);
            Assert.AreEqual(testCase.Expected, unit.ToString());
        }

        [TestCaseSource(nameof(HappyPathSource))]
        public void TryParseSuccess(TestCase testCase)
        {
            Assert.AreEqual(true, ResistanceUnit.TryParse(testCase.Text, out var result));
            Assert.AreEqual(testCase.Expected, result.ToString());
        }

        public class TestCase
        {
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