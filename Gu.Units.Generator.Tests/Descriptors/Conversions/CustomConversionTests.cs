namespace Gu.Units.Generator.Tests.Descriptors.Conversions
{
    using System;
    using System.Threading.Tasks;
    using NUnit.Framework;

    public static class CustomConversionTests
    {
        [Test]
        public static async Task CustomConversion()
        {
            using var settings = MockSettings.Create();
            var conversion = new CustomConversion("Fahrenheit", "°F", "(fahrenheit + 459.67)/1.8", "1.8*kelvin - 459.67");
            settings.Kelvins.CustomConversions.Add(conversion);
            Assert.AreEqual("(fahrenheit + 459.67)/1.8", conversion.ToSi);
            Assert.AreEqual("1.8*kelvin - 459.67", conversion.FromSi);
            Assert.AreEqual("1 °F = 255.927777777778 K", await conversion.GetSymbolConversionAsync().ConfigureAwait(false));
            Assert.Inconclusive("Does not roundtrip cleanly");
            ////Assert.AreEqual(true, conversion.CanRoundtripCoreAsync);
        }

        [Explicit]
        [Test]
        public static void ThrowsIfWrongParameter()
        {
            using var settings = MockSettings.Create();
            var conversion = new CustomConversion("Fahrenheit", "°F", "(fahrenheit + 459.67)/1.8", "1.8*kelvin - 459.67");
            settings.Kelvins.CustomConversions.Add(conversion);
            var exception = Assert.Throws<ArgumentException>(() => conversion.FromSi = "metres + 45");
            Assert.AreEqual("(2,8): error CS0103: The name 'metres' does not exist in the current context", exception.Message);
        }
    }
}
