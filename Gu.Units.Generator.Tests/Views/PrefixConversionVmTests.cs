namespace Gu.Units.Generator.Tests.Views
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    public static class PrefixConversionVmTests
    {
        [Test]
        public static void SetIsUsedToTrueAddsConversion()
        {
            using var settings = MockSettings.Create();
            var prefixConversion = PrefixConversion.Create(settings.Amperes, settings.Milli);
            using var conversionVm = PrefixConversionVm.Create(settings.Amperes, settings.Milli);
            Assert.IsFalse(conversionVm.IsUsed);
            Assert.IsEmpty(settings.Amperes.PrefixConversions);

            conversionVm.IsUsed = true;
            var expected = new[] { prefixConversion };
            CollectionAssert.AreEqual(expected, settings.Amperes.PrefixConversions, PrefixConversionComparer.Default);
        }

        [Test]
        public static async Task MilliAmperesAsync()
        {
            using var settings = MockSettings.Create();
            using var conversionVm = PrefixConversionVm.Create(settings.Amperes, settings.Milli);
            Assert.AreEqual("milliamperes / 1000", conversionVm.Conversion.ToSi);
            Assert.AreEqual("1000 * amperes", conversionVm.Conversion.FromSi);
            Assert.AreEqual("1 mA = 0.001 A", await conversionVm.Conversion.GetSymbolConversionAsync().ConfigureAwait(false));
            Assert.AreEqual(true, await conversionVm.Conversion.CanRoundtripAsync().ConfigureAwait(false));

            CollectionAssert.DoesNotContain(settings.Amperes.PrefixConversions, conversionVm.Conversion);

            conversionVm.IsUsed = true;
            CollectionAssert.Contains(settings.Amperes.PrefixConversions, conversionVm.Conversion);

            conversionVm.IsUsed = false;
            CollectionAssert.DoesNotContain(settings.Amperes.PrefixConversions, conversionVm.Conversion);
        }

        [Test]
        public static async Task MilliGramsAsync()
        {
            using var settings = MockSettings.Create();
            using var conversionVm = PrefixConversionVm.Create(settings.Grams, settings.Milli);
            Assert.AreEqual(1E-6, ((PrefixConversion)conversionVm.Conversion).Factor);
            Assert.AreEqual("milligrams / 1000000", conversionVm.Conversion.ToSi);
            Assert.AreEqual("1000000 * kilograms", conversionVm.Conversion.FromSi);
            Assert.AreEqual("1 mg = 1E-06 kg", await conversionVm.Conversion.GetSymbolConversionAsync().ConfigureAwait(false));
            Assert.AreEqual(true, await conversionVm.Conversion.CanRoundtripAsync().ConfigureAwait(false));

            CollectionAssert.DoesNotContain(settings.Grams.PrefixConversions, conversionVm.Conversion);

            conversionVm.IsUsed = true;
            CollectionAssert.Contains(settings.Grams.PrefixConversions, conversionVm.Conversion);

            conversionVm.IsUsed = false;
            CollectionAssert.DoesNotContain(settings.Grams.PrefixConversions, conversionVm.Conversion);
        }
    }
}
