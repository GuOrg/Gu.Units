namespace Gu.Units.Tests
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    public static class QuantityParseTests
    {
        private static readonly CultureInfo Sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly TestCaseData[] TestCases =
        {
            Create("1.2 m", s => Length.Parse(s, CultureInfo.InvariantCulture), Length.FromMetres(1.2)),
            Create("1.2 μm", s => Length.Parse(s, CultureInfo.InvariantCulture), Length.FromMicrometres(1.2)),
            Create("1.2 \u00B5m", s => Length.Parse(s, CultureInfo.InvariantCulture), Length.FromMicrometres(1.2)),
            Create("1.2 \u03BCm", s => Length.Parse(s, CultureInfo.InvariantCulture), Length.FromMicrometres(1.2)),
            Create(Length.FromMicrometres(1.2).ToString(CultureInfo.InvariantCulture), s => Length.Parse(s, CultureInfo.InvariantCulture), Length.FromMicrometres(1.2)),
            Create("1.2 m^2", s => Area.Parse(s, CultureInfo.InvariantCulture), Area.FromSquareMetres(1.2)),
            Create("1,2 m^2", s => Area.Parse(s, Sv), Area.FromSquareMetres(1.2)),
            Create("1.2m²", s => Area.Parse(s, CultureInfo.InvariantCulture), Area.FromSquareMetres(1.2)),
            Create("1.2s", s => Time.Parse(s, CultureInfo.InvariantCulture), Time.FromSeconds(1.2)),
            Create("1.2h", s => Time.Parse(s, CultureInfo.InvariantCulture), Time.FromHours(1.2)),
            Create("1.2ms", s => Time.Parse(s, CultureInfo.InvariantCulture), Time.FromMilliseconds(1.2)),
            Create("1.2kg", s => Mass.Parse(s, CultureInfo.InvariantCulture), Mass.FromKilograms(1.2)),
            Create("1.2g", s => Mass.Parse(s, CultureInfo.InvariantCulture), Mass.FromGrams(1.2)),
            Create("1.2m³", s => Volume.Parse(s, CultureInfo.InvariantCulture), Volume.FromCubicMetres(1.2)),
            Create("1.2m^3", s => Volume.Parse(s, CultureInfo.InvariantCulture), Volume.FromCubicMetres(1.2)),
            Create("1.2m/s", s => Speed.Parse(s, CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            Create("1.2m⋅s⁻¹", s => Speed.Parse(s, CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            Create("1.2m*s⁻¹", s => Speed.Parse(s, CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            Create("1.2m¹⋅s⁻¹", s => Speed.Parse(s,  CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            Create("1.2m^1⋅s⁻¹", s => Speed.Parse(s,  CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            Create("1.2m^1⋅s^-1", s => Speed.Parse(s,  CultureInfo.InvariantCulture), Speed.FromMetresPerSecond(1.2)),
            Create("1.2m^1/s^2", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            Create("1.2m/s^2", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            Create("1.2 m/s^2", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            Create("1.2 m / s^2", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            Create("1.2 m / s²", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMetresPerSecondSquared(1.2)),
            Create("1.2 mm / s²", s => Acceleration.Parse(s,  CultureInfo.InvariantCulture), Acceleration.FromMillimetresPerSecondSquared(1.2)),
        };

        [TestCaseSource(nameof(TestCases))]
        public static void Parse(string text, Func<string, IQuantity> parse, IQuantity expected)
        {
            var actual = parse(text);
            Assert.AreEqual(expected, actual);
        }

        private static TestCaseData Create(string text, Func<string, IQuantity> parse, IQuantity expected)
        {
            return new TestCaseData(text, parse, expected);
        }
    }
}
