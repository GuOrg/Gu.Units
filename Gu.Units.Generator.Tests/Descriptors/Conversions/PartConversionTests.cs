namespace Gu.Units.Generator.Tests.Descriptors.Conversions
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    // ⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹
    public static class PartConversionTests
    {
        [Test]
        public static void SquareMillimetres()
        {
            using var settings = MockSettings.Create();
            var millimetres = PrefixConversion.Create(settings.Metres, settings.Milli);
            settings.Metres.PrefixConversions.Add(millimetres);
            var millimetrePart = PartConversion.CreatePart(2, millimetres);
            var conversion = PartConversion.Create(settings.Metres, millimetrePart);
            Assert.AreEqual("mm²", conversion.Symbol);
            Assert.AreEqual("SquareMillimetres", conversion.Name);
            Assert.AreEqual(1E-6, conversion.Factor);
        }

        [Test]
        public static void GramsPerCubicMetre()
        {
            using var settings = MockSettings.Create();
            var gramPart = PartConversion.CreatePart(1, settings.Grams);
            var volumePart = PartConversion.CreatePart(-1, settings.CubicMetres);
            var conversion = PartConversion.Create(settings.KilogramsPerCubicMetre, gramPart, volumePart);
            Assert.AreEqual("g/m³", conversion.Symbol);
            Assert.AreEqual("GramsPerCubicMetre", conversion.Name);
            Assert.AreEqual(1E-3, conversion.Factor);
        }

        [Test]
        public static void MilliGramsPerCubicMetre()
        {
            using var settings = MockSettings.Create();
            var milligram = PrefixConversion.Create(settings.Grams, settings.Milli);
            settings.Grams.PrefixConversions.Add(milligram);
            var milliGramPart = PartConversion.CreatePart(1, milligram);
            var volumePart = PartConversion.CreatePart(-1, settings.CubicMetres);
            var conversion = PartConversion.Create(settings.Kilograms, milliGramPart, volumePart);
            Assert.AreEqual("mg/m³", conversion.Symbol);
            Assert.AreEqual("MilligramsPerCubicMetre", conversion.Name);
            Assert.AreEqual(1E-6, conversion.Factor);
        }

        [Test]
        public static async Task MetresPerSecondCubed()
        {
            using var settings = MockSettings.Create();
            var metrePart = PartConversion.CreatePart(1, settings.Metres);
            var secondPart = PartConversion.CreatePart(-2, settings.Seconds);
            var conversion = PartConversion.Create(settings.MetresPerSecondSquared, metrePart, secondPart);
            Assert.AreEqual("m/s²", conversion.Symbol);
            Assert.AreEqual("MetresPerSecondSquared", conversion.Name);
            Assert.AreEqual(1, conversion.Factor);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public static async Task MilliMetresPerSecondCubed()
        {
            using var settings = MockSettings.Create();
            var millimetres = PrefixConversion.Create(settings.Metres, settings.Milli);
            settings.Metres.PrefixConversions.Add(millimetres);
            var metrePart = PartConversion.CreatePart(1, millimetres);
            var secondPart = PartConversion.CreatePart(-2, settings.Seconds);
            var conversion = PartConversion.Create(settings.MetresPerSecondSquared, metrePart, secondPart);
            Assert.AreEqual("mm/s²", conversion.Symbol);
            Assert.AreEqual("MillimetresPerSecondSquared", conversion.Name);
            Assert.AreEqual(0.001, conversion.Factor);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }
    }
}
