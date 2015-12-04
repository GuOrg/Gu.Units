namespace Gu.Units.Generator.Tests.Descriptors
{
    using NUnit.Framework;
    using WpfStuff;

    public class StringToFormulaConverterTests
    {
        [TestCase("10*x")]
        public void SimpleFactorTest(string s)
        {
            var converter = new StringToFormulaConverter();
            Assert.True(converter.CanConvertFrom(null, typeof(string)));
            var formula = (ConversionFormula)converter.ConvertFrom(null, null, s);
            Assert.AreEqual(s, formula.ToSi);
            Assert.AreEqual("x/10", formula.FromSi);
        }
    }
}
