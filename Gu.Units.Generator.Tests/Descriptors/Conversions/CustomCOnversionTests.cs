namespace Gu.Units.Generator.Tests.Descriptors.Conversions
{
    using System;
    using NUnit.Framework;

    public class CustomConversionTests
    {
        [Test]
        public void CustomConversion()
        {
            var settings = MockSettings.Create();
            var conversion = new CustomConversion("Fahrenheit", "°F", "(fahrenheit + 459.67)/1.8", "1.8*kelvin - 459.67");
            settings.Kelvins.CustomConversions.Add(conversion);
            Assert.AreEqual("(fahrenheit + 459.67)/1.8", conversion.ToSi);
            Assert.AreEqual("1.8*kelvin - 459.67", conversion.FromSi);
            Assert.AreEqual("1 °F = 255.927777777778 K", conversion.SymbolConversion);
            Assert.Inconclusive("Does not roundtrip cleanly");
            //Assert.AreEqual(true, conversion.CanRoundtrip);
        }

        [Test]
        public void ThrowsIfWrongParameter()
        {
            var settings = MockSettings.Create();
            var conversion = new CustomConversion("Fahrenheit", "°F", "(fahrenheit + 459.67)/1.8", "1.8*kelvin - 459.67");
            settings.Kelvins.CustomConversions.Add(conversion);
            var exception = Assert.Throws<ArgumentException>(() => conversion.FromSi = "metres + 45");
            Assert.AreEqual("(2,8): error CS0103: The name 'metres' does not exist in the current context", exception.Message);
        }
    }
}
