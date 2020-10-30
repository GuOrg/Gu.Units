namespace Gu.Units.Wpf.Tests
{
    using NUnit.Framework;

    public static class StringFormatParserTests
    {
        [TestCase("{0:F1 mm}")]
        [TestCase("F1 mm")]
        public static void TryParse(string format)
        {
            var success = StringFormatParser<LengthUnit>.TryParse(format, out var actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(null, actual.PrePadding);
            Assert.AreEqual("F1", actual.ValueFormat);
            Assert.AreEqual(" ", actual.Padding);
            Assert.AreEqual("mm", actual.SymbolFormat);
            Assert.AreEqual(null, actual.PostPadding);
        }
    }
}
