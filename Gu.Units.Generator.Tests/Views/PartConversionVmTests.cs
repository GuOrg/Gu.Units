namespace Gu.Units.Generator.Tests.Views
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class PartConversionVmTests
    {
        [Test]
        public async Task CubicMillimetresAsync()
        {
            var settings = MockSettings.Create();
            var millimetres = PrefixConversion.Create(settings.Metres, settings.Milli);
            settings.Metres.PrefixConversions.Add(millimetres);
            var conversion = PartConversion.Create(settings.CubicMetres, new PartConversion.PowerPart(3, millimetres));
            using (var conversionVm = new PartConversionVm(settings.CubicMetres, conversion))
            {
                Assert.AreEqual(1E-9, ((PartConversion)conversionVm.Conversion).Factor);
                Assert.AreEqual("cubicMillimetres / 1000000000", conversionVm.Conversion.ToSi);
                Assert.AreEqual("1000000000 * cubicMetres", conversionVm.Conversion.FromSi);
                Assert.AreEqual("1 mm³ = 1E-09 m³", await conversionVm.Conversion.GetSymbolConversionAsync().ConfigureAwait(false));
                Assert.AreEqual(true, await conversionVm.Conversion.CanRoundtripAsync().ConfigureAwait(false));
            }
        }

        [Test]
        public void IsUsed()
        {
            var settings = MockSettings.Create();
            var millimetres = PrefixConversion.Create(settings.Metres, settings.Milli);
            settings.Metres.PrefixConversions.Add(millimetres);
            var conversion = PartConversion.Create(settings.CubicMetres, new PartConversion.PowerPart(3, millimetres));
            using (var conversionVm = new PartConversionVm(settings.CubicMetres, conversion) { IsUsed = true })
            {
                CollectionAssert.Contains(settings.CubicMetres.PartConversions, conversion);

                conversionVm.IsUsed = false;
                CollectionAssert.DoesNotContain(settings.CubicMetres.PartConversions, conversion);
            }
        }
    }
}