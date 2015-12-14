namespace Gu.Units.Generator.Tests.Descriptors.Conversions
{
    using NUnit.Framework;

    public class PrefixConversionTests
    {
        [Test]
        public void CreateMilliAmperes()
        {
            var settings = MockSettings.Create();
            var conversion = PrefixConversion.Create(settings.Amperes, settings.Milli);
            settings.Amperes.PrefixConversions.Add(conversion);
            Assert.AreEqual("Milliamperes", conversion.Name);
            Assert.AreEqual("mA", conversion.Symbol);
            Assert.AreEqual(0.001, conversion.Factor);
        }

        [Test]
        public void CreateMilligrams()
        {
            var settings = MockSettings.Create();
            var conversion = PrefixConversion.Create(settings.Grams, settings.Milli);
            settings.Grams.PrefixConversions.Add(conversion);
            Assert.AreEqual("Milligrams", conversion.Name);
            Assert.AreEqual("mg", conversion.Symbol);
            Assert.AreEqual(1E-6, conversion.Factor);
        }
    }
}
