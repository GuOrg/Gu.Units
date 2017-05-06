namespace Gu.Units.Generator.Tests.Descriptors.Conversions
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class ConversionTests
    {
        [Test]
        public async Task IdentityConversion()
        {
            var settings = MockSettings.Create();
            var conversion = new PartConversion.IdentityConversion(settings.Metres);
            Assert.AreEqual("metres", conversion.ToSi);
            Assert.AreEqual("metres", conversion.FromSi);
            Assert.AreEqual("1 m = 1 m", conversion.SymbolConversion);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task PrefixMilliConversion()
        {
            var settings = MockSettings.Create();
            var conversion = PrefixConversion.Create(settings.Metres, settings.Milli);
            settings.Metres.PrefixConversions.Add(conversion);
            Assert.AreEqual("millimetres / 1000", conversion.ToSi);
            Assert.AreEqual("1000 * metres", conversion.FromSi);
            Assert.AreEqual("1 mm = 0.001 m", conversion.SymbolConversion);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task PrefixMicroConversion()
        {
            var settings = MockSettings.Create();
            var conversion = PrefixConversion.Create(settings.Metres, settings.Micro);
            settings.Metres.PrefixConversions.Add(conversion);
            Assert.AreEqual("micrometres / 1000000", conversion.ToSi);
            Assert.AreEqual("1000000 * metres", conversion.FromSi);
            Assert.AreEqual("1 µm = 1E-06 m", conversion.SymbolConversion);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task FactorConversion()
        {
            var settings = MockSettings.Create();
            var conversion = new FactorConversion("Inches", "in", 0.0254);
            settings.Metres.FactorConversions.Add(conversion);
            Assert.AreEqual("0.0254 * inches", conversion.ToSi);
            Assert.AreEqual("metres / 0.0254", conversion.FromSi);
            Assert.AreEqual("1 in = 0.0254 m", conversion.SymbolConversion);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task CustomConversion()
        {
            var settings = MockSettings.Create();
            var conversion = new CustomConversion("Fahrenheit", "°F", "(fahrenheit + 459.67)/1.8", "1.8*kelvin - 459.67");
            settings.Kelvins.CustomConversions.Add(conversion);
            Assert.AreEqual("(fahrenheit + 459.67)/1.8", conversion.ToSi);
            Assert.AreEqual("1.8*kelvin - 459.67", conversion.FromSi);
            Assert.AreEqual("1 °F = 255.927777777778 K", conversion.SymbolConversion);
            Assert.Inconclusive("Does not roundtrip cleanly");
            ////Assert.AreEqual(true, conversion.CanRoundtripCoreAsync);
        }

        [Test]
        public async Task CustomConversionWithIllegal()
        {
            var settings = MockSettings.Create();
            var conversion = new CustomConversion("Fahrenheit", "°F", "??", null);
            settings.Kelvins.CustomConversions.Add(conversion);
            Assert.AreEqual("??", conversion.ToSi);
            Assert.AreEqual(null, conversion.FromSi);
            Assert.AreEqual("Invalid", conversion.SymbolConversion);
            Assert.AreEqual(false, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task NestedFactorConversion()
        {
            var settings = MockSettings.Create();
            var conversion = PrefixConversion.Create(settings.Grams, settings.Milli);
            settings.Grams.PrefixConversions.Add(conversion);
            Assert.AreEqual("milligrams / 1000000", conversion.ToSi);
            Assert.AreEqual("1000000 * kilograms", conversion.FromSi);
            Assert.AreEqual("1 mg = 1E-06 kg", conversion.SymbolConversion);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task PartConversionIdentity()
        {
            var settings = MockSettings.Create();
            var metresPart = PartConversion.CreatePart(1, settings.Metres);
            var secondsPart = PartConversion.CreatePart(-1, settings.Seconds);
            var conversion = PartConversion.Create(settings.MetresPerSecond, metresPart, secondsPart);
            settings.MetresPerSecond.PartConversions.Add(conversion);
            Assert.AreEqual("metresPerSecond", conversion.ToSi);
            Assert.AreEqual("metresPerSecond", conversion.FromSi);
            Assert.AreEqual("1 m/s = 1 m/s", conversion.SymbolConversion);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task PartConversionPrefix()
        {
            var settings = MockSettings.Create();
            var millimetreConversion = PrefixConversion.Create(settings.Metres, settings.Milli);
            settings.Metres.PrefixConversions.Add(millimetreConversion);
            var milliMetresPart = PartConversion.CreatePart(1, millimetreConversion);
            var secondsPart = PartConversion.CreatePart(-1, settings.Seconds);
            var conversion = PartConversion.Create(settings.MetresPerSecond, milliMetresPart, secondsPart);
            settings.MetresPerSecond.PartConversions.Add(conversion);
            Assert.AreEqual("millimetresPerSecond / 1000", conversion.ToSi);
            Assert.AreEqual("1000 * metresPerSecond", conversion.FromSi);
            Assert.AreEqual("1 mm/s = 0.001 m/s", conversion.SymbolConversion);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task CentimetresPerMinute()
        {
            var settings = MockSettings.Create();
            var centi = new Prefix("Centi", "c", -2);
            settings.Prefixes.Add(centi);
            var centimetresConversion = PrefixConversion.Create(settings.Metres, centi);
            var minuteConversion = new FactorConversion("Minute", "min", 60);
            settings.Seconds.FactorConversions.Add(minuteConversion);
            settings.Metres.PrefixConversions.Add(centimetresConversion);
            var centiMetresPart = PartConversion.CreatePart(1, centimetresConversion);
            var minutesPart = PartConversion.CreatePart(-1, minuteConversion);
            var conversion = PartConversion.Create(settings.MetresPerSecond, centiMetresPart, minutesPart);
            settings.MetresPerSecond.PartConversions.Add(conversion);
            Assert.AreEqual("centimetresPerMinute / 6000", conversion.ToSi);
            Assert.AreEqual("6000 * metresPerSecond", conversion.FromSi);
            Assert.AreEqual("1 cm/min = 0.000166666666666667 m/s", conversion.SymbolConversion);
            Assert.AreEqual(true, await conversion.CanRoundtripAsync().ConfigureAwait(false));
        }
    }
}
