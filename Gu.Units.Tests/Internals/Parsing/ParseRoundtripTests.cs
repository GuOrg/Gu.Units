namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using NUnit.Framework;
    using Sources;

    public class ParseRoundtripTests
    {
        [TestCaseSource(nameof(HappyPaths))]
        public void ParseRoundtrip(ISuccessData data)
        {
            using (Thread.CurrentThread.UsingTempCulture(data.CultureInfo))
            {
                var actual = data.Parse(data.Text);
                Assert.AreEqual(data.Expected, actual);
                var toString = actual.ToString();
                var roundtripped = data.Parse(toString);
                Assert.AreEqual(data.Expected, roundtripped);
            }
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void ParseRoundtripWithCulture(ISuccessData data)
        {
            var actual = data.Parse(data.Text, data.CultureInfo);
            Assert.AreEqual(data.Expected, actual);
            var toString = ((IFormattable)actual).ToString(null, data.CultureInfo);
            var roundtripped = data.Parse(toString, data.CultureInfo);
            Assert.AreEqual(data.Expected, roundtripped);
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseRoundtrip(ISuccessData data)
        {
            using (Thread.CurrentThread.UsingTempCulture(data.CultureInfo))
            {
                object actual;
                var success = data.TryParse(data.Text, out actual);
                Assert.AreEqual(true, success);
                Assert.AreEqual(data.Expected, actual);
                var toString = actual.ToString();
                success = data.TryParse(toString, out actual);
                Assert.AreEqual(true, success);
                Assert.AreEqual(data.Expected, actual);
            }
        }

        [TestCaseSource(nameof(HappyPaths))]
        public void TryParseRoundtripWithCulture(ISuccessData data)
        {
            object actual;
            var success = data.TryParse(data.Text, data.CultureInfo, out actual);
            Assert.AreEqual(true, success);
            Assert.AreEqual(data.Expected, actual);
            var toString = ((IFormattable)actual).ToString(null, data.CultureInfo);
            success = data.TryParse(data.Text, data.CultureInfo, out actual);
            Assert.AreEqual(data.Expected, actual);
            Assert.AreEqual(true, success);
        }

        private const string Superscripts = "⋅⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹"; // keeping this here for copy pasting
        private static readonly CultureInfo en = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo sv = CultureInfo.GetCultureInfo("sv-SE");

        private static readonly IReadOnlyList<ISuccessData> HappyPaths = new ISuccessData[]
        {
            SuccessData.Create("1.2m^2", en, Area.FromSquareMetres(1.2)),
            SuccessData.Create("1.2m²", en, Area.FromSquareMetres(1.2)),
            SuccessData.Create("1,2m²", sv, Area.FromSquareMetres(1.2)),
            SuccessData.Create("1.2s", en, Time.FromSeconds(1.2)),
            SuccessData.Create("1.2h", en, Time.FromHours(1.2)),
            SuccessData.Create("1.2ms", en, Time.FromMilliseconds(1.2)),
            SuccessData.Create("1.2kg", en, Mass.FromKilograms(1.2)),
            SuccessData.Create("1.2g", en, Mass.FromGrams(1.2)),
            SuccessData.Create("1.2m³", en, Volume.FromCubicMetres(1.2)),
            SuccessData.Create("1.2m^3", en, Volume.FromCubicMetres(1.2)),
            SuccessData.Create("1.2m/s", en, Speed.FromMetresPerSecond(1.2)),
            SuccessData.Create("1.2m⋅s⁻¹", en, Speed.FromMetresPerSecond(1.2)),
            SuccessData.Create("1.2m*s⁻¹", en, Speed.FromMetresPerSecond(1.2)),
            SuccessData.Create("1.2m¹⋅s⁻¹", en, Speed.FromMetresPerSecond(1.2)),
            SuccessData.Create("1.2m^1⋅s⁻¹", en, Speed.FromMetresPerSecond(1.2)),
            SuccessData.Create("1.2m^1⋅s^-1", en, Speed.FromMetresPerSecond(1.2)),
            SuccessData.Create("1.2m^1/s^2", en, Acceleration.FromMetresPerSecondSquared(1.2)),
            SuccessData.Create("1.2m/s^2", en, Acceleration.FromMetresPerSecondSquared(1.2)),
            SuccessData.Create("1.2 m/s^2", en, Acceleration.FromMetresPerSecondSquared(1.2)),
            SuccessData.Create("1.2 m / s^2", en, Acceleration.FromMetresPerSecondSquared(1.2)),
            SuccessData.Create("1.2 m / s²", en, Acceleration.FromMetresPerSecondSquared(1.2)),
            SuccessData.Create("1.2 mm / s²", en, Acceleration.FromMillimetresPerSecondSquared(1.2)),
        };
    }
}