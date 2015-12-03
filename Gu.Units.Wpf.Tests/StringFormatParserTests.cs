namespace Gu.Units.Wpf.Tests
{
    using NUnit.Framework;

    public class StringFormatParserTests
    {
        [TestCase("{0:F1 mm}")]
        [TestCase("F1 mm")]
        public void TryParse(string format)
        {
            QuantityFormat<LengthUnit> actual;
            var success = StringFormatParser<LengthUnit>.TryParse(format, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(null, actual.PrePadding);
            Assert.AreEqual("F1", actual.ValueFormat);
            Assert.AreEqual(" ", actual.Padding);
            Assert.AreEqual("mm", actual.SymbolFormat);
            Assert.AreEqual(null, actual.PostPadding);
        }
    }
}
