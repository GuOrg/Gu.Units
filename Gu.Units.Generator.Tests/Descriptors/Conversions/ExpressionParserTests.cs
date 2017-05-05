namespace Gu.Units.Generator.Tests.Descriptors.Conversions
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class ExpressionParserTests
    {
        [Test]
        public async Task FactorConversion()
        {
            var text = "1E6*kilograms";
            var actual = await ExpressionParser.EvaluateAsync(1, "kilograms", text).ConfigureAwait(false);
            Assert.AreEqual(1E6 * 1, actual);
        }
    }
}
