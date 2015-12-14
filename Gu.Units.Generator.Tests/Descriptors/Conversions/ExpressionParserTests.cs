namespace Gu.Units.Generator.Tests.Descriptors.Conversions
{
    using NUnit.Framework;

    public class ExpressionParserTests
    {
        [Test]
        public void FactorConversion()
        {
            var text = "1E6*kilograms";
            var actual = ExpressionParser.Evaluate(1, "kilograms", text);
            Assert.AreEqual(1E6 * 1, actual);
        }
    }
}
