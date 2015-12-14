namespace Gu.Units.Generator.Tests.Descriptors
{
    using NUnit.Framework;

    public class UnitPartsExtTests
    {
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const char MultiplyDot = '⋅';

        [TestCase(1, "m")]
        [TestCase(2, "m²")]
        [TestCase(-1, "m⁻¹")]
        public void MetresToUnitString(int power, string expected)
        {
            var settings = MockSettings.Create();
            var parts = new[] { UnitAndPower.Create(settings.Metres, power) };

            var actual = parts.AsSymbol();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, "m⋅s")]
        [TestCase(1, -1, "m/s")]
        [TestCase(3, -1, "m³/s")]
        [TestCase(-1, -1, "m⁻¹⋅s⁻¹")]
        public void MetresSecondsToUnitString(int metresPower, int secondsPower, string expected)
        {
            var settings = MockSettings.Create();
            var parts = new[]
            {
                UnitAndPower.Create(settings.Metres, metresPower),
                UnitAndPower.Create(settings.Seconds, secondsPower)
            };

            var actual = parts.AsSymbol();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SecondsMetresToUnitString()
        {
            var settings = MockSettings.Create();
            var parts = new[]
            {
                UnitAndPower.Create(settings.Seconds, -1),
                UnitAndPower.Create(settings.Metres, 1),
            };

            var actual = parts.AsSymbol();
            Assert.AreEqual("m/s", actual);
        }
    }
}