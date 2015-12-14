namespace Gu.Units.Generator.Tests.Views
{
    using NUnit.Framework;

    public class PrefixConversionVmTests
    {
        [Test]
        public void SetIsUsedToTrueAddsConversion()
        {
            var settings = MockSettings.Create();
            var prefixConversion = PrefixConversion.Create(settings.Amperes, settings.Milli);
            var conversionVm = PrefixConversionVm.Create(settings.Amperes, settings.Milli);
            Assert.IsFalse(conversionVm.IsUsed);
            Assert.IsEmpty(settings.Amperes.PrefixConversions);

            conversionVm.IsUsed = true;
            var expected = new[] { prefixConversion };
            CollectionAssert.AreEqual(expected, settings.Amperes.PrefixConversions, PrefixConversionComparer.Default);
        }

        [Test]
        public void MilliAmperes()
        {
            var settings = MockSettings.Create();
            var conversionVm = PrefixConversionVm.Create(settings.Amperes, settings.Milli);
            Assert.AreEqual("milliamperes/1000", conversionVm.Conversion.ToSi);
            Assert.AreEqual("1000*amperes", conversionVm.Conversion.FromSi);
            Assert.AreEqual("1 mA = 0.001 A", conversionVm.Conversion.SymbolConversion);
            Assert.AreEqual(true, conversionVm.Conversion.CanRoundtrip);


            CollectionAssert.DoesNotContain(settings.Amperes.PrefixConversions, conversionVm.Conversion);

            conversionVm.IsUsed = true;
            CollectionAssert.Contains(settings.Amperes.PrefixConversions, conversionVm.Conversion);

            conversionVm.IsUsed = false;
            CollectionAssert.DoesNotContain(settings.Amperes.PrefixConversions, conversionVm.Conversion);
        }

        [Test]
        public void MilliGrams()
        {
            var settings = MockSettings.Create();
            var conversionVm = PrefixConversionVm.Create(settings.Grams, settings.Milli);
            Assert.AreEqual(1E-6, conversionVm.Conversion.Factor);
            Assert.AreEqual("milligrams/1000000", conversionVm.Conversion.ToSi);
            Assert.AreEqual("1000000*kilograms", conversionVm.Conversion.FromSi);
            Assert.AreEqual("1 mg = 1E-06 kg", conversionVm.Conversion.SymbolConversion);
            Assert.AreEqual(true, conversionVm.Conversion.CanRoundtrip);

            CollectionAssert.DoesNotContain(settings.Grams.PrefixConversions, conversionVm.Conversion);

            conversionVm.IsUsed = true;
            CollectionAssert.Contains(settings.Grams.PrefixConversions, conversionVm.Conversion);

            conversionVm.IsUsed = false;
            CollectionAssert.DoesNotContain(settings.Grams.PrefixConversions, conversionVm.Conversion);
        }
    }
}